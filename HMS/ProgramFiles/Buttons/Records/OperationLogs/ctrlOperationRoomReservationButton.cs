using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Records.OperationLogs
{
    public partial class ctrlOperationRoomReservationButton : ctrlButtonBase
    {
        public ctrlOperationRoomReservationButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmRoomReservationsList frmPa = new frmRoomReservationsList();
                frmPa.MdiParent = clsMDIParent.MDIPARENT;
                frmPa.Dock = DockStyle.Fill;
                try { 
                frmPa.Show();
                }
                catch { }
            }
        }
        private void ctrlOperationRoomReservationButton_Load(object sender, EventArgs e)
        {

        }
    }
}
