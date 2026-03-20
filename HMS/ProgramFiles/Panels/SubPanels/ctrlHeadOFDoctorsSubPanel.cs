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

namespace HMS.ProgramFiles.Panels.SubPanels
{
    public partial class ctrlHeadOFDoctorsSubPanel : subPanelBase
    {
        public ctrlHeadOFDoctorsSubPanel()
        {
            InitializeComponent();
            ctrlDoctorButton1.Panel = this;
            ctrlDiagnosisButton1.Panel = this;
            ctrlAllDoctorReservationButton1.Panel = this;
            ctrlOperaionsButton1.Panel = this;
            ctrlServicesTypesButton1.Panel = this;
            ctrlSpecilizationsButton1.Panel = this;

        }

        private void ctrlHeadOFDoctorsSubPanel_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
