namespace HMS
{
    partial class frmAddEditSpecilization
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
            this.ctrlAddEditSpecilization1 = new HMS.Add_Edit.ctrlAddEditSpecilization();
            this.SuspendLayout();
            // 
            // ctrlAddEditSpecilization1
            // 
            this.ctrlAddEditSpecilization1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditSpecilization1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditSpecilization1.Name = "ctrlAddEditSpecilization1";
            this.ctrlAddEditSpecilization1.Size = new System.Drawing.Size(1456, 450);
            this.ctrlAddEditSpecilization1.TabIndex = 0;
            this.ctrlAddEditSpecilization1.Load += new System.EventHandler(this.ctrlAddEditSpecilization1_Load);
            // 
            // frmAddEditSpecilization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 450);
            this.Controls.Add(this.ctrlAddEditSpecilization1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditSpecilization";
            this.Text = "frmAddEditSpecilization";
            this.Load += new System.EventHandler(this.frmAddEditSpecilization_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.ctrlAddEditSpecilization ctrlAddEditSpecilization1;
    }
}