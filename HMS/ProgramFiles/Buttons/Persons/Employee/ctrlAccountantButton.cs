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
    public partial class ctrlAccountantButton : ctrlButtonBase
    {
        public ctrlAccountantButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmAccountantListcs frmAc = new frmAccountantListcs();
                frmAc.MdiParent = clsMDIParent.MDIPARENT;
                frmAc.Dock = DockStyle.Fill;
                try
                {
                    frmAc.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlAccountant_Load(object sender, EventArgs e)
        {

        }

       
    }
}
