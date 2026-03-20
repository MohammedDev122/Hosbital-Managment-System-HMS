namespace HMS
{
    partial class frmAddEditOperation
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
            this.ctrlAddEditOperation1 = new HMS.Add_Edit.AddEditServices.ctrlAddEditOperation();
            this.SuspendLayout();
            // 
            // ctrlAddEditOperation1
            // 
            this.ctrlAddEditOperation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditOperation1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditOperation1.Name = "ctrlAddEditOperation1";
            this.ctrlAddEditOperation1.Size = new System.Drawing.Size(1327, 599);
            this.ctrlAddEditOperation1.TabIndex = 0;
            this.ctrlAddEditOperation1.Load += new System.EventHandler(this.ctrlAddEditOperation1_Load);
            // 
            // frmAddEditOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 599);
            this.Controls.Add(this.ctrlAddEditOperation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditOperation";
            this.Text = "frmAddEditOperation";
            this.Load += new System.EventHandler(this.frmAddEditOperation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditServices.ctrlAddEditOperation ctrlAddEditOperation1;
    }
}