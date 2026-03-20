using HMS.Lists.Admins;
using HosbitalBussinessLayer;
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
    public partial class frmMedicalRecordsList : Form
    {
        public frmMedicalRecordsList(int employeeID)
        {
            InitializeComponent();
      
            ctrlMedicalRecordListForDoctor1.SetID(clsEmployees.GetEmployeeRoleID(employeeID));
            ctrlMedicalRecordListForDoctor1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmMedicalRecordsList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlMedicalRecordListForDoctor1_Load(object sender, EventArgs e)
        {

        }
    }
}
