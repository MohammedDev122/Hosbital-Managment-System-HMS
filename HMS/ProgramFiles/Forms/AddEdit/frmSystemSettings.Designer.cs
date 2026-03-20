namespace HMS
{
    partial class frmSystemSettings
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
            this.editSystemSettings1 = new HMS.Add_Edit.EditSystemSettings();
            this.SuspendLayout();
            // 
            // editSystemSettings1
            // 
            this.editSystemSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editSystemSettings1.Location = new System.Drawing.Point(0, 0);
            this.editSystemSettings1.Name = "editSystemSettings1";
            this.editSystemSettings1.Size = new System.Drawing.Size(1401, 469);
            this.editSystemSettings1.TabIndex = 0;
            this.editSystemSettings1.Load += new System.EventHandler(this.editSystemSettings1_Load);
            // 
            // frmSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 469);
            this.Controls.Add(this.editSystemSettings1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSystemSettings";
            this.Text = "frmSystemSettings";
            this.Load += new System.EventHandler(this.frmSystemSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.EditSystemSettings editSystemSettings1;
    }
}