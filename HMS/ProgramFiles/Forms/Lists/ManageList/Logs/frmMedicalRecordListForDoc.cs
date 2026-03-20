using HMS.Lists.Admins;
using HMS.Lists.Others.Employee;
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
    public partial class frmMedicalRecordSelectListForDoc : Form
    {
        int _DoctorID = -1;
        public frmMedicalRecordSelectListForDoc(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
            ctrlMedicalRecordListForDoctor1.SetID(_DoctorID);

            ctrlMedicalRecordListForDoctor1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }

        private void frmMedicalRecordListForDoc_Load(object sender, EventArgs e)
        {
        }

        private void ctrlMedicalRecordListForDoctor1_Load(object sender, EventArgs e)
        {

        }
        public Action<ctrlMedicalRecordSelectListForDoctor.info> Selected;
        private void ctrlMedicalRecordListForDoctor1_OnIdSelected(object sender, Lists.Others.Employee.ctrlMedicalRecordSelectListForDoctor.info e)
        {
            if (e != null) {
                Selected.Invoke(e);
                this.Close();
            
            }

            


        }
    }
}
