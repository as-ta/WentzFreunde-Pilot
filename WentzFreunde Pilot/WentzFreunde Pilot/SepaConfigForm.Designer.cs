namespace WentzFreunde_Pilot
{
    partial class SepaConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SepaConfigForm));
            btnOK = new Button();
            btnAbbrechen = new Button();
            grpCreditor = new GroupBox();
            lblCreditorId = new Label();
            txtCreditorId = new TextBox();
            lblBIC = new Label();
            txtBIC = new TextBox();
            lblIBAN = new Label();
            txtIBAN = new TextBox();
            lblVereinsname = new Label();
            txtVereinsname = new TextBox();
            grpCreditor.SuspendLayout();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(1131, 309);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(264, 46);
            btnOK.TabIndex = 22;
            btnOK.Text = "Creditor speichern";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnAbbrechen
            // 
            btnAbbrechen.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAbbrechen.Location = new Point(958, 309);
            btnAbbrechen.Name = "btnAbbrechen";
            btnAbbrechen.Size = new Size(150, 46);
            btnAbbrechen.TabIndex = 21;
            btnAbbrechen.Text = "Abbrechen";
            btnAbbrechen.UseVisualStyleBackColor = true;
            btnAbbrechen.Click += btnAbbrechen_Click;
            // 
            // grpCreditor
            // 
            grpCreditor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpCreditor.Controls.Add(lblCreditorId);
            grpCreditor.Controls.Add(txtCreditorId);
            grpCreditor.Controls.Add(lblBIC);
            grpCreditor.Controls.Add(txtBIC);
            grpCreditor.Controls.Add(lblIBAN);
            grpCreditor.Controls.Add(txtIBAN);
            grpCreditor.Controls.Add(lblVereinsname);
            grpCreditor.Controls.Add(txtVereinsname);
            grpCreditor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpCreditor.Location = new Point(12, 34);
            grpCreditor.Name = "grpCreditor";
            grpCreditor.Size = new Size(1400, 226);
            grpCreditor.TabIndex = 23;
            grpCreditor.TabStop = false;
            grpCreditor.Text = "Creditorendaten";
            // 
            // lblCreditorId
            // 
            lblCreditorId.AutoSize = true;
            lblCreditorId.Font = new Font("Segoe UI", 9F);
            lblCreditorId.Location = new Point(0, 144);
            lblCreditorId.Name = "lblCreditorId";
            lblCreditorId.Size = new Size(150, 32);
            lblCreditorId.TabIndex = 14;
            lblCreditorId.Text = "Gläubiger-ID";
            // 
            // txtCreditorId
            // 
            txtCreditorId.Font = new Font("Segoe UI", 9F);
            txtCreditorId.Location = new Point(219, 141);
            txtCreditorId.Name = "txtCreditorId";
            txtCreditorId.Size = new Size(1154, 39);
            txtCreditorId.TabIndex = 18;
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
            // lblVereinsname
            // 
            lblVereinsname.AutoSize = true;
            lblVereinsname.Font = new Font("Segoe UI", 9F);
            lblVereinsname.Location = new Point(0, 54);
            lblVereinsname.Name = "lblVereinsname";
            lblVereinsname.Size = new Size(151, 32);
            lblVereinsname.TabIndex = 6;
            lblVereinsname.Text = "Vereinsname";
            // 
            // txtVereinsname
            // 
            txtVereinsname.Font = new Font("Segoe UI", 9F);
            txtVereinsname.Location = new Point(219, 51);
            txtVereinsname.Name = "txtVereinsname";
            txtVereinsname.Size = new Size(1154, 39);
            txtVereinsname.TabIndex = 14;
            // 
            // SepaConfigForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 379);
            Controls.Add(grpCreditor);
            Controls.Add(btnOK);
            Controls.Add(btnAbbrechen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1450, 450);
            MinimizeBox = false;
            MinimumSize = new Size(1450, 450);
            Name = "SepaConfigForm";
            Text = "SepaConfigForm";
            grpCreditor.ResumeLayout(false);
            grpCreditor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnOK;
        private Button btnAbbrechen;
        private GroupBox grpCreditor;
        private Label lblCreditorId;
        private TextBox txtCreditorId;
        private Label lblBIC;
        private TextBox txtBIC;
        private Label lblIBAN;
        private TextBox txtIBAN;
        private Label lblVereinsname;
        private TextBox txtVereinsname;
    }
}