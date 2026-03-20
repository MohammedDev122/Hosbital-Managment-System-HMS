namespace HMS.ProgramFiles.Panels.SubPanels
{
    partial class subPanelBase
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
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.MaximumSize = new System.Drawing.Size(180, 401);
            this.panel1.Size = new System.Drawing.Size(180, 401);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // subPanelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximumSize = new System.Drawing.Size(180, 401);
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "subPanelBase";
            this.Size = new System.Drawing.Size(180, 401);
            this.Load += new System.EventHandler(this.subPanelBase_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
