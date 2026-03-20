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
    public partial class frmDoctorReservationList : Form
    {
        public frmDoctorReservationList(int employeeID)
        {
            InitializeComponent();
            ctrlDoctorReservationForDoctorList1.SetID(clsEmployees.GetEmployeeRoleID(employeeID));
            ctrlDoctorReservationForDoctorList1.CloseForm = CloseForm;
        }
        void CloseForm()
        {
            this.Close();
        }
        private void frmDoctorReservationList_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDoctorReservationForDoctorList1_Load(object sender, EventArgs e)
        {

        }
    }
}
