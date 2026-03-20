namespace HMS.Add_Edit
{
    partial class EditSystemSettings
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
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.cmbThemes = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEdit
            // 
            this.lblAddEdit.Location = new System.Drawing.Point(539, 31);
            this.lblAddEdit.Size = new System.Drawing.Size(254, 38);
            this.lblAddEdit.Text = "System Settings";
            // 
            // label
            // 
            this.label.Visible = false;
            // 
            // lblID
            // 
            this.lblID.Visible = false;
            // 
            // button1
            // 
            this.button1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label1.Location = new System.Drawing.Point(65, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Language:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label2.Location = new System.Drawing.Point(65, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Theme:";
            // 
            // cmbLang
            // 
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(293, 222);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(121, 24);
            this.cmbLang.TabIndex = 4;
            this.cmbLang.SelectedIndexChanged += new System.EventHandler(this.cmbLang_SelectedIndexChanged);
            // 
            // cmbThemes
            // 
            this.cmbThemes.FormattingEnabled = true;
            this.cmbThemes.Location = new System.Drawing.Point(293, 364);
            this.cmbThemes.Name = "cmbThemes";
            this.cmbThemes.Size = new System.Drawing.Size(121, 24);
            this.cmbThemes.TabIndex = 5;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(1161, 384);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(229, 72);
            this.btnSaveSettings.TabIndex = 6;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // EditSystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.cmbThemes);
            this.Controls.Add(this.cmbLang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditSystemSettings";
            this.Load += new System.EventHandler(this.AddEditSystemSettings_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblAddEdit, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.cmbLang, 0);
            this.Controls.SetChildIndex(this.cmbThemes, 0);
            this.Controls.SetChildIndex(this.btnSaveSettings, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.ComboBox cmbThemes;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}
