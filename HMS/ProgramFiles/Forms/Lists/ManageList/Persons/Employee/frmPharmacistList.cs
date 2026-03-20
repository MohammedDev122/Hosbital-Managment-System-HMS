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
    public partial class frmPharmacistList : Form
    {
        public frmPharmacistList()
        {
            InitializeComponent();
            ctrlPharmacistListViewForAdmin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void ctrlPharmacistListViewForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
