namespace HMS
{
    partial class frmAddEditStaffMember
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
            this.ctrlEmployeeListViewForOthers1 = new HMS.Lists.Others.Employee.ctrlEmployeeListViewForOthers();
            this.ctrlStaffForOperation1 = new HMS.Lists.Owners.ctrlStaffForOperation();
            this.SuspendLayout();
            // 
            // ctrlEmployeeListViewForOthers1
            // 
            this.ctrlEmployeeListViewForOthers1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlEmployeeListViewForOthers1.Location = new System.Drawing.Point(0, 522);
            this.ctrlEmployeeListViewForOthers1.Name = "ctrlEmployeeListViewForOthers1";
            this.ctrlEmployeeListViewForOthers1.Size = new System.Drawing.Size(1392, 418);
            this.ctrlEmployeeListViewForOthers1.TabIndex = 1;
            // 
            // ctrlStaffForOperation1
            // 
            this.ctrlStaffForOperation1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlStaffForOperation1.Location = new System.Drawing.Point(0, 0);
            this.ctrlStaffForOperation1.Name = "ctrlStaffForOperation1";
            this.ctrlStaffForOperation1.Size = new System.Drawing.Size(1392, 516);
            this.ctrlStaffForOperation1.TabIndex = 0;
            this.ctrlStaffForOperation1.Load += new System.EventHandler(this.ctrlStaffForOperation1_Load);
            // 
            // frmAddEditStaffMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 940);
            this.Controls.Add(this.ctrlEmployeeListViewForOthers1);
            this.Controls.Add(this.ctrlStaffForOperation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditStaffMember";
            this.Text = "frmAddEditStaffMember";
            this.Load += new System.EventHandler(this.frmAddEditStaffMember_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.ctrlStaffForOperation ctrlStaffForOperation1;
        private Lists.Others.Employee.ctrlEmployeeListViewForOthers ctrlEmployeeListViewForOthers1;
    }
}