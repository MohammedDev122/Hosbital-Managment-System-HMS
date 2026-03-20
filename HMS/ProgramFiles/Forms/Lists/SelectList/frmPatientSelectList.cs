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
    public partial class frmPatientSelectList : Form
    {
       public int PatientID = -1;
        public frmPatientSelectList()
        {
            InitializeComponent();
            ctrlPatientListViewForOthers1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        public Action<int> OnIDSelected;


        private void ctrlPatientListViewForOthers1_OnSelectedID(object sender, int e)
        {
            PatientID = e;
            if (PatientID != -1)
            {
                OnIDSelected?.Invoke(PatientID);
                this.Close();
            }
        }
        private void frmPatientSelectList_Load(object sender, EventArgs e)
        {

        }
        private void ctrlPatientListViewForOthers1_Load(object sender, EventArgs e)
        {

        }
    }
}
