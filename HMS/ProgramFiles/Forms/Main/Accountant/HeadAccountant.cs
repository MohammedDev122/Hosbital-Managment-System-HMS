using HMS.ProgramFiles.Panels.MainPanel;
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
    public partial class HeadAccountant : Form
    {
        public HeadAccountant(int EmplyeeID)
        {
            InitializeComponent();

            clsMDIParent.MDIPARENT = this;
            ctrlHeadAccountant1.SetID(EmplyeeID);

            ctrlHeadAccountant1.ctrlAccountantSubPanelButton1.SetThePanel(ctrlHeadOfAccountantSupPanel1);
            ctrlHeadAccountant1.ShrinkSub = ctrlHeadAccountant1.ctrlAccountantSubPanelButton1.Shrink;
            ctrlHeadAccountant1.ctrlAccountantSubPanelButton1.ExtendMainPanel = ctrlHeadAccountant1.Extened;
        }

        private void HeadAccountant_Load(object sender, EventArgs e)
        {
           ctrlHeadAccountant1.ctrlPaymentsButton1.RunWhenProgramInitiated();
        }
    }
}
