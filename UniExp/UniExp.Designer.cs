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
            this.dataGridViewCriteria = new System.Windows.Forms.DataGridView();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCriterias = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadCriterias = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCriteria
            // 
            this.dataGridViewCriteria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCriteria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCriteria.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridViewCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCriteria.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewCriteria.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewCriteria.Name = "dataGridViewCriteria";
            this.dataGridViewCriteria.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewCriteria.Size = new System.Drawing.Size(800, 426);
            this.dataGridViewCriteria.TabIndex = 0;
            this.dataGridViewCriteria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCriteria_CellContentClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
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
            // UniExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewCriteria);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "UniExp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniExp";
            this.Load += new System.EventHandler(this.UniExp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCriteria)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCriteria;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem SaveCriterias;
        private System.Windows.Forms.ToolStripMenuItem LoadCriterias;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

