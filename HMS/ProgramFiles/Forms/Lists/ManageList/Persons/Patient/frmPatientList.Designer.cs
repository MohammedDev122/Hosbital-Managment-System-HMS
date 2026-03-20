namespace HMS
{
    partial class frmPatientList
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
            this.ctrlPatientListViewForAdmin1 = new HMS.Lists.Admins.Persons.Patient.ctrlPatientListViewForAdmin();
            this.SuspendLayout();
            // 
            // ctrlPatientListViewForAdmin1
            // 
            this.ctrlPatientListViewForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPatientListViewForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPatientListViewForAdmin1.Name = "ctrlPatientListViewForAdmin1";
            this.ctrlPatientListViewForAdmin1.Size = new System.Drawing.Size(1373, 508);
            this.ctrlPatientListViewForAdmin1.TabIndex = 0;
            this.ctrlPatientListViewForAdmin1.Load += new System.EventHandler(this.ctrlPatientListViewForAdmin1_Load);
            // 
            // frmPatientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 508);
            this.Controls.Add(this.ctrlPatientListViewForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientList";
            this.Text = "frmPatientList";
            this.Load += new System.EventHandler(this.frmPatientList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.Persons.Patient.ctrlPatientListViewForAdmin ctrlPatientListViewForAdmin1;
    }
}