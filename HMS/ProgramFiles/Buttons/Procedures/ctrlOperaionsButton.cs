using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Procedures
{
    public partial class ctrlOperaionsButton : ctrlButtonBase
    {
        public ctrlOperaionsButton()
        {
            InitializeComponent();
            
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmOperationList frmOp = new frmOperationList();
                frmOp.MdiParent = clsMDIParent.MDIPARENT;
                frmOp.Dock = DockStyle.Fill;
                try
                {
                    frmOp.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlOperaionsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
