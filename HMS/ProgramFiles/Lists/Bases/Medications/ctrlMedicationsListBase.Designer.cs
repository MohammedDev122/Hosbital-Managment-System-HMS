namespace HMS.Lists.Bases.Medications
{
    partial class ctrlMedicationsListBase
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCatorgy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(548, 26);
            this.label1.Size = new System.Drawing.Size(185, 39);
            this.label1.Text = "Medication";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(832, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Catorgy";
            // 
            // cmbCatorgy
            // 
            this.cmbCatorgy.FormattingEnabled = true;
            this.cmbCatorgy.Location = new System.Drawing.Point(949, 121);
            this.cmbCatorgy.Name = "cmbCatorgy";
            this.cmbCatorgy.Size = new System.Drawing.Size(121, 24);
            this.cmbCatorgy.TabIndex = 5;
            this.cmbCatorgy.SelectedIndexChanged += new System.EventHandler(this.cmbCatorgy_SelectedIndexChanged);
            // 
            // ctrlMedicationsListBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCatorgy);
            this.Controls.Add(this.label3);
            this.Name = "ctrlMedicationsListBase";
            this.Load += new System.EventHandler(this.ctrlMedicationsListBase_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbCatorgy, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCatorgy;
    }
}
