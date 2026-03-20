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
    public partial class ctrlPatientButtons : ctrlButtonBase
    {
        public ctrlPatientButtons()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmPatientList frmPa = new frmPatientList();
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try
                {
                    frmPa.Show();
                }
                catch { }
            }
        }
        private void ctrlPatientButtons_Load(object sender, EventArgs e)
        {

        }
    }
}
