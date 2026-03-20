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
    public partial class ctrlPatientLogsButton : ctrlButtonBase
    {
        public ctrlPatientLogsButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmPatientLogsList frmPa = new frmPatientLogsList();
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try { 
                frmPa.Show();
                }
                catch { }
            }
        }
        private void ctrlPatientLogsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
