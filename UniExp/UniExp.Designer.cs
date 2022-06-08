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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMailn = new System.Windows.Forms.SplitContainer();
            this.panelLstBoxProjName = new System.Windows.Forms.Panel();
            this.pnlProjectsName = new System.Windows.Forms.Panel();
            this.lstBoxProjName = new System.Windows.Forms.ListBox();
            this.pnlProject = new System.Windows.Forms.Panel();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.splitContainerGrid = new System.Windows.Forms.SplitContainer();
            this.pnlGridCriteria = new System.Windows.Forms.Panel();
            this.dataGridViewCriteria = new System.Windows.Forms.DataGridView();
            this.pnlCriteria = new System.Windows.Forms.Panel();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.pnlGridRole = new System.Windows.Forms.Panel();
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.pnlRole = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.btnMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreated = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExist = new System.Windows.Forms.ToolStripMenuItem();
            this.LogicalOut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btninfoUniExp = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblInfoHelp = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMailn)).BeginInit();
            this.splitContainerMailn.Panel1.SuspendLayout();
            this.splitContainerMailn.Panel2.SuspendLayout();
            this.splitContainerMailn.SuspendLayout();
            this.panelLstBoxProjName.SuspendLayout();
            this.pnlProjectsName.SuspendLayout();
            this.pnlProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGrid)).BeginInit();
            this.splitContainerGrid.Panel1.SuspendLayout();
            this.splitContainerGrid.Panel2.SuspendLayout();
            this.splitContainerGrid.SuspendLayout();
            this.pnlGridCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).BeginInit();
            this.pnlCriteria.SuspendLayout();
            this.pnlGridRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.pnlRole.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.panelMain.Controls.Add(this.MainMenu);
            this.panelMain.Controls.Add(this.statusStrip);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(962, 411);
            this.panelMain.TabIndex = 3;
            // 
            // splitContainerMailn
            // 
            this.splitContainerMailn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMailn.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMailn.Name = "splitContainerMailn";
            // 
            // splitContainerMailn.Panel1
            // 
            this.splitContainerMailn.Panel1.AutoScroll = true;
            this.splitContainerMailn.Panel1.Controls.Add(this.panelLstBoxProjName);
            // 
            // splitContainerMailn.Panel2
            // 
            this.splitContainerMailn.Panel2.Controls.Add(this.splitContainerGrid);
            this.splitContainerMailn.Size = new System.Drawing.Size(962, 365);
            this.splitContainerMailn.SplitterDistance = 189;
            this.splitContainerMailn.TabIndex = 7;
            // 
            // panelLstBoxProjName
            // 
            this.panelLstBoxProjName.Controls.Add(this.pnlProjectsName);
            this.panelLstBoxProjName.Controls.Add(this.pnlProject);
            this.panelLstBoxProjName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLstBoxProjName.Location = new System.Drawing.Point(0, 0);
            this.panelLstBoxProjName.Name = "panelLstBoxProjName";
            this.panelLstBoxProjName.Size = new System.Drawing.Size(189, 365);
            this.panelLstBoxProjName.TabIndex = 5;
            // 
            // pnlProjectsName
            // 
            this.pnlProjectsName.Controls.Add(this.lstBoxProjName);
            this.pnlProjectsName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProjectsName.Location = new System.Drawing.Point(0, 25);
            this.pnlProjectsName.Name = "pnlProjectsName";
            this.pnlProjectsName.Size = new System.Drawing.Size(189, 340);
            this.pnlProjectsName.TabIndex = 4;
            // 
            // lstBoxProjName
            // 
            this.lstBoxProjName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxProjName.FormattingEnabled = true;
            this.lstBoxProjName.Location = new System.Drawing.Point(0, 0);
            this.lstBoxProjName.Name = "lstBoxProjName";
            this.lstBoxProjName.Size = new System.Drawing.Size(189, 340);
            this.lstBoxProjName.TabIndex = 0;
            this.lstBoxProjName.SelectedIndexChanged += new System.EventHandler(this.lstBoxProjName_SelectedIndexChanged);
            // 
            // pnlProject
            // 
            this.pnlProject.Controls.Add(this.lblProjectName);
            this.pnlProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProject.Location = new System.Drawing.Point(0, 0);
            this.pnlProject.Name = "pnlProject";
            this.pnlProject.Size = new System.Drawing.Size(189, 25);
            this.pnlProject.TabIndex = 2;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProjectName.Location = new System.Drawing.Point(3, 4);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(56, 15);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "Проекты";
            // 
            // splitContainerGrid
            // 
            this.splitContainerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGrid.Location = new System.Drawing.Point(0, 0);
            this.splitContainerGrid.Name = "splitContainerGrid";
            this.splitContainerGrid.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerGrid.Panel1
            // 
            this.splitContainerGrid.Panel1.Controls.Add(this.pnlGridCriteria);
            this.splitContainerGrid.Panel1.Controls.Add(this.pnlCriteria);
            // 
            // splitContainerGrid.Panel2
            // 
            this.splitContainerGrid.Panel2.Controls.Add(this.pnlGridRole);
            this.splitContainerGrid.Panel2.Controls.Add(this.pnlRole);
            this.splitContainerGrid.Size = new System.Drawing.Size(769, 365);
            this.splitContainerGrid.SplitterDistance = 177;
            this.splitContainerGrid.TabIndex = 4;
            // 
            // pnlGridCriteria
            // 
            this.pnlGridCriteria.Controls.Add(this.dataGridViewCriteria);
            this.pnlGridCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridCriteria.Location = new System.Drawing.Point(0, 25);
            this.pnlGridCriteria.Name = "pnlGridCriteria";
            this.pnlGridCriteria.Size = new System.Drawing.Size(769, 152);
            this.pnlGridCriteria.TabIndex = 3;
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
            this.dataGridViewCriteria.Size = new System.Drawing.Size(769, 152);
            this.dataGridViewCriteria.TabIndex = 0;
            this.dataGridViewCriteria.AutoSizeColumnsModeChanged += new System.Windows.Forms.DataGridViewAutoSizeColumnsModeEventHandler(this.dataGridViewCriteria_AutoSizeColumnsModeChanged);
            this.dataGridViewCriteria.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewCriteria_CellBeginEdit);
            this.dataGridViewCriteria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriteria_CellClick);
            this.dataGridViewCriteria.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriteria_CellValueChanged);
            this.dataGridViewCriteria.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewCriteria_RowsAdded);
            this.dataGridViewCriteria.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewCriteria_RowsRemoved);
            // 
            // pnlCriteria
            // 
            this.pnlCriteria.Controls.Add(this.lblCriteria);
            this.pnlCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCriteria.Location = new System.Drawing.Point(0, 0);
            this.pnlCriteria.Name = "pnlCriteria";
            this.pnlCriteria.Size = new System.Drawing.Size(769, 25);
            this.pnlCriteria.TabIndex = 2;
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCriteria.Location = new System.Drawing.Point(4, 4);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(61, 15);
            this.lblCriteria.TabIndex = 0;
            this.lblCriteria.Text = "Критерии";
            // 
            // pnlGridRole
            // 
            this.pnlGridRole.Controls.Add(this.dataGridViewRoles);
            this.pnlGridRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridRole.Location = new System.Drawing.Point(0, 25);
            this.pnlGridRole.Name = "pnlGridRole";
            this.pnlGridRole.Size = new System.Drawing.Size(769, 159);
            this.pnlGridRole.TabIndex = 4;
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
            this.dataGridViewRoles.Size = new System.Drawing.Size(769, 159);
            this.dataGridViewRoles.TabIndex = 1;
            this.dataGridViewRoles.AutoSizeColumnsModeChanged += new System.Windows.Forms.DataGridViewAutoSizeColumnsModeEventHandler(this.dataGridViewRoles_AutoSizeColumnsModeChanged);
            this.dataGridViewRoles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewRoles_CellBeginEdit);
            this.dataGridViewRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRoles_CellClick);
            this.dataGridViewRoles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRoles_CellValueChanged);
            this.dataGridViewRoles.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewRoles_RowsAdded);
            this.dataGridViewRoles.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewRoles_RowsRemoved);
            // 
            // pnlRole
            // 
            this.pnlRole.Controls.Add(this.lblRole);
            this.pnlRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRole.Location = new System.Drawing.Point(0, 0);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(769, 25);
            this.pnlRole.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRole.Location = new System.Drawing.Point(4, 4);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(54, 15);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "Правила";
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuFile,
            this.LogicalOut,
            this.btnInfo});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(962, 24);
            this.MainMenu.TabIndex = 5;
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
            this.btnCreated.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.btnCreated.Size = new System.Drawing.Size(173, 22);
            this.btnCreated.Text = "Создать";
            this.btnCreated.ToolTipText = "Создать новый файл проекта";
            this.btnCreated.Click += new System.EventHandler(this.btnCreated_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(173, 22);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.ToolTipText = "Открыть заранее созданный файл проекта";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSave.Size = new System.Drawing.Size(173, 22);
            this.btnSave.Text = "Сохранить";
            this.btnSave.ToolTipText = "Сохранить текущие изменения в проекте\r\n";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.btnUndo.Size = new System.Drawing.Size(173, 22);
            this.btnUndo.Text = "Отменить";
            this.btnUndo.ToolTipText = "Отменить текущие изменения в проекте";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // btnExist
            // 
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.Name = "btnExist";
            this.btnExist.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.btnExist.Size = new System.Drawing.Size(173, 22);
            this.btnExist.Text = "Закрыть";
            this.btnExist.ToolTipText = "Закрыть программу";
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // LogicalOut
            // 
            this.LogicalOut.Name = "LogicalOut";
            this.LogicalOut.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.LogicalOut.Size = new System.Drawing.Size(291, 20);
            this.LogicalOut.Text = "Логический вывод и объяснение его результатов";
            this.LogicalOut.Click += new System.EventHandler(this.LogicalOut_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btninfoUniExp,
            this.AboutToolStripMenuItem});
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(65, 20);
            this.btnInfo.Text = "Справка";
            // 
            // btninfoUniExp
            // 
            this.btninfoUniExp.Image = ((System.Drawing.Image)(resources.GetObject("btninfoUniExp.Image")));
            this.btninfoUniExp.Name = "btninfoUniExp";
            this.btninfoUniExp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.btninfoUniExp.Size = new System.Drawing.Size(198, 22);
            this.btninfoUniExp.Text = "Просмотр справки";
            this.btninfoUniExp.ToolTipText = "Открыть справку программы";
            this.btninfoUniExp.Click += new System.EventHandler(this.btninfoUniExp_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.ToolTipText = "Открыть сведеия о программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfoHelp,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 389);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(962, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblInfoHelp
            // 
            this.lblInfoHelp.Enabled = false;
            this.lblInfoHelp.Name = "lblInfoHelp";
            this.lblInfoHelp.Size = new System.Drawing.Size(66, 17);
            this.lblInfoHelp.Text = "F1 справка";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Enabled = false;
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel.Text = "Папка с проектами";
            // 
            // UniExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 411);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UniExp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор базы знаний";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UniExp_FormClosing);
            this.Load += new System.EventHandler(this.UniExp_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.splitContainerMailn.Panel1.ResumeLayout(false);
            this.splitContainerMailn.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMailn)).EndInit();
            this.splitContainerMailn.ResumeLayout(false);
            this.panelLstBoxProjName.ResumeLayout(false);
            this.pnlProjectsName.ResumeLayout(false);
            this.pnlProject.ResumeLayout(false);
            this.pnlProject.PerformLayout();
            this.splitContainerGrid.Panel1.ResumeLayout(false);
            this.splitContainerGrid.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGrid)).EndInit();
            this.splitContainerGrid.ResumeLayout(false);
            this.pnlGridCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).EndInit();
            this.pnlCriteria.ResumeLayout(false);
            this.pnlCriteria.PerformLayout();
            this.pnlGridRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.pnlRole.ResumeLayout(false);
            this.pnlRole.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMailn;
        private System.Windows.Forms.Panel panelLstBoxProjName;
        private System.Windows.Forms.ListBox lstBoxProjName;
        private System.Windows.Forms.SplitContainer splitContainerGrid;
        private System.Windows.Forms.DataGridView dataGridViewCriteria;
        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem btnMenuFile;
        private System.Windows.Forms.ToolStripMenuItem btnCreated;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnExist;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem btnInfo;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btninfoUniExp;
        private System.Windows.Forms.ToolStripStatusLabel lblInfoHelp;
        private System.Windows.Forms.Panel pnlGridCriteria;
        private System.Windows.Forms.Panel pnlCriteria;
        private System.Windows.Forms.Label lblCriteria;
        private System.Windows.Forms.Panel pnlGridRole;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlProjectsName;
        private System.Windows.Forms.Panel pnlProject;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.ToolStripMenuItem LogicalOut;
    }
}

