namespace HMS
{
    partial class frmPharmacistList
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
            this.ctrlPharmacistListViewForAdmin1 = new HMS.Lists.Admins.ctrlPharmacistListViewForAdmin();
            this.SuspendLayout();
            // 
            // ctrlPharmacistListViewForAdmin1
            // 
            this.ctrlPharmacistListViewForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPharmacistListViewForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPharmacistListViewForAdmin1.Name = "ctrlPharmacistListViewForAdmin1";
            this.ctrlPharmacistListViewForAdmin1.Size = new System.Drawing.Size(1476, 663);
            this.ctrlPharmacistListViewForAdmin1.TabIndex = 0;
            this.ctrlPharmacistListViewForAdmin1.Load += new System.EventHandler(this.ctrlPharmacistListViewForAdmin1_Load);
            // 
            // frmPharmacistList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 663);
            this.Controls.Add(this.ctrlPharmacistListViewForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPharmacistList";
            this.Text = "frmPharmacistList";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlPharmacistListViewForAdmin ctrlPharmacistListViewForAdmin1;
    }
}