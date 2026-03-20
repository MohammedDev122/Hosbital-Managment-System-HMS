using HMS.ProgramFiles.Panels.MainPanel;
using HMS.ProgramFiles.Panels.MainPanel.NursePanel;
using HMS.ProgramFiles.Panels.SubPanels;
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
    public partial class HeadNurse : Form
    {
        public HeadNurse(int EmployeeID)
        {
            InitializeComponent();
            clsMDIParent.MDIPARENT = this;

            ctrlHeadNurse1.SetID(EmployeeID);
            ctrlHeadNurse1.ctrlNurseSubPanelButton1.SetThePanel(ctrlHeadOfNurseSupPanel1);
            ctrlHeadNurse1.ShrinkSub = ctrlHeadNurse1.ctrlNurseSubPanelButton1.Shrink;
            ctrlHeadNurse1.ctrlNurseSubPanelButton1.ExtendMainPanel = ctrlHeadNurse1.Extened;
        }

        private void HeadNurse_Load(object sender, EventArgs e)
        {
            ctrlHeadNurse1.ctrlNurseReservationButton1.RunWhenProgramInitiated();

        }
    }
}
