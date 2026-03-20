using HosbitalBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.User
{
    public partial class ctrlMyPersonalInfoButton : ctrlButtonBase
    {
        public ctrlMyPersonalInfoButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                clsEmployees employee = clsEmployees.FindByID(_SignedMemberID);
                if (employee != null)
                {
                    frmAddEditPerson frmPa = new frmAddEditPerson(employee.PersonID);
                    frmPa.MdiParent = clsMDIParent.MDIPARENT;
                    frmPa.Dock = DockStyle.Fill;
                    frmPa.Show();
                }
            }
        }
        private void ctrlMyPersonalInfoButton_Load(object sender, EventArgs e)
        {

        }
    }
}
