using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class Accountant : Form
    {
        public Accountant(int ID)
        {
            InitializeComponent();
            clsMDIParent.MDIPARENT = this;
            ctrlAccountantPanel1.SetID(ID);
        }

        private void Accountant_Load(object sender, EventArgs e)
        {

        }
    }
}
