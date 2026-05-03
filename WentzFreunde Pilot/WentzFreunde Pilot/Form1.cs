using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using ClosedXML.Excel;
using System.Globalization;

namespace WentzFreunde_Pilot
{
    public partial class FrmMain : Form
    {
        //private List<Data.Member> members = new List<Data.Member>();
        private BindingList<Data.Member> members;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var geladeneMitglieder = BussinesLogic.MemberSave.Laden();

            members = new BindingList<Data.Member>(geladeneMitglieder);

            this.WindowState = FormWindowState.Maximized;

            gridMembers.AutoGenerateColumns = true;
            gridMembers.DataSource = members;

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
                Mitgliedernummer = naechsteNummer.ToString("D7"),
                Eintritt = "00000"
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
                    gridMembers.Refresh();
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
                gridMembers.Refresh();

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
                            Eintritt = row.Cell(17).GetString().Trim().PadLeft(5, '0')
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
                gridMembers.Refresh();

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
    }
}
