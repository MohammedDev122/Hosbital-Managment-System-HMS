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
    public partial class frmDoctorList : Form
    {
        public frmDoctorList()
        {
            InitializeComponent();
            ctrlDoctorListViewForAdmin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void ctrlDoctorListViewForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
