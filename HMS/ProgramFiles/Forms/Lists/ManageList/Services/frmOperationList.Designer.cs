namespace HMS
{
    partial class frmOperationList
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
            this.ctrlOperationListViewForAdmins1 = new HMS.Lists.Admins.Procedure.ctrlOperationListViewForAdmins();
            this.SuspendLayout();
            // 
            // ctrlOperationListViewForAdmins1
            // 
            this.ctrlOperationListViewForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlOperationListViewForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlOperationListViewForAdmins1.Name = "ctrlOperationListViewForAdmins1";
            this.ctrlOperationListViewForAdmins1.Size = new System.Drawing.Size(1483, 774);
            this.ctrlOperationListViewForAdmins1.TabIndex = 0;
            this.ctrlOperationListViewForAdmins1.Load += new System.EventHandler(this.ctrlOperationListViewForAdmins1_Load);
            // 
            // frmOperationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 774);
            this.Controls.Add(this.ctrlOperationListViewForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOperationList";
            this.Text = "frmOperationList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.Procedure.ctrlOperationListViewForAdmins ctrlOperationListViewForAdmins1;
    }
}