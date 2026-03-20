namespace HMS
{
    partial class frmPaymentLists
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
            this.ctrlPaymentListForAdmins1 = new HMS.Lists.Admins.ctrlPaymentListForAdmins();
            this.SuspendLayout();
            // 
            // ctrlPaymentListForAdmins1
            // 
            this.ctrlPaymentListForAdmins1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPaymentListForAdmins1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPaymentListForAdmins1.Name = "ctrlPaymentListForAdmins1";
            this.ctrlPaymentListForAdmins1.Size = new System.Drawing.Size(1344, 589);
            this.ctrlPaymentListForAdmins1.TabIndex = 0;
            this.ctrlPaymentListForAdmins1.Load += new System.EventHandler(this.ctrlPaymentListForAdmins1_Load);
            // 
            // frmPaymentLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 589);
            this.Controls.Add(this.ctrlPaymentListForAdmins1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPaymentLists";
            this.Text = "frmPaymentLists";
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Admins.ctrlPaymentListForAdmins ctrlPaymentListForAdmins1;
    }
}