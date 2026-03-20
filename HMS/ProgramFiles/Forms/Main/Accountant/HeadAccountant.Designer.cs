namespace HMS
{
    partial class HeadAccountant
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
            this.ctrlHeadOfAccountantSupPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOfAccountantSupPanel();
            this.ctrlHeadAccountant1 = new HMS.ProgramFiles.Panels.MainPanel.AccountantPanel.ctrlHeadAccountant();
            this.SuspendLayout();
            // 
            // ctrlHeadOfAccountantSupPanel1
            // 
            this.ctrlHeadOfAccountantSupPanel1.Location = new System.Drawing.Point(225, 50);
            this.ctrlHeadOfAccountantSupPanel1.MaximumSize = new System.Drawing.Size(180, 401);
            this.ctrlHeadOfAccountantSupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfAccountantSupPanel1.Name = "ctrlHeadOfAccountantSupPanel1";
            this.ctrlHeadOfAccountantSupPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfAccountantSupPanel1.TabIndex = 2;
            // 
            // ctrlHeadAccountant1
            // 
            this.ctrlHeadAccountant1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlHeadAccountant1.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeadAccountant1.MaximumSize = new System.Drawing.Size(230, 1000);
            this.ctrlHeadAccountant1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlHeadAccountant1.Name = "ctrlHeadAccountant1";
            this.ctrlHeadAccountant1.Size = new System.Drawing.Size(230, 1000);
            this.ctrlHeadAccountant1.TabIndex = 1;
            // 
            // HeadAccountant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 915);
            this.Controls.Add(this.ctrlHeadOfAccountantSupPanel1);
            this.Controls.Add(this.ctrlHeadAccountant1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 962);
            this.Name = "HeadAccountant";
            this.Text = "HeadAccountant";
            this.Load += new System.EventHandler(this.HeadAccountant_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.MainPanel.AccountantPanel.ctrlHeadAccountant ctrlHeadAccountant1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOfAccountantSupPanel ctrlHeadOfAccountantSupPanel1;
    }
}