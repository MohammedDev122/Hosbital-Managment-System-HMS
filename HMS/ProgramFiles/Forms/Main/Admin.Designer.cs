namespace HMS
{
    partial class Admin
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
            this.ctrlAdminPanel1 = new HMS.ProgramFiles.Panels.ctrlAdminPanel();
            this.ctrlHeadOfAccountantSupPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOfAccountantSupPanel();
            this.ctrlHeadOFDoctorsSubPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOFDoctorsSubPanel();
            this.ctrlHeadOfPharmacistSupPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOfPharmacistSupPanel();
            this.ctrlHeadOfNurseSupPanel1 = new HMS.ProgramFiles.Panels.SubPanels.ctrlHeadOfNurseSupPanel();
            this.SuspendLayout();
            // 
            // ctrlAdminPanel1
            // 
            this.ctrlAdminPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlAdminPanel1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAdminPanel1.MaximumSize = new System.Drawing.Size(290, 1000);
            this.ctrlAdminPanel1.MinimumSize = new System.Drawing.Size(50, 1000);
            this.ctrlAdminPanel1.Name = "ctrlAdminPanel1";
            this.ctrlAdminPanel1.Size = new System.Drawing.Size(290, 1000);
            this.ctrlAdminPanel1.TabIndex = 1;
            // 
            // ctrlHeadOfAccountantSupPanel1
            // 
            this.ctrlHeadOfAccountantSupPanel1.Location = new System.Drawing.Point(287, 86);
            this.ctrlHeadOfAccountantSupPanel1.MaximumSize = new System.Drawing.Size(180, 401);
            this.ctrlHeadOfAccountantSupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfAccountantSupPanel1.Name = "ctrlHeadOfAccountantSupPanel1";
            this.ctrlHeadOfAccountantSupPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfAccountantSupPanel1.TabIndex = 2;
            // 
            // ctrlHeadOFDoctorsSubPanel1
            // 
            this.ctrlHeadOFDoctorsSubPanel1.Location = new System.Drawing.Point(287, 164);
            this.ctrlHeadOFDoctorsSubPanel1.MaximumSize = new System.Drawing.Size(180, 401);
            this.ctrlHeadOFDoctorsSubPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOFDoctorsSubPanel1.Name = "ctrlHeadOFDoctorsSubPanel1";
            this.ctrlHeadOFDoctorsSubPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOFDoctorsSubPanel1.TabIndex = 3;
            // 
            // ctrlHeadOfPharmacistSupPanel1
            // 
            this.ctrlHeadOfPharmacistSupPanel1.Location = new System.Drawing.Point(287, 112);
            this.ctrlHeadOfPharmacistSupPanel1.MaximumSize = new System.Drawing.Size(180, 401);
            this.ctrlHeadOfPharmacistSupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfPharmacistSupPanel1.Name = "ctrlHeadOfPharmacistSupPanel1";
            this.ctrlHeadOfPharmacistSupPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfPharmacistSupPanel1.TabIndex = 4;
            // 
            // ctrlHeadOfNurseSupPanel1
            // 
            this.ctrlHeadOfNurseSupPanel1.Location = new System.Drawing.Point(287, 222);
            this.ctrlHeadOfNurseSupPanel1.MaximumSize = new System.Drawing.Size(250, 401);
            this.ctrlHeadOfNurseSupPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfNurseSupPanel1.Name = "ctrlHeadOfNurseSupPanel1";
            this.ctrlHeadOfNurseSupPanel1.Size = new System.Drawing.Size(1, 1);
            this.ctrlHeadOfNurseSupPanel1.TabIndex = 5;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 577);
            this.Controls.Add(this.ctrlHeadOfNurseSupPanel1);
            this.Controls.Add(this.ctrlHeadOfPharmacistSupPanel1);
            this.Controls.Add(this.ctrlHeadOFDoctorsSubPanel1);
            this.Controls.Add(this.ctrlHeadOfAccountantSupPanel1);
            this.Controls.Add(this.ctrlAdminPanel1);
            this.IsMdiContainer = true;
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgramFiles.Panels.ctrlAdminPanel ctrlAdminPanel1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOfAccountantSupPanel ctrlHeadOfAccountantSupPanel1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOFDoctorsSubPanel ctrlHeadOFDoctorsSubPanel1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOfPharmacistSupPanel ctrlHeadOfPharmacistSupPanel1;
        private ProgramFiles.Panels.SubPanels.ctrlHeadOfNurseSupPanel ctrlHeadOfNurseSupPanel1;
    }
}