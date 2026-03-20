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
    public partial class frmPatientList : Form
    {
        public frmPatientList()
        {
            InitializeComponent();
            ctrlPatientListViewForAdmin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmPatientList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPatientListViewForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
