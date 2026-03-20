using HMS.Forms;
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
    public partial class ctrlOperationRoomsButton : ctrlButtonBase
    {
        public ctrlOperationRoomsButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmRoomsListForAdmin frmRoom = new frmRoomsListForAdmin();
                frmRoom.MdiParent = clsMDIParent.MDIPARENT;
                frmRoom.Dock = DockStyle.Fill;
                try
                {
                    frmRoom.Show();
                }
                catch { }
            }
        }
        private void ctrlOperationRoomsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
