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
    public partial class ctrlDoctorInfo : ctrlEmployeeInfo
    {
        public ctrlDoctorInfo()
        {
            InitializeComponent();
        }

        private void ctrlDoctorInfo_Load(object sender, EventArgs e)
        {

        }
        protected void EmptyAllDoctorRec()
        {
            EmptyAllEmployeeRec();
            lblSpecilization.Text = "-";
            lblDoctorID.Text = "-";

        }
        protected void FillDoctorInfo(clsDoctors doctors)
        {

            clsEmployees employees = clsEmployees.FindByID(doctors.EmplyeeID);

            FillEmployeeInfo(employees);
            lblSpecilization.Text = Convert.ToString(clsSpecilization.FindSpecilizationByID(doctors.SpecilizationID).SpecilizationName);
            lblDoctorID.Text = Convert.ToString(doctors.DoctorID);


        }
       override protected void lblSearch_Click(object sender, EventArgs e)
        {
            int DoctorID = -1;
            if(int.TryParse(Convert.ToString(txtSearch.Text),out int ID))
            {

                DoctorID = ID;
                clsDoctors doctor=clsDoctors.FindByID(DoctorID);
                if (doctor != null)
                {



                    FillDoctorInfo(doctor);





                }
                else { EmptyAllDoctorRec(); }
            }
        }
    }
}
