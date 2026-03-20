namespace HMS
{
    partial class frmPharmecyRecordList
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
            this.ctrlPharmaceyRecordListForAdmin1 = new HMS.Lists.Admins.ctrlPharmaceyRecordListForAdmin();
            this.SuspendLayout();
            // 
            // ctrlPharmaceyRecordListForAdmin1
            // 
            this.ctrlPharmaceyRecordListForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPharmaceyRecordListForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPharmaceyRecordListForAdmin1.Name = "ctrlPharmaceyRecordListForAdmin1";
            this.ctrlPharmaceyRecordListForAdmin1.Size = new System.Drawing.Size(1381, 544);
            this.ctrlPharmaceyRecordListForAdmin1.TabIndex = 0;
            this.ctrlPharmaceyRecordListForAdmin1.Load += new System.EventHandler(this.ctrlPharmaceyRecordListForAdmin1_Load);
            // 
            // frmPharmecyRecordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 544);
            this.Controls.Add(this.ctrlPharmaceyRecordListForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPharmecyRecordList";
            this.Text = "frmPharmecyRecordList";
            this.Load += new System.EventHandler(this.frmPharmecyRecordList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlPharmaceyRecordListForAdmin ctrlPharmaceyRecordListForAdmin1;
    }
}