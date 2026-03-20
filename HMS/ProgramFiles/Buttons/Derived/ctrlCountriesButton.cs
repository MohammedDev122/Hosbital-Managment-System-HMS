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
    public partial class ctrlCountriesButton : ctrlButtonBase
    {
        public ctrlCountriesButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmCountriesList frmCo = new frmCountriesList();
                frmCo.MdiParent = clsMDIParent.MDIPARENT;
                frmCo.Dock = DockStyle.Fill;
                try
                {
                    frmCo.Show();
                }
                catch { }
            }
        }
        private void ctrlCountriesButton_Load(object sender, EventArgs e)
        {

        }
    }
}
