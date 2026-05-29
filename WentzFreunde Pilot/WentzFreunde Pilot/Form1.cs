using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using ClosedXML.Excel;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace WentzFreunde_Pilot
{
    public partial class FrmMain : Form
    {
        //private List<Data.Member> members = new List<Data.Member>();
        //private BindingList<Data.Member> members;
        private SortableBindingList<Data.Member> members;


        private BindingSource memberBindingSource = new BindingSource();
        private SepaConfig sepaConfig;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var geladeneMitglieder = BussinesLogic.MemberSave.Laden();

            sepaConfig = BussinesLogic.SepaConfigSave.Laden();

            //members = new BindingList<Data.Member>(geladeneMitglieder);
            members = new SortableBindingList<Data.Member>(
                BussinesLogic.MemberSave.Laden()
            );

            memberBindingSource.DataSource = members;


            this.WindowState = FormWindowState.Maximized;

            gridMembers.AutoGenerateColumns = true;

            gridMembers.DataSource = memberBindingSource;

            gridMembers.ReadOnly = true;
            gridMembers.AllowUserToOrderColumns = true;
            gridMembers.AllowUserToResizeColumns = true;
            gridMembers.AllowDrop = false;
            gridMembers.AllowUserToAddRows = false;
            gridMembers.AllowUserToDeleteRows = false;
            gridMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMembers.MultiSelect = false;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BussinesLogic.MemberSave.Speichern(members.ToList());

            MessageBox.Show("Mitglieder wurden gespeichert.");
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            int naechsteNummer = 1;

            if (members.Count > 0)
            {
                naechsteNummer = members
                    .Select(m => int.TryParse(m.Mitgliedernummer, out int nr) ? nr : 0)
                    .Max() + 1;
            }

            Data.Member neuesMitglied = new Data.Member
            {
                Mitgliedernummer = naechsteNummer.ToString("D7")
            };

            using (formMember form = new formMember(neuesMitglied))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    members.Add(form.Mitglied);
                    BussinesLogic.MemberSave.Speichern(members.ToList());
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridMembers.CurrentRow == null)
            {
                MessageBox.Show("Bitte zuerst ein Mitglied auswählen.");
                return;
            }

            Data.Member selected = gridMembers.CurrentRow.DataBoundItem as Data.Member;

            if (selected == null)
                return;

            using (formMember form = new formMember(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Wichtig: DataGridView aktualisieren
                    BussinesLogic.MemberSave.Speichern(members.ToList());
                    AktualisiereGrid();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridMembers.CurrentRow == null)
            {
                MessageBox.Show("Bitte zuerst ein Mitglied auswählen.");
                return;
            }

            Data.Member selected = gridMembers.CurrentRow.DataBoundItem as Data.Member;

            if (selected == null)
                return;

            DialogResult result = MessageBox.Show(
                $"Möchtest du das Mitglied wirklich löschen?\n\n{selected.Vorname} {selected.Name}",
                "Mitglied löschen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                members.Remove(selected);
                BussinesLogic.MemberSave.Speichern(members.ToList());
                AktualisiereGrid();

                MessageBox.Show("Mitglied wurde gelöscht.");
            }
        }

        private void datenAusExcelImportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Die Daten werden aus der Excel-Datei importiert.\n\n" +
                "Wichtige Hinweise:\n" +
                "• Die Excel-Datei muss die korrekte Reihenfolge der Spalten einhalten.\n" +
                "• Die Daten werden zum bestehenden Datenbestand hinzugefügt.\n\n" +
                "Möchten Sie fortfahren?",
                "Excel-Import",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );


            if (result != DialogResult.Yes)
                return;


            using OpenFileDialog dialog = new OpenFileDialog();


            dialog.Filter = "Excel-Dateien (*.xlsx)|*.xlsx";
            dialog.Title = "Mitglieder aus Excel importieren";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;


            if (IstDateiGesperrt(dialog.FileName))
            {
                MessageBox.Show(
                    "Die ausgewählte Excel-Datei ist aktuell geöffnet oder wird von einem anderen Programm verwendet.\n\n" +
                    "Bitte schließen Sie die Datei und starten Sie den Import erneut.",
                    "Datei ist gesperrt",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int importiert = 0;

            try
            {
                using XLWorkbook workbook = new XLWorkbook(dialog.FileName);
                IXLWorksheet sheet = workbook.Worksheet(1);

                var rows = sheet.RowsUsed().Skip(1).ToList();

                progressStatus.Visible = true;
                progressStatus.Minimum = 0;
                progressStatus.Maximum = rows.Count;
                progressStatus.Value = 0;

                foreach (IXLRow row in rows)
                {
                    try
                    {
                        Data.Member mitglied = new Data.Member
                        {
                            Mitgliedernummer = row.Cell(1).GetString().Trim().PadLeft(7, '0'),
                            Anrede = row.Cell(2).GetString().Trim(),
                            Anrede2 = row.Cell(3).GetString().Trim(),
                            Name = row.Cell(4).GetString().Trim(),
                            Vorname = row.Cell(5).GetString().Trim(),
                            Titel = row.Cell(6).GetString().Trim(),
                            Strasse = row.Cell(7).GetString().Trim(),
                            Plz = row.Cell(8).GetString().Trim(),
                            Wohnort = row.Cell(9).GetString().Trim(),
                            Telefonnummer = row.Cell(10).GetString().Trim(),
                            Mitgliedsbeitrag = LeseDecimal(row.Cell(11).GetString()),
                            KontoinhaberNachname = row.Cell(12).GetString().Trim(),
                            KontoinhaberVorname = row.Cell(13).GetString().Trim(),
                            NameDerBank = row.Cell(14).GetString().Trim(),
                            IBAN = row.Cell(15).GetString().Trim(),
                            BIC = row.Cell(16).GetString().Trim(),
                            Email = row.Cell(18).GetString().Trim(),
                            Mitarbeit = (row.Cell(19).GetString().Trim() == "ja"),

                            /*
                            Mandatsdatum = DateTime.TryParseExact(
                                row.Cell(20).GetString().Trim(),
                                new[] { "dd.MM.yyyy", "d.M.yyyy", "yyyy-MM-dd" },
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime mandatsDatum) ? mandatsDatum : DateTime.MinValue,
                            Mandatsreferenz = row.Cell(21).GetString().Trim()
                            */
                            Mandatsdatum = row.Cell(17).GetDateTime().Date,
                            Mandatsreferenz = row.Cell(1).GetString().Trim().PadLeft(7, '0')
                        };

                        members.Add(mitglied);
                        importiert++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Fehler beim Import in Excel-Zeile {row.RowNumber()}:\n\n{ex.Message}",
                            "Importfehler",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    progressStatus.Value++;
                    Application.DoEvents();
                }

                BussinesLogic.MemberSave.Speichern(members.ToList());
                AktualisiereGrid();

                MessageBox.Show(
                    $"{importiert} Mitglieder wurden importiert.",
                    "Import abgeschlossen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "Die Excel-Datei konnte nicht gelesen werden.\n\n" +
                    "Bitte prüfen Sie, ob die Datei noch geöffnet ist oder ob Sie Zugriff darauf haben.",
                    "Dateifehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Beim Import ist ein unerwarteter Fehler aufgetreten:\n\n" + ex.Message,
                    "Importfehler",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressStatus.Visible = false;
            }
        }

        private bool IstDateiGesperrt(string dateipfad)
        {
            try
            {
                using FileStream stream = File.Open(dateipfad, FileMode.Open, FileAccess.Read, FileShare.None);
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        private decimal LeseDecimal(string wert)
        {
            if (decimal.TryParse(wert, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"), out decimal ergebnis))
                return ergebnis;

            if (decimal.TryParse(wert, NumberStyles.Any, CultureInfo.InvariantCulture, out ergebnis))
                return ergebnis;

            return 0;
        }

        private void alleDatenLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (members.Count == 0)
            {
                MessageBox.Show("Es sind keine Daten vorhanden.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Möchten Sie wirklich ALLE Mitglieder löschen?\n\n" +
                "Diese Aktion kann nicht rückgängig gemacht werden!",
                "Alle Mitglieder löschen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            // Liste leeren
            members.Clear();

            BussinesLogic.MemberSave.Speichern(members.ToList());

            MessageBox.Show("Alle Mitglieder wurden gelöscht.");
        }

        private void gridMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit_Click(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string suche = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(suche))
            {
                memberBindingSource.DataSource = members;
            }
            else
            {
                var gefiltert = members
                    .Where(m =>
                        (m.Mitgliedernummer ?? "").ToLower().Contains(suche) ||
                        (m.Name ?? "").ToLower().Contains(suche) ||
                        (m.Vorname ?? "").ToLower().Contains(suche) ||
                        (m.Wohnort ?? "").ToLower().Contains(suche) ||
                        (m.Email ?? "").ToLower().Contains(suche) ||
                        (m.IBAN ?? "").ToLower().Contains(suche))
                    .ToList();

                memberBindingSource.DataSource = gefiltert;
            }

            gridMembers.Refresh();
        }

        private void AktualisiereGrid()
        {
            memberBindingSource.DataSource = null;
            memberBindingSource.DataSource = members;
            gridMembers.Refresh();
        }

        private void sepaXMLExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "SEPA XML-Datei (*.xml)|*.xml";
                dialog.Title = "SEPA-Lastschriftdatei speichern";
                dialog.FileName = $"SEPA_Lastschrift_{DateTime.Now:yyyyMMdd}.xml";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    var exportResult = SepaExport.ErstelleSepaLastschrift(
                        dialog.FileName,
                        members.ToList(),
                        sepaConfig);

                    string meldung =
                        $"Die SEPA-XML-Datei wurde erfolgreich erstellt.\n\n" +
                        $"Exportiert: {exportResult.Exportiert}\n" +
                        $"Ausgelassen: {exportResult.Ausgelassen}";

                    if (exportResult.Warnungen.Count > 0)
                    {
                        meldung += "\n\nNicht exportierte Mitglieder:\n" +
                                   string.Join("\n", exportResult.Warnungen.Take(20));

                        if (exportResult.Warnungen.Count > 20)
                        {
                            meldung += $"\n... und {exportResult.Warnungen.Count - 20} weitere.";
                        }
                    }

                    MessageBox.Show(
                        meldung,
                        "SEPA-Export",
                        MessageBoxButtons.OK,
                        exportResult.Ausgelassen > 0
                            ? MessageBoxIcon.Warning
                            : MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Fehler beim Erstellen der SEPA-Datei:\n\n" + ex.Message,
                        "SEPA-Fehler",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void datenDesCreditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SepaConfigForm form = new SepaConfigForm(sepaConfig))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BussinesLogic.SepaConfigSave.Speichern(sepaConfig);

                    MessageBox.Show("SEPA-Einstellungen wurden gespeichert.");
                }
            }
        }

        private void datensicherungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "Zielordner für die Datensicherung auswählen";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string zielOrdner = dialog.SelectedPath;

                string backupDatei = Path.Combine(
                    zielOrdner,
                    $"Mitgliederverwaltung_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.zip"
                );

                string mitgliederXml = BussinesLogic.MemberSave.GetDateiPfad();
                string sepaConfigXml = BussinesLogic.SepaConfigSave.GetDateiPfad();

                /*
                MessageBox.Show(
                    "Verwendete Dateien:\n\n" +
                    "Mitglieder:\n" + mitgliederXml + "\n\n" +
                    "SEPA-Konfiguration:\n" + sepaConfigXml,
                    "Debug: Dateipfade",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                */


                using FileStream zipStream = new FileStream(backupDatei, FileMode.Create);
                using ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create);

                FuegeDateiZuZipHinzu(zip, mitgliederXml, "mitglieder.xml");
                FuegeDateiZuZipHinzu(zip, sepaConfigXml, "sepa_config.xml");

                MessageBox.Show(
                    "Die Datensicherung wurde erfolgreich erstellt:\n\n" + backupDatei,
                    "Datensicherung",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Fehler bei der Datensicherung:\n\n" + ex.Message,
                    "Datensicherung",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void FuegeDateiZuZipHinzu(ZipArchive zip, string dateipfad, string nameImZip)
        {
            if (!File.Exists(dateipfad))
                throw new FileNotFoundException("Datei wurde nicht gefunden.", dateipfad);

            zip.CreateEntryFromFile(dateipfad, nameImZip);
        }

        private void datensicherungImportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult warnung = MessageBox.Show(
                "Achtung!\n\n" +
                "Beim Einspielen der Datensicherung wird der aktuelle Datenbestand überschrieben.\n\n" +
                "Diese Aktion kann nicht rückgängig gemacht werden.\n\n" +
                "Möchten Sie wirklich fortfahren?",
                "Datensicherung einspielen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (warnung != DialogResult.Yes)
                return;

            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "ZIP-Dateien (*.zip)|*.zip";
            dialog.Title = "Datensicherung auswählen";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string mitgliederXml = BussinesLogic.MemberSave.GetDateiPfad();
                string sepaConfigXml = BussinesLogic.SepaConfigSave.GetDateiPfad();

                using ZipArchive zip = ZipFile.OpenRead(dialog.FileName);

                ZipArchiveEntry mitgliederEntry = zip.GetEntry("mitglieder.xml");
                ZipArchiveEntry sepaConfigEntry = zip.GetEntry("sepa_config.xml");

                if (mitgliederEntry == null || sepaConfigEntry == null)
                {
                    MessageBox.Show(
                        "Die ausgewählte ZIP-Datei ist keine gültige Datensicherung.\n\n" +
                        "Erwartet werden:\n" +
                        "• mitglieder.xml\n" +
                        "• sepa_config.xml",
                        "Ungültige Datensicherung",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                // aktuelle Dateien überschreiben
                mitgliederEntry.ExtractToFile(mitgliederXml, true);
                sepaConfigEntry.ExtractToFile(sepaConfigXml, true);

                // Daten neu laden
                members = new SortableBindingList<Data.Member>(
                    BussinesLogic.MemberSave.Laden()
                );

                memberBindingSource.DataSource = members;
                gridMembers.DataSource = memberBindingSource;
                gridMembers.Refresh();

                sepaConfig = BussinesLogic.SepaConfigSave.Laden();

                MessageBox.Show(
                    "Die Datensicherung wurde erfolgreich eingespielt.",
                    "Datensicherung",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Fehler beim Einspielen der Datensicherung:\n\n" + ex.Message,
                    "Datensicherung",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SepaTestBatchesErzeugen(int startIndex, int anzahl, int batchSize)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Ordner für SEPA-Testdateien auswählen";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var zahlendeMitglieder = members
                .Where(m => m.Mitgliedsbeitrag > 0 && !string.IsNullOrWhiteSpace(m.IBAN))
                .ToList();

            var testMitglieder = zahlendeMitglieder
                .Skip(startIndex)
                .Take(anzahl)
                .ToList();

            int batchNummer = 1;

            for (int i = 0; i < testMitglieder.Count; i += batchSize)
            {
                var batch = testMitglieder
                    .Skip(i)
                    .Take(batchSize)
                    .ToList();

                string datei = Path.Combine(
                    dialog.SelectedPath,
                    $"SEPA_Test_{startIndex + i + 1:D4}_bis_{startIndex + i + batch.Count:D4}.xml");

                SepaExport.ErstelleSepaLastschrift(datei, batch, sepaConfig);

                batchNummer++;
            }

            MessageBox.Show("Die eingeschränkten SEPA-Testdateien wurden erstellt.");
        }

        private void sepaBatchesErzeugenDevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SepaTestBatchesErzeugen(0, 900, 40);
        }
    }
}
