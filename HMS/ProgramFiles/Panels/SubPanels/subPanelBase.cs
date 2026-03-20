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
    public partial class subPanelBase : ctrlPanelBase
    {
        public subPanelBase()
        {
            InitializeComponent();
        }

        private void subPanelBase_Load(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
