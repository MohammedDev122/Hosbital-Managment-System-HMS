namespace HMS
{
    partial class ctrlBaseDGV
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
            this.components = new System.ComponentModel.Container();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.ContextMenuStrip = this.contextMenuStrip1;
            this.DGV1.EnableHeadersVisualStyles = false;
            this.DGV1.GridColor = System.Drawing.Color.IndianRed;
            this.DGV1.Location = new System.Drawing.Point(10, 184);
            this.DGV1.Name = "DGV1";
            this.DGV1.RowHeadersWidth = 51;
            this.DGV1.RowTemplate.Height = 24;
            this.DGV1.Size = new System.Drawing.Size(1329, 304);
            this.DGV1.TabIndex = 0;
            this.DGV1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellDoubleClick);
            this.DGV1.DragDrop += new System.Windows.Forms.DragEventHandler(this.DGV1_DragDrop);
            this.DGV1.DragEnter += new System.Windows.Forms.DragEventHandler(this.DGV1_DragEnter);
            this.DGV1.DragOver += new System.Windows.Forms.DragEventHandler(this.DGV1_DragOver);
            this.DGV1.DragLeave += new System.EventHandler(this.DGV1_DragLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 32);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.label1.Location = new System.Drawing.Point(559, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "title";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(363, 117);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(227, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbSearch
            // 
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(216, 116);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(120, 24);
            this.cmbSearch.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search By";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close (X)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlBaseDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV1);
            this.Name = "ctrlBaseDGV";
            this.Size = new System.Drawing.Size(1359, 718);
            this.Load += new System.EventHandler(this.ctrlBaseDGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DGV1;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.ComboBox cmbSearch;
        protected System.Windows.Forms.Label label2;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        protected System.Windows.Forms.Button button1;
    }
}
