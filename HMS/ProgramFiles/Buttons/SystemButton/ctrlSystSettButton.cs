using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.SystemButton
{
    public partial class ctrlSystSettButton : ctrlButtonBase
    {
        public ctrlSystSettButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmSystemSettings frmPa = new frmSystemSettings();
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                frmPa.Show();
            }
        }
        private void ctrlSystSettButton_Load(object sender, EventArgs e)
        {

        }
    }
}
