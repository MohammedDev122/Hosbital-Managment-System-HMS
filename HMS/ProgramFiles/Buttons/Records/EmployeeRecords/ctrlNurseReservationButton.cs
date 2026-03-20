using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Records.EmployeeRecords
{
    public partial class ctrlNurseReservationButton : ctrlButtonBase
    {
        public ctrlNurseReservationButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmNurseReservationList frmNR = new frmNurseReservationList(_SignedMemberID);
                frmNR.MdiParent = clsMDIParent.MDIPARENT;
                frmNR.Dock = DockStyle.Fill;
                try { 
                frmNR.Show();
                }
                catch { }
            }
        }
        private void ctrlNurseReservationButton_Load(object sender, EventArgs e)
        {

        }
    }
}
