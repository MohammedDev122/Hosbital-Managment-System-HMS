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
    public partial class frmServicesTypesList : Form
    {
        public frmServicesTypesList()
        {
            InitializeComponent();
            ctrlServicesTypesListForAdmins1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void ctrlServicesTypesListForAdmins1_Load(object sender, EventArgs e)
        {

        }
    }
}
