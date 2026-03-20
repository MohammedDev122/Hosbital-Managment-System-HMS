namespace HMS
{
    partial class frmPrescriptionList
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
            this.ctrlPrescriptionListForDoctor1 = new HMS.Lists.Admins.ctrlPrescriptionListForDoctor();
            this.SuspendLayout();
            // 
            // ctrlPrescriptionListForDoctor1
            // 
            this.ctrlPrescriptionListForDoctor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPrescriptionListForDoctor1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPrescriptionListForDoctor1.Name = "ctrlPrescriptionListForDoctor1";
            this.ctrlPrescriptionListForDoctor1.Size = new System.Drawing.Size(1327, 510);
            this.ctrlPrescriptionListForDoctor1.TabIndex = 0;
            this.ctrlPrescriptionListForDoctor1.Load += new System.EventHandler(this.ctrlPrescriptionListForDoctor1_Load);
            // 
            // frmPrescriptionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 510);
            this.Controls.Add(this.ctrlPrescriptionListForDoctor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrescriptionList";
            this.Text = "frmPrescription";
            this.Load += new System.EventHandler(this.frmPrescriptionList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlPrescriptionListForDoctor ctrlPrescriptionListForDoctor1;
    }
}