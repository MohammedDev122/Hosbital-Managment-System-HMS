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
    public partial class ctrlHeadOfNurseSupPanel : subPanelBase
    {
        public ctrlHeadOfNurseSupPanel()
        {
            InitializeComponent();
            ctrlNurseButton1.Panel = this;
            ctrlAllNursesReservationsButton1.Panel = this;
        }

        private void ctrlHeadOfNurseSupPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
