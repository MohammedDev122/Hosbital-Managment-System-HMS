using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons
{
    public partial class ctrlEmployeeButton : ctrlButtonBase
    {
        public ctrlEmployeeButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmEmployeeList frmEm = new frmEmployeeList();
                frmEm.MdiParent = clsMDIParent.MDIPARENT;
                frmEm.Dock = DockStyle.Fill;
                try
                {
                    frmEm.Show();
                }
                catch { }
            }
        }
        private void ctrlEmployeeButton_Load(object sender, EventArgs e)
        {

        }
    }
}
