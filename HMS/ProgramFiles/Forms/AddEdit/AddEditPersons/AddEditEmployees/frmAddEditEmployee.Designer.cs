namespace HMS
{
    partial class frmAddEditEmployee
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
            this.ctrlAddEditEmployee1 = new HMS.Add_Edit.ctrlAddEditEmployee();
            this.SuspendLayout();
            // 
            // ctrlAddEditEmployee1
            // 
            this.ctrlAddEditEmployee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditEmployee1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditEmployee1.Name = "ctrlAddEditEmployee1";
            this.ctrlAddEditEmployee1.Size = new System.Drawing.Size(1395, 548);
            this.ctrlAddEditEmployee1.TabIndex = 0;
            this.ctrlAddEditEmployee1.Load += new System.EventHandler(this.ctrlAddEditEmployee1_Load);
            // 
            // frmAddEditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 548);
            this.Controls.Add(this.ctrlAddEditEmployee1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditEmployee";
            this.Text = "frmAddEditEmployee";
            this.Load += new System.EventHandler(this.frmAddEditEmployee_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.ctrlAddEditEmployee ctrlAddEditEmployee1;
    }
}