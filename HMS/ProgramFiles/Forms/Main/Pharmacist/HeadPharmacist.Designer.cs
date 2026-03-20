namespace HMS
{
    partial class HeadPharmacist
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
            this.ctrlHeadOfPharmacistSupPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOfPharmacistSupPanel();
            this.ctrlHeadPharmacist1 = new HMS.ProgramFiles.Panels.MainPanel.PharmacistPanel.ctrlHeadPharmacist();
            this.SuspendLayout();
            // 
            // ctrlHeadOfPharmacistSupPanel1
            // 
            this.ctrlHeadOfPharmacistSupPanel1.Location = new System.Drawing.Point(246, 12);
            this.ctrlHeadOfPharmacistSupPanel1.MaximumSize = new System.Drawing.Size(180, 401);
            this.ctrlHeadOfPharmacistSupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfPharmacistSupPanel1.Name = "ctrlHeadOfPharmacistSupPanel1";
            this.ctrlHeadOfPharmacistSupPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfPharmacistSupPanel1.TabIndex = 3;
            // 
            // ctrlHeadPharmacist1
            // 
            this.ctrlHeadPharmacist1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlHeadPharmacist1.Location = new System.Drawing.Point(0, 0);
            this.ctrlHeadPharmacist1.MaximumSize = new System.Drawing.Size(250, 1000);
            this.ctrlHeadPharmacist1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlHeadPharmacist1.Name = "ctrlHeadPharmacist1";
            this.ctrlHeadPharmacist1.Size = new System.Drawing.Size(250, 1000);
            this.ctrlHeadPharmacist1.TabIndex = 1;
            // 
            // HeadPharmacist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1887, 971);
            this.Controls.Add(this.ctrlHeadOfPharmacistSupPanel1);
            this.Controls.Add(this.ctrlHeadPharmacist1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1905, 1018);
            this.Name = "HeadPharmacist";
            this.Text = "HeadPharmacist";
            this.Load += new System.EventHandler(this.HeadPharmacist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.MainPanel.PharmacistPanel.ctrlHeadPharmacist ctrlHeadPharmacist1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOfPharmacistSupPanel ctrlHeadOfPharmacistSupPanel1;
    }
}