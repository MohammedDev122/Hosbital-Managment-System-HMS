namespace HMS
{
    partial class frmDepartmentList
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
            this.ctrlDepartmentListForAdmins1 = new HMS.Lists.Admins.ctrlDepartmentListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlDepartmentListForAdmins1
            // 
            this.ctrlDepartmentListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDepartmentListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDepartmentListForAdmins1.Name = "ctrlDepartmentListForAdmins1";
            this.ctrlDepartmentListForAdmins1.Size = new System.Drawing.Size(1378, 479);
            this.ctrlDepartmentListForAdmins1.TabIndex = 0;
            this.ctrlDepartmentListForAdmins1.Load += new System.EventHandler(this.ctrlDepartmentListForAdmins1_Load);
            // 
            // frmDepartmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 479);
            this.Controls.Add(this.ctrlDepartmentListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDepartmentList";
            this.Text = "frmDepartmentList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlDepartmentListForAdmins ctrlDepartmentListForAdmins1;
    }
}