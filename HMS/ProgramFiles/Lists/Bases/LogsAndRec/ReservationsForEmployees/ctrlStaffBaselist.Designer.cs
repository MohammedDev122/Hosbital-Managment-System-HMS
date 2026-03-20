namespace HMS.Lists.Bases.LogsAndRec.ReservationsForEmployees
{
    partial class ctrlStaffBaselist
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
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(511, 21);
            this.label1.Size = new System.Drawing.Size(268, 39);
            this.label1.Text = "Operations Staff";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(976, 90);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 24);
            this.cmbDepartment.TabIndex = 6;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label4.Location = new System.Drawing.Point(810, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Department";
            // 
            // ctrlStaffBaselist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDepartment);
            this.Name = "ctrlStaffBaselist";
            this.Load += new System.EventHandler(this.ctrlStaffBaselist_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbState, 0);
            this.Controls.SetChildIndex(this.cmbDepartment, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label4;
    }
}
