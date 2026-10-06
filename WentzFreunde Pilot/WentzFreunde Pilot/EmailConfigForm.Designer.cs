namespace WentzFreunde_Pilot
{
    partial class EmailConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailConfigForm));
            grpEMailConfig = new GroupBox();
            btnSpeichern = new Button();
            btnAbbrechen = new Button();
            txtSmtpServer = new TextBox();
            lblSmtpServer = new Label();
            numSmtpPort = new NumericUpDown();
            lblSmtpPort = new Label();
            lblBenutzername = new Label();
            txtBenutzername = new TextBox();
            txtAbsenderAdresse = new TextBox();
            lblAbsenderAdresse = new Label();
            lblAbsenderName = new Label();
            txtAbsenderName = new TextBox();
            grpEMailConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSmtpPort).BeginInit();
            SuspendLayout();
            // 
            // grpEMailConfig
            // 
            grpEMailConfig.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpEMailConfig.Controls.Add(txtAbsenderName);
            grpEMailConfig.Controls.Add(lblAbsenderName);
            grpEMailConfig.Controls.Add(lblAbsenderAdresse);
            grpEMailConfig.Controls.Add(txtAbsenderAdresse);
            grpEMailConfig.Controls.Add(txtBenutzername);
            grpEMailConfig.Controls.Add(lblBenutzername);
            grpEMailConfig.Controls.Add(lblSmtpPort);
            grpEMailConfig.Controls.Add(numSmtpPort);
            grpEMailConfig.Controls.Add(lblSmtpServer);
            grpEMailConfig.Controls.Add(txtSmtpServer);
            grpEMailConfig.Location = new Point(12, 12);
            grpEMailConfig.Name = "grpEMailConfig";
            grpEMailConfig.Size = new Size(736, 152);
            grpEMailConfig.TabIndex = 0;
            grpEMailConfig.TabStop = false;
            grpEMailConfig.Text = "SMTP Zugangsdaten";
            // 
            // btnSpeichern
            // 
            btnSpeichern.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSpeichern.Location = new Point(673, 179);
            btnSpeichern.Name = "btnSpeichern";
            btnSpeichern.Size = new Size(75, 23);
            btnSpeichern.TabIndex = 1;
            btnSpeichern.Text = "Speichern";
            btnSpeichern.UseVisualStyleBackColor = true;
            btnSpeichern.Click += this.btnSpeichern_Click;
            // 
            // btnAbbrechen
            // 
            btnAbbrechen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAbbrechen.Location = new Point(592, 179);
            btnAbbrechen.Name = "btnAbbrechen";
            btnAbbrechen.Size = new Size(75, 23);
            btnAbbrechen.TabIndex = 2;
            btnAbbrechen.Text = "Abbrechen";
            btnAbbrechen.UseVisualStyleBackColor = true;
            // 
            // txtSmtpServer
            // 
            txtSmtpServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSmtpServer.Location = new Point(104, 27);
            txtSmtpServer.Name = "txtSmtpServer";
            txtSmtpServer.Size = new Size(626, 23);
            txtSmtpServer.TabIndex = 0;
            // 
            // lblSmtpServer
            // 
            lblSmtpServer.AutoSize = true;
            lblSmtpServer.Location = new Point(6, 30);
            lblSmtpServer.Name = "lblSmtpServer";
            lblSmtpServer.Size = new Size(75, 15);
            lblSmtpServer.TabIndex = 1;
            lblSmtpServer.Text = "SMTP-Server";
            // 
            // numSmtpPort
            // 
            numSmtpPort.Location = new Point(104, 56);
            numSmtpPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numSmtpPort.Name = "numSmtpPort";
            numSmtpPort.Size = new Size(120, 23);
            numSmtpPort.TabIndex = 2;
            // 
            // lblSmtpPort
            // 
            lblSmtpPort.AutoSize = true;
            lblSmtpPort.Location = new Point(6, 58);
            lblSmtpPort.Name = "lblSmtpPort";
            lblSmtpPort.Size = new Size(65, 15);
            lblSmtpPort.TabIndex = 3;
            lblSmtpPort.Text = "SMTP-Port";
            // 
            // lblBenutzername
            // 
            lblBenutzername.AutoSize = true;
            lblBenutzername.Location = new Point(273, 58);
            lblBenutzername.Name = "lblBenutzername";
            lblBenutzername.Size = new Size(83, 15);
            lblBenutzername.TabIndex = 4;
            lblBenutzername.Text = "Benutzername";
            // 
            // txtBenutzername
            // 
            txtBenutzername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBenutzername.Location = new Point(374, 55);
            txtBenutzername.Name = "txtBenutzername";
            txtBenutzername.Size = new Size(356, 23);
            txtBenutzername.TabIndex = 5;
            // 
            // txtAbsenderAdresse
            // 
            txtAbsenderAdresse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAbsenderAdresse.Location = new Point(104, 85);
            txtAbsenderAdresse.Name = "txtAbsenderAdresse";
            txtAbsenderAdresse.Size = new Size(626, 23);
            txtAbsenderAdresse.TabIndex = 6;
            // 
            // lblAbsenderAdresse
            // 
            lblAbsenderAdresse.AutoSize = true;
            lblAbsenderAdresse.Location = new Point(6, 88);
            lblAbsenderAdresse.Name = "lblAbsenderAdresse";
            lblAbsenderAdresse.Size = new Size(96, 15);
            lblAbsenderAdresse.TabIndex = 7;
            lblAbsenderAdresse.Text = "Absenderadresse";
            // 
            // lblAbsenderName
            // 
            lblAbsenderName.AutoSize = true;
            lblAbsenderName.Location = new Point(6, 115);
            lblAbsenderName.Name = "lblAbsenderName";
            lblAbsenderName.Size = new Size(87, 15);
            lblAbsenderName.TabIndex = 8;
            lblAbsenderName.Text = "Absendername";
            // 
            // txtAbsenderName
            // 
            txtAbsenderName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAbsenderName.Location = new Point(104, 115);
            txtAbsenderName.Name = "txtAbsenderName";
            txtAbsenderName.Size = new Size(626, 23);
            txtAbsenderName.TabIndex = 9;
            // 
            // EmailConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 224);
            Controls.Add(btnAbbrechen);
            Controls.Add(btnSpeichern);
            Controls.Add(grpEMailConfig);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmailConfigForm";
            Text = "E-Mail Konfiguration";
            grpEMailConfig.ResumeLayout(false);
            grpEMailConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSmtpPort).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpEMailConfig;
        private Button btnSpeichern;
        private Button btnAbbrechen;
        private TextBox txtSmtpServer;
        private Label lblSmtpServer;
        private TextBox txtAbsenderName;
        private Label lblAbsenderName;
        private Label lblAbsenderAdresse;
        private TextBox txtAbsenderAdresse;
        private TextBox txtBenutzername;
        private Label lblBenutzername;
        private Label lblSmtpPort;
        private NumericUpDown numSmtpPort;
    }
}