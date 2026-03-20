namespace HMS.Lists.Bases.Services
{
    partial class ctrlOperationListViewBase
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
            this.cmbSpecilization = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(518, 20);
            this.label1.Size = new System.Drawing.Size(251, 39);
            this.label1.Text = "Operations List";
            // 
            // cmbSpecilization
            // 
            this.cmbSpecilization.FormattingEnabled = true;
            this.cmbSpecilization.Location = new System.Drawing.Point(823, 110);
            this.cmbSpecilization.Name = "cmbSpecilization";
            this.cmbSpecilization.Size = new System.Drawing.Size(121, 24);
            this.cmbSpecilization.TabIndex = 8;
            this.cmbSpecilization.SelectedIndexChanged += new System.EventHandler(this.cmbSpecilization_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label5.Location = new System.Drawing.Point(647, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Specilization";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label6.Location = new System.Drawing.Point(647, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Result";
            // 
            // cmbResult
            // 
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(823, 81);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(121, 24);
            this.cmbResult.TabIndex = 10;
            this.cmbResult.SelectedIndexChanged += new System.EventHandler(this.cmbResult_SelectedIndexChanged);
            // 
            // ctrlOperationListViewBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSpecilization);
            this.Name = "ctrlOperationListViewBase";
            this.Load += new System.EventHandler(this.ctrlOperationListViewBase_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.cmbSearch, 0);
            this.Controls.SetChildIndex(this.cmbSpecilization, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbResult, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FullData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSpecilization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbResult;
    }
}
