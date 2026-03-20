namespace HMS.Lists
{
    partial class ctrlDoctorListViewBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSpecilization = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Visible = false;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Visible = false;
            // 
            // cmbCountry
            // 
            this.cmbCountry.Visible = false;
            // 
            // label3
            // 
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(184, 39);
            this.label1.Text = "Doctor List";
            // 
            // cmbSearch
            // 
            this.cmbSearch.AutoCompleteCustomSource.AddRange(new string[] {
            "DoctorID",
            "FirstName",
            "LastName"});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label6.Location = new System.Drawing.Point(706, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Specilization";
            // 
            // cmbSpecilization
            // 
            this.cmbSpecilization.FormattingEnabled = true;
            this.cmbSpecilization.Location = new System.Drawing.Point(877, 71);
            this.cmbSpecilization.Name = "cmbSpecilization";
            this.cmbSpecilization.Size = new System.Drawing.Size(121, 24);
            this.cmbSpecilization.TabIndex = 14;
            this.cmbSpecilization.SelectedIndexChanged += new System.EventHandler(this.cmbSpecilization_SelectedIndexChanged);
            // 
            // ctrlDoctorListViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbSpecilization);
            this.Controls.Add(this.label6);
            this.Name = "ctrlDoctorListViewBase";
            this.Load += new System.EventHandler(this.ctrlDoctorListViewForAdmin_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbDepartment, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbState, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbSpecilization, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSpecilization;
    }
}
