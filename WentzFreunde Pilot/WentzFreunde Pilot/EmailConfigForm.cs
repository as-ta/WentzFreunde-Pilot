using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WentzFreunde_Pilot.Data;

namespace WentzFreunde_Pilot
{
    public partial class EmailConfigForm : Form
    {
        private readonly EmailConfig _config;
        public EmailConfigForm(EmailConfig config)
        {
            InitializeComponent();

            _config = config;

            txtSmtpServer.Text = _config.SmtpServer;
            numSmtpPort.Value = _config.SmtpPort;
            txtBenutzername.Text = _config.Benutzername;
            txtAbsenderAdresse.Text = _config.AbsenderAdresse;
            txtAbsenderName.Text = _config.AbsenderName;
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSmtpServer.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie den SMTP-Server ein.",
                    "E-Mail-Einstellungen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSmtpServer.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBenutzername.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie den Benutzernamen ein.",
                    "E-Mail-Einstellungen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBenutzername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAbsenderAdresse.Text))
            {
                MessageBox.Show(
                    "Bitte geben Sie die Absenderadresse ein.",
                    "E-Mail-Einstellungen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAbsenderAdresse.Focus();
                return;
            }

            _config.SmtpServer = txtSmtpServer.Text.Trim();
            _config.SmtpPort = (int)numSmtpPort.Value;
            _config.Benutzername = txtBenutzername.Text.Trim();
            _config.AbsenderAdresse = txtAbsenderAdresse.Text.Trim();
            _config.AbsenderName = txtAbsenderName.Text.Trim();

            BussinesLogic.EmailConfigSave.Speichern(_config);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
