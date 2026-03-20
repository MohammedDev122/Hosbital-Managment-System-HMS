namespace HMS
{
    partial class frmOperationListForMember
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
            this.ctrlOperationListViewForStaffMember1 = new HMS.Lists.Owners.Employee.ctrlOperationListViewForStaffMember();
            this.SuspendLayout();
            // 
            // ctrlOperationListViewForStaffMember1
            // 
            this.ctrlOperationListViewForStaffMember1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOperationListViewForStaffMember1.Location = new System.Drawing.Point(0, 0);
            this.ctrlOperationListViewForStaffMember1.Name = "ctrlOperationListViewForStaffMember1";
            this.ctrlOperationListViewForStaffMember1.Size = new System.Drawing.Size(1440, 510);
            this.ctrlOperationListViewForStaffMember1.TabIndex = 0;
            this.ctrlOperationListViewForStaffMember1.Load += new System.EventHandler(this.ctrlOperationListViewForStaffMember1_Load);
            // 
            // frmOperationListForMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 510);
            this.Controls.Add(this.ctrlOperationListViewForStaffMember1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOperationListForMember";
            this.Text = "frmOperationListForMember";
            this.Load += new System.EventHandler(this.frmOperationListForMember_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Owners.Employee.ctrlOperationListViewForStaffMember ctrlOperationListViewForStaffMember1;
    }
}