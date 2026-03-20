namespace HMS
{
    partial class frmPatientSelectList
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
            this.ctrlPatientListViewForOthers1 = new HMS.Lists.Others.Patient.ctrlPatientListViewForOthers();
            this.SuspendLayout();
            // 
            // ctrlPatientListViewForOthers1
            // 
            this.ctrlPatientListViewForOthers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPatientListViewForOthers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPatientListViewForOthers1.Name = "ctrlPatientListViewForOthers1";
            this.ctrlPatientListViewForOthers1.Size = new System.Drawing.Size(1377, 390);
            this.ctrlPatientListViewForOthers1.TabIndex = 0;
            this.ctrlPatientListViewForOthers1.OnSelectedID += new System.EventHandler<int>(this.ctrlPatientListViewForOthers1_OnSelectedID);
            this.ctrlPatientListViewForOthers1.Load += new System.EventHandler(this.ctrlPatientListViewForOthers1_Load);
            // 
            // frmPatientSelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 390);
            this.Controls.Add(this.ctrlPatientListViewForOthers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientSelectList";
            this.Text = "frmPatientSelectList";
            this.Load += new System.EventHandler(this.frmPatientSelectList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Lists.Others.Patient.ctrlPatientListViewForOthers ctrlPatientListViewForOthers1;
    }
}