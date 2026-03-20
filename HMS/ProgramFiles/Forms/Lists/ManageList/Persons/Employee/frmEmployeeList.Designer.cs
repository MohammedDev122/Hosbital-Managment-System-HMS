namespace HMS
{
    partial class frmEmployeeList
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
            this.ctrlEmployeeListForAdmins1 = new HMS.Lists.Admins.Persons.Employee.ctrlEmployeeListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlEmployeeListForAdmins1
            // 
            this.ctrlEmployeeListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEmployeeListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEmployeeListForAdmins1.Name = "ctrlEmployeeListForAdmins1";
            this.ctrlEmployeeListForAdmins1.Size = new System.Drawing.Size(1386, 901);
            this.ctrlEmployeeListForAdmins1.TabIndex = 0;
            this.ctrlEmployeeListForAdmins1.Load += new System.EventHandler(this.ctrlEmployeeListForAdmins1_Load);
            // 
            // frmEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 901);
            this.Controls.Add(this.ctrlEmployeeListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployeeList";
            this.Text = "frmEmployeeList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.Persons.Employee.ctrlEmployeeListForAdmins ctrlEmployeeListForAdmins1;
    }
}