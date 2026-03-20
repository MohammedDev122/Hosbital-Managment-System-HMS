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
    public partial class ctrlEmployeeInfo : ctrlPersonInfo
    {
        public ctrlEmployeeInfo()
        {
            InitializeComponent();
        }

        private void ctrlEmployeeInfo_Load(object sender, EventArgs e)
        {

        }
        string _printEmployeeState(clsEmployees.enState state)
        {

            if (state == clsEmployees.enState.enWorking)
            {
                return "Working";
            }
            else
            {
                return "Fired";
            }

        }

        protected void EmptyAllEmployeeRec()
        {
            EmptyAllPersonRec();
            lblEmployeeID.Text = "_";
            lblSalery.Text = "_";
            lblDepartment.Text = "_";
            lblWorkingDays.Text = "_";
            lblState.Text = "_";
            lblEmploymentDate.Text = "_";
            lblExitDate.Text = "_";

        }
        protected void FillEmployeeInfo(clsEmployees employee)
        {
            clsPerson person = clsPerson.FindByID(employee.PersonID);

            FillPersonInfo(person);
            lblEmployeeID.Text = Convert.ToString(employee.EmplyeeID);
            lblSalery.Text=Convert.ToString(employee.Salery);
            lblDepartment.Text = Convert.ToString(clsDeparmtments.FindDepartmentByID(employee.DepartmentID).DepartmentName);
            lblWorkingDays.Text = Convert.ToString(employee.WorkingDays);
            lblState.Text = Convert.ToString(_printEmployeeState(employee.EmployeeState));
            lblEmploymentDate.Text = Convert.ToString(employee.EmploymentDate);
            lblExitDate.Text = Convert.ToString(employee.DueDate);



        }


    override   protected void lblSearch_Click(object sender, EventArgs e)
        {
            int EmployeeID = -1;
            if(int.TryParse(Convert.ToString(txtSearch.Text),out int ID))
            {
                EmployeeID = ID;
            clsEmployees Employee=    clsEmployees.FindByID(EmployeeID);
                if (Employee != null)
                {
                    FillEmployeeInfo(Employee);
                }
                else
                {
                    EmptyAllEmployeeRec();
                }

            }
            
            




        }

        private void lblPersonID_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
