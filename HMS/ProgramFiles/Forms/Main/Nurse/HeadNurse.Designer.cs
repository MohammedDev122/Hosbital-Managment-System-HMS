namespace HMS
{
    partial class HeadNurse
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
            this.ctrlHeadNurse1 = new HMS.ProgramFiles.Panels.MainPanel.NursePanel.ctrlHeadNurse();
            this.ctrlHeadOfNurseSupPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOfNurseSupPanel();
            this.SuspendLayout();
            // 
            // ctrlHeadNurse1
            // 
            this.ctrlHeadNurse1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlHeadNurse1.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeadNurse1.MaximumSize = new System.Drawing.Size(230, 1000);
            this.ctrlHeadNurse1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlHeadNurse1.Name = "ctrlHeadNurse1";
            this.ctrlHeadNurse1.Size = new System.Drawing.Size(230, 1000);
            this.ctrlHeadNurse1.TabIndex = 4;
            // 
            // ctrlHeadOfNurseSupPanel1
            // 
            this.ctrlHeadOfNurseSupPanel1.Location = new System.Drawing.Point(231, 194);
            this.ctrlHeadOfNurseSupPanel1.MaximumSize = new System.Drawing.Size(250, 401);
            this.ctrlHeadOfNurseSupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfNurseSupPanel1.Name = "ctrlHeadOfNurseSupPanel1";
            this.ctrlHeadOfNurseSupPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfNurseSupPanel1.TabIndex = 1;
            // 
            // HeadNurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 915);
            this.Controls.Add(this.ctrlHeadNurse1);
            this.Controls.Add(this.ctrlHeadOfNurseSupPanel1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 962);
            this.Name = "HeadNurse";
            this.Text = "HeadNurse";
            this.Load += new System.EventHandler(this.HeadNurse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.SubPanels.ctrlHeadOfNurseSupPanel ctrlHeadOfNurseSupPanel1;
        private ProgramFiles.Panels.MainPanel.NursePanel.ctrlHeadNurse ctrlHeadNurse1;
    }
}