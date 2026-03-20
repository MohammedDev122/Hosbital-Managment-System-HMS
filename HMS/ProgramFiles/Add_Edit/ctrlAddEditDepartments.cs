using HMS.Lists.Others.Employee;
using HosbitalBussinessLayer.Logs;
using HosbitalBussinessLayer.Procedures;
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

namespace HMS.Add_Edit
{
    public partial class ctrlAddEditDepartments : ctrlAddEditBase
    {
        public ctrlAddEditDepartments()
        {
            InitializeComponent();
        }
        protected void FillDepartmentInfo(int DeparmentID)
        {
            clsDeparmtments Department = clsDeparmtments.FindDepartmentByID(DeparmentID);
            lblID.Text = Convert.ToString(ID);

            lblDepartmentName.Text = Department.DepartmentName;
            if (int.TryParse(Convert.ToString(Department.DepartmentManagerID), out int ManagerID))
            {
                txtDepartmentManagerID.Text = ManagerID.ToString();




            }
            lblNumOfEmployees.Text = Convert.ToString(Department.NumOfEmployees);



        }

        override protected void FillInfo(int ID)
        {
            clsDeparmtments Departments = clsDeparmtments.FindDepartmentByID(ID);

            if (ID != -1)
            {
                if (Departments != null)
                {

                    setAddEdit("Edit Department");
                    _Mode = enMode.enUpdate;
                    FillDepartmentInfo(Departments.DepartmentID);

                    //FillInfo


                }
                else
                {
                    setAddEdit("Add New Department");
                    btnSave.Enabled = false;
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Department");
                _Mode = enMode.enAddNew;
                btnSave.Enabled = false;

                //new Record


            }






        }

        protected void UpdateDepartment(clsDeparmtments Department)
        {

            if (int.TryParse(Convert.ToString(txtDepartmentManagerID.Text), out int DeparmentManager))
            {


                Department.DepartmentManagerID = (DeparmentManager);


            }

            if (Department.Save())
            {
                FillInfo(Department.DepartmentID);

            }
            else
            {
                MessageBox.Show(Department.Cause.ToString(), "Error");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            clsDeparmtments Department = clsDeparmtments.FindDepartmentByID(ID);
            UpdateDepartment(Department);
            FillInfo(Department.DepartmentID);





        }






        private void ctrlAddEditDepartments_Load(object sender, EventArgs e)
        {

        }

        private void txtDepartmentManagerID_TextChanged(object sender, EventArgs e)
        {

            if (!int.TryParse(Convert.ToString(lblID.Text), out int DepartmentID))
            {
                if (int.TryParse(Convert.ToString(txtDepartmentManagerID.Text), out int ManagerID))
                {

                    clsEmployees Employee = clsEmployees.FindByID(ManagerID);
                    if (Employee != null)
                    {
                        if (Employee.EmployeeState == clsEmployees.enState.enWorking)
                        {
                            if (Employee.DepartmentID != Convert.ToInt32(lblID.Text))
                            {
                                btnSave.Enabled = true;




                            }
                            else
                            {
                                btnSave.Enabled = false;


                            }



                        }

                        else
                        {
                            btnSave.Enabled = false;
                        }


                    }
                    else
                    {

                        btnSave.Enabled = false;
                    }

                }
                else
                {

                    btnSave.Enabled = false;
                }
            }

        }
        void FillEmployeeInfo(int EmployeeID)
        {
            txtDepartmentManagerID.Text = EmployeeID.ToString();
        }
        private void btnSelectEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeSelectList frmEmployeeList = new frmEmployeeSelectList(lblDepartmentName.Text);
            frmEmployeeList.EmployeeIDSelected += FillEmployeeInfo;

            frmEmployeeList.MdiParent = clsMDIParent.MDIPARENT;
            frmEmployeeList.Dock = DockStyle.Fill;
            try
            {
                frmEmployeeList.Show();
            }
            catch { }
        }
    }
}
