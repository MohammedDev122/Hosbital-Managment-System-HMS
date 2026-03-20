namespace HMS
{
    partial class frmAddEditDoctor
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
            this.ctrlAddEditDoctor1 = new HMS.Add_Edit.AddEditPerson.ctrlAddEditDoctor();
            this.SuspendLayout();
            // 
            // ctrlAddEditDoctor1
            // 
            this.ctrlAddEditDoctor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditDoctor1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditDoctor1.Name = "ctrlAddEditDoctor1";
            this.ctrlAddEditDoctor1.Size = new System.Drawing.Size(1419, 601);
            this.ctrlAddEditDoctor1.TabIndex = 0;
            this.ctrlAddEditDoctor1.Load += new System.EventHandler(this.ctrlAddEditDoctor1_Load);
            // 
            // frmAddEditDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 601);
            this.Controls.Add(this.ctrlAddEditDoctor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditDoctor";
            this.Text = "frmAddEditDoctor";
            this.Load += new System.EventHandler(this.frmAddEditDoctor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Add_Edit.AddEditPerson.ctrlAddEditDoctor ctrlAddEditDoctor1;
    }
}