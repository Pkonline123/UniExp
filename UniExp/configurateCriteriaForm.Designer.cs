namespace UniExp
{
    partial class configurateCriteriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configurateCriteriaForm));
            this.panelConfigurateCriteria = new System.Windows.Forms.Panel();
            this.btnCancelConfigurateCriteria = new System.Windows.Forms.Button();
            this.btnSaveConfigurateCriteria = new System.Windows.Forms.Button();
            this.dataGridViewConfigurateCriteria = new System.Windows.Forms.DataGridView();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.txtBoxCriteriaName = new System.Windows.Forms.TextBox();
            this.panelConfigurateCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfigurateCriteria)).BeginInit();
            this.SuspendLayout();
            // 
            // panelConfigurateCriteria
            // 
            this.panelConfigurateCriteria.Controls.Add(this.btnCancelConfigurateCriteria);
            this.panelConfigurateCriteria.Controls.Add(this.btnSaveConfigurateCriteria);
            this.panelConfigurateCriteria.Controls.Add(this.dataGridViewConfigurateCriteria);
            this.panelConfigurateCriteria.Location = new System.Drawing.Point(10, 66);
            this.panelConfigurateCriteria.Name = "panelConfigurateCriteria";
            this.panelConfigurateCriteria.Size = new System.Drawing.Size(329, 172);
            this.panelConfigurateCriteria.TabIndex = 2;
            // 
            // btnCancelConfigurateCriteria
            // 
            this.btnCancelConfigurateCriteria.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelConfigurateCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelConfigurateCriteria.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelConfigurateCriteria.Image")));
            this.btnCancelConfigurateCriteria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelConfigurateCriteria.Location = new System.Drawing.Point(239, 129);
            this.btnCancelConfigurateCriteria.Name = "btnCancelConfigurateCriteria";
            this.btnCancelConfigurateCriteria.Size = new System.Drawing.Size(90, 36);
            this.btnCancelConfigurateCriteria.TabIndex = 2;
            this.btnCancelConfigurateCriteria.Text = "Отменить";
            this.btnCancelConfigurateCriteria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelConfigurateCriteria.UseVisualStyleBackColor = true;
            // 
            // btnSaveConfigurateCriteria
            // 
            this.btnSaveConfigurateCriteria.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveConfigurateCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveConfigurateCriteria.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveConfigurateCriteria.Image")));
            this.btnSaveConfigurateCriteria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveConfigurateCriteria.Location = new System.Drawing.Point(0, 129);
            this.btnSaveConfigurateCriteria.Name = "btnSaveConfigurateCriteria";
            this.btnSaveConfigurateCriteria.Size = new System.Drawing.Size(90, 36);
            this.btnSaveConfigurateCriteria.TabIndex = 1;
            this.btnSaveConfigurateCriteria.Text = "Добавить";
            this.btnSaveConfigurateCriteria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveConfigurateCriteria.UseVisualStyleBackColor = true;
            this.btnSaveConfigurateCriteria.Click += new System.EventHandler(this.btnSaveConfigurateCriteria_Click);
            // 
            // dataGridViewConfigurateCriteria
            // 
            this.dataGridViewConfigurateCriteria.AllowDrop = true;
            this.dataGridViewConfigurateCriteria.AllowUserToAddRows = false;
            this.dataGridViewConfigurateCriteria.AllowUserToDeleteRows = false;
            this.dataGridViewConfigurateCriteria.AllowUserToResizeColumns = false;
            this.dataGridViewConfigurateCriteria.AllowUserToResizeRows = false;
            this.dataGridViewConfigurateCriteria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewConfigurateCriteria.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewConfigurateCriteria.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewConfigurateCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConfigurateCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewConfigurateCriteria.GridColor = System.Drawing.Color.Black;
            this.dataGridViewConfigurateCriteria.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewConfigurateCriteria.Name = "dataGridViewConfigurateCriteria";
            this.dataGridViewConfigurateCriteria.Size = new System.Drawing.Size(329, 123);
            this.dataGridViewConfigurateCriteria.TabIndex = 0;
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Location = new System.Drawing.Point(8, 13);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(58, 13);
            this.lblCriteria.TabIndex = 3;
            this.lblCriteria.Text = "Критерий:";
            // 
            // txtBoxCriteriaName
            // 
            this.txtBoxCriteriaName.Enabled = false;
            this.txtBoxCriteriaName.Location = new System.Drawing.Point(10, 29);
            this.txtBoxCriteriaName.Name = "txtBoxCriteriaName";
            this.txtBoxCriteriaName.ReadOnly = true;
            this.txtBoxCriteriaName.Size = new System.Drawing.Size(329, 20);
            this.txtBoxCriteriaName.TabIndex = 4;
            // 
            // configurateCriteriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(351, 243);
            this.Controls.Add(this.txtBoxCriteriaName);
            this.Controls.Add(this.lblCriteria);
            this.Controls.Add(this.panelConfigurateCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "configurateCriteriaForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конфигуратор значений";
            this.Load += new System.EventHandler(this.configurateCriteriaForm_Load);
            this.panelConfigurateCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConfigurateCriteria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelConfigurateCriteria;
        private System.Windows.Forms.Button btnCancelConfigurateCriteria;
        private System.Windows.Forms.Button btnSaveConfigurateCriteria;
        private System.Windows.Forms.DataGridView dataGridViewConfigurateCriteria;
        private System.Windows.Forms.Label lblCriteria;
        private System.Windows.Forms.TextBox txtBoxCriteriaName;
    }
}