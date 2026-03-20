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
    public partial class frmPrescriptionSelectList : Form
    {
        public frmPrescriptionSelectList()
        {
            InitializeComponent();
            ctrlPrescriptionsListForOthers1.OnSelectedID += ctrlPatientListViewForOthers1_OnSelectedID;
            ctrlPrescriptionsListForOthers1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        public Action<int> OnIDSelected;
        public int PrescriptionID = -1;


        private void ctrlPatientListViewForOthers1_OnSelectedID(object sender, int e)
        {
            PrescriptionID = e;
            if (PrescriptionID != -1)
            {
                OnIDSelected?.Invoke(PrescriptionID);
                this.Close();
            }
        }
        private void frmPrescriptionSelectList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPrescriptionsListForOthers1_Load(object sender, EventArgs e)
        {

        }
    }
}
