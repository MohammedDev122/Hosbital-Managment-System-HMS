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
    public partial class frmDoctorSelectList : Form
    {
        int DoctorID = -1;
        public frmDoctorSelectList()
        {
            InitializeComponent();
            ctrlDoctorListViewForOthers1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        public Action<int> OnIDSelected;
        private void ctrlDoctorListViewForOthers1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDoctorListViewForOthers1_OnSelectedID(object sender, int e)
        {
            DoctorID = e;
            if (DoctorID != -1) {

                OnIDSelected?.Invoke(DoctorID);
                this.Close();

            }
        }

        private void frmDoctorSelectList_Load(object sender, EventArgs e)
        {

        }
    }
}
