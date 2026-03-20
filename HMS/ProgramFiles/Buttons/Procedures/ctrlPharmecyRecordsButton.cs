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
    public partial class ctrlPharmecyRecordsButton : ctrlButtonBase
    {
        public ctrlPharmecyRecordsButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmPharmecyRecordList frmPa = new frmPharmecyRecordList(_SignedMemberID);
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try
                {
                    frmPa.Show();
                }
                catch { }
            }
        }

        private void ctrlPharmecyRecordsButton_Load(object sender, EventArgs e)
        {

        }
    }
}
