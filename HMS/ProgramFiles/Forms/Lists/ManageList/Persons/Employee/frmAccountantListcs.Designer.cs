namespace HMS
{
    partial class frmAccountantListcs
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
            this.ctrlAccountantListViewForAdmin1 = new HMS.Lists.Admins.ctrlAccountantListViewForAdmin();
            this.SuspendLayout();
            // 
            // ctrlAccountantListViewForAdmin1
            // 
            this.ctrlAccountantListViewForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAccountantListViewForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAccountantListViewForAdmin1.Name = "ctrlAccountantListViewForAdmin1";
            this.ctrlAccountantListViewForAdmin1.Size = new System.Drawing.Size(1387, 514);
            this.ctrlAccountantListViewForAdmin1.TabIndex = 0;
            this.ctrlAccountantListViewForAdmin1.Load += new System.EventHandler(this.ctrlAccountantListViewForAdmin1_Load);
            // 
            // frmAccountantListcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 514);
            this.Controls.Add(this.ctrlAccountantListViewForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAccountantListcs";
            this.Text = "frmAccountantListcs";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlAccountantListViewForAdmin ctrlAccountantListViewForAdmin1;
    }
}