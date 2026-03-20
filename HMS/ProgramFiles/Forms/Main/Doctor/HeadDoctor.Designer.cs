namespace HMS
{
    partial class HeadDoctor
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
            this.ctrlHeadOFDoctorsSubPanel2 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOFDoctorsSubPanel();
            this.ctrlHeadDoctor1 = new HMS.ProgramFiles.Panels.MainPanel.ctrlHeadDoctor();
            this.SuspendLayout();
            // 
            // ctrlHeadOFDoctorsSubPanel2
            // 
            this.ctrlHeadOFDoctorsSubPanel2.Location = new System.Drawing.Point(225, 77);
            this.ctrlHeadOFDoctorsSubPanel2.MaximumSize = new System.Drawing.Size(240, 401);
            this.ctrlHeadOFDoctorsSubPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOFDoctorsSubPanel2.Name = "ctrlHeadOFDoctorsSubPanel2";
            this.ctrlHeadOFDoctorsSubPanel2.Size = new System.Drawing.Size(240, 401);
            this.ctrlHeadOFDoctorsSubPanel2.TabIndex = 5;
            // 
            // ctrlHeadDoctor1
            // 
            this.ctrlHeadDoctor1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlHeadDoctor1.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeadDoctor1.MaximumSize = new System.Drawing.Size(230, 1000);
            this.ctrlHeadDoctor1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlHeadDoctor1.Name = "ctrlHeadDoctor1";
            this.ctrlHeadDoctor1.Size = new System.Drawing.Size(230, 1000);
            this.ctrlHeadDoctor1.TabIndex = 1;
            // 
            // HeadDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 953);
            this.Controls.Add(this.ctrlHeadOFDoctorsSubPanel2);
            this.Controls.Add(this.ctrlHeadDoctor1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 962);
            this.Name = "HeadDoctor";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ProgramFiles.Panels.MainPanel.ctrlHeadDoctor ctrlHeadDoctor1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOFDoctorsSubPanel ctrlHeadOFDoctorsSubPanel2;
    }
}