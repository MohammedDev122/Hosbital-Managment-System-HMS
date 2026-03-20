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
    public partial class ctrlHeadOfPharmacistSupPanel : subPanelBase
    {
        public ctrlHeadOfPharmacistSupPanel()
        {
            InitializeComponent();
            ctrlCatorgiesButton1.Panel = this;
            ctrlPharmacistButton1.Panel = this;
            ctrlMedicationButton1.Panel = this;
        }

        private void ctrlHeadOfPharmacistSupPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
