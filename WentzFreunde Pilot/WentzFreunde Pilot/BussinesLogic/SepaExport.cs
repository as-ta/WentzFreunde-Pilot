using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using WentzFreunde_Pilot.Data;

public static class SepaExport
{
    public static void ErstelleSepaLastschrift(string dateipfad, List<Member> members, SepaConfig config)
    {
        var zahlungen = members
            .Where(m =>
                !string.IsNullOrWhiteSpace(m.IBAN) &&
                m.Mitgliedsbeitrag > 0)
            .ToList();

        if (zahlungen.Count == 0)
            throw new Exception("Es wurden keine Mitglieder mit IBAN und Mitgliedsbeitrag gefunden.");

        foreach (var m in zahlungen)
        {
            if (string.IsNullOrWhiteSpace(m.Mandatsreferenz))
                throw new Exception($"Mandatsreferenz fehlt bei Mitglied {m.Mitgliedernummer} - {m.Name}.");

            if (m.Mandatsdatum == DateTime.MinValue)
                throw new Exception($"Mandatsdatum fehlt bei Mitglied {m.Mitgliedernummer} - {m.Name}.");
        }

        XNamespace ns = "urn:iso:std:iso:20022:tech:xsd:pain.008.001.02";

        string messageId = "MSG" + DateTime.Now.ToString("yyyyMMddHHmmss");
        string paymentId = "PMT" + DateTime.Now.ToString("yyyyMMddHHmmss");

        decimal summe = zahlungen.Sum(m => m.Mitgliedsbeitrag);

        XDocument doc = new XDocument(
            new XDeclaration("1.0", "UTF-8", "yes"),
            new XElement(ns + "Document",
                new XElement(ns + "CstmrDrctDbtInitn",

                    new XElement(ns + "GrpHdr",
                        new XElement(ns + "MsgId", messageId),
                        new XElement(ns + "CreDtTm", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement(ns + "NbOfTxs", zahlungen.Count),
                        new XElement(ns + "CtrlSum", Betrag(summe)),
                        new XElement(ns + "InitgPty",
                            new XElement(ns + "Nm", config.Vereinsname)
                        )
                    ),

                    new XElement(ns + "PmtInf",
                        new XElement(ns + "PmtInfId", paymentId),
                        new XElement(ns + "PmtMtd", "DD"),
                        new XElement(ns + "BtchBookg", "true"),
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

                        new XElement(ns + "ReqdColltnDt", DateTime.Today.AddDays(5).ToString("yyyy-MM-dd")),

                        new XElement(ns + "Cdtr",
                            new XElement(ns + "Nm", config.Vereinsname)
                        ),

                        new XElement(ns + "CdtrAcct",
                            new XElement(ns + "Id",
                                new XElement(ns + "IBAN", EntferneLeerzeichen(config.CreditorIban))
                            )
                        ),

                        new XElement(ns + "CdtrAgt",
                            new XElement(ns + "FinInstnId",
                                new XElement(ns + "BIC", config.CreditorBic)
                            )
                        ),

                        new XElement(ns + "ChrgBr", "SLEV"),

                        new XElement(ns + "CdtrSchmeId",
                            new XElement(ns + "Id",
                                new XElement(ns + "PrvtId",
                                    new XElement(ns + "Othr",
                                        new XElement(ns + "Id", config.CreditorId),
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
    }

    private static XElement ErstelleTransaktion(XNamespace ns, Member m)
    {
        string kontoinhaber = $"{m.KontoinhaberVorname} {m.KontoinhaberNachname}".Trim();

        if (string.IsNullOrWhiteSpace(kontoinhaber))
            kontoinhaber = $"{m.Vorname} {m.Name}".Trim();

        return new XElement(ns + "DrctDbtTxInf",

            new XElement(ns + "PmtId",
                new XElement(ns + "EndToEndId", "MB-" + m.Mitgliedernummer)
            ),

            new XElement(ns + "InstdAmt",
                new XAttribute("Ccy", "EUR"),
                Betrag(m.Mitgliedsbeitrag)
            ),

            new XElement(ns + "DrctDbtTx",
                new XElement(ns + "MndtRltdInf",
                    new XElement(ns + "MndtId", m.Mandatsreferenz),
                    new XElement(ns + "DtOfSgntr", m.Mandatsdatum.ToString("yyyy-MM-dd"))
                )
            ),

            new XElement(ns + "DbtrAgt",
                new XElement(ns + "FinInstnId",
                    string.IsNullOrWhiteSpace(m.BIC)
                        ? new XElement(ns + "Othr", new XElement(ns + "Id", "NOTPROVIDED"))
                        : new XElement(ns + "BIC", EntferneLeerzeichen(m.BIC))
                )
            ),

            new XElement(ns + "Dbtr",
                new XElement(ns + "Nm", kontoinhaber)
            ),

            new XElement(ns + "DbtrAcct",
                new XElement(ns + "Id",
                    new XElement(ns + "IBAN", EntferneLeerzeichen(m.IBAN))
                )
            ),

            new XElement(ns + "RmtInf",
                new XElement(ns + "Ustrd", "Mitgliedsbeitrag " + DateTime.Now.Year)
            )
        );
    }

    private static string Betrag(decimal wert)
    {
        return wert.ToString("0.00", CultureInfo.InvariantCulture);
    }

    private static string EntferneLeerzeichen(string wert)
    {
        return (wert ?? "").Replace(" ", "").Trim();
    }
}