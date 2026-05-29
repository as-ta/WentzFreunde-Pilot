using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using WentzFreunde_Pilot.Data;

public static class SepaExport
{
    public static SepaExportResult ErstelleSepaLastschrift(
        string dateipfad,
        List<Member> members,
        SepaConfig config)
    {
        var result = new SepaExportResult();

        if (string.IsNullOrWhiteSpace(config.Vereinsname))
            throw new Exception("Vereinsname fehlt.");

        if (string.IsNullOrWhiteSpace(config.CreditorIban))
            throw new Exception("Gläubiger-IBAN fehlt.");

        if (string.IsNullOrWhiteSpace(config.CreditorId))
            throw new Exception("Gläubiger-ID fehlt.");

        var zahlungen = new List<Member>();

        foreach (var m in members)
        {
            string fehler = PruefeMitgliedFuerSepa(m);

            if (!string.IsNullOrWhiteSpace(fehler))
            {
                result.Warnungen.Add(
                    $"{m.Mitgliedernummer} - {m.Name}, {m.Vorname}: {fehler}");
                result.Ausgelassen++;
                continue;
            }

            zahlungen.Add(m);
        }

        if (zahlungen.Count == 0)
            throw new Exception("Es wurden keine gültigen Mitglieder für den SEPA-Export gefunden.");

        XNamespace ns = "urn:iso:std:iso:20022:tech:xsd:pain.008.001.08";

        string messageId = "MSG" + DateTime.Now.ToString("yyyyMMddHHmmss");
        string paymentId = "PMT" + DateTime.Now.ToString("yyyyMMddHHmmss");

        decimal summe = zahlungen.Sum(m => m.Mitgliedsbeitrag);

        string creditorBic = EntferneLeerzeichen(config.CreditorBic);

        XDocument doc = new XDocument(
            new XDeclaration("1.0", "UTF-8", null),
            new XElement(ns + "Document",
                new XElement(ns + "CstmrDrctDbtInitn",

                    new XElement(ns + "GrpHdr",
                        new XElement(ns + "MsgId", messageId),
                        new XElement(ns + "CreDtTm", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement(ns + "NbOfTxs", zahlungen.Count),
                        new XElement(ns + "CtrlSum", Betrag(summe)),
                        new XElement(ns + "InitgPty",
                            new XElement(ns + "Nm", SepaText(config.Vereinsname, 70))
                        )
                    ),

                    new XElement(ns + "PmtInf",
                        new XElement(ns + "PmtInfId", paymentId),
                        new XElement(ns + "PmtMtd", "DD"),
                        new XElement(ns + "BtchBookg", true),
                        new XElement(ns + "NbOfTxs", zahlungen.Count),
                        new XElement(ns + "CtrlSum", Betrag(summe)),

                        new XElement(ns + "PmtTpInf",
                            new XElement(ns + "SvcLvl",
                                new XElement(ns + "Cd", "SEPA")
                            ),
                            new XElement(ns + "LclInstrm",
                                new XElement(ns + "Cd", "CORE")
                            ),
                            new XElement(ns + "SeqTp", "RCUR")
                        ),

                        new XElement(ns + "ReqdColltnDt", NaechsterBankarbeitstag(DateTime.Today.AddDays(5)).ToString("yyyy-MM-dd")),

                        new XElement(ns + "Cdtr",
                            new XElement(ns + "Nm", SepaText(config.Vereinsname, 70))
                        ),

                        new XElement(ns + "CdtrAcct",
                            new XElement(ns + "Id",
                                new XElement(ns + "IBAN", NormalisiereIban(config.CreditorIban))
                            )
                        ),

                        new XElement(ns + "CdtrAgt",
                            new XElement(ns + "FinInstnId",
                                !string.IsNullOrWhiteSpace(creditorBic)
                                    ? new XElement(ns + "BICFI", creditorBic)
                                    : new XElement(ns + "Othr",
                                        new XElement(ns + "Id", "NOTPROVIDED")
                                    )
                            )
                        ),

                        new XElement(ns + "ChrgBr", "SLEV"),

                        new XElement(ns + "CdtrSchmeId",
                            new XElement(ns + "Id",
                                new XElement(ns + "PrvtId",
                                    new XElement(ns + "Othr",
                                        new XElement(ns + "Id", EntferneLeerzeichen(config.CreditorId)),
                                        new XElement(ns + "SchmeNm",
                                            new XElement(ns + "Prtry", "SEPA")
                                        )
                                    )
                                )
                            )
                        ),

                        zahlungen.Select(m => ErstelleTransaktion(ns, m))
                    )
                )
            )
        );

        doc.Save(dateipfad);

        result.Exportiert = zahlungen.Count;
        return result;
    }

    private static DateTime NaechsterBankarbeitstag(DateTime datum)
    {
        while (datum.DayOfWeek == DayOfWeek.Saturday ||
               datum.DayOfWeek == DayOfWeek.Sunday)
        {
            datum = datum.AddDays(1);
        }

        return datum;
    }

    private static XElement ErstelleTransaktion(XNamespace ns, Member m)
    {
        string debtorName = $"{m.Vorname} {m.Name}".Trim();

        return new XElement(ns + "DrctDbtTxInf",

            new XElement(ns + "PmtId",
                new XElement(ns + "EndToEndId", "MITGLIED-" + m.Mitgliedernummer)
            ),

            new XElement(ns + "InstdAmt",
                new XAttribute("Ccy", "EUR"),
                Betrag(m.Mitgliedsbeitrag)
            ),

            new XElement(ns + "DrctDbtTx",
                new XElement(ns + "MndtRltdInf",
                    new XElement(ns + "MndtId", SepaText(m.Mandatsreferenz.Trim(), 35)),
                    new XElement(ns + "DtOfSgntr", m.Mandatsdatum.ToString("yyyy-MM-dd"))
                )
            ),

            new XElement(ns + "DbtrAgt",
                new XElement(ns + "FinInstnId",
                    new XElement(ns + "Othr",
                        new XElement(ns + "Id", "NOTPROVIDED")
                    )
                )
            ),

            new XElement(ns + "Dbtr",
                new XElement(ns + "Nm", SepaText(debtorName, 70))
            ),

            new XElement(ns + "DbtrAcct",
                new XElement(ns + "Id",
                    new XElement(ns + "IBAN", NormalisiereIban(m.IBAN))
                )
            ),

            new XElement(ns + "RmtInf",
                new XElement(ns + "Ustrd", SepaText($"Mitgliedsbeitrag {DateTime.Now.Year} / Mitglied {m.Mitgliedernummer}", 140))
            )
        );
    }

    private static string PruefeMitgliedFuerSepa(Member m)
    {
        if (m.Mitgliedsbeitrag <= 0)
            return "Mitgliedsbeitrag fehlt oder ist 0.";

        if (m.Mitgliedsbeitrag != decimal.Round(m.Mitgliedsbeitrag, 2))
            return "Mitgliedsbeitrag hat mehr als 2 Nachkommastellen.";

        if (string.IsNullOrWhiteSpace(m.IBAN))
            return "IBAN fehlt.";

        string iban = EntferneLeerzeichen(m.IBAN).ToUpper();

        if (!IstGueltigeIban(iban))
            return "IBAN ist ungültig.";

        if (string.IsNullOrWhiteSpace(m.Name))
            return "Name fehlt.";

        string debtorName = $"{m.Vorname} {m.Name}".Trim();

        if (string.IsNullOrWhiteSpace(debtorName))
            return "Zahlungspflichtiger Name fehlt.";

        if (SepaText(debtorName, 70).Length == 0)
            return "Name enthält keine gültigen SEPA-Zeichen.";

        if (string.IsNullOrWhiteSpace(m.Mandatsreferenz))
            return "Mandatsreferenz fehlt.";

        if (m.Mandatsreferenz.Length > 35)
            return "Mandatsreferenz ist länger als 35 Zeichen.";

        if (SepaText(m.Mandatsreferenz, 35) != m.Mandatsreferenz.Trim())
            return "Mandatsreferenz enthält ungültige SEPA-Zeichen.";

        if (m.Mandatsdatum == DateTime.MinValue)
            return "Mandatsdatum fehlt.";

        if (m.Mandatsdatum > DateTime.Today)
            return "Mandatsdatum liegt in der Zukunft.";

        return "";
    }

    private static bool IstGueltigeIban(string iban)
    {
        if (string.IsNullOrWhiteSpace(iban))
            return false;

        iban = iban.Replace(" ", "").ToUpper();

        if (iban.Length < 15 || iban.Length > 34)
            return false;

        if (!iban.All(char.IsLetterOrDigit))
            return false;

        string umgestellt = iban.Substring(4) + iban.Substring(0, 4);

        string numerisch = "";

        foreach (char c in umgestellt)
        {
            if (char.IsDigit(c))
            {
                numerisch += c;
            }
            else if (char.IsLetter(c))
            {
                numerisch += (c - 'A' + 10).ToString();
            }
            else
            {
                return false;
            }
        }

        int rest = 0;

        foreach (char c in numerisch)
        {
            rest = (rest * 10 + (c - '0')) % 97;
        }

        return rest == 1;
    }

    private static string Betrag(decimal betrag)
    {
        return betrag.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }

    private static string EntferneLeerzeichen(string wert)
    {
        return string.IsNullOrWhiteSpace(wert)
            ? ""
            : wert.Replace(" ", "").Trim();
    }

    private static string Kuerze(string wert, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(wert))
            return "";

        wert = wert.Trim();

        return wert.Length <= maxLength
            ? wert
            : wert.Substring(0, maxLength);
    }

    private static string SepaText(string wert, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(wert))
            return "";

        wert = wert.Trim();

        wert = wert
            .Replace("ä", "ae")
            .Replace("ö", "oe")
            .Replace("ü", "ue")
            .Replace("Ä", "Ae")
            .Replace("Ö", "Oe")
            .Replace("Ü", "Ue")
            .Replace("ß", "ss")
            .Replace("é", "e")
            .Replace("è", "e")
            .Replace("á", "a")
            .Replace("à", "a")
            .Replace("ç", "c");

        var erlaubt = wert.Where(c =>
            char.IsLetterOrDigit(c) ||
            c == ' ' ||
            c == '/' ||
            c == '-' ||
            c == '?' ||
            c == ':' ||
            c == '(' ||
            c == ')' ||
            c == '.' ||
            c == ',' ||
            c == '\'' ||
            c == '+');

        wert = new string(erlaubt.ToArray());

        return wert.Length <= maxLength
            ? wert
            : wert.Substring(0, maxLength);
    }

    private static string NormalisiereIban(string iban)
    {
        if (string.IsNullOrWhiteSpace(iban))
            return "";

        iban = iban
            .Replace(" ", "")
            .Trim()
            .ToUpper();

        if (!iban.All(char.IsLetterOrDigit))
            return "";

        return iban;
    }
}