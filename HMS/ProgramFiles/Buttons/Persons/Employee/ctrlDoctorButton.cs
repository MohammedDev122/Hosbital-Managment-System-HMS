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
    public partial class ctrlDoctorButton : ctrlButtonBase
    {
        public ctrlDoctorButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmDoctorList frmDo = new frmDoctorList();
                frmDo.MdiParent = clsMDIParent.MDIPARENT;
                frmDo.Dock = DockStyle.Fill;
                try
                {
                    frmDo.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlDoctorButton_Load(object sender, EventArgs e)
        {

        }
    }
}
