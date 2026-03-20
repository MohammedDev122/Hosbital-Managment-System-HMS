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
    public partial class ctrlAllNursesReservationsButton : ctrlButtonBase
    {
        public ctrlAllNursesReservationsButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmAllNurseReservationsList frmNR = new frmAllNurseReservationsList();
                frmNR.MdiParent = clsMDIParent.MDIPARENT;
                frmNR.Dock = DockStyle.Fill;
                try { 
                frmNR.Show();
                if (Panel != null)
                {
                    Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlAllNursesReservationsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
