namespace HMS.Lists.Owners.Employee
{
    partial class ctrlDiagnosisListViewForDoctor
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
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Visible = false;
            // 
            // cmbSpecilization
            // 
            this.cmbSpecilization.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // button1
            // 
            this.button1.Visible = false;
            // 
            // ctrlDiagnosisListViewForDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ctrlDiagnosisListViewForDoctor";
            this.Load += new System.EventHandler(this.ctrlDiagnosisListViewForDoctor_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbSpecilization, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
