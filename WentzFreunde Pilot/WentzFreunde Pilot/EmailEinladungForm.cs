using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using WentzFreunde_Pilot.Data;
using System.Diagnostics;

namespace WentzFreunde_Pilot
{
    public partial class EmailEinladungForm : Form
    {

        private readonly List<Data.Member> _mitglieder;
        private Data.EmailConfig _emailConfig;
        private string _anhangDatei = "";

        public EmailEinladungForm(List<Data.Member> mitglieder, Data.EmailConfig emailConfig)
        {
            InitializeComponent();

            txtBetreff.Text =
                "Einladung zur Mitgliederversammlung 2026";

            txtNachricht.Text =
                "Liebe Mitglieder:innen," + Environment.NewLine +
                Environment.NewLine +
                "wir laden Sie und Euch herzlich zur diesjährigen Mitgliederversammlung der" +
                Environment.NewLine +
                Environment.NewLine +
                "Freunde des Wentzinger Gymnasiums Freiburg e.V." +
                Environment.NewLine +
                Environment.NewLine +
                "ein." +
                Environment.NewLine +
                Environment.NewLine +
                "Termin: Montag, 2. November 2026, 19:00 Uhr" +
                Environment.NewLine +
                "Ort: Wentzinger Gymnasium, Raum A209" +
                Environment.NewLine +
                Environment.NewLine +
                "Die Eingangstür auf der Gymnasiumsseite " +
                "(Richtung Norden, nicht auf der Mensaseite) wird geöffnet sein." +
                Environment.NewLine +
                Environment.NewLine +
                "Tagesordnung:" +
                Environment.NewLine +
                Environment.NewLine +
                "1. Jahresbericht des Vorstands" + Environment.NewLine +
                "2. Kassenbericht" + Environment.NewLine +
                "3. Bericht der Kassenprüfer" + Environment.NewLine +
                "4. Aussprache über die Berichte" + Environment.NewLine +
                "5. Entlastung des Vorstands" + Environment.NewLine +
                "6. Beschlussfassung über die Änderung der Satzung" + Environment.NewLine +
                "7. Wahl neuer Beisitzer:innen" + Environment.NewLine +
                "8. Sonstiges" +
                Environment.NewLine +
                Environment.NewLine +
                "Wir freuen uns auf Ihr und Euer Kommen!" +
                Environment.NewLine +
                Environment.NewLine +
                "Mit freundlichen Grüßen" +
                Environment.NewLine +
                Environment.NewLine +
                "Silvia Kopp" +
                Environment.NewLine +
                "Freunde des Wentzinger Gymnasiums Freiburg e.V.";

            _mitglieder = mitglieder;
            _emailConfig = emailConfig;

            var mitEmail = _mitglieder
                .Where(m => !string.IsNullOrWhiteSpace(m.Email))
                .ToList();

            var ohneEmail = _mitglieder
                .Where(m => string.IsNullOrWhiteSpace(m.Email))
                .ToList();

            AktualisiereVersandInfo();

            lblOhneEmail.Text =
                $"Ohne E-Mail-Adresse: {ohneEmail.Count} Mitglieder";

            numBatchSize.Value = 50;
        }

        private async void btnVersenden_Click(object sender, EventArgs e)
        {
            // ---------------------------------------------------------
            // 1. Eingaben prüfen
            // ---------------------------------------------------------

            if (string.IsNullOrWhiteSpace(txtBetreff.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie einen Betreff ein.",
                    "Angabe fehlt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBetreff.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNachricht.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie einen Nachrichtentext ein.",
                    "Angabe fehlt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNachricht.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPasswort.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie das SMTP-Passwort ein.",
                    "SMTP-Passwort fehlt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPasswort.Focus();
                return;
            }

            // ---------------------------------------------------------
            // 2. Ungültige E-Mail-Adressen prüfen
            // ---------------------------------------------------------
            /*
            var ungueltige = _mitglieder
                .Where(m =>
                    !string.IsNullOrWhiteSpace(m.Email) &&
                    !IstGueltigeEmail(m.Email))
                .ToList();

            if (ungueltige.Count > 0)
            {
                MessageBox.Show(
                    $"Es wurden {ungueltige.Count} ungültige E-Mail-Adresse(n) gefunden.\n\n" +
                    "Bitte korrigieren Sie diese vor dem Versand.\n" +
                    "Die betroffenen Mitglieder sehen Sie über die Vorschau.",
                    "Versand nicht möglich",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            */

            // ---------------------------------------------------------
            // 3. Empfängerliste erstellen
            // ---------------------------------------------------------

            var empfaenger = _mitglieder
                .Where(m =>
                    !string.IsNullOrWhiteSpace(m.Email) &&
                    IstGueltigeEmail(m.Email))
                .Select(m => m.Email.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (empfaenger.Count == 0)
            {
                MessageBox.Show(
                    "Es wurden keine gültigen Empfänger gefunden.",
                    "Versand nicht möglich",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ---------------------------------------------------------
            // 4. Batchdaten berechnen
            // ---------------------------------------------------------

            int batchSize = (int)numBatchSize.Value;

            int anzahlBatches = (int)Math.Ceiling(
                (double)empfaenger.Count / batchSize);

            string anhangInfo = string.IsNullOrWhiteSpace(_anhangDatei)
                ? "Kein Anhang"
                : Path.GetFileName(_anhangDatei);

            // ---------------------------------------------------------
            // 5. LETZTE Sicherheitsabfrage
            // ---------------------------------------------------------

            DialogResult antwort = MessageBox.Show(
                "E-MAIL-VERSAND STARTEN?\n\n" +
                $"Empfänger: {empfaenger.Count}\n" +
                $"Batchgröße: {batchSize}\n" +
                $"E-Mails: {anzahlBatches}\n" +
                $"Anhang: {anhangInfo}\n\n" +
                "Die Empfänger werden ausschließlich als BCC versendet.\n\n" +
                "Soll der Versand jetzt wirklich gestartet werden?",
                "Mitgliederversammlung – E-Mail-Versand",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (antwort != DialogResult.Yes)
                return;


            string protokollPfad = "";

            try
            {
                protokollPfad =
                    BussinesLogic.EmailVersandProtokoll.NeuesProtokoll();

                BussinesLogic.EmailVersandProtokoll.Schreiben(
                    protokollPfad,
                    "VERSAND GESTARTET");

                BussinesLogic.EmailVersandProtokoll.Schreiben(
                    protokollPfad,
                    $"Betreff: {txtBetreff.Text.Trim()}");

                BussinesLogic.EmailVersandProtokoll.Schreiben(
                    protokollPfad,
                    $"Empfänger: {empfaenger.Count}");

                BussinesLogic.EmailVersandProtokoll.Schreiben(
                    protokollPfad,
                    $"Batchgröße: {batchSize}");

                BussinesLogic.EmailVersandProtokoll.Schreiben(
                    protokollPfad,
                    $"Batches: {anzahlBatches}");

                BussinesLogic.EmailVersandProtokoll.Schreiben(
                    protokollPfad,
                    $"Anhang: {anhangInfo}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Die Protokolldatei konnte nicht angelegt werden.\n\n" +
                    ex.Message + "\n\n" +
                    "Der E-Mail-Versand wurde NICHT gestartet.",
                    "Protokollfehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // ---------------------------------------------------------
            // 6. Batches vorbereiten
            // ---------------------------------------------------------

            var batches = new List<List<string>>();

            for (int i = 0; i < empfaenger.Count; i += batchSize)
            {
                batches.Add(
                    empfaenger
                        .Skip(i)
                        .Take(batchSize)
                        .ToList());
            }

            // ---------------------------------------------------------
            // 7. Oberfläche für Versand vorbereiten
            // ---------------------------------------------------------

            btnVersenden.Enabled = false;
            btnTestmail.Enabled = false;
            btnBatchTest.Enabled = false;
            btnAbbrechen.Enabled = false;

            progressVersand.Visible = true;
            lblVersandStatus.Visible = true;

            progressVersand.Minimum = 0;
            progressVersand.Maximum = batches.Count;
            progressVersand.Value = 0;

            lblVersandStatus.Text =
                $"Versand wird gestartet – 0 von {empfaenger.Count} Empfängern";

            int erfolgreicheBatches = 0;
            int versendeteEmpfaenger = 0;

            try
            {
                // -----------------------------------------------------
                // 8. Alle Batches über EINE SMTP-Verbindung senden
                // -----------------------------------------------------

                await BussinesLogic.EmailService.SendeBatchesAsync(
                    _emailConfig,
                    txtPasswort.Text,
                    batches,
                    txtBetreff.Text.Trim(),
                    txtNachricht.Text,
                    _anhangDatei,

                    (batchNummer, gesamtBatches, anzahlEmpfaenger) =>
                    {
                        erfolgreicheBatches = batchNummer;
                        versendeteEmpfaenger = anzahlEmpfaenger;

                        progressVersand.Value = batchNummer;

                        lblVersandStatus.Text =
                            $"Mail {batchNummer} von {gesamtBatches} – " +
                            $"{anzahlEmpfaenger} von {empfaenger.Count} Empfängern";

                        Text =
                            $"E-Mail-Versand – Mail {batchNummer} von {gesamtBatches}";

                        try
                        {
                            int empfaengerImBatch =
                                batches[batchNummer - 1].Count;

                            BussinesLogic.EmailVersandProtokoll.Schreiben(
                                protokollPfad,
                                $"Batch {batchNummer}/{gesamtBatches} erfolgreich - " +
                                $"{empfaengerImBatch} Empfänger - " +
                                $"insgesamt {anzahlEmpfaenger}/{empfaenger.Count}");
                        }
                        catch
                        {
                            // Der Versand darf nach bereits versendeten E-Mails
                            // nicht wegen eines Protokollfehlers abgebrochen werden.
                        }
                    });

                // -----------------------------------------------------
                // 9. Erfolgreich abgeschlossen
                // -----------------------------------------------------

                lblVersandStatus.Text =
                    $"Versand abgeschlossen – {versendeteEmpfaenger} Empfänger";

                try
                {
                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        "VERSAND ABGESCHLOSSEN");

                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        $"Erfolgreiche Batches: {erfolgreicheBatches}");

                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        $"Erfolgreiche Empfänger: {versendeteEmpfaenger}");
                }
                catch
                {
                    // Versand war erfolgreich.
                    // Ein Protokollfehler ändert daran nichts.
                }

                MessageBox.Show(
                    "Der E-Mail-Versand wurde erfolgreich abgeschlossen.\n\n" +
                    $"Empfänger: {versendeteEmpfaenger}\n" +
                    $"Versendete E-Mails: {erfolgreicheBatches}",
                    "Versand abgeschlossen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // -----------------------------------------------------
                // 10. Fehler
                // -----------------------------------------------------

                lblVersandStatus.Text = "Versand abgebrochen.";

                try
                {
                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        "VERSAND ABGEBROCHEN");

                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        $"Erfolgreiche Batches: {erfolgreicheBatches} von {batches.Count}");

                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        $"Erfolgreiche Empfänger: {versendeteEmpfaenger} von {empfaenger.Count}");

                    BussinesLogic.EmailVersandProtokoll.Schreiben(
                        protokollPfad,
                        $"Fehler: {ex.Message}");
                }
                catch
                {
                    // Der ursprüngliche Versandfehler ist wichtiger.
                }

                MessageBox.Show(
                    "Der Versand wurde wegen eines Fehlers abgebrochen.\n\n" +
                    $"Erfolgreiche Batches: {erfolgreicheBatches} von {batches.Count}\n" +
                    $"Bereits versendete Empfänger: {versendeteEmpfaenger} " +
                    $"von {empfaenger.Count}\n\n" +
                    "Fehler:\n" +
                    ex.Message + "\n\n" +
                    "WICHTIG: Den Versand nicht einfach erneut starten, " +
                    "da bereits Empfänger die Nachricht erhalten haben können.",
                    "Versand abgebrochen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // -----------------------------------------------------
                // 11. Oberfläche wieder freigeben
                // -----------------------------------------------------

                btnVersenden.Enabled = true;
                btnTestmail.Enabled = true;
                btnBatchTest.Enabled = true;
                btnAbbrechen.Enabled = true;

                Text = "E-Mail-Einladung";

                progressVersand.Visible = false;
                lblVersandStatus.Visible = false;
            }
        }

        private void btnAnhang_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Einladung auswählen";
            dialog.Filter = "PDF-Dateien (*.pdf)|*.pdf";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            _anhangDatei = dialog.FileName;
            txtAnhang.Text = _anhangDatei;
        }

        private void AktualisiereVersandInfo()
        {
            int anzahlEmpfaenger = _mitglieder
                .Count(m => !string.IsNullOrWhiteSpace(m.Email));

            int batchSize = (int)numBatchSize.Value;

            int anzahlMails = (int)Math.Ceiling(
                (double)anzahlEmpfaenger / batchSize);

            lblEmpfaenger.Text =
                $"Empfänger: {anzahlEmpfaenger} Mitglieder mit E-Mail-Adresse " +
                $"→ {anzahlMails} E-Mails";
        }

        private void numBatchSize_ValueChanged(object sender, EventArgs e)
        {
            AktualisiereVersandInfo();
        }

        private void btnVorschau_Click(object sender, EventArgs e)
        {
            // Alle Mitglieder, bei denen überhaupt eine E-Mail-Adresse eingetragen ist
            var mitEmail = _mitglieder
                .Where(m => !string.IsNullOrWhiteSpace(m.Email))
                .ToList();

            // Ungültige E-Mail-Adressen ermitteln
            var ungueltige = mitEmail
                .Where(m => !IstGueltigeEmail(m.Email))
                .ToList();

            // Gültige E-Mail-Adressen ermitteln
            var gueltige = mitEmail
                .Where(m => IstGueltigeEmail(m.Email))
                .ToList();

            // Doppelte E-Mail-Adressen ermitteln
            var doppelte = gueltige
                .GroupBy(
                    m => m.Email.Trim(),
                    StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() > 1)
                .ToList();

            // Für den tatsächlichen Versand jede E-Mail-Adresse
            // nur einmal berücksichtigen
            var empfaenger = gueltige
                .GroupBy(
                    m => m.Email.Trim(),
                    StringComparer.OrdinalIgnoreCase)
                .Select(g => g.First())
                .ToList();

            int batchSize = (int)numBatchSize.Value;

            var ausgabe = new StringBuilder();

            // ---------------------------------------------------------
            // Zusammenfassung
            // ---------------------------------------------------------

            ausgabe.AppendLine($"Mit E-Mail-Adresse: {mitEmail.Count}");
            ausgabe.AppendLine($"Gültige Adressen: {gueltige.Count}");
            ausgabe.AppendLine($"Ungültige Adressen: {ungueltige.Count}");
            ausgabe.AppendLine($"Doppelte Adressen: {doppelte.Count}");

            // ---------------------------------------------------------
            // Ungültige E-Mail-Adressen
            // ---------------------------------------------------------

            if (ungueltige.Count > 0)
            {
                ausgabe.AppendLine();
                ausgabe.AppendLine("UNGÜLTIGE E-MAIL-ADRESSEN:");
                ausgabe.AppendLine("----------------------------------------");

                foreach (var m in ungueltige)
                {
                    ausgabe.AppendLine(
                        $"{m.Mitgliedernummer} | " +
                        $"{m.Vorname} {m.Name} | " +
                        $"{m.Email}");
                }
            }

            // ---------------------------------------------------------
            // Doppelte E-Mail-Adressen
            // ---------------------------------------------------------

            if (doppelte.Count > 0)
            {
                ausgabe.AppendLine();
                ausgabe.AppendLine("DOPPELTE E-MAIL-ADRESSEN:");
                ausgabe.AppendLine("----------------------------------------");

                foreach (var gruppe in doppelte)
                {
                    ausgabe.AppendLine(gruppe.Key);

                    foreach (var m in gruppe)
                    {
                        ausgabe.AppendLine(
                            $"   {m.Mitgliedernummer} | " +
                            $"{m.Vorname} {m.Name}");
                    }
                }
            }

            // ---------------------------------------------------------
            // Batch-Aufteilung
            // ---------------------------------------------------------

            ausgabe.AppendLine();
            ausgabe.AppendLine("VERSAND:");
            ausgabe.AppendLine("----------------------------------------");

            int mailNummer = 1;

            for (int i = 0; i < empfaenger.Count; i += batchSize)
            {
                var batch = empfaenger
                    .Skip(i)
                    .Take(batchSize)
                    .ToList();

                ausgabe.AppendLine(
                    $"Mail {mailNummer}: {batch.Count} Empfänger");

                mailNummer++;
            }

            ausgabe.AppendLine();
            ausgabe.AppendLine(
                $"Tatsächliche Empfänger: {empfaenger.Count}");

            // ---------------------------------------------------------
            // Ergebnis anzeigen
            // ---------------------------------------------------------

            MessageBox.Show(
                ausgabe.ToString(),
                "Versandvorschau",
                MessageBoxButtons.OK,
                ungueltige.Count > 0
                    ? MessageBoxIcon.Warning
                    : MessageBoxIcon.Information);
        }

        private bool IstGueltigeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var adresse = new MailAddress(email.Trim());

                return adresse.Address.Equals(
                    email.Trim(),
                    StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void chkPasswortAnzeigen_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswort.UseSystemPasswordChar = !chkPasswortAnzeigen.Checked;
        }

        private async void btnTestmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestEmpfaenger.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie eine Test-E-Mail-Adresse ein.",
                    "Testmail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTestEmpfaenger.Focus();
                return;
            }

            if (!IstGueltigeEmail(txtTestEmpfaenger.Text))
            {
                MessageBox.Show(
                    "Die Test-E-Mail-Adresse ist ungültig.",
                    "Testmail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTestEmpfaenger.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPasswort.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie das SMTP-Passwort ein.",
                    "Testmail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPasswort.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBetreff.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie einen Betreff ein.",
                    "Testmail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtNachricht.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie einen Nachrichtentext ein.",
                    "Testmail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                btnTestmail.Enabled = false;

                await BussinesLogic.EmailService.SendeTestmailAsync(
                    _emailConfig,
                    txtPasswort.Text,
                    txtTestEmpfaenger.Text.Trim(),
                    txtBetreff.Text,
                    txtNachricht.Text,
                    _anhangDatei);

                MessageBox.Show(
                    "Die Testmail wurde erfolgreich versendet.",
                    "Testmail",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Die Testmail konnte nicht versendet werden.\n\n" +
                    ex.Message,
                    "Fehler beim E-Mail-Versand",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnTestmail.Enabled = true;
            }
        }

        private void lblAnhang_Click(object sender, EventArgs e)
        {

        }

        private async void btnBatchTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswort.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie zuerst das SMTP-Passwort ein.",
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPasswort.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBetreff.Text) ||
                string.IsNullOrWhiteSpace(txtNachricht.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie Betreff und Nachricht ein.",
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var testEmpfaenger = txtBatchTestEmpfaenger.Text
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (testEmpfaenger.Count == 0)
            {
                MessageBox.Show(
                    "Bitte geben Sie mindestens eine Testadresse ein.",
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Alle Testadressen überprüfen
            var ungueltige = testEmpfaenger
                .Where(x => !IstGueltigeEmail(x))
                .ToList();

            if (ungueltige.Count > 0)
            {
                MessageBox.Show(
                    "Folgende Testadresse(n) sind ungültig:\n\n" +
                    string.Join("\n", ungueltige),
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Sicherheit: maximal 5 Testempfänger
            if (testEmpfaenger.Count > 5)
            {
                MessageBox.Show(
                    "Für den BCC-Test sind maximal 5 Empfänger erlaubt.",
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult antwort = MessageBox.Show(
                "BCC-TEST SENDEN?\n\n" +
                $"Testempfänger: {testEmpfaenger.Count}\n" +
                $"Anhang: {(string.IsNullOrWhiteSpace(_anhangDatei)
                    ? "Kein Anhang"
                    : Path.GetFileName(_anhangDatei))}\n\n" +
                "Es wird genau EINE E-Mail versendet.\n" +
                "Die Testadressen stehen ausschließlich im BCC-Feld.",
                "BCC-Test",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (antwort != DialogResult.Yes)
                return;

            try
            {
                btnBatchTest.Enabled = false;

                var testBatches = new List<List<string>>
                {
                    testEmpfaenger
                };

                await BussinesLogic.EmailService.SendeBatchesAsync(
                    _emailConfig,
                    txtPasswort.Text,
                    testBatches,
                    txtBetreff.Text.Trim(),
                    txtNachricht.Text,
                    _anhangDatei,
                    (batchNummer, gesamtBatches, anzahlEmpfaenger) =>
                    {
                        // Beim Test nur ein Batch.
                        // Deshalb ist hier keine Fortschrittsanzeige notwendig.
                    });

                MessageBox.Show(
                    $"BCC-Test erfolgreich.\n\n" +
                    $"Eine E-Mail wurde an {testEmpfaenger.Count} " +
                    "BCC-Empfänger versendet.",
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Der BCC-Test ist fehlgeschlagen.\n\n" +
                    ex.Message,
                    "BCC-Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnBatchTest.Enabled = true;
            }
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProtokolle_Click(object sender, EventArgs e)
        {
            string ordner = BussinesLogic.EmailVersandProtokoll.GetOrdnerPfad();

            Process.Start("explorer.exe", ordner);
        }
    }
}
