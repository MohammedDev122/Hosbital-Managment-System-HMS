namespace HMS
{
    partial class frmLoginsList
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
            this.ctrlLoginsListForAdmin1 = new HMS.Lists.Admins.ctrlLoginsListForAdmin();
            this.SuspendLayout();
            // 
            // ctrlLoginsListForAdmin1
            // 
            this.ctrlLoginsListForAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLoginsListForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLoginsListForAdmin1.Name = "ctrlLoginsListForAdmin1";
            this.ctrlLoginsListForAdmin1.Size = new System.Drawing.Size(1372, 484);
            this.ctrlLoginsListForAdmin1.TabIndex = 0;
            this.ctrlLoginsListForAdmin1.Load += new System.EventHandler(this.ctrlLoginsListForAdmin1_Load);
            // 
            // frmLoginsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 484);
            this.Controls.Add(this.ctrlLoginsListForAdmin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginsList";
            this.Text = "frmLoginsList";
            this.Load += new System.EventHandler(this.frmLoginsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlLoginsListForAdmin ctrlLoginsListForAdmin1;
    }
}