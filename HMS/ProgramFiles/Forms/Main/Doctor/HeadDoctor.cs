using HMS.Buttons.Procedures;
using HMS.ProgramFiles.Panels.MainPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class HeadDoctor : Form
    {
        public HeadDoctor(int EmployeeID)
        {
            InitializeComponent();
            clsMDIParent.MDIPARENT = this;

            ctrlHeadDoctor1.SetID(EmployeeID);
            clsMDIParent.MDIPARENT = this;
            ctrlHeadDoctor1.ctrlDoctorSubPanelButton1.SetThePanel(ctrlHeadOFDoctorsSubPanel2);
            ctrlHeadDoctor1.ShrinkSub=ctrlHeadDoctor1.ctrlDoctorSubPanelButton1.Shrink;
            ctrlHeadDoctor1.ctrlDoctorSubPanelButton1.ExtendMainPanel = ctrlHeadDoctor1.Extened;
        }

        private void ctrlDoctorPanel1_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ctrlHeadDoctor1.ctrlDoctorReservationButton1.RunWhenProgramInitiated();

        }
    }
}
