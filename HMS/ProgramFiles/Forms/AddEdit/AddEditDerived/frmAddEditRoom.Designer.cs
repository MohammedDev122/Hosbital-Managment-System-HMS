namespace HMS
{
    partial class frmAddEditRoom
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
            this.ctrlAddEditRoom1 = new HMS.Add_Edit.ctrlAddEditRoom();
            this.SuspendLayout();
            // 
            // ctrlAddEditRoom1
            // 
            this.ctrlAddEditRoom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditRoom1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditRoom1.Name = "ctrlAddEditRoom1";
            this.ctrlAddEditRoom1.Size = new System.Drawing.Size(1352, 450);
            this.ctrlAddEditRoom1.TabIndex = 0;
            this.ctrlAddEditRoom1.Load += new System.EventHandler(this.ctrlAddEditRoom1_Load);
            // 
            // frmAddEditRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 450);
            this.Controls.Add(this.ctrlAddEditRoom1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditRoom";
            this.Text = "frmAddEditRoom";
            this.Load += new System.EventHandler(this.frmAddEditRoom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.ctrlAddEditRoom ctrlAddEditRoom1;
    }
}