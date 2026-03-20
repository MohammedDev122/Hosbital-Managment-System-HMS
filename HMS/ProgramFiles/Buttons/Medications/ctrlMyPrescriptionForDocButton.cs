using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Medications
{
    public partial class ctrlMyPrescriptionForDocButton : ctrlButtonBase
    {
        public ctrlMyPrescriptionForDocButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmPrescriptionList frmPa = new frmPrescriptionList(_SignedMemberID);
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try
                {
                    frmPa.Show();
                }
                catch { }
            }
        }

        private void ctrlMyPrescriptionForDoc_Load(object sender, EventArgs e)
        {

        }
    }
}
