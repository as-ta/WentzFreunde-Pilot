namespace WentzFreunde_Pilot
{
    partial class EmailEinladungForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailEinladungForm));
            lblEmpfaenger = new Label();
            lblBetreff = new Label();
            lblOhneEmail = new Label();
            txtBetreff = new TextBox();
            lblNachricht = new Label();
            txtNachricht = new TextBox();
            lblAnhang = new Label();
            txtAnhang = new TextBox();
            btnAnhang = new Button();
            lblBCCCount = new Label();
            numBatchSize = new NumericUpDown();
            btnAbbrechen = new Button();
            btnVersenden = new Button();
            btnVorschau = new Button();
            txtPasswort = new TextBox();
            lblPasswort = new Label();
            chkPasswortAnzeigen = new CheckBox();
            lblTestEmpfaenger = new Label();
            txtTestEmpfaenger = new TextBox();
            btnTestmail = new Button();
            lblBatchTestEmpfaenger = new Label();
            txtBatchTestEmpfaenger = new TextBox();
            btnBatchTest = new Button();
            progressVersand = new ProgressBar();
            lblVersandStatus = new Label();
            btnProtokolle = new Button();
            ((System.ComponentModel.ISupportInitialize)numBatchSize).BeginInit();
            SuspendLayout();
            // 
            // lblEmpfaenger
            // 
            lblEmpfaenger.AutoSize = true;
            lblEmpfaenger.Location = new Point(12, 20);
            lblEmpfaenger.Name = "lblEmpfaenger";
            lblEmpfaenger.Size = new Size(68, 15);
            lblEmpfaenger.TabIndex = 0;
            lblEmpfaenger.Text = "Empfänger:";
            // 
            // lblBetreff
            // 
            lblBetreff.AutoSize = true;
            lblBetreff.Location = new Point(12, 61);
            lblBetreff.Name = "lblBetreff";
            lblBetreff.Size = new Size(42, 15);
            lblBetreff.TabIndex = 3;
            lblBetreff.Text = "Betreff";
            // 
            // lblOhneEmail
            // 
            lblOhneEmail.AutoSize = true;
            lblOhneEmail.Location = new Point(12, 35);
            lblOhneEmail.Name = "lblOhneEmail";
            lblOhneEmail.Size = new Size(76, 15);
            lblOhneEmail.TabIndex = 2;
            lblOhneEmail.Text = "Ohne E-Mail:";
            // 
            // txtBetreff
            // 
            txtBetreff.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBetreff.Location = new Point(12, 79);
            txtBetreff.Name = "txtBetreff";
            txtBetreff.Size = new Size(632, 23);
            txtBetreff.TabIndex = 4;
            // 
            // lblNachricht
            // 
            lblNachricht.AutoSize = true;
            lblNachricht.Location = new Point(12, 115);
            lblNachricht.Name = "lblNachricht";
            lblNachricht.Size = new Size(62, 15);
            lblNachricht.TabIndex = 5;
            lblNachricht.Text = "Nachricht:";
            // 
            // txtNachricht
            // 
            txtNachricht.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNachricht.Location = new Point(12, 133);
            txtNachricht.Multiline = true;
            txtNachricht.Name = "txtNachricht";
            txtNachricht.Size = new Size(632, 189);
            txtNachricht.TabIndex = 6;
            // 
            // lblAnhang
            // 
            lblAnhang.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAnhang.AutoSize = true;
            lblAnhang.Location = new Point(11, 338);
            lblAnhang.Name = "lblAnhang";
            lblAnhang.Size = new Size(52, 15);
            lblAnhang.TabIndex = 7;
            lblAnhang.Text = "Anhang:";
            lblAnhang.Click += lblAnhang_Click;
            // 
            // txtAnhang
            // 
            txtAnhang.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAnhang.Location = new Point(12, 356);
            txtAnhang.Name = "txtAnhang";
            txtAnhang.ReadOnly = true;
            txtAnhang.Size = new Size(569, 23);
            txtAnhang.TabIndex = 8;
            // 
            // btnAnhang
            // 
            btnAnhang.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnhang.Location = new Point(587, 356);
            btnAnhang.Name = "btnAnhang";
            btnAnhang.Size = new Size(57, 23);
            btnAnhang.TabIndex = 9;
            btnAnhang.Text = "...";
            btnAnhang.UseVisualStyleBackColor = true;
            btnAnhang.Click += btnAnhang_Click;
            // 
            // lblBCCCount
            // 
            lblBCCCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblBCCCount.AutoSize = true;
            lblBCCCount.Location = new Point(12, 392);
            lblBCCCount.Name = "lblBCCCount";
            lblBCCCount.Size = new Size(154, 15);
            lblBCCCount.TabIndex = 10;
            lblBCCCount.Text = "BCC-Empfänger pro E-Mail:";
            // 
            // numBatchSize
            // 
            numBatchSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            numBatchSize.Location = new Point(12, 410);
            numBatchSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBatchSize.Name = "numBatchSize";
            numBatchSize.Size = new Size(154, 23);
            numBatchSize.TabIndex = 11;
            numBatchSize.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numBatchSize.ValueChanged += numBatchSize_ValueChanged;
            // 
            // btnAbbrechen
            // 
            btnAbbrechen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAbbrechen.Location = new Point(487, 541);
            btnAbbrechen.Name = "btnAbbrechen";
            btnAbbrechen.Size = new Size(75, 23);
            btnAbbrechen.TabIndex = 12;
            btnAbbrechen.Text = "Abbrechen";
            btnAbbrechen.UseVisualStyleBackColor = true;
            btnAbbrechen.Click += btnAbbrechen_Click;
            // 
            // btnVersenden
            // 
            btnVersenden.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVersenden.Location = new Point(568, 541);
            btnVersenden.Name = "btnVersenden";
            btnVersenden.Size = new Size(75, 23);
            btnVersenden.TabIndex = 13;
            btnVersenden.Text = "Versenden";
            btnVersenden.UseVisualStyleBackColor = true;
            btnVersenden.Click += btnVersenden_Click;
            // 
            // btnVorschau
            // 
            btnVorschau.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVorschau.Location = new Point(12, 541);
            btnVorschau.Name = "btnVorschau";
            btnVorschau.Size = new Size(75, 23);
            btnVorschau.TabIndex = 14;
            btnVorschau.Text = "Vorschau";
            btnVorschau.UseVisualStyleBackColor = true;
            btnVorschau.Click += btnVorschau_Click;
            // 
            // txtPasswort
            // 
            txtPasswort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPasswort.Location = new Point(199, 410);
            txtPasswort.Name = "txtPasswort";
            txtPasswort.Size = new Size(445, 23);
            txtPasswort.TabIndex = 15;
            txtPasswort.UseSystemPasswordChar = true;
            // 
            // lblPasswort
            // 
            lblPasswort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPasswort.AutoSize = true;
            lblPasswort.Location = new Point(198, 392);
            lblPasswort.Name = "lblPasswort";
            lblPasswort.Size = new Size(54, 15);
            lblPasswort.TabIndex = 16;
            lblPasswort.Text = "Passwort";
            // 
            // chkPasswortAnzeigen
            // 
            chkPasswortAnzeigen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chkPasswortAnzeigen.AutoSize = true;
            chkPasswortAnzeigen.Location = new Point(521, 391);
            chkPasswortAnzeigen.Name = "chkPasswortAnzeigen";
            chkPasswortAnzeigen.Size = new Size(123, 19);
            chkPasswortAnzeigen.TabIndex = 17;
            chkPasswortAnzeigen.Text = "Passwort anzeigen";
            chkPasswortAnzeigen.UseVisualStyleBackColor = true;
            chkPasswortAnzeigen.CheckedChanged += chkPasswortAnzeigen_CheckedChanged;
            // 
            // lblTestEmpfaenger
            // 
            lblTestEmpfaenger.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTestEmpfaenger.AutoSize = true;
            lblTestEmpfaenger.Location = new Point(12, 456);
            lblTestEmpfaenger.Name = "lblTestEmpfaenger";
            lblTestEmpfaenger.Size = new Size(89, 15);
            lblTestEmpfaenger.TabIndex = 18;
            lblTestEmpfaenger.Text = "Testempfänger:";
            // 
            // txtTestEmpfaenger
            // 
            txtTestEmpfaenger.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTestEmpfaenger.Location = new Point(162, 453);
            txtTestEmpfaenger.Name = "txtTestEmpfaenger";
            txtTestEmpfaenger.Size = new Size(372, 23);
            txtTestEmpfaenger.TabIndex = 19;
            // 
            // btnTestmail
            // 
            btnTestmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTestmail.Location = new Point(540, 453);
            btnTestmail.Name = "btnTestmail";
            btnTestmail.Size = new Size(104, 23);
            btnTestmail.TabIndex = 20;
            btnTestmail.Text = "Testmail senden";
            btnTestmail.UseVisualStyleBackColor = true;
            btnTestmail.Click += btnTestmail_Click;
            // 
            // lblBatchTestEmpfaenger
            // 
            lblBatchTestEmpfaenger.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblBatchTestEmpfaenger.AutoSize = true;
            lblBatchTestEmpfaenger.Location = new Point(12, 485);
            lblBatchTestEmpfaenger.Name = "lblBatchTestEmpfaenger";
            lblBatchTestEmpfaenger.Size = new Size(153, 15);
            lblBatchTestEmpfaenger.TabIndex = 21;
            lblBatchTestEmpfaenger.Text = "Adr. für BCC (Komma getr.)";
            // 
            // txtBatchTestEmpfaenger
            // 
            txtBatchTestEmpfaenger.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBatchTestEmpfaenger.Location = new Point(162, 482);
            txtBatchTestEmpfaenger.Name = "txtBatchTestEmpfaenger";
            txtBatchTestEmpfaenger.Size = new Size(372, 23);
            txtBatchTestEmpfaenger.TabIndex = 22;
            // 
            // btnBatchTest
            // 
            btnBatchTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBatchTest.Location = new Point(540, 482);
            btnBatchTest.Name = "btnBatchTest";
            btnBatchTest.Size = new Size(104, 23);
            btnBatchTest.TabIndex = 23;
            btnBatchTest.Text = "BCC-Test senden";
            btnBatchTest.UseVisualStyleBackColor = true;
            btnBatchTest.Click += btnBatchTest_Click;
            // 
            // progressVersand
            // 
            progressVersand.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressVersand.Location = new Point(4, 3);
            progressVersand.Name = "progressVersand";
            progressVersand.Size = new Size(652, 14);
            progressVersand.TabIndex = 24;
            progressVersand.Visible = false;
            // 
            // lblVersandStatus
            // 
            lblVersandStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVersandStatus.AutoSize = true;
            lblVersandStatus.Location = new Point(378, 20);
            lblVersandStatus.Name = "lblVersandStatus";
            lblVersandStatus.Size = new Size(79, 15);
            lblVersandStatus.TabIndex = 25;
            lblVersandStatus.Text = "Versandstatus";
            lblVersandStatus.Visible = false;
            // 
            // btnProtokolle
            // 
            btnProtokolle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnProtokolle.Location = new Point(93, 541);
            btnProtokolle.Name = "btnProtokolle";
            btnProtokolle.Size = new Size(131, 23);
            btnProtokolle.TabIndex = 26;
            btnProtokolle.Text = "Protokolle öffnen";
            btnProtokolle.UseVisualStyleBackColor = true;
            btnProtokolle.Click += btnProtokolle_Click;
            // 
            // EmailEinladungForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 582);
            Controls.Add(btnProtokolle);
            Controls.Add(lblVersandStatus);
            Controls.Add(progressVersand);
            Controls.Add(btnBatchTest);
            Controls.Add(txtBatchTestEmpfaenger);
            Controls.Add(lblBatchTestEmpfaenger);
            Controls.Add(btnTestmail);
            Controls.Add(txtTestEmpfaenger);
            Controls.Add(lblTestEmpfaenger);
            Controls.Add(chkPasswortAnzeigen);
            Controls.Add(lblPasswort);
            Controls.Add(txtPasswort);
            Controls.Add(btnVorschau);
            Controls.Add(btnVersenden);
            Controls.Add(btnAbbrechen);
            Controls.Add(numBatchSize);
            Controls.Add(lblBCCCount);
            Controls.Add(btnAnhang);
            Controls.Add(txtAnhang);
            Controls.Add(lblAnhang);
            Controls.Add(txtNachricht);
            Controls.Add(lblNachricht);
            Controls.Add(txtBetreff);
            Controls.Add(lblBetreff);
            Controls.Add(lblOhneEmail);
            Controls.Add(lblEmpfaenger);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmailEinladungForm";
            Text = "Einladung zur Mitgliederversammlung";
            ((System.ComponentModel.ISupportInitialize)numBatchSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmpfaenger;
        private Label lblBetreff;
        private Label lblOhneEmail;
        private TextBox txtBetreff;
        private Label lblNachricht;
        private TextBox txtNachricht;
        private Label lblAnhang;
        private TextBox txtAnhang;
        private Button btnAnhang;
        private Label lblBCCCount;
        private NumericUpDown numBatchSize;
        private Button btnAbbrechen;
        private Button btnVersenden;
        private Button btnVorschau;
        private TextBox txtPasswort;
        private Label lblPasswort;
        private CheckBox chkPasswortAnzeigen;
        private Label lblTestEmpfaenger;
        private TextBox txtTestEmpfaenger;
        private Button btnTestmail;
        private Label lblBatchTestEmpfaenger;
        private TextBox txtBatchTestEmpfaenger;
        private Button btnBatchTest;
        private ProgressBar progressVersand;
        private Label lblVersandStatus;
        private Button btnProtokolle;
    }
}