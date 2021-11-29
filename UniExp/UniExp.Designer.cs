namespace UniExp
{
    partial class UniExp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UniExp));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.btnMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreated = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExist = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.splitContainerMailn = new System.Windows.Forms.SplitContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridViewCriteria = new System.Windows.Forms.DataGridView();
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.panelLstBoxProjName = new System.Windows.Forms.Panel();
            this.lstBoxProjName = new System.Windows.Forms.ListBox();
            this.MainMenu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMailn)).BeginInit();
            this.splitContainerMailn.Panel1.SuspendLayout();
            this.splitContainerMailn.Panel2.SuspendLayout();
            this.splitContainerMailn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.panelLstBoxProjName.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuFile});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(962, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // btnMenuFile
            // 
            this.btnMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreated,
            this.btnOpen,
            this.toolStripSeparator1,
            this.btnSave,
            this.btnUndo,
            this.toolStripSeparator2,
            this.btnExist});
            this.btnMenuFile.Name = "btnMenuFile";
            this.btnMenuFile.Size = new System.Drawing.Size(48, 20);
            this.btnMenuFile.Text = "Файл";
            // 
            // btnCreated
            // 
            this.btnCreated.Image = ((System.Drawing.Image)(resources.GetObject("btnCreated.Image")));
            this.btnCreated.Name = "btnCreated";
            this.btnCreated.Size = new System.Drawing.Size(132, 22);
            this.btnCreated.Text = "Создать";
            this.btnCreated.Click += new System.EventHandler(this.btnCreated_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(132, 22);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 22);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(132, 22);
            this.btnUndo.Text = "Отменить";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // btnExist
            // 
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(132, 22);
            this.btnExist.Text = "Закрыть";
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "data.json";
            this.saveFileDialog.Filter = "Данные|*.json";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Создать проекта";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "data.json";
            this.openFileDialog.Filter = "Данные|*.json";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\vsproj_andrey\\UniExp\\UniExp\\Projects";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainerMailn);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(962, 387);
            this.panelMain.TabIndex = 3;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Enabled = false;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel.Text = "Папка с проектами";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 389);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(962, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // splitContainerMailn
            // 
            this.splitContainerMailn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMailn.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMailn.Name = "splitContainerMailn";
            // 
            // splitContainerMailn.Panel1
            // 
            this.splitContainerMailn.Panel1.AutoScroll = true;
            this.splitContainerMailn.Panel1.Controls.Add(this.panelLstBoxProjName);
            // 
            // splitContainerMailn.Panel2
            // 
            this.splitContainerMailn.Panel2.Controls.Add(this.splitContainer);
            this.splitContainerMailn.Size = new System.Drawing.Size(962, 387);
            this.splitContainerMailn.SplitterDistance = 189;
            this.splitContainerMailn.TabIndex = 3;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGridViewCriteria);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridViewRoles);
            this.splitContainer.Size = new System.Drawing.Size(769, 387);
            this.splitContainer.SplitterDistance = 188;
            this.splitContainer.TabIndex = 4;
            // 
            // dataGridViewCriteria
            // 
            this.dataGridViewCriteria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCriteria.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCriteria.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCriteria.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCriteria.MultiSelect = false;
            this.dataGridViewCriteria.Name = "dataGridViewCriteria";
            this.dataGridViewCriteria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCriteria.Size = new System.Drawing.Size(769, 188);
            this.dataGridViewCriteria.TabIndex = 0;
            this.dataGridViewCriteria.AutoSizeColumnsModeChanged += new System.Windows.Forms.DataGridViewAutoSizeColumnsModeEventHandler(this.dataGridViewCriteria_AutoSizeColumnsModeChanged);
            this.dataGridViewCriteria.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewCriteria_CellBeginEdit);
            this.dataGridViewCriteria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriteria_CellClick);
            this.dataGridViewCriteria.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriteria_CellValueChanged);
            this.dataGridViewCriteria.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewCriteria_RowsAdded);
            this.dataGridViewCriteria.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewCriteria_RowsRemoved);
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewRoles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRoles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewRoles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRoles.MultiSelect = false;
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewRoles.Size = new System.Drawing.Size(769, 195);
            this.dataGridViewRoles.TabIndex = 1;
            // 
            // panelLstBoxProjName
            // 
            this.panelLstBoxProjName.Controls.Add(this.lstBoxProjName);
            this.panelLstBoxProjName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLstBoxProjName.Location = new System.Drawing.Point(0, 0);
            this.panelLstBoxProjName.Name = "panelLstBoxProjName";
            this.panelLstBoxProjName.Size = new System.Drawing.Size(189, 387);
            this.panelLstBoxProjName.TabIndex = 4;
            // 
            // lstBoxProjName
            // 
            this.lstBoxProjName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxProjName.FormattingEnabled = true;
            this.lstBoxProjName.Location = new System.Drawing.Point(0, 0);
            this.lstBoxProjName.Name = "lstBoxProjName";
            this.lstBoxProjName.Size = new System.Drawing.Size(189, 387);
            this.lstBoxProjName.TabIndex = 0;
            this.lstBoxProjName.SelectedIndexChanged += new System.EventHandler(this.lstBoxProjName_SelectedIndexChanged);
            // 
            // UniExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 411);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "UniExp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniExp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UniExp_FormClosing);
            this.Load += new System.EventHandler(this.UniExp_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainerMailn.Panel1.ResumeLayout(false);
            this.splitContainerMailn.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMailn)).EndInit();
            this.splitContainerMailn.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.panelLstBoxProjName.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem btnMenuFile;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem btnCreated;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnExist;
        private System.Windows.Forms.SplitContainer splitContainerMailn;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridViewCriteria;
        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.Panel panelLstBoxProjName;
        private System.Windows.Forms.ListBox lstBoxProjName;
    }
}

