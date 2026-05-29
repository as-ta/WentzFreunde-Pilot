namespace WentzFreunde_Pilot
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            statusMain = new StatusStrip();
            lblVersion = new ToolStripStatusLabel();
            progressStatus = new ToolStripProgressBar();
            menMain = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            neuesMitgliedAnlegenToolStripMenuItem = new ToolStripMenuItem();
            mitgliedBearbeitenToolStripMenuItem = new ToolStripMenuItem();
            mitgliedLöschenToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            datenAusExcelImportierenToolStripMenuItem = new ToolStripMenuItem();
            alleDatenLöschenToolStripMenuItem = new ToolStripMenuItem();
            bankingToolStripMenuItem = new ToolStripMenuItem();
            sepaXMLExportierenToolStripMenuItem = new ToolStripMenuItem();
            einstellungenToolStripMenuItem = new ToolStripMenuItem();
            datenDesCreditorsToolStripMenuItem = new ToolStripMenuItem();
            datensicherungToolStripMenuItem = new ToolStripMenuItem();
            datensicherungImportierenToolStripMenuItem = new ToolStripMenuItem();
            gridMembers = new DataGridView();
            lblSearch = new Label();
            txtSearch = new TextBox();
            sepaBatchesErzeugenDevToolStripMenuItem = new ToolStripMenuItem();
            statusMain.SuspendLayout();
            menMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridMembers).BeginInit();
            SuspendLayout();
            // 
            // statusMain
            // 
            statusMain.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusMain.AutoSize = false;
            statusMain.Dock = DockStyle.None;
            statusMain.ImageScalingSize = new Size(32, 32);
            statusMain.Items.AddRange(new ToolStripItem[] { lblVersion, progressStatus });
            statusMain.Location = new Point(0, 375);
            statusMain.Name = "statusMain";
            statusMain.Padding = new Padding(1, 0, 8, 0);
            statusMain.RightToLeft = RightToLeft.No;
            statusMain.Size = new Size(770, 20);
            statusMain.TabIndex = 0;
            statusMain.TabStop = true;
            statusMain.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(63, 15);
            lblVersion.Text = "Version 1.0";
            // 
            // progressStatus
            // 
            progressStatus.Name = "progressStatus";
            progressStatus.Size = new Size(377, 14);
            progressStatus.Visible = false;
            // 
            // menMain
            // 
            menMain.ImageScalingSize = new Size(32, 32);
            menMain.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, bankingToolStripMenuItem, einstellungenToolStripMenuItem });
            menMain.Location = new Point(0, 0);
            menMain.Name = "menMain";
            menMain.Padding = new Padding(3, 1, 0, 1);
            menMain.Size = new Size(770, 24);
            menMain.TabIndex = 1;
            menMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { neuesMitgliedAnlegenToolStripMenuItem, mitgliedBearbeitenToolStripMenuItem, mitgliedLöschenToolStripMenuItem, toolStripSeparator1, datenAusExcelImportierenToolStripMenuItem, alleDatenLöschenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 22);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuesMitgliedAnlegenToolStripMenuItem
            // 
            neuesMitgliedAnlegenToolStripMenuItem.Name = "neuesMitgliedAnlegenToolStripMenuItem";
            neuesMitgliedAnlegenToolStripMenuItem.Size = new Size(220, 22);
            neuesMitgliedAnlegenToolStripMenuItem.Text = "Neues Mitglied anlegen";
            neuesMitgliedAnlegenToolStripMenuItem.Click += btnAddMember_Click;
            // 
            // mitgliedBearbeitenToolStripMenuItem
            // 
            mitgliedBearbeitenToolStripMenuItem.Name = "mitgliedBearbeitenToolStripMenuItem";
            mitgliedBearbeitenToolStripMenuItem.Size = new Size(220, 22);
            mitgliedBearbeitenToolStripMenuItem.Text = "Mitglied bearbeiten";
            mitgliedBearbeitenToolStripMenuItem.Click += btnEdit_Click;
            // 
            // mitgliedLöschenToolStripMenuItem
            // 
            mitgliedLöschenToolStripMenuItem.Name = "mitgliedLöschenToolStripMenuItem";
            mitgliedLöschenToolStripMenuItem.Size = new Size(220, 22);
            mitgliedLöschenToolStripMenuItem.Text = "Mitglied löschen";
            mitgliedLöschenToolStripMenuItem.Click += btnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(217, 6);
            // 
            // datenAusExcelImportierenToolStripMenuItem
            // 
            datenAusExcelImportierenToolStripMenuItem.Name = "datenAusExcelImportierenToolStripMenuItem";
            datenAusExcelImportierenToolStripMenuItem.Size = new Size(220, 22);
            datenAusExcelImportierenToolStripMenuItem.Text = "Daten aus Excel importieren";
            datenAusExcelImportierenToolStripMenuItem.Click += datenAusExcelImportierenToolStripMenuItem_Click;
            // 
            // alleDatenLöschenToolStripMenuItem
            // 
            alleDatenLöschenToolStripMenuItem.Name = "alleDatenLöschenToolStripMenuItem";
            alleDatenLöschenToolStripMenuItem.Size = new Size(220, 22);
            alleDatenLöschenToolStripMenuItem.Text = "Alle Mitglieder löschen";
            alleDatenLöschenToolStripMenuItem.Click += alleDatenLöschenToolStripMenuItem_Click;
            // 
            // bankingToolStripMenuItem
            // 
            bankingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sepaXMLExportierenToolStripMenuItem, sepaBatchesErzeugenDevToolStripMenuItem });
            bankingToolStripMenuItem.Name = "bankingToolStripMenuItem";
            bankingToolStripMenuItem.Size = new Size(62, 22);
            bankingToolStripMenuItem.Text = "Banking";
            // 
            // sepaXMLExportierenToolStripMenuItem
            // 
            sepaXMLExportierenToolStripMenuItem.Name = "sepaXMLExportierenToolStripMenuItem";
            sepaXMLExportierenToolStripMenuItem.Size = new Size(227, 22);
            sepaXMLExportierenToolStripMenuItem.Text = "Sepa-XML exportieren";
            sepaXMLExportierenToolStripMenuItem.Click += sepaXMLExportierenToolStripMenuItem_Click;
            // 
            // einstellungenToolStripMenuItem
            // 
            einstellungenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { datenDesCreditorsToolStripMenuItem, datensicherungToolStripMenuItem, datensicherungImportierenToolStripMenuItem });
            einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            einstellungenToolStripMenuItem.Size = new Size(90, 22);
            einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // datenDesCreditorsToolStripMenuItem
            // 
            datenDesCreditorsToolStripMenuItem.Name = "datenDesCreditorsToolStripMenuItem";
            datenDesCreditorsToolStripMenuItem.Size = new Size(222, 22);
            datenDesCreditorsToolStripMenuItem.Text = "Daten des Creditors";
            datenDesCreditorsToolStripMenuItem.Click += datenDesCreditorsToolStripMenuItem_Click;
            // 
            // datensicherungToolStripMenuItem
            // 
            datensicherungToolStripMenuItem.Name = "datensicherungToolStripMenuItem";
            datensicherungToolStripMenuItem.Size = new Size(222, 22);
            datensicherungToolStripMenuItem.Text = "Daten sichern";
            datensicherungToolStripMenuItem.Click += datensicherungToolStripMenuItem_Click;
            // 
            // datensicherungImportierenToolStripMenuItem
            // 
            datensicherungImportierenToolStripMenuItem.Name = "datensicherungImportierenToolStripMenuItem";
            datensicherungImportierenToolStripMenuItem.Size = new Size(222, 22);
            datensicherungImportierenToolStripMenuItem.Text = "Datensicherung importieren";
            datensicherungImportierenToolStripMenuItem.Click += datensicherungImportierenToolStripMenuItem_Click;
            // 
            // gridMembers
            // 
            gridMembers.AllowUserToOrderColumns = true;
            gridMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMembers.Location = new Point(0, 57);
            gridMembers.Margin = new Padding(2, 1, 2, 1);
            gridMembers.Name = "gridMembers";
            gridMembers.RowHeadersWidth = 82;
            gridMembers.Size = new Size(770, 317);
            gridMembers.TabIndex = 2;
            gridMembers.CellDoubleClick += gridMembers_CellDoubleClick;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(6, 29);
            lblSearch.Margin = new Padding(2, 0, 2, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(39, 15);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Suche";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(52, 26);
            txtSearch.Margin = new Padding(2, 1, 2, 1);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(713, 23);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // sepaBatchesErzeugenDevToolStripMenuItem
            // 
            sepaBatchesErzeugenDevToolStripMenuItem.Name = "sepaBatchesErzeugenDevToolStripMenuItem";
            sepaBatchesErzeugenDevToolStripMenuItem.Size = new Size(227, 22);
            sepaBatchesErzeugenDevToolStripMenuItem.Text = "Sepa-Batches erzeugen (Dev)";
            sepaBatchesErzeugenDevToolStripMenuItem.Click += sepaBatchesErzeugenDevToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 395);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(gridMembers);
            Controls.Add(statusMain);
            Controls.Add(menMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menMain;
            Margin = new Padding(2, 1, 2, 1);
            Name = "FrmMain";
            Text = "WentzFreunde Pilot";
            Load += FrmMain_Load;
            statusMain.ResumeLayout(false);
            statusMain.PerformLayout();
            menMain.ResumeLayout(false);
            menMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusMain;
        private MenuStrip menMain;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem neuesMitgliedAnlegenToolStripMenuItem;
        private DataGridView gridMembers;
        private ToolStripMenuItem mitgliedBearbeitenToolStripMenuItem;
        private ToolStripMenuItem mitgliedLöschenToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem datenAusExcelImportierenToolStripMenuItem;
        private ToolStripMenuItem alleDatenLöschenToolStripMenuItem;
        private ToolStripMenuItem bankingToolStripMenuItem;
        private ToolStripMenuItem sepaXMLExportierenToolStripMenuItem;
        private ToolStripProgressBar progressStatus;
        private ToolStripStatusLabel lblVersion;
        private Label lblSearch;
        private TextBox txtSearch;
        private ToolStripMenuItem einstellungenToolStripMenuItem;
        private ToolStripMenuItem datenDesCreditorsToolStripMenuItem;
        private ToolStripMenuItem datensicherungToolStripMenuItem;
        private ToolStripMenuItem datensicherungImportierenToolStripMenuItem;
        private ToolStripMenuItem sepaBatchesErzeugenDevToolStripMenuItem;
    }
}
