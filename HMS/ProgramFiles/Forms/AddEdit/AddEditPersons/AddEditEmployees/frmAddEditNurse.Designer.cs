namespace HMS
{
    partial class frmAddEditNurse
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
            this.ctrlAddEditNurse1 = new HMS.Add_Edit.AddEditPerson.AddEditEmployees.ctrlAddEditNurse();
            this.SuspendLayout();
            // 
            // ctrlAddEditNurse1
            // 
            this.ctrlAddEditNurse1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditNurse1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditNurse1.Name = "ctrlAddEditNurse1";
            this.ctrlAddEditNurse1.Size = new System.Drawing.Size(1456, 663);
            this.ctrlAddEditNurse1.TabIndex = 0;
            this.ctrlAddEditNurse1.Load += new System.EventHandler(this.ctrlAddEditNurse1_Load);
            // 
            // frmAddEditNurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 663);
            this.Controls.Add(this.ctrlAddEditNurse1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditNurse";
            this.Text = "frmAddEditNurse";
            this.Load += new System.EventHandler(this.frmAddEditNurse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditPerson.AddEditEmployees.ctrlAddEditNurse ctrlAddEditNurse1;
    }
}