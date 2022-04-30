
namespace UniExp
{
    partial class Graph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            this.pctBox = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pctBox)).BeginInit();
            this.panelBtn.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctBox
            // 
            this.pctBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctBox.Image = ((System.Drawing.Image)(resources.GetObject("pctBox.Image")));
            this.pctBox.Location = new System.Drawing.Point(0, 0);
            this.pctBox.Name = "pctBox";
            this.pctBox.Size = new System.Drawing.Size(1308, 717);
            this.pctBox.TabIndex = 0;
            this.pctBox.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1228, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 39);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panelBtn
            // 
            this.panelBtn.Controls.Add(this.btnClose);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtn.Location = new System.Drawing.Point(0, 717);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(1308, 39);
            this.panelBtn.TabIndex = 2;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.pctBox);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1308, 717);
            this.panelMain.TabIndex = 3;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 756);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Граф";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Graph_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pctBox)).EndInit();
            this.panelBtn.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelBtn;
        private System.Windows.Forms.Panel panelMain;
    }
}