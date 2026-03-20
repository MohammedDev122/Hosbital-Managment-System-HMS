namespace HMS
{
    partial class frmAddEditPharmecyRecords
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
            this.ctrlAddEditPharmecyRecord1 = new HMS.Add_Edit.Medications.ctrlAddEditPharmecyRecord();
            this.SuspendLayout();
            // 
            // ctrlAddEditPharmecyRecord1
            // 
            this.ctrlAddEditPharmecyRecord1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPharmecyRecord1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPharmecyRecord1.Name = "ctrlAddEditPharmecyRecord1";
            this.ctrlAddEditPharmecyRecord1.Size = new System.Drawing.Size(1446, 506);
            this.ctrlAddEditPharmecyRecord1.TabIndex = 0;
            this.ctrlAddEditPharmecyRecord1.Load += new System.EventHandler(this.ctrlAddEditPharmecyRecord1_Load);
            // 
            // frmAddEditPharmecyRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 506);
            this.Controls.Add(this.ctrlAddEditPharmecyRecord1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditPharmecyRecords";
            this.Text = "frmAddEditPharmecyRecords";
            this.Load += new System.EventHandler(this.frmAddEditPharmecyRecords_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.Medications.ctrlAddEditPharmecyRecord ctrlAddEditPharmecyRecord1;
    }
}