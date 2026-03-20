namespace HMS
{
    partial class frmCountriesList
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
            this.ctrlCountriesListForAdmins1 = new HMS.Lists.Admins.ctrlCountriesListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlCountriesListForAdmins1
            // 
            this.ctrlCountriesListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCountriesListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlCountriesListForAdmins1.Name = "ctrlCountriesListForAdmins1";
            this.ctrlCountriesListForAdmins1.Size = new System.Drawing.Size(1378, 492);
            this.ctrlCountriesListForAdmins1.TabIndex = 0;
            this.ctrlCountriesListForAdmins1.Load += new System.EventHandler(this.ctrlCountriesListForAdmins1_Load);
            // 
            // frmCountriesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 492);
            this.Controls.Add(this.ctrlCountriesListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCountriesList";
            this.Text = "frmCountriesList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlCountriesListForAdmins ctrlCountriesListForAdmins1;
    }
}