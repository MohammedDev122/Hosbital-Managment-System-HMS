namespace HMS
{
    partial class frmSpecilizationList
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
            this.ctrlSpecilizationListForAdmins1 = new HMS.Lists.Admins.ctrlSpecilizationListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlSpecilizationListForAdmins1
            // 
            this.ctrlSpecilizationListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSpecilizationListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlSpecilizationListForAdmins1.Name = "ctrlSpecilizationListForAdmins1";
            this.ctrlSpecilizationListForAdmins1.Size = new System.Drawing.Size(1399, 513);
            this.ctrlSpecilizationListForAdmins1.TabIndex = 0;
            this.ctrlSpecilizationListForAdmins1.Load += new System.EventHandler(this.ctrlSpecilizationListForAdmins1_Load);
            // 
            // frmSpecilizationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 513);
            this.Controls.Add(this.ctrlSpecilizationListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSpecilizationList";
            this.Text = "frmSpecilizationList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlSpecilizationListForAdmins ctrlSpecilizationListForAdmins1;
    }
}