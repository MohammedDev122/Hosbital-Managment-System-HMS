using HMS.ProgramFiles.Panels.MainPanel.AccountantPanel;
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
    public partial class HeadPharmacist : Form
    {
        public HeadPharmacist(int EmplyeeID)
        {
            InitializeComponent();
            clsMDIParent.MDIPARENT = this;

            ctrlHeadPharmacist1.SetID(EmplyeeID);

            ctrlHeadPharmacist1.ctrlPharmacistSupPanelButton1.SetThePanel(ctrlHeadOfPharmacistSupPanel1);
            ctrlHeadPharmacist1.ShrinkSub = ctrlHeadPharmacist1.ctrlPharmacistSupPanelButton1.Shrink;
            ctrlHeadPharmacist1.ctrlPharmacistSupPanelButton1.ExtendMainPanel = ctrlHeadPharmacist1.Extened;

        }

        private void HeadPharmacist_Load(object sender, EventArgs e)
        {
            ctrlHeadPharmacist1.ctrlPharmecyRecordsButton1.RunWhenProgramInitiated();
        }
    }
}
