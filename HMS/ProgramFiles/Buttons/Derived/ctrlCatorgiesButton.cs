using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Derived
{
    public partial class ctrlCatorgiesButton : ctrlButtonBase
    {
        public ctrlCatorgiesButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmMedicalCatorgyList frmPa = new frmMedicalCatorgyList();
                frmPa.MdiParent=clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try
                {
                    frmPa.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlCatorgiesButton_Load(object sender, EventArgs e)
        {

        }
    }
}
