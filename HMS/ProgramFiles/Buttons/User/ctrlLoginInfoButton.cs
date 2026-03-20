using HMS.Buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.ProgramFiles.Buttons.User
{
    public partial class ctrlLoginInfoButton : ctrlButtonBase
    {
        public ctrlLoginInfoButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
frmAddEditLogin frmLog=new frmAddEditLogin(_SignedMemberID);
                frmLog.MdiParent=clsMDIParent.MDIPARENT;
                frmLog.Dock = DockStyle.Fill;
                frmLog.Show();
            }
        }
        private void ctrlLoginInfoButton_Load(object sender, EventArgs e)
        {

        }
    }
}
