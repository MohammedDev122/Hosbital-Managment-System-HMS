namespace HMS
{
    partial class frmAddEditLogin
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
            this.ctrlAddEditLogin1 = new HMS.Add_Edit.ctrlAddEditLogin();
            this.SuspendLayout();
            // 
            // ctrlAddEditLogin1
            // 
            this.ctrlAddEditLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditLogin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditLogin1.Name = "ctrlAddEditLogin1";
            this.ctrlAddEditLogin1.Size = new System.Drawing.Size(1381, 575);
            this.ctrlAddEditLogin1.TabIndex = 0;
            this.ctrlAddEditLogin1.Load += new System.EventHandler(this.ctrlAddEditLogin1_Load);
            // 
            // frmAddEditLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 575);
            this.Controls.Add(this.ctrlAddEditLogin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditLogin";
            this.Text = "frmAddEditLogin";
            this.Load += new System.EventHandler(this.frmAddEditLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.ctrlAddEditLogin ctrlAddEditLogin1;
    }
}