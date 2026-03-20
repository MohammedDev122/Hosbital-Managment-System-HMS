namespace HMS
{
    partial class frmNurseList
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
            this.ctrlNurseListForAdmins1 = new HMS.Lists.Admins.ctrlNurseListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlNurseListForAdmins1
            // 
            this.ctrlNurseListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlNurseListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlNurseListForAdmins1.Name = "ctrlNurseListForAdmins1";
            this.ctrlNurseListForAdmins1.Size = new System.Drawing.Size(1394, 533);
            this.ctrlNurseListForAdmins1.TabIndex = 0;
            this.ctrlNurseListForAdmins1.Load += new System.EventHandler(this.ctrlNurseListForAdmins1_Load);
            // 
            // frmNurseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 533);
            this.Controls.Add(this.ctrlNurseListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNurseList";
            this.Text = "frmNurseList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlNurseListForAdmins ctrlNurseListForAdmins1;
    }
}