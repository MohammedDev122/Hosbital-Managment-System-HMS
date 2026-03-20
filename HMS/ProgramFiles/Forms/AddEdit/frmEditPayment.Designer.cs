namespace HMS
{
    partial class frmEditPayment
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
            this.ctrlAddEditPayments1 = new HMS.Add_Edit.AddEditServices.ctrlAddEditPayments();
            this.SuspendLayout();
            // 
            // ctrlAddEditPayments1
            // 
            this.ctrlAddEditPayments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPayments1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPayments1.Name = "ctrlAddEditPayments1";
            this.ctrlAddEditPayments1.Size = new System.Drawing.Size(1408, 591);
            this.ctrlAddEditPayments1.TabIndex = 0;
            this.ctrlAddEditPayments1.Load += new System.EventHandler(this.ctrlAddEditPayments1_Load);
            // 
            // frmEditPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 591);
            this.Controls.Add(this.ctrlAddEditPayments1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditPayment";
            this.Text = "frmEditPayment";
            this.Load += new System.EventHandler(this.frmEditPayment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditServices.ctrlAddEditPayments ctrlAddEditPayments1;
    }
}