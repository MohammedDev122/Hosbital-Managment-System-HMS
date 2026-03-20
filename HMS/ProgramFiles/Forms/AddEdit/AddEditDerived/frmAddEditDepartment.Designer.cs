namespace HMS
{
    partial class frmAddEditDepartment
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
            this.ctrlAddEditDepartments1 = new HMS.Add_Edit.ctrlAddEditDepartments();
            this.SuspendLayout();
            // 
            // ctrlAddEditDepartments1
            // 
            this.ctrlAddEditDepartments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditDepartments1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditDepartments1.Name = "ctrlAddEditDepartments1";
            this.ctrlAddEditDepartments1.Size = new System.Drawing.Size(1461, 450);
            this.ctrlAddEditDepartments1.TabIndex = 0;
            this.ctrlAddEditDepartments1.Load += new System.EventHandler(this.ctrlAddEditDepartments1_Load);
            // 
            // frmAddEditDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 450);
            this.Controls.Add(this.ctrlAddEditDepartments1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditDepartment";
            this.Text = "frmAddEditDepartment";
            this.Load += new System.EventHandler(this.frmAddEditDepartment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.ctrlAddEditDepartments ctrlAddEditDepartments1;
    }
}