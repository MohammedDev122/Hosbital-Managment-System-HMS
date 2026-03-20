using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Buttons.Persons.Employee
{
    public partial class ctrlNurseButton : ctrlButtonBase
    {
        public ctrlNurseButton()
        {
            InitializeComponent();
        }
        override protected void button1_Click(object sender, EventArgs e)
        {
            if (CloseAllOthers())
            {
                frmNurseList frmNu = new frmNurseList();
                frmNu.MdiParent = clsMDIParent.MDIPARENT;
                frmNu.Dock = DockStyle.Fill;
                try
                {
                    frmNu.Show();
              
                if (Panel != null)
                {
                    Panel.Size = Panel.MinimumSize;
                }
                }
                catch 
                {
                }
            }
        }
        private void ctrlNurseButton_Load(object sender, EventArgs e)
        {

        }
    }
}
