namespace HMS.Add_Edit.Medications
{
    partial class ctrlAddEditMedCatorgy
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumOfMedication = new System.Windows.Forms.Label();
            this.txtCatorgy = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Size = new System.Drawing.Size(75, 38);
            this.lblAddEdit.Text = "Add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label1.Location = new System.Drawing.Point(65, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Catorgy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label2.Location = new System.Drawing.Point(65, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Num Of Medication:";
            // 
            // lblNumOfMedication
            // 
            this.lblNumOfMedication.AutoSize = true;
            this.lblNumOfMedication.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblNumOfMedication.Location = new System.Drawing.Point(308, 337);
            this.lblNumOfMedication.Name = "lblNumOfMedication";
            this.lblNumOfMedication.Size = new System.Drawing.Size(27, 29);
            this.lblNumOfMedication.TabIndex = 5;
            this.lblNumOfMedication.Text = "0";
            // 
            // txtCatorgy
            // 
            this.txtCatorgy.Location = new System.Drawing.Point(186, 230);
            this.txtCatorgy.Name = "txtCatorgy";
            this.txtCatorgy.Size = new System.Drawing.Size(141, 22);
            this.txtCatorgy.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1192, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 69);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlAddEditMedCatorgy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCatorgy);
            this.Controls.Add(this.lblNumOfMedication);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrlAddEditMedCatorgy";
            this.Load += new System.EventHandler(this.ctrlAddEditMedCatorgy_Load);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblNumOfMedication, 0);
            this.Controls.SetChildIndex(this.txtCatorgy, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumOfMedication;
        private System.Windows.Forms.TextBox txtCatorgy;
        private System.Windows.Forms.Button btnSave;
    }
}
