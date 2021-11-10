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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCriterias = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadCriterias = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelLstBoxProjName = new System.Windows.Forms.Panel();
            this.lstBoxProjName = new System.Windows.Forms.ListBox();
            this.SelectFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridViewCriteria = new System.Windows.Forms.DataGridView();
            this.MainMenu.SuspendLayout();
            this.panelLstBoxProjName.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.SelectFolder});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(962, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveCriterias,
            this.LoadCriterias});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 20);
            this.MenuFile.Text = "Файл";
            // 
            // SaveCriterias
            // 
            this.SaveCriterias.Name = "SaveCriterias";
            this.SaveCriterias.Size = new System.Drawing.Size(153, 22);
            this.SaveCriterias.Text = "Сохранить";
            this.SaveCriterias.Click += new System.EventHandler(this.SaveCriterias_Click);
            // 
            // LoadCriterias
            // 
            this.LoadCriterias.Name = "LoadCriterias";
            this.LoadCriterias.Size = new System.Drawing.Size(153, 22);
            this.LoadCriterias.Text = "Открыть файл";
            this.LoadCriterias.Click += new System.EventHandler(this.LoadCriterias_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "data.json";
            this.saveFileDialog.Filter = "Данные|*.json";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "data.json";
            this.openFileDialog.Filter = "Данные|*.json";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // panelLstBoxProjName
            // 
            this.panelLstBoxProjName.Controls.Add(this.lstBoxProjName);
            this.panelLstBoxProjName.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLstBoxProjName.Location = new System.Drawing.Point(0, 0);
            this.panelLstBoxProjName.Name = "panelLstBoxProjName";
            this.panelLstBoxProjName.Size = new System.Drawing.Size(164, 365);
            this.panelLstBoxProjName.TabIndex = 2;
            // 
            // lstBoxProjName
            // 
            this.lstBoxProjName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxProjName.FormattingEnabled = true;
            this.lstBoxProjName.Location = new System.Drawing.Point(0, 0);
            this.lstBoxProjName.Name = "lstBoxProjName";
            this.lstBoxProjName.Size = new System.Drawing.Size(164, 365);
            this.lstBoxProjName.TabIndex = 0;
            this.lstBoxProjName.SelectedIndexChanged += new System.EventHandler(this.lstBoxProjName_SelectedIndexChanged);
            // 
            // SelectFolder
            // 
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(101, 20);
            this.SelectFolder.Text = "Выбрать папку";
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\vsproj_andrey\\UniExp\\UniExp\\Projects";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Controls.Add(this.panelLstBoxProjName);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(962, 365);
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
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(164, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGridViewCriteria);
            this.splitContainer.Size = new System.Drawing.Size(798, 365);
            this.splitContainer.SplitterDistance = 178;
            this.splitContainer.TabIndex = 3;
            // 
            // dataGridViewCriteria
            // 
            this.dataGridViewCriteria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCriteria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCriteria.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridViewCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCriteria.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCriteria.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCriteria.Name = "dataGridViewCriteria";
            this.dataGridViewCriteria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCriteria.Size = new System.Drawing.Size(798, 178);
            this.dataGridViewCriteria.TabIndex = 0;
            // 
            // UniExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 411);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "UniExp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniExp";
            this.Load += new System.EventHandler(this.UniExp_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panelLstBoxProjName.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem SaveCriterias;
        private System.Windows.Forms.ToolStripMenuItem LoadCriterias;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panelLstBoxProjName;
        private System.Windows.Forms.ListBox lstBoxProjName;
        private System.Windows.Forms.ToolStripMenuItem SelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridViewCriteria;
    }
}

