namespace HMS
{
    partial class frmAddEditServiceTypes
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
            this.ctrlEditServicesTypes1 = new HMS.Add_Edit.ctrlEditServicesTypes();
            this.SuspendLayout();
            // 
            // ctrlEditServicesTypes1
            // 
            this.ctrlEditServicesTypes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEditServicesTypes1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEditServicesTypes1.Name = "ctrlEditServicesTypes1";
            this.ctrlEditServicesTypes1.Size = new System.Drawing.Size(1423, 450);
            this.ctrlEditServicesTypes1.TabIndex = 0;
            this.ctrlEditServicesTypes1.Load += new System.EventHandler(this.ctrlEditServicesTypes1_Load);
            // 
            // frmAddEditServiceTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 450);
            this.Controls.Add(this.ctrlEditServicesTypes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditServiceTypes";
            this.Text = "frmAddEditServiceTypes";
            this.Load += new System.EventHandler(this.frmAddEditServiceTypes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.ctrlEditServicesTypes ctrlEditServicesTypes1;
    }
}