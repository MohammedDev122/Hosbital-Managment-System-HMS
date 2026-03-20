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
    public partial class ctrlDepartmentsButton : ctrlButtonBase
    {
        public ctrlDepartmentsButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmDepartmentList frmPa = new frmDepartmentList();
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try
                {
                    frmPa.Show();
                }
                catch { }
            }
        }
        private void ctrlDepartmentsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
