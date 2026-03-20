using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Procedures
{
    public partial class ctrlMyOperationMemberButton : ctrlButtonBase
    {
        public ctrlMyOperationMemberButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmOperationListForMember frmOp = new frmOperationListForMember(_SignedMemberID);
                frmOp.MdiParent = clsMDIParent.MDIPARENT;
                frmOp.Dock = DockStyle.Fill;
                try
                {
                    frmOp.Show();
                }
                catch { }
                }
        }
        private void ctrlMyOperationMemberButton_Load(object sender, EventArgs e)
        {

        }
    }
}
