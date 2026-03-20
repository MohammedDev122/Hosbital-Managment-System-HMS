using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Records.SystemLogs
{
    public partial class ctrlLogsListButton : ctrlButtonBase
    {
        public ctrlLogsListButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmLogsList frmPa = new frmLogsList();
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill; try { 
                frmPa.Show();
                }
                catch { }
            }
        }
        private void ctrlLogsListButton_Load(object sender, EventArgs e)
        {

        }
    }
}
