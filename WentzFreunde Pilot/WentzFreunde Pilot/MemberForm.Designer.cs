using System.Xml.Linq;

namespace WentzFreunde_Pilot
{
    partial class formMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public Data.Member Mitglied { get; private set; }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public formMember(Data.Member mitglied)
        {
            InitializeComponent();

            Mitglied = mitglied;

            cmbAnrede.Items.AddRange(new string[] { "geehrte", "geehrter", "Liebe" });
            cmbAnrede2.Items.AddRange(new string[] { "Herr", "Frau", "Familie" });

            DatenInFormularLaden();
        }

        private void DatenInFormularLaden()
        {
            txtMitgliedernummer.Text = Mitglied.Mitgliedernummer;
            cmbAnrede.Text = Mitglied.Anrede;
            cmbAnrede2.Text = Mitglied.Anrede2;

            txtVorname.Text = Mitglied.Vorname;
            txtNachname.Text = Mitglied.Name;
            txtTitel.Text = Mitglied.Titel;

            txtStrasse.Text = Mitglied.Strasse;
            txtPlz.Text = Mitglied.Plz;
            txtWohnort.Text = Mitglied.Wohnort;

            txtTelefonnummer.Text = Mitglied.Telefonnummer;
            txtMitgliedsbeitrag.Text = Mitglied.Mitgliedsbeitrag.ToString("0.00");

            txtKontoinhaberNachname.Text = Mitglied.KontoinhaberNachname;
            txtKontoinhaberVorname.Text = Mitglied.KontoinhaberVorname;
            txtNameDerBank.Text = Mitglied.NameDerBank;
            txtIBAN.Text = Mitglied.IBAN;
            txtBIC.Text = Mitglied.BIC;

            txtEmail.Text = Mitglied.Email;
            txtEintritt.Text = Mitglied.Eintritt;

            chbMitarbeit.Checked = Mitglied.Mitarbeit;

            dateMandatsdatum.Value = Mitglied.Mandatsdatum == default ? DateTime.Now : Mitglied.Mandatsdatum;
            txtMandatsreferenz.Text = Mitglied.Mandatsreferenz;
        }

        private void DatenAusFormularUebernehmen()
        {
            Mitglied.Mitgliedernummer = txtMitgliedernummer.Text.Trim();
            Mitglied.Anrede = cmbAnrede.Text.Trim();
            Mitglied.Anrede2 = cmbAnrede2.Text.Trim();

            Mitglied.Name = txtNachname.Text.Trim();
            Mitglied.Vorname = txtVorname.Text.Trim();
            Mitglied.Titel = txtTitel.Text.Trim();

            Mitglied.Strasse = txtStrasse.Text.Trim();
            Mitglied.Plz = txtPlz.Text.Trim();
            Mitglied.Wohnort = txtWohnort.Text.Trim();

            Mitglied.Telefonnummer = txtTelefonnummer.Text.Trim();

            if (decimal.TryParse(txtMitgliedsbeitrag.Text.Trim(), out decimal beitrag))
                Mitglied.Mitgliedsbeitrag = beitrag;
            else
                Mitglied.Mitgliedsbeitrag = 0;

            Mitglied.KontoinhaberNachname = txtKontoinhaberNachname.Text.Trim();
            Mitglied.KontoinhaberVorname = txtKontoinhaberVorname.Text.Trim();
            Mitglied.NameDerBank = txtNameDerBank.Text.Trim();
            Mitglied.IBAN = txtIBAN.Text.Trim();
            Mitglied.BIC = txtBIC.Text.Trim();

            Mitglied.Email = txtEmail.Text.Trim();
            Mitglied.Eintritt = txtEintritt.Text.Trim();

            Mitglied.Mitarbeit = chbMitarbeit.Checked;

            Mitglied.Mandatsdatum = dateMandatsdatum.Value;
            Mitglied.Mandatsreferenz = txtMandatsreferenz.Text.Trim();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DatenAusFormularUebernehmen();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMember));
            btnAbbrechen = new Button();
            btnOK = new Button();
            grpPersonal = new GroupBox();
            lblAnrede2 = new Label();
            lblAnrede = new Label();
            cmbAnrede2 = new ComboBox();
            cmbAnrede = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefonnummer = new Label();
            txtTelefonnummer = new TextBox();
            lblWohnohrt = new Label();
            txtWohnort = new TextBox();
            lblPlz = new Label();
            txtPlz = new TextBox();
            lblStrasse = new Label();
            txtStrasse = new TextBox();
            lblTitel = new Label();
            txtTitel = new TextBox();
            lblNachname = new Label();
            txtNachname = new TextBox();
            lblVorname = new Label();
            txtVorname = new TextBox();
            grpBank = new GroupBox();
            dateMandatsdatum = new DateTimePicker();
            lblMandatsdatum = new Label();
            lblMandatsreferenz = new Label();
            txtMandatsreferenz = new TextBox();
            lblNameDerBank = new Label();
            txtNameDerBank = new TextBox();
            lblBIC = new Label();
            txtBIC = new TextBox();
            lblIBAN = new Label();
            txtIBAN = new TextBox();
            lblKontoinhaberNachname = new Label();
            txtKontoinhaberNachname = new TextBox();
            lblKontoinhaberVorname = new Label();
            txtKontoinhaberVorname = new TextBox();
            lblMitgliedernummer = new Label();
            txtMitgliedernummer = new TextBox();
            txtEintritt = new TextBox();
            lblBeitrag = new Label();
            txtMitgliedsbeitrag = new TextBox();
            lblEuro = new Label();
            chbMitarbeit = new CheckBox();
            grpPersonal.SuspendLayout();
            grpBank.SuspendLayout();
            SuspendLayout();
            // 
            // btnAbbrechen
            // 
            btnAbbrechen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAbbrechen.Location = new Point(958, 759);
            btnAbbrechen.Name = "btnAbbrechen";
            btnAbbrechen.Size = new Size(150, 46);
            btnAbbrechen.TabIndex = 19;
            btnAbbrechen.Text = "Abbrechen";
            btnAbbrechen.UseVisualStyleBackColor = true;
            btnAbbrechen.Click += btnAbbrechen_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(1131, 759);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(264, 46);
            btnOK.TabIndex = 20;
            btnOK.Text = "Mitglied speichern";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // grpPersonal
            // 
            grpPersonal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpPersonal.Controls.Add(lblAnrede2);
            grpPersonal.Controls.Add(lblAnrede);
            grpPersonal.Controls.Add(cmbAnrede2);
            grpPersonal.Controls.Add(cmbAnrede);
            grpPersonal.Controls.Add(lblEmail);
            grpPersonal.Controls.Add(txtEmail);
            grpPersonal.Controls.Add(lblTelefonnummer);
            grpPersonal.Controls.Add(txtTelefonnummer);
            grpPersonal.Controls.Add(lblWohnohrt);
            grpPersonal.Controls.Add(txtWohnort);
            grpPersonal.Controls.Add(lblPlz);
            grpPersonal.Controls.Add(txtPlz);
            grpPersonal.Controls.Add(lblStrasse);
            grpPersonal.Controls.Add(txtStrasse);
            grpPersonal.Controls.Add(lblTitel);
            grpPersonal.Controls.Add(txtTitel);
            grpPersonal.Controls.Add(lblNachname);
            grpPersonal.Controls.Add(txtNachname);
            grpPersonal.Controls.Add(lblVorname);
            grpPersonal.Controls.Add(txtVorname);
            grpPersonal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpPersonal.Location = new Point(12, 98);
            grpPersonal.Name = "grpPersonal";
            grpPersonal.Size = new Size(1400, 341);
            grpPersonal.TabIndex = 3;
            grpPersonal.TabStop = false;
            grpPersonal.Text = "Mitglied";
            // 
            // lblAnrede2
            // 
            lblAnrede2.AutoSize = true;
            lblAnrede2.Font = new Font("Segoe UI", 9F);
            lblAnrede2.Location = new Point(757, 269);
            lblAnrede2.Name = "lblAnrede2";
            lblAnrede2.Size = new Size(111, 32);
            lblAnrede2.TabIndex = 20;
            lblAnrede2.Text = "Anrede 2";
            // 
            // lblAnrede
            // 
            lblAnrede.AutoSize = true;
            lblAnrede.Font = new Font("Segoe UI", 9F);
            lblAnrede.Location = new Point(10, 266);
            lblAnrede.Name = "lblAnrede";
            lblAnrede.Size = new Size(91, 32);
            lblAnrede.TabIndex = 19;
            lblAnrede.Text = "Anrede";
            // 
            // cmbAnrede2
            // 
            cmbAnrede2.Font = new Font("Segoe UI", 9F);
            cmbAnrede2.FormattingEnabled = true;
            cmbAnrede2.Location = new Point(945, 266);
            cmbAnrede2.Name = "cmbAnrede2";
            cmbAnrede2.Size = new Size(437, 40);
            cmbAnrede2.TabIndex = 13;
            // 
            // cmbAnrede
            // 
            cmbAnrede.Font = new Font("Segoe UI", 9F);
            cmbAnrede.FormattingEnabled = true;
            cmbAnrede.Location = new Point(229, 263);
            cmbAnrede.Name = "cmbAnrede";
            cmbAnrede.Size = new Size(437, 40);
            cmbAnrede.TabIndex = 12;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(757, 224);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(82, 32);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "E-Mail";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(945, 221);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(437, 39);
            txtEmail.TabIndex = 11;
            // 
            // lblTelefonnummer
            // 
            lblTelefonnummer.AutoSize = true;
            lblTelefonnummer.Font = new Font("Segoe UI", 9F);
            lblTelefonnummer.Location = new Point(10, 221);
            lblTelefonnummer.Name = "lblTelefonnummer";
            lblTelefonnummer.Size = new Size(93, 32);
            lblTelefonnummer.TabIndex = 14;
            lblTelefonnummer.Text = "Telefon";
            // 
            // txtTelefonnummer
            // 
            txtTelefonnummer.Font = new Font("Segoe UI", 9F);
            txtTelefonnummer.Location = new Point(229, 218);
            txtTelefonnummer.Name = "txtTelefonnummer";
            txtTelefonnummer.Size = new Size(437, 39);
            txtTelefonnummer.TabIndex = 10;
            // 
            // lblWohnohrt
            // 
            lblWohnohrt.AutoSize = true;
            lblWohnohrt.Font = new Font("Segoe UI", 9F);
            lblWohnohrt.Location = new Point(757, 176);
            lblWohnohrt.Name = "lblWohnohrt";
            lblWohnohrt.Size = new Size(48, 32);
            lblWohnohrt.TabIndex = 12;
            lblWohnohrt.Text = "Ort";
            // 
            // txtWohnort
            // 
            txtWohnort.Font = new Font("Segoe UI", 9F);
            txtWohnort.Location = new Point(945, 176);
            txtWohnort.Name = "txtWohnort";
            txtWohnort.Size = new Size(437, 39);
            txtWohnort.TabIndex = 9;
            // 
            // lblPlz
            // 
            lblPlz.AutoSize = true;
            lblPlz.Font = new Font("Segoe UI", 9F);
            lblPlz.Location = new Point(10, 176);
            lblPlz.Name = "lblPlz";
            lblPlz.Size = new Size(134, 32);
            lblPlz.TabIndex = 10;
            lblPlz.Text = "Postleitzahl";
            // 
            // txtPlz
            // 
            txtPlz.Font = new Font("Segoe UI", 9F);
            txtPlz.Location = new Point(229, 173);
            txtPlz.Name = "txtPlz";
            txtPlz.Size = new Size(195, 39);
            txtPlz.TabIndex = 8;
            // 
            // lblStrasse
            // 
            lblStrasse.AutoSize = true;
            lblStrasse.Font = new Font("Segoe UI", 9F);
            lblStrasse.Location = new Point(10, 131);
            lblStrasse.Name = "lblStrasse";
            lblStrasse.Size = new Size(162, 32);
            lblStrasse.TabIndex = 8;
            lblStrasse.Text = "Straße / HsNo";
            // 
            // txtStrasse
            // 
            txtStrasse.Font = new Font("Segoe UI", 9F);
            txtStrasse.Location = new Point(229, 128);
            txtStrasse.Name = "txtStrasse";
            txtStrasse.Size = new Size(437, 39);
            txtStrasse.TabIndex = 7;
            // 
            // lblTitel
            // 
            lblTitel.AutoSize = true;
            lblTitel.Font = new Font("Segoe UI", 9F);
            lblTitel.Location = new Point(10, 38);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(60, 32);
            lblTitel.TabIndex = 6;
            lblTitel.Text = "Titel";
            // 
            // txtTitel
            // 
            txtTitel.Font = new Font("Segoe UI", 9F);
            txtTitel.Location = new Point(229, 35);
            txtTitel.Name = "txtTitel";
            txtTitel.Size = new Size(195, 39);
            txtTitel.TabIndex = 4;
            // 
            // lblNachname
            // 
            lblNachname.AutoSize = true;
            lblNachname.Font = new Font("Segoe UI", 9F);
            lblNachname.Location = new Point(757, 86);
            lblNachname.Name = "lblNachname";
            lblNachname.Size = new Size(129, 32);
            lblNachname.TabIndex = 4;
            lblNachname.Text = "Nachname";
            // 
            // txtNachname
            // 
            txtNachname.Font = new Font("Segoe UI", 9F);
            txtNachname.Location = new Point(945, 83);
            txtNachname.Name = "txtNachname";
            txtNachname.Size = new Size(437, 39);
            txtNachname.TabIndex = 6;
            // 
            // lblVorname
            // 
            lblVorname.AutoSize = true;
            lblVorname.Font = new Font("Segoe UI", 9F);
            lblVorname.Location = new Point(10, 86);
            lblVorname.Name = "lblVorname";
            lblVorname.Size = new Size(109, 32);
            lblVorname.TabIndex = 2;
            lblVorname.Text = "Vorname";
            // 
            // txtVorname
            // 
            txtVorname.Font = new Font("Segoe UI", 9F);
            txtVorname.Location = new Point(229, 83);
            txtVorname.Name = "txtVorname";
            txtVorname.Size = new Size(437, 39);
            txtVorname.TabIndex = 5;
            // 
            // grpBank
            // 
            grpBank.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBank.Controls.Add(dateMandatsdatum);
            grpBank.Controls.Add(lblMandatsdatum);
            grpBank.Controls.Add(lblMandatsreferenz);
            grpBank.Controls.Add(txtMandatsreferenz);
            grpBank.Controls.Add(lblNameDerBank);
            grpBank.Controls.Add(txtNameDerBank);
            grpBank.Controls.Add(lblBIC);
            grpBank.Controls.Add(txtBIC);
            grpBank.Controls.Add(lblIBAN);
            grpBank.Controls.Add(txtIBAN);
            grpBank.Controls.Add(lblKontoinhaberNachname);
            grpBank.Controls.Add(txtKontoinhaberNachname);
            grpBank.Controls.Add(lblKontoinhaberVorname);
            grpBank.Controls.Add(txtKontoinhaberVorname);
            grpBank.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpBank.Location = new Point(22, 478);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(1400, 250);
            grpBank.TabIndex = 4;
            grpBank.TabStop = false;
            grpBank.Text = "Bankdaten / Kontoinhaber";
            grpBank.Enter += grpBank_Enter;
            // 
            // dateMandatsdatum
            // 
            dateMandatsdatum.Font = new Font("Segoe UI", 9F);
            dateMandatsdatum.Location = new Point(936, 187);
            dateMandatsdatum.Name = "dateMandatsdatum";
            dateMandatsdatum.Size = new Size(437, 39);
            dateMandatsdatum.TabIndex = 22;
            // 
            // lblMandatsdatum
            // 
            lblMandatsdatum.AutoSize = true;
            lblMandatsdatum.Font = new Font("Segoe UI", 9F);
            lblMandatsdatum.Location = new Point(747, 192);
            lblMandatsdatum.Name = "lblMandatsdatum";
            lblMandatsdatum.Size = new Size(175, 32);
            lblMandatsdatum.TabIndex = 21;
            lblMandatsdatum.Text = "Mandatsdatum";
            // 
            // lblMandatsreferenz
            // 
            lblMandatsreferenz.AutoSize = true;
            lblMandatsreferenz.Font = new Font("Segoe UI", 9F);
            lblMandatsreferenz.Location = new Point(0, 189);
            lblMandatsreferenz.Name = "lblMandatsreferenz";
            lblMandatsreferenz.Size = new Size(194, 32);
            lblMandatsreferenz.TabIndex = 19;
            lblMandatsreferenz.Text = "Mandatsreferenz";
            // 
            // txtMandatsreferenz
            // 
            txtMandatsreferenz.Font = new Font("Segoe UI", 9F);
            txtMandatsreferenz.Location = new Point(219, 186);
            txtMandatsreferenz.Name = "txtMandatsreferenz";
            txtMandatsreferenz.Size = new Size(437, 39);
            txtMandatsreferenz.TabIndex = 20;
            // 
            // lblNameDerBank
            // 
            lblNameDerBank.AutoSize = true;
            lblNameDerBank.Font = new Font("Segoe UI", 9F);
            lblNameDerBank.Location = new Point(0, 144);
            lblNameDerBank.Name = "lblNameDerBank";
            lblNameDerBank.Size = new Size(179, 32);
            lblNameDerBank.TabIndex = 14;
            lblNameDerBank.Text = "Name der Bank";
            // 
            // txtNameDerBank
            // 
            txtNameDerBank.Font = new Font("Segoe UI", 9F);
            txtNameDerBank.Location = new Point(219, 141);
            txtNameDerBank.Name = "txtNameDerBank";
            txtNameDerBank.Size = new Size(1154, 39);
            txtNameDerBank.TabIndex = 18;
            // 
            // lblBIC
            // 
            lblBIC.AutoSize = true;
            lblBIC.Font = new Font("Segoe UI", 9F);
            lblBIC.Location = new Point(747, 99);
            lblBIC.Name = "lblBIC";
            lblBIC.Size = new Size(49, 32);
            lblBIC.TabIndex = 12;
            lblBIC.Text = "BIC";
            // 
            // txtBIC
            // 
            txtBIC.Font = new Font("Segoe UI", 9F);
            txtBIC.Location = new Point(936, 96);
            txtBIC.Name = "txtBIC";
            txtBIC.Size = new Size(437, 39);
            txtBIC.TabIndex = 17;
            // 
            // lblIBAN
            // 
            lblIBAN.AutoSize = true;
            lblIBAN.Font = new Font("Segoe UI", 9F);
            lblIBAN.Location = new Point(0, 99);
            lblIBAN.Name = "lblIBAN";
            lblIBAN.Size = new Size(67, 32);
            lblIBAN.TabIndex = 10;
            lblIBAN.Text = "IBAN";
            // 
            // txtIBAN
            // 
            txtIBAN.Font = new Font("Segoe UI", 9F);
            txtIBAN.Location = new Point(219, 96);
            txtIBAN.Name = "txtIBAN";
            txtIBAN.Size = new Size(437, 39);
            txtIBAN.TabIndex = 16;
            // 
            // lblKontoinhaberNachname
            // 
            lblKontoinhaberNachname.AutoSize = true;
            lblKontoinhaberNachname.Font = new Font("Segoe UI", 9F);
            lblKontoinhaberNachname.Location = new Point(747, 54);
            lblKontoinhaberNachname.Name = "lblKontoinhaberNachname";
            lblKontoinhaberNachname.Size = new Size(129, 32);
            lblKontoinhaberNachname.TabIndex = 8;
            lblKontoinhaberNachname.Text = "Nachname";
            // 
            // txtKontoinhaberNachname
            // 
            txtKontoinhaberNachname.Font = new Font("Segoe UI", 9F);
            txtKontoinhaberNachname.Location = new Point(936, 51);
            txtKontoinhaberNachname.Name = "txtKontoinhaberNachname";
            txtKontoinhaberNachname.Size = new Size(437, 39);
            txtKontoinhaberNachname.TabIndex = 15;
            // 
            // lblKontoinhaberVorname
            // 
            lblKontoinhaberVorname.AutoSize = true;
            lblKontoinhaberVorname.Font = new Font("Segoe UI", 9F);
            lblKontoinhaberVorname.Location = new Point(0, 54);
            lblKontoinhaberVorname.Name = "lblKontoinhaberVorname";
            lblKontoinhaberVorname.Size = new Size(109, 32);
            lblKontoinhaberVorname.TabIndex = 6;
            lblKontoinhaberVorname.Text = "Vorname";
            // 
            // txtKontoinhaberVorname
            // 
            txtKontoinhaberVorname.Font = new Font("Segoe UI", 9F);
            txtKontoinhaberVorname.Location = new Point(219, 51);
            txtKontoinhaberVorname.Name = "txtKontoinhaberVorname";
            txtKontoinhaberVorname.Size = new Size(437, 39);
            txtKontoinhaberVorname.TabIndex = 14;
            // 
            // lblMitgliedernummer
            // 
            lblMitgliedernummer.AutoSize = true;
            lblMitgliedernummer.Font = new Font("Segoe UI", 9F);
            lblMitgliedernummer.Location = new Point(22, 42);
            lblMitgliedernummer.Name = "lblMitgliedernummer";
            lblMitgliedernummer.Size = new Size(204, 32);
            lblMitgliedernummer.TabIndex = 2;
            lblMitgliedernummer.Text = "Mitgliedsnummer";
            // 
            // txtMitgliedernummer
            // 
            txtMitgliedernummer.Location = new Point(241, 39);
            txtMitgliedernummer.Name = "txtMitgliedernummer";
            txtMitgliedernummer.Size = new Size(195, 39);
            txtMitgliedernummer.TabIndex = 1;
            // 
            // txtEintritt
            // 
            txtEintritt.Location = new Point(483, 42);
            txtEintritt.Name = "txtEintritt";
            txtEintritt.Size = new Size(195, 39);
            txtEintritt.TabIndex = 2;
            // 
            // lblBeitrag
            // 
            lblBeitrag.AutoSize = true;
            lblBeitrag.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBeitrag.Location = new Point(769, 45);
            lblBeitrag.Name = "lblBeitrag";
            lblBeitrag.Size = new Size(96, 32);
            lblBeitrag.TabIndex = 6;
            lblBeitrag.Text = "Beitrag";
            // 
            // txtMitgliedsbeitrag
            // 
            txtMitgliedsbeitrag.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtMitgliedsbeitrag.Location = new Point(909, 45);
            txtMitgliedsbeitrag.Name = "txtMitgliedsbeitrag";
            txtMitgliedsbeitrag.Size = new Size(195, 39);
            txtMitgliedsbeitrag.TabIndex = 3;
            // 
            // lblEuro
            // 
            lblEuro.AutoSize = true;
            lblEuro.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEuro.Location = new Point(1126, 48);
            lblEuro.Name = "lblEuro";
            lblEuro.Size = new Size(28, 32);
            lblEuro.TabIndex = 8;
            lblEuro.Text = "€";
            // 
            // chbMitarbeit
            // 
            chbMitarbeit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chbMitarbeit.AutoSize = true;
            chbMitarbeit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chbMitarbeit.Location = new Point(22, 765);
            chbMitarbeit.Name = "chbMitarbeit";
            chbMitarbeit.Size = new Size(270, 36);
            chbMitarbeit.TabIndex = 21;
            chbMitarbeit.Text = "zur Mitarbeit bereit";
            chbMitarbeit.UseVisualStyleBackColor = true;
            // 
            // formMember
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 829);
            Controls.Add(chbMitarbeit);
            Controls.Add(lblEuro);
            Controls.Add(txtMitgliedsbeitrag);
            Controls.Add(lblBeitrag);
            Controls.Add(txtEintritt);
            Controls.Add(lblMitgliedernummer);
            Controls.Add(grpBank);
            Controls.Add(txtMitgliedernummer);
            Controls.Add(grpPersonal);
            Controls.Add(btnOK);
            Controls.Add(btnAbbrechen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1450, 900);
            MinimizeBox = false;
            MinimumSize = new Size(1450, 900);
            Name = "formMember";
            Text = "Wentzinger Freund";
            Load += formMember_Load;
            grpPersonal.ResumeLayout(false);
            grpPersonal.PerformLayout();
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAbbrechen;
        private Button btnOK;
        private GroupBox grpPersonal;
        private Label lblVorname;
        private TextBox txtVorname;
        private GroupBox grpBank;
        private Label lblMitgliedernummer;
        private TextBox txtMitgliedernummer;
        private Label lblNachname;
        private TextBox txtNachname;
        private Label lblTitel;
        private TextBox txtTitel;
        private Label lblPlz;
        private TextBox txtPlz;
        private Label lblStrasse;
        private TextBox txtStrasse;
        private Label lblWohnohrt;
        private TextBox txtWohnort;
        private Label lblTelefonnummer;
        private TextBox txtTelefonnummer;
        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtEintritt;
        private Label lblAnrede2;
        private Label lblAnrede;
        private ComboBox cmbAnrede2;
        private ComboBox cmbAnrede;
        private Label lblBeitrag;
        private TextBox txtMitgliedsbeitrag;
        private Label lblEuro;
        private Label lblKontoinhaberNachname;
        private TextBox txtKontoinhaberNachname;
        private Label lblKontoinhaberVorname;
        private TextBox txtKontoinhaberVorname;
        private Label lblBIC;
        private TextBox txtBIC;
        private Label lblIBAN;
        private TextBox txtIBAN;
        private Label lblNameDerBank;
        private TextBox txtNameDerBank;
        private CheckBox chbMitarbeit;
        private Label lblMandatsdatum;
        private Label lblMandatsreferenz;
        private TextBox txtMandatsreferenz;
        private DateTimePicker dateMandatsdatum;
    }
}