namespace HMS
{
    partial class frmServicesTypesList
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
            this.ctrlServicesTypesListForAdmins1 = new HMS.Lists.Admins.ctrlServicesTypesListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlServicesTypesListForAdmins1
            // 
            this.ctrlServicesTypesListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlServicesTypesListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlServicesTypesListForAdmins1.Name = "ctrlServicesTypesListForAdmins1";
            this.ctrlServicesTypesListForAdmins1.Size = new System.Drawing.Size(1350, 589);
            this.ctrlServicesTypesListForAdmins1.TabIndex = 0;
            this.ctrlServicesTypesListForAdmins1.Load += new System.EventHandler(this.ctrlServicesTypesListForAdmins1_Load);
            // 
            // frmServicesTypesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 589);
            this.Controls.Add(this.ctrlServicesTypesListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmServicesTypesList";
            this.Text = "frmServicesTypesList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlServicesTypesListForAdmins ctrlServicesTypesListForAdmins1;
    }
}