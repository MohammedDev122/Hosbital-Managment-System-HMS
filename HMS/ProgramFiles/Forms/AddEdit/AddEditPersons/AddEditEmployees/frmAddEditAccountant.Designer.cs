namespace HMS
{
    partial class frmAddEditAccountant
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
            this.ctrlAddEditAccountant1 = new HMS.Add_Edit.AddEditPerson.AddEditEmployees.ctrlAddEditAccountant();
            this.SuspendLayout();
            // 
            // ctrlAddEditAccountant1
            // 
            this.ctrlAddEditAccountant1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditAccountant1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditAccountant1.Name = "ctrlAddEditAccountant1";
            this.ctrlAddEditAccountant1.Size = new System.Drawing.Size(1417, 601);
            this.ctrlAddEditAccountant1.TabIndex = 0;
            this.ctrlAddEditAccountant1.Load += new System.EventHandler(this.ctrlAddEditAccountant1_Load);
            // 
            // frmAddEditAccountant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 601);
            this.Controls.Add(this.ctrlAddEditAccountant1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditAccountant";
            this.Text = "frmAddEditAccountant";
            this.Load += new System.EventHandler(this.frmAddEditAccountant_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditPerson.AddEditEmployees.ctrlAddEditAccountant ctrlAddEditAccountant1;
    }
}