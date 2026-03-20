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
    public partial class ctrlAllDoctorReservationButton : ctrlButtonBase
    {
        public ctrlAllDoctorReservationButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmAllDoctorReservationList frmDR = new frmAllDoctorReservationList();
                frmDR.MdiParent = clsMDIParent.MDIPARENT;
                frmDR.Dock = DockStyle.Fill;
                try
                {
                    frmDR.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlDoctorReservationButton_Load(object sender, EventArgs e)
        {

        }
    }
}
