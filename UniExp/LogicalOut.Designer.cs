
namespace UniExp
{
    partial class LogicalOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogicalOut));
            this.dataGridViewIf = new System.Windows.Forms.DataGridView();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnLogicOut = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMaim = new System.Windows.Forms.SplitContainer();
            this.splitContainerSergeev = new System.Windows.Forms.SplitContainer();
            this.lstBoxLogicOut = new System.Windows.Forms.ListBox();
            this.txtBoxInfoSergev = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIf)).BeginInit();
            this.panelBtn.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMaim)).BeginInit();
            this.splitContainerMaim.Panel1.SuspendLayout();
            this.splitContainerMaim.Panel2.SuspendLayout();
            this.splitContainerMaim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSergeev)).BeginInit();
            this.splitContainerSergeev.Panel1.SuspendLayout();
            this.splitContainerSergeev.Panel2.SuspendLayout();
            this.splitContainerSergeev.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewIf
            // 
            this.dataGridViewIf.AllowUserToAddRows = false;
            this.dataGridViewIf.AllowUserToDeleteRows = false;
            this.dataGridViewIf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIf.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIf.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewIf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIf.GridColor = System.Drawing.Color.Black;
            this.dataGridViewIf.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewIf.MultiSelect = false;
            this.dataGridViewIf.Name = "dataGridViewIf";
            this.dataGridViewIf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewIf.Size = new System.Drawing.Size(800, 306);
            this.dataGridViewIf.TabIndex = 5;
            this.dataGridViewIf.AutoSizeColumnsModeChanged += new System.Windows.Forms.DataGridViewAutoSizeColumnsModeEventHandler(this.dataGridViewIf_AutoSizeColumnsModeChanged);
            this.dataGridViewIf.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewIf_MouseClick);
            this.dataGridViewIf.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIf_CellValueChanged);
            // 
            // btnExist
            // 
            this.btnExist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExist.Image = ((System.Drawing.Image)(resources.GetObject("btnExist.Image")));
            this.btnExist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExist.Location = new System.Drawing.Point(713, 3);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 31);
            this.btnExist.TabIndex = 6;
            this.btnExist.Text = "Закрыть";
            this.btnExist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.MouseHover += new System.EventHandler(this.btnExist_MouseHover);
            // 
            // btnLogicOut
            // 
            this.btnLogicOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogicOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogicOut.Image")));
            this.btnLogicOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogicOut.Location = new System.Drawing.Point(355, 3);
            this.btnLogicOut.Name = "btnLogicOut";
            this.btnLogicOut.Size = new System.Drawing.Size(75, 31);
            this.btnLogicOut.TabIndex = 7;
            this.btnLogicOut.Text = "Вывод";
            this.btnLogicOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogicOut.UseVisualStyleBackColor = true;
            this.btnLogicOut.Click += new System.EventHandler(this.btnLogicOut_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph.Image = ((System.Drawing.Image)(resources.GetObject("btnGraph.Image")));
            this.btnGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraph.Location = new System.Drawing.Point(12, 3);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(96, 31);
            this.btnGraph.TabIndex = 8;
            this.btnGraph.Text = "Объяснение";
            this.btnGraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // panelBtn
            // 
            this.panelBtn.Controls.Add(this.btnGraph);
            this.panelBtn.Controls.Add(this.btnExist);
            this.panelBtn.Controls.Add(this.btnLogicOut);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtn.Location = new System.Drawing.Point(0, 509);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(800, 37);
            this.panelBtn.TabIndex = 9;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainerMaim);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 509);
            this.panelMain.TabIndex = 10;
            // 
            // splitContainerMaim
            // 
            this.splitContainerMaim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMaim.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMaim.Name = "splitContainerMaim";
            this.splitContainerMaim.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMaim.Panel1
            // 
            this.splitContainerMaim.Panel1.Controls.Add(this.dataGridViewIf);
            // 
            // splitContainerMaim.Panel2
            // 
            this.splitContainerMaim.Panel2.Controls.Add(this.splitContainerSergeev);
            this.splitContainerMaim.Size = new System.Drawing.Size(800, 509);
            this.splitContainerMaim.SplitterDistance = 306;
            this.splitContainerMaim.TabIndex = 0;
            // 
            // splitContainerSergeev
            // 
            this.splitContainerSergeev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSergeev.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSergeev.Name = "splitContainerSergeev";
            this.splitContainerSergeev.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSergeev.Panel1
            // 
            this.splitContainerSergeev.Panel1.Controls.Add(this.lstBoxLogicOut);
            // 
            // splitContainerSergeev.Panel2
            // 
            this.splitContainerSergeev.Panel2.Controls.Add(this.txtBoxInfoSergev);
            this.splitContainerSergeev.Size = new System.Drawing.Size(800, 199);
            this.splitContainerSergeev.SplitterDistance = 139;
            this.splitContainerSergeev.TabIndex = 3;
            // 
            // lstBoxLogicOut
            // 
            this.lstBoxLogicOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxLogicOut.FormattingEnabled = true;
            this.lstBoxLogicOut.HorizontalScrollbar = true;
            this.lstBoxLogicOut.Location = new System.Drawing.Point(0, 0);
            this.lstBoxLogicOut.Name = "lstBoxLogicOut";
            this.lstBoxLogicOut.Size = new System.Drawing.Size(800, 139);
            this.lstBoxLogicOut.TabIndex = 1;
            // 
            // txtBoxInfoSergev
            // 
            this.txtBoxInfoSergev.BackColor = System.Drawing.Color.White;
            this.txtBoxInfoSergev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxInfoSergev.Location = new System.Drawing.Point(0, 0);
            this.txtBoxInfoSergev.Multiline = true;
            this.txtBoxInfoSergev.Name = "txtBoxInfoSergev";
            this.txtBoxInfoSergev.ReadOnly = true;
            this.txtBoxInfoSergev.Size = new System.Drawing.Size(800, 56);
            this.txtBoxInfoSergev.TabIndex = 3;
            // 
            // LogicalOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogicalOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Логический вывод и объяснение его результатов";
            this.Load += new System.EventHandler(this.logicalOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIf)).EndInit();
            this.panelBtn.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.splitContainerMaim.Panel1.ResumeLayout(false);
            this.splitContainerMaim.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMaim)).EndInit();
            this.splitContainerMaim.ResumeLayout(false);
            this.splitContainerSergeev.Panel1.ResumeLayout(false);
            this.splitContainerSergeev.Panel2.ResumeLayout(false);
            this.splitContainerSergeev.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSergeev)).EndInit();
            this.splitContainerSergeev.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewIf;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnLogicOut;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Panel panelBtn;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMaim;
        private System.Windows.Forms.SplitContainer splitContainerSergeev;
        private System.Windows.Forms.ListBox lstBoxLogicOut;
        private System.Windows.Forms.TextBox txtBoxInfoSergev;
    }
}