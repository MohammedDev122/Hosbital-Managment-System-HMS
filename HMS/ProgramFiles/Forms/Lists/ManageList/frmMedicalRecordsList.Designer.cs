namespace HMS
{
    partial class frmMedicalRecordsList
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
            this.ctrlMedicalRecordListForDoctor1 = new HMS.Lists.Owners.ctrlMedicalRecordListForDoctor();
            this.SuspendLayout();
            // 
            // ctrlMedicalRecordListForDoctor1
            // 
            this.ctrlMedicalRecordListForDoctor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlMedicalRecordListForDoctor1.Location = new System.Drawing.Point(0, 0);
            this.ctrlMedicalRecordListForDoctor1.Name = "ctrlMedicalRecordListForDoctor1";
            this.ctrlMedicalRecordListForDoctor1.Size = new System.Drawing.Size(1295, 521);
            this.ctrlMedicalRecordListForDoctor1.TabIndex = 0;
            this.ctrlMedicalRecordListForDoctor1.Load += new System.EventHandler(this.ctrlMedicalRecordListForDoctor1_Load);
            // 
            // frmMedicalRecordsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 521);
            this.Controls.Add(this.ctrlMedicalRecordListForDoctor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMedicalRecordsList";
            this.Text = "frmMedicalRecordsList";
            this.Load += new System.EventHandler(this.frmMedicalRecordsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.ctrlMedicalRecordListForDoctor ctrlMedicalRecordListForDoctor1;
    }
}