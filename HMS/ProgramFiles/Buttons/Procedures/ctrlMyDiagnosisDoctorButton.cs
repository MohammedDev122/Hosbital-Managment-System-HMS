using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Procedures
{
    public partial class ctrlMyDiagnosisDoctorButton : ctrlButtonBase
    {
        public ctrlMyDiagnosisDoctorButton()
        {
            InitializeComponent();
        }
       
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmDiagnosisForDoctor frmDD = new frmDiagnosisForDoctor(_SignedMemberID);
                frmDD.MdiParent = clsMDIParent.MDIPARENT;
                frmDD.Dock = DockStyle.Fill;
                try
                {
                    frmDD.Show();
                }
                catch { }
            }
        }
        private void ctrlMyDiagnosisDoctor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
