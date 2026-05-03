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
            gridMembers = new DataGridView();
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
            statusMain.Location = new Point(0, 801);
            statusMain.Name = "statusMain";
            statusMain.RightToLeft = RightToLeft.No;
            statusMain.Size = new Size(1430, 42);
            statusMain.TabIndex = 0;
            statusMain.TabStop = true;
            statusMain.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(130, 32);
            lblVersion.Text = "Version 1.0";
            // 
            // progressStatus
            // 
            progressStatus.Name = "progressStatus";
            progressStatus.Size = new Size(700, 30);
            progressStatus.Visible = false;
            // 
            // menMain
            // 
            menMain.ImageScalingSize = new Size(32, 32);
            menMain.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, bankingToolStripMenuItem });
            menMain.Location = new Point(0, 0);
            menMain.Name = "menMain";
            menMain.Size = new Size(1430, 42);
            menMain.TabIndex = 1;
            menMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { neuesMitgliedAnlegenToolStripMenuItem, mitgliedBearbeitenToolStripMenuItem, mitgliedLöschenToolStripMenuItem, toolStripSeparator1, datenAusExcelImportierenToolStripMenuItem, alleDatenLöschenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(90, 38);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuesMitgliedAnlegenToolStripMenuItem
            // 
            neuesMitgliedAnlegenToolStripMenuItem.Name = "neuesMitgliedAnlegenToolStripMenuItem";
            neuesMitgliedAnlegenToolStripMenuItem.Size = new Size(446, 44);
            neuesMitgliedAnlegenToolStripMenuItem.Text = "Neues Mitglied anlegen";
            neuesMitgliedAnlegenToolStripMenuItem.Click += btnAddMember_Click;
            // 
            // mitgliedBearbeitenToolStripMenuItem
            // 
            mitgliedBearbeitenToolStripMenuItem.Name = "mitgliedBearbeitenToolStripMenuItem";
            mitgliedBearbeitenToolStripMenuItem.Size = new Size(446, 44);
            mitgliedBearbeitenToolStripMenuItem.Text = "Mitglied bearbeiten";
            mitgliedBearbeitenToolStripMenuItem.Click += btnEdit_Click;
            // 
            // mitgliedLöschenToolStripMenuItem
            // 
            mitgliedLöschenToolStripMenuItem.Name = "mitgliedLöschenToolStripMenuItem";
            mitgliedLöschenToolStripMenuItem.Size = new Size(446, 44);
            mitgliedLöschenToolStripMenuItem.Text = "Mitglied löschen";
            mitgliedLöschenToolStripMenuItem.Click += btnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(443, 6);
            // 
            // datenAusExcelImportierenToolStripMenuItem
            // 
            datenAusExcelImportierenToolStripMenuItem.Name = "datenAusExcelImportierenToolStripMenuItem";
            datenAusExcelImportierenToolStripMenuItem.Size = new Size(446, 44);
            datenAusExcelImportierenToolStripMenuItem.Text = "Daten aus Excel importieren";
            datenAusExcelImportierenToolStripMenuItem.Click += datenAusExcelImportierenToolStripMenuItem_Click;
            // 
            // alleDatenLöschenToolStripMenuItem
            // 
            alleDatenLöschenToolStripMenuItem.Name = "alleDatenLöschenToolStripMenuItem";
            alleDatenLöschenToolStripMenuItem.Size = new Size(446, 44);
            alleDatenLöschenToolStripMenuItem.Text = "Alle Daten löschen";
            alleDatenLöschenToolStripMenuItem.Click += alleDatenLöschenToolStripMenuItem_Click;
            // 
            // bankingToolStripMenuItem
            // 
            bankingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sepaXMLExportierenToolStripMenuItem });
            bankingToolStripMenuItem.Name = "bankingToolStripMenuItem";
            bankingToolStripMenuItem.Size = new Size(120, 38);
            bankingToolStripMenuItem.Text = "Banking";
            // 
            // sepaXMLExportierenToolStripMenuItem
            // 
            sepaXMLExportierenToolStripMenuItem.Name = "sepaXMLExportierenToolStripMenuItem";
            sepaXMLExportierenToolStripMenuItem.Size = new Size(385, 44);
            sepaXMLExportierenToolStripMenuItem.Text = "Sepa-XML exportieren";
            // 
            // gridMembers
            // 
            gridMembers.AllowUserToOrderColumns = true;
            gridMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMembers.Location = new Point(0, 40);
            gridMembers.Name = "gridMembers";
            gridMembers.RowHeadersWidth = 82;
            gridMembers.Size = new Size(1430, 758);
            gridMembers.TabIndex = 2;
            gridMembers.CellDoubleClick += gridMembers_CellDoubleClick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1430, 843);
            Controls.Add(gridMembers);
            Controls.Add(statusMain);
            Controls.Add(menMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menMain;
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
    }
}
