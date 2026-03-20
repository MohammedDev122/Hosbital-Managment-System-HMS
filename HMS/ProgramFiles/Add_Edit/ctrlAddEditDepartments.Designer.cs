namespace HMS.Add_Edit
{
    partial class ctrlAddEditDepartments
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
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.lblNumOfEmployees = new System.Windows.Forms.Label();
            this.txtDepartmentManagerID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelectEmployee = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(65, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Department Name:";
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblDepartmentName.Location = new System.Drawing.Point(298, 211);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(76, 29);
            this.lblDepartmentName.TabIndex = 4;
            this.lblDepartmentName.Text = ".........";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(65, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Department Manager ID:";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label100.Location = new System.Drawing.Point(642, 211);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(241, 29);
            this.label100.TabIndex = 6;
            this.label100.Text = "Num Of Employees:";
            // 
            // lblNumOfEmployees
            // 
            this.lblNumOfEmployees.AutoSize = true;
            this.lblNumOfEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.lblNumOfEmployees.Location = new System.Drawing.Point(925, 211);
            this.lblNumOfEmployees.Name = "lblNumOfEmployees";
            this.lblNumOfEmployees.Size = new System.Drawing.Size(69, 29);
            this.lblNumOfEmployees.TabIndex = 7;
            this.lblNumOfEmployees.Text = "........";
            // 
            // txtDepartmentManagerID
            // 
            this.txtDepartmentManagerID.Location = new System.Drawing.Point(385, 316);
            this.txtDepartmentManagerID.Name = "txtDepartmentManagerID";
            this.txtDepartmentManagerID.Size = new System.Drawing.Size(112, 22);
            this.txtDepartmentManagerID.TabIndex = 8;
            this.txtDepartmentManagerID.TextChanged += new System.EventHandler(this.txtDepartmentManagerID_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1241, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 47);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelectEmployee
            // 
            this.btnSelectEmployee.Location = new System.Drawing.Point(515, 316);
            this.btnSelectEmployee.Name = "btnSelectEmployee";
            this.btnSelectEmployee.Size = new System.Drawing.Size(74, 28);
            this.btnSelectEmployee.TabIndex = 10;
            this.btnSelectEmployee.Text = "......";
            this.btnSelectEmployee.UseVisualStyleBackColor = true;
            this.btnSelectEmployee.Click += new System.EventHandler(this.btnSelectEmployee_Click);
            // 
            // ctrlAddEditDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectEmployee);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDepartmentManagerID);
            this.Controls.Add(this.lblNumOfEmployees);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDepartmentName);
            this.Controls.Add(this.label1);
            this.Name = "ctrlAddEditDepartments";
            this.Load += new System.EventHandler(this.ctrlAddEditDepartments_Load);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDepartmentName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label100, 0);
            this.Controls.SetChildIndex(this.lblNumOfEmployees, 0);
            this.Controls.SetChildIndex(this.txtDepartmentManagerID, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnSelectEmployee, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label lblNumOfEmployees;
        private System.Windows.Forms.TextBox txtDepartmentManagerID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelectEmployee;
    }
}
