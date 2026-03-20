namespace HMS
{
    partial class frmMedicationList
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
            this.ctrlMedicationListForAdmins1 = new HMS.Lists.ctrlMedicationListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlMedicationListForAdmins1
            // 
            this.ctrlMedicationListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMedicationListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMedicationListForAdmins1.Name = "ctrlMedicationListForAdmins1";
            this.ctrlMedicationListForAdmins1.Size = new System.Drawing.Size(1376, 512);
            this.ctrlMedicationListForAdmins1.TabIndex = 0;
            this.ctrlMedicationListForAdmins1.Load += new System.EventHandler(this.ctrlMedicationListForAdmins1_Load);
            // 
            // frmMedicationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 512);
            this.Controls.Add(this.ctrlMedicationListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMedicationList";
            this.Text = "frmMedicationList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.ctrlMedicationListForAdmins ctrlMedicationListForAdmins1;
    }
}