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
    public partial class ctrlDiagnosisButton : ctrlButtonBase
    {
        public ctrlDiagnosisButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmDiagnosisList frmD = new frmDiagnosisList();
                frmD.MdiParent = clsMDIParent.MDIPARENT;
                frmD.Dock = DockStyle.Fill;
                try
                {
                    frmD.Show();
                    if (Panel != null)
                    {
                        Panel.Size = Panel.MinimumSize;
                    }
                }
                catch { }
            }
        }
        private void ctrlDiagnosisButton_Load(object sender, EventArgs e)
        {

        }
    }
}
