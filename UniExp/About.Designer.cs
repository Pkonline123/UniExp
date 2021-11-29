namespace UniExp
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnBackward = new System.Windows.Forms.Button();
            this.lblVersionName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblDeveloperName = new System.Windows.Forms.Label();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblLeaderName = new System.Windows.Forms.Label();
            this.picBoxSFU = new System.Windows.Forms.PictureBox();
            this.lblLeader = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSFU)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnBackward);
            this.panelMain.Controls.Add(this.lblVersionName);
            this.panelMain.Controls.Add(this.lblVersion);
            this.panelMain.Controls.Add(this.lblProjectName);
            this.panelMain.Controls.Add(this.lblDeveloperName);
            this.panelMain.Controls.Add(this.lblDeveloper);
            this.panelMain.Controls.Add(this.lblLeaderName);
            this.panelMain.Controls.Add(this.picBoxSFU);
            this.panelMain.Controls.Add(this.lblLeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(608, 328);
            this.panelMain.TabIndex = 0;
            // 
            // btnBackward
            // 
            this.btnBackward.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBackward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackward.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackward.Image = ((System.Drawing.Image)(resources.GetObject("btnBackward.Image")));
            this.btnBackward.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackward.Location = new System.Drawing.Point(496, 293);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(100, 23);
            this.btnBackward.TabIndex = 11;
            this.btnBackward.Text = "Закрыть";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.MouseHover += new System.EventHandler(this.btnBackward_MouseHover);
            // 
            // lblVersionName
            // 
            this.lblVersionName.AutoSize = true;
            this.lblVersionName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVersionName.Location = new System.Drawing.Point(85, 176);
            this.lblVersionName.Name = "lblVersionName";
            this.lblVersionName.Size = new System.Drawing.Size(53, 19);
            this.lblVersionName.TabIndex = 10;
            this.lblVersionName.Text = "0.0.0.0";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVersion.Location = new System.Drawing.Point(12, 176);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(66, 19);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.Text = "Версия:";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProjectName.Location = new System.Drawing.Point(11, 139);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(269, 19);
            this.lblProjectName.TabIndex = 8;
            this.lblProjectName.Text = "Универсальная экспертная система";
            // 
            // lblDeveloperName
            // 
            this.lblDeveloperName.AutoSize = true;
            this.lblDeveloperName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDeveloperName.Location = new System.Drawing.Point(99, 106);
            this.lblDeveloperName.Name = "lblDeveloperName";
            this.lblDeveloperName.Size = new System.Drawing.Size(177, 15);
            this.lblDeveloperName.TabIndex = 4;
            this.lblDeveloperName.Text = "Зачитайлов Андрей Сергеевич";
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDeveloper.Location = new System.Drawing.Point(12, 107);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(74, 15);
            this.lblDeveloper.TabIndex = 3;
            this.lblDeveloper.Text = "Выполнили:";
            // 
            // lblLeaderName
            // 
            this.lblLeaderName.AutoSize = true;
            this.lblLeaderName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeaderName.Location = new System.Drawing.Point(96, 90);
            this.lblLeaderName.Name = "lblLeaderName";
            this.lblLeaderName.Size = new System.Drawing.Size(167, 15);
            this.lblLeaderName.TabIndex = 2;
            this.lblLeaderName.Text = "Сергеев Николай Евгеньевич";
            // 
            // picBoxSFU
            // 
            this.picBoxSFU.Location = new System.Drawing.Point(220, 12);
            this.picBoxSFU.Name = "picBoxSFU";
            this.picBoxSFU.Size = new System.Drawing.Size(100, 50);
            this.picBoxSFU.TabIndex = 1;
            this.picBoxSFU.TabStop = false;
            // 
            // lblLeader
            // 
            this.lblLeader.AutoSize = true;
            this.lblLeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeader.Location = new System.Drawing.Point(12, 90);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(85, 15);
            this.lblLeader.TabIndex = 0;
            this.lblLeader.Text = "Руководитель:";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 328);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.About_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.About_KeyDown);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSFU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox picBoxSFU;
        private System.Windows.Forms.Label lblLeader;
        private System.Windows.Forms.Label lblDeveloperName;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblLeaderName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblVersionName;
        private System.Windows.Forms.Button btnBackward;
    }
}