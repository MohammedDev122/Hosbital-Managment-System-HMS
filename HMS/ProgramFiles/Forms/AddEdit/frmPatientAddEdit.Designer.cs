namespace HMS
{
    partial class frmPatientAddEdit
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
            this.ctrlAddEditPatient1 = new HMS.Add_Edit.AddEditPerson.AddEditPatient.ctrlAddEditPatient();
            this.SuspendLayout();
            // 
            // ctrlAddEditPatient1
            // 
            this.ctrlAddEditPatient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPatient1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPatient1.Name = "ctrlAddEditPatient1";
            this.ctrlAddEditPatient1.Size = new System.Drawing.Size(1494, 615);
            this.ctrlAddEditPatient1.TabIndex = 0;
            this.ctrlAddEditPatient1.Load += new System.EventHandler(this.ctrlAddEditPatient1_Load);
            // 
            // frmPatientAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 615);
            this.Controls.Add(this.ctrlAddEditPatient1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientAddEdit";
            this.Text = "frmPatientAddEdit";
            this.Load += new System.EventHandler(this.frmPatientAddEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditPerson.AddEditPatient.ctrlAddEditPatient ctrlAddEditPatient1;
    }
}