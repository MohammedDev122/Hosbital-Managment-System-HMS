using HMS.ProgramFiles.Panels.MainPanel;
using HMS.ProgramFiles.Panels.MainPanel.AccountantPanel;
using HMS.ProgramFiles.Panels.MainPanel.NursePanel;
using HMS.ProgramFiles.Panels.MainPanel.PharmacistPanel;
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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            clsMDIParent.MDIPARENT = this;

            //acountant

            ctrlAdminPanel1.ctrlAccountantSubPanelButton1.SetThePanel(ctrlHeadOfAccountantSupPanel1);
            ctrlAdminPanel1.ShrinkSub = ctrlAdminPanel1.ctrlAccountantSubPanelButton1.Shrink;
            ctrlAdminPanel1.ctrlAccountantSubPanelButton1.ExtendMainPanel = ctrlAdminPanel1.Extened;
            //doctor
            ctrlAdminPanel1.ctrlDoctorSubPanelButton1.SetThePanel(ctrlHeadOFDoctorsSubPanel1);
            ctrlAdminPanel1.ShrinkSub = ctrlAdminPanel1.ctrlDoctorSubPanelButton1.Shrink;
            ctrlAdminPanel1.ctrlDoctorSubPanelButton1.ExtendMainPanel = ctrlAdminPanel1.Extened;
            //nurse
            ctrlAdminPanel1.ctrlNurseSubPanelButton1.SetThePanel(ctrlHeadOfNurseSupPanel1);
            ctrlAdminPanel1.ShrinkSub = ctrlAdminPanel1.ctrlNurseSubPanelButton1.Shrink;
            ctrlAdminPanel1.ctrlNurseSubPanelButton1.ExtendMainPanel = ctrlAdminPanel1.Extened;
            //Phaemacist

            ctrlAdminPanel1.ctrlPharmacistSupPanelButton1.SetThePanel(ctrlHeadOfPharmacistSupPanel1);
            ctrlAdminPanel1.ShrinkSub = ctrlAdminPanel1.ctrlPharmacistSupPanelButton1.Shrink;
            ctrlAdminPanel1.ctrlPharmacistSupPanelButton1.ExtendMainPanel = ctrlAdminPanel1.Extened;
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
