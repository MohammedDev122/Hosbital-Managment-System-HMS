namespace HMS.Lists.Bases.Services
{
    partial class ctrlDiagnosisListViewBase
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSpecilization = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(234, 39);
            this.label1.Text = "Diagnosis List";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label5.Location = new System.Drawing.Point(661, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Specilization";
            // 
            // cmbSpecilization
            // 
            this.cmbSpecilization.FormattingEnabled = true;
            this.cmbSpecilization.Location = new System.Drawing.Point(849, 113);
            this.cmbSpecilization.Name = "cmbSpecilization";
            this.cmbSpecilization.Size = new System.Drawing.Size(121, 24);
            this.cmbSpecilization.TabIndex = 9;
            this.cmbSpecilization.SelectedIndexChanged += new System.EventHandler(this.cmbSpecilization_SelectedIndexChanged);
            // 
            // ctrlDiagnosisListViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbSpecilization);
            this.Controls.Add(this.label5);
            this.Name = "ctrlDiagnosisListViewBase";
            this.Load += new System.EventHandler(this.ctrlDiagnosisListViewBase_Load);
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

        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox cmbSpecilization;
    }
}
