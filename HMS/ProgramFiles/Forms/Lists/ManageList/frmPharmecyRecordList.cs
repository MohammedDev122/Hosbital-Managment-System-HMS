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
    public partial class frmPharmecyRecordList : Form
    {
        public frmPharmecyRecordList(int EmployeeID)
        {
            InitializeComponent();
            ctrlPharmaceyRecordListForAdmin1.SetID(EmployeeID);
            ctrlPharmaceyRecordListForAdmin1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmPharmecyRecordList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPharmaceyRecordListForAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
