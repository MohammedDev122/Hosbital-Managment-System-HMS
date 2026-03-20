namespace HMS
{
    partial class frmDoctorSelectList
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
            this.ctrlDoctorListViewForOthers1 = new HMS.Lists.ctrlDoctorListViewForOthers();
            this.SuspendLayout();
            // 
            // ctrlDoctorListViewForOthers1
            // 
            this.ctrlDoctorListViewForOthers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDoctorListViewForOthers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDoctorListViewForOthers1.Name = "ctrlDoctorListViewForOthers1";
            this.ctrlDoctorListViewForOthers1.Size = new System.Drawing.Size(1355, 450);
            this.ctrlDoctorListViewForOthers1.TabIndex = 0;
            this.ctrlDoctorListViewForOthers1.OnSelectedID += new System.EventHandler<int>(this.ctrlDoctorListViewForOthers1_OnSelectedID);
            this.ctrlDoctorListViewForOthers1.Load += new System.EventHandler(this.ctrlDoctorListViewForOthers1_Load);
            // 
            // frmDoctorSelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 450);
            this.Controls.Add(this.ctrlDoctorListViewForOthers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoctorSelectList";
            this.Text = "frmDoctorSelectList";
            this.Load += new System.EventHandler(this.frmDoctorSelectList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.ctrlDoctorListViewForOthers ctrlDoctorListViewForOthers1;
    }
}