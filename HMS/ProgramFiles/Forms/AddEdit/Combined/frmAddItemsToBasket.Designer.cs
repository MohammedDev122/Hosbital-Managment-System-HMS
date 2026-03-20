namespace HMS
{
    partial class frmAddItemsToBasket
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
            this.ctrlBasketListForAdmin1 = new HMS.Lists.Admins.ctrlBasketListForAdmin();
            this.ctrlPrescripedMedListForPatientInPharmecy1 = new HMS.Lists.Others.ctrlPrescripedMedListForPatientInPharmecy();
            this.SuspendLayout();
            // 
            // ctrlBasketListForAdmin1
            // 
            this.ctrlBasketListForAdmin1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlBasketListForAdmin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlBasketListForAdmin1.Name = "ctrlBasketListForAdmin1";
            this.ctrlBasketListForAdmin1.Size = new System.Drawing.Size(1481, 310);
            this.ctrlBasketListForAdmin1.TabIndex = 1;
            this.ctrlBasketListForAdmin1.Load += new System.EventHandler(this.ctrlBasketListForAdmin1_Load);
            // 
            // ctrlPrescripedMedListForPatientInPharmecy1
            // 
            this.ctrlPrescripedMedListForPatientInPharmecy1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlPrescripedMedListForPatientInPharmecy1.Location = new System.Drawing.Point(0, 509);
            this.ctrlPrescripedMedListForPatientInPharmecy1.Name = "ctrlPrescripedMedListForPatientInPharmecy1";
            this.ctrlPrescripedMedListForPatientInPharmecy1.Size = new System.Drawing.Size(1481, 546);
            this.ctrlPrescripedMedListForPatientInPharmecy1.TabIndex = 0;
            // 
            // frmAddItemsToBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 1055);
            this.Controls.Add(this.ctrlBasketListForAdmin1);
            this.Controls.Add(this.ctrlPrescripedMedListForPatientInPharmecy1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddItemsToBasket";
            this.Text = "frmAddItemsToBasket";
            this.Load += new System.EventHandler(this.frmAddItemsToBasket_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Others.ctrlPrescripedMedListForPatientInPharmecy ctrlPrescripedMedListForPatientInPharmecy1;
        private Lists.Admins.ctrlBasketListForAdmin ctrlBasketListForAdmin1;
    }
}