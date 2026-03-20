using HMS.Add_Edit.AddEditPerson;
using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
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

namespace HMS.Add_Edit
{
    public partial class ctrlAddEditEmployee : ctrlAddEditPerson
    {
        protected int InheritedID=-1;
        public ctrlAddEditEmployee()
        {
            InitializeComponent();

            FillDebpartmentCMB();
            FillStateCMB();
        }
        void FillDebpartmentCMB()
        {

            cmbDepartment.Items.Clear();
            DataTable dt = clsDeparmtments.GetAllDepartments();
            foreach (DataRow dr in dt.Rows)
            {
                cmbDepartment.Items.Add(dr["DepartmentName"]);


            }
            cmbDepartment.SelectedIndex = 0;
        }
        void FillStateCMB()
        {

            cmbState.Items.Clear();
            cmbState.Items.Add("Working");
            cmbState.Items.Add("Fired");

            cmbState.SelectedIndex = 0;
        }

        private void ctrlAddEditEmployee_Load(object sender, EventArgs e)
        {

        }

        private void btnGetPhotoPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                txtPhotoPath.Text = openFileDialog1.FileName;


                pictureBox1.BackgroundImage = Image.FromFile(txtPhotoPath.Text);
            }
        }
        void FillEmployeeState(clsEmployees.enState state) {
            if(state==clsEmployees.enState.enWorking)
            cmbState.SelectedIndex = cmbState.Items.IndexOf("Working");
            else
                cmbState.SelectedIndex = cmbState.Items.IndexOf("Fired");


        }
        protected void FillLoginInfo(clsLogins login)
        {

            txtLoginName.Text = login.LoginName;
            txtPhotoPath.Text = login.PhotoPath;
            if (!string.IsNullOrEmpty(txtPhotoPath.Text))
            {
                pictureBox1.BackgroundImage = Image.FromFile(login.PhotoPath);
            }

        }
        protected void FillEmployeeInfo(int EmployeeID)
        {
            InheritedID = EmployeeID; 
            clsEmployees Employees=clsEmployees.FindByID(EmployeeID);
            lblID.Text = EmployeeID.ToString();
            txtSalery.Text = Convert.ToString(Employees.Salery);
            cmbDepartment.SelectedIndex = cmbDepartment.Items.IndexOf(clsDeparmtments.FindDepartmentByID(Employees.DepartmentID).DepartmentName);
            lblWorkingDays.Text=Convert.ToString(Employees.WorkingDays);
            FillEmployeeState(Employees.EmployeeState);
            dtpEmploymentDate.Value = Employees.EmploymentDate;
            if (Employees.DueDate != null)
                lblDueDate.Text = Employees.DueDate.ToString();
            clsLogins Login = clsLogins.FindLoginInfoByEmployeeID(Employees.EmplyeeID);
            if (Login != null)
            {
                FillLoginInfo(Login);
            }
            FillPersonInfo(Employees.PersonID);
        }
        override protected void FillInfo(int ID)
        {
            clsEmployees Employee = clsEmployees.FindByID(ID);

            if (ID != -1)
            {
                if (Employee != null)
                {

                    setAddEdit("Edit Employee");
                    _Mode = enMode.enUpdate;
                    FillPersonInfo(Employee.PersonID);
                    FillEmployeeInfo(Employee.EmplyeeID);
                    btnLoginInfo.Visible = true;
                    btnInheritedInfo.Visible = false;


                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Employee");
                    _Mode = enMode.enAddNew;
                    btnLoginInfo.Visible = false;
                    btnInheritedInfo.Visible = true;
                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Employee");
                _Mode = enMode.enAddNew;
                //new Record
                btnLoginInfo.Visible = false;


            }






        }

        private void btnLoginInfo_Click(object sender, EventArgs e)
        {
            if (gbLoginInfo.Visible)
            {

                gbLoginInfo.Visible = false;

            }
            else
            {
                gbLoginInfo.Visible = true;
            }
        }

       protected clsEmployees.enState setEmployeeState()
        {
            if (cmbState.SelectedItem.ToString() == "Working")
            {

                return clsEmployees.enState.enWorking;

            }
            else
            {
                return clsEmployees.enState.enFired;
            }



        }
        protected void AddNewEmployee(clsEmployees employee)
        {
            if(InheritedID==-1)
            {
                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
                employee.Phone = txtPhone.Text;
                employee.DateofBirth = dtpDateOfBirth.Value;
                employee.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
                employee.Account.AccountNum = txtAccountName.Text;
                if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
                {
                    employee.Account.AmmountOfMoney = Ammount;
                }
                employee.Account.Password = txtPassword.Text;
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    employee.Salery = salery;
                }
                //do not forget to modefy DepartmentID Access level to Protected
                employee.DepartmentID=clsDeparmtments.FindDepartmentByName(cmbDepartment.SelectedItem.ToString()).DepartmentID;
               
                employee.EmployeeState = setEmployeeState();
                employee.EmploymentDate=dtpEmploymentDate.Value;
               
                if (employee.SaveEmployee())
                {
                    ID = employee.EmplyeeID;
                   

                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(employee.Cause.ToString(), "Error");
                }

            }
            else
            {
                FillPersonInfo(InheritedID);
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    employee.Salery = salery;
                }
                //do not forget to modefy DepartmentID Access level to Protected
                employee.DepartmentID = clsDeparmtments.FindDepartmentByName(cmbDepartment.SelectedItem.ToString()).DepartmentID;
               
                employee.EmployeeState = setEmployeeState();
                employee.EmploymentDate = dtpEmploymentDate.Value;

                if (employee.SaveEmployee(InheritedID))
                {
                    ID = employee.EmplyeeID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(employee.Cause.ToString(), "Error");
                }



            }

          
        }
        protected void AddUpdateLogin(int EmployeeID)
        {
            clsEmployees Employee = clsEmployees.FindByID(EmployeeID);
            clsLogins Login = clsLogins.FindLoginInfoByEmployeeID(Employee.EmplyeeID);
            if (Login != null)
            {

                Login.LoginName=txtLoginName.Text;
                if (!string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    Login.Password = txtLoginPassword.Text;
                }
                Login.PhotoPath=txtPhotoPath.Text;
                if (!Login.Save())
                {

                    MessageBox.Show(Login.Cause.ToString(), "Error");

                }



            }
            else
            {
                Login=new clsLogins();
                Login.EmployeeID = Employee.EmplyeeID;
                Login.LoginName = txtLoginName.Text;
                Login.Password = txtLoginPassword.Text;
                Login.PhotoPath = txtPhotoPath.Text;
                if (!Login.Save())
                {

                    MessageBox.Show(Login.Cause.ToString(), "Error");

                }




            }



        }
        protected void UpdateEmployee(clsEmployees employee)
        {

            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            employee.Phone = txtPhone.Text;
            employee.DateofBirth = dtpDateOfBirth.Value;
            employee.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            employee.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
            {
                employee.Account.AmmountOfMoney = Ammount;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                employee.Account.Password = txtPassword.Text;
            }
            if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
            {
                employee.Salery = salery;
            }
            //do not forget to modefy DepartmentID Access level to Protected
            employee.DepartmentID = clsDeparmtments.FindDepartmentByName(cmbDepartment.SelectedItem.ToString()).DepartmentID;
           
            employee.EmployeeState = setEmployeeState();
            employee.EmploymentDate = dtpEmploymentDate.Value;

            if (employee.SaveEmployee(InheritedID))
            {
                ID = employee.EmplyeeID;
                if(!string.IsNullOrWhiteSpace(txtLoginName.Text))
                AddUpdateLogin(employee.EmplyeeID);

                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(employee.Cause.ToString(), "Error");
            }

        }


        override  protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsEmployees Employee = new clsEmployees();

                AddNewEmployee(Employee);
            }
            else
            {

                clsEmployees Employee = clsEmployees.FindByID(ID);
                UpdateEmployee(Employee);





            }
        }
       
        virtual protected void btnInheritedInfo_Click(object sender, EventArgs e)
        {
            frmPersonSelectList frmPerson = new frmPersonSelectList();

            frmPerson.OnPersonSelected += FillPersonInfo;
            frmPerson.MdiParent = clsMDIParent.MDIPARENT;
            frmPerson.Dock = DockStyle.Fill;
            try
            {
                frmPerson.Show();
            }
            catch { }
        }

        private void txtPhotoPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
