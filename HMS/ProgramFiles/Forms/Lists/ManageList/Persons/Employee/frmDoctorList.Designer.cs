namespace HMS
{
    partial class frmDoctorList
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
            this.ctrlDoctorListViewForAdmin1 = new HMS.Lists.ctrlDoctorListViewForAdmin();
            this.SuspendLayout();
            // 
            // ctrlDoctorListViewForAdmin1
            // 
            this.ctrlDoctorListViewForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDoctorListViewForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDoctorListViewForAdmin1.Name = "ctrlDoctorListViewForAdmin1";
            this.ctrlDoctorListViewForAdmin1.Size = new System.Drawing.Size(1414, 547);
            this.ctrlDoctorListViewForAdmin1.TabIndex = 0;
            this.ctrlDoctorListViewForAdmin1.Load += new System.EventHandler(this.ctrlDoctorListViewForAdmin1_Load);
            // 
            // frmDoctorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 547);
            this.Controls.Add(this.ctrlDoctorListViewForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoctorList";
            this.Text = "frmDoctorList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.ctrlDoctorListViewForAdmin ctrlDoctorListViewForAdmin1;
    }
}