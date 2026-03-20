using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Persons.Employee
{
    public partial class ctrlPharmacistButton : ctrlButtonBase
    {
        public ctrlPharmacistButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmPharmacistList frmPh = new frmPharmacistList();
                frmPh.MdiParent = clsMDIParent.MDIPARENT;
                frmPh.Dock = DockStyle.Fill;
                try
                {
                    frmPh.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlPharmacistButton_Load(object sender, EventArgs e)
        {

        }
    }
}
