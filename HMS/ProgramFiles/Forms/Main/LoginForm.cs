using HosbitalBussinessLayer;
using HosbitalBussinessLayer.Logs.SystemLoginsAndLogs;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        void _ClearData()
        {
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;

        }
        private void button1_Click(object sender, EventArgs e)
        {


           clsLogins LoggedUser= clsLogins.FindLoginInfoByLohinName(txtUserName.Text);
            if(LoggedUser!=null)
            {
                if (clsProtect1.Compute(txtPassword.Text) == LoggedUser.Password)
                {
                    clsLogs logs = new clsLogs();
                    logs.LoginID = LoggedUser.ID;
logs.Save();
                   clsEmployees Employee= clsEmployees.FindByID(LoggedUser.EmployeeID);
                    if (Employee != null)
                    {
                        LoggedEmployee.LoggedEmployeeID = Employee.EmplyeeID;
                        switch (Employee.DepartmentID)
                        {

                            case (5):
                                if (clsDeparmtments.FindDepartmentByID(Employee.DepartmentID).DepartmentManagerID == Employee.EmplyeeID)
                                {
                                    this.Visible = false;
                                    HeadNurse headNurse = new HeadNurse(Employee.EmplyeeID);
                                    headNurse.ShowDialog();
                                    _ClearData();
                                    this.Visible=true;

                                }
                                else
                                {
                                    this.Visible = false;
                                    Nurse Nurse = new Nurse(Employee.EmplyeeID);
                                    Nurse.ShowDialog();
                                    _ClearData();
                                    this.Visible = true;


                                }
                                break;
                            case (6):
                                if (clsDeparmtments.FindDepartmentByID(Employee.DepartmentID).DepartmentManagerID == Employee.EmplyeeID)
                                {
                                    this.Visible = false;
                                    HeadPharmacist HeadPharmacist = new HeadPharmacist(Employee.EmplyeeID);
                                    HeadPharmacist.ShowDialog();
                                    _ClearData();
                                    this.Visible = true;

                                }
                                else
                                {
                                    this.Visible = false;
                                    Pharmacist Nurse = new Pharmacist(Employee.EmplyeeID);
                                    Nurse.ShowDialog();
                                    _ClearData();
                                    this.Visible = true;


                                }
                                break;
                            case (9):

                                if (clsDeparmtments.FindDepartmentByID(Employee.DepartmentID).DepartmentManagerID == Employee.EmplyeeID)
                                {
                                    this.Visible = false;
                                    HeadDoctor HeadDoctor = new HeadDoctor(Employee.EmplyeeID);
                                    HeadDoctor.ShowDialog();
                                    _ClearData();
                                    this.Visible = true;

                                }
                                else
                                {
                                    this.Visible = false;
                                    Doctor Doctor = new Doctor(Employee.EmplyeeID);
                                    Doctor.ShowDialog();
                                    _ClearData();

                                    this.Visible = true;


                                }
                                break;
                            case (10):

                                if (clsDeparmtments.FindDepartmentByID(Employee.DepartmentID).DepartmentManagerID == Employee.EmplyeeID)
                                {
                                    this.Visible = false;
                                    HeadAccountant HeadAccountant = new HeadAccountant(Employee.EmplyeeID);
                                    HeadAccountant.ShowDialog();
                                    _ClearData();

                                    this.Visible = true;

                                }
                                else
                                {
                                    this.Visible = false;
                                    Accountant Acountant = new Accountant(Employee.EmplyeeID);
                                    Acountant.ShowDialog();
                                    _ClearData();

                                    this.Visible = true;


                                }
                                break;

                        }
                    }




                }
                else
                {
                    MessageBox.Show("Wrong 0^0");


                }




            }
            else if(txtUserName.Text.ToLower()=="the admin1000"&txtPassword.Text.ToLower()=="also theadmin1000") {


                this.Visible = false;
                Admin Admin1 = new Admin();
                Admin1.ShowDialog();
                _ClearData();

                this.Visible = true;




            }







        }
    }
}
