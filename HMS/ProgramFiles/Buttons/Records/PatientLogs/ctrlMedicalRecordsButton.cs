using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Records.PatientLogs
{
    public partial class ctrlMedicalRecordsButton : ctrlButtonBase
    {
        public ctrlMedicalRecordsButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmMedicalRecordsList frmMR = new frmMedicalRecordsList(_SignedMemberID);
                frmMR.MdiParent = clsMDIParent.MDIPARENT;
                frmMR.Dock = DockStyle.Fill;
                try {
                frmMR.Show();
                }
                catch { }
            }
        }
        private void ctrlMedicalRecordsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
