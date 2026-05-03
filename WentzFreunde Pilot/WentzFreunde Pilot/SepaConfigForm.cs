using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WentzFreunde_Pilot
{
    public partial class SepaConfigForm : Form
    {
        public SepaConfig Config { get; private set; }

        public SepaConfigForm(SepaConfig config)
        {
            InitializeComponent();
            Config = config;

            txtVereinsname.Text = config.Vereinsname;
            txtIBAN.Text = config.CreditorIban;
            txtBIC.Text = config.CreditorBic;
            txtCreditorId.Text = config.CreditorId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Config.Vereinsname = txtVereinsname.Text.Trim();
            Config.CreditorIban = txtIBAN.Text.Trim();
            Config.CreditorBic = txtBIC.Text.Trim();
            Config.CreditorId = txtCreditorId.Text.Trim();

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
