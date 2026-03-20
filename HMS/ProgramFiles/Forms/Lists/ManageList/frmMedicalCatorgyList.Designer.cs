namespace HMS
{
    partial class frmMedicalCatorgyList
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
            this.ctrlMedicalCatorgyListForAdmin1 = new HMS.Lists.Admins.Persons.ctrlMedicalCatorgyListForAdmin();
            this.SuspendLayout();
            // 
            // ctrlMedicalCatorgyListForAdmin1
            // 
            this.ctrlMedicalCatorgyListForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMedicalCatorgyListForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMedicalCatorgyListForAdmin1.Name = "ctrlMedicalCatorgyListForAdmin1";
            this.ctrlMedicalCatorgyListForAdmin1.Size = new System.Drawing.Size(1382, 586);
            this.ctrlMedicalCatorgyListForAdmin1.TabIndex = 0;
            this.ctrlMedicalCatorgyListForAdmin1.Load += new System.EventHandler(this.ctrlMedicalCatorgyListForAdmin1_Load);
            // 
            // frmMedicalCatorgyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 586);
            this.Controls.Add(this.ctrlMedicalCatorgyListForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMedicalCatorgyList";
            this.Text = "frmMedicalCatorgyList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.Persons.ctrlMedicalCatorgyListForAdmin ctrlMedicalCatorgyListForAdmin1;
    }
}