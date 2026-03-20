using HMS.Lists.Admins;
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
    public partial class frmLoginsList : Form
    {
        public frmLoginsList()
        {
            InitializeComponent();

           ctrlLoginsListForAdmin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmLoginsList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlLoginsListForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
