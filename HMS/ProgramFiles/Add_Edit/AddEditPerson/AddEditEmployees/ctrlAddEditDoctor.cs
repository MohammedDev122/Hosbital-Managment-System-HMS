using HosbitalBussinessLayer;
using HosbitalBussinessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Add_Edit.AddEditPerson
{
    public partial class ctrlAddEditDoctor : ctrlAddEditEmployee
    {
        public ctrlAddEditDoctor()
        {
            InitializeComponent();
            FillSpecilizationCMB();
        }
        void FillSpecilizationCMB()
        {

            cmbSpecilization.Items.Clear();
            DataTable dt =clsSpecilization.GetAllSpecilizations();
            foreach (DataRow dr in dt.Rows) {
                cmbSpecilization.Items.Add(dr["Specilization"]);
            
            
            
            }

            cmbSpecilization.SelectedIndex = 0;
        }
        override protected void FillInfo(int ID)
        {
            clsDoctors Doctor = clsDoctors.FindByID(ID);

            if (ID != -1)
            {
                if (Doctor != null)
                {

                    setAddEdit("Edit Doctor");
                    _Mode = enMode.enUpdate;
                    FillPersonInfo(Doctor.PersonID);
                    FillEmployeeInfo(Doctor.EmplyeeID);
                    lblID.Text = Doctor.DoctorID.ToString();
                    cmbSpecilization.SelectedIndex = cmbSpecilization.Items.IndexOf(clsSpecilization.FindSpecilizationByID(Doctor.SpecilizationID).SpecilizationName);
                    btnLoginInfo.Visible = true;
                    btnInheritedInfo.Visible = false;


                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Doctor");
                    _Mode = enMode.enAddNew;
                    btnLoginInfo.Visible = false;
                    btnInheritedInfo.Visible = true;
                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Doctor");
                _Mode = enMode.enAddNew;
                //new Record
                btnLoginInfo.Visible = false;


            }






        }


        protected void AddNewDoctor(clsDoctors Doctor)
        {
            if (InheritedID == -1)
            {
                Doctor.FirstName = txtFirstName.Text;
                Doctor.LastName = txtLastName.Text;
                Doctor.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
                Doctor.Phone = txtPhone.Text;
                Doctor.DateofBirth = dtpDateOfBirth.Value;
                Doctor.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
                Doctor.Account.AccountNum = txtAccountName.Text;
                if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
                {
                    Doctor.Account.AmmountOfMoney = Ammount;
                }
                Doctor.Account.Password = txtPassword.Text;
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Doctor.Salery = salery;
                }
                if (cmbSpecilization.SelectedItem != null)
                {
                    Doctor.SpecilizationID = clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;
                }
              
                if (Doctor.SaveDoctor())
                {
                    ID = Doctor.DoctorID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Doctor.Cause.ToString(), "Error");
                }

            }
            else
            {
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Doctor.Salery = salery;
                }
                //do not forget to modefy DepartmentID Access level to Protected

                if (cmbSpecilization.SelectedItem != null)
                {
                    Doctor.SpecilizationID = clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;
                }
                if (Doctor.SaveDoctor(clsEmployees.FindByID(InheritedID).PersonID))
                {
                    ID = Doctor.DoctorID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Doctor.Cause.ToString(), "Error");
                }



            }


        }

        protected void UpdateDoctor(clsDoctors Doctor)
        {

            Doctor.FirstName = txtFirstName.Text;
            Doctor.LastName = txtLastName.Text;
            Doctor.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Doctor.Phone = txtPhone.Text;
            Doctor.DateofBirth = dtpDateOfBirth.Value;
            Doctor.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Doctor.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
            {
                Doctor.Account.AmmountOfMoney = Ammount;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                Doctor.Account.Password = txtPassword.Text;
            }
            if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
            {
                Doctor.Salery = salery;
            }
            //do not forget to modefy DepartmentID Access level to Protected

            Doctor.EmployeeState = setEmployeeState();
            Doctor.SpecilizationID = clsSpecilization.FindSpecilizationByName(cmbSpecilization.SelectedItem.ToString()).SpecilizationID;

            if (Doctor.SaveDoctor())
            {
                ID = Doctor.DoctorID;
                if (!string.IsNullOrWhiteSpace(txtLoginName.Text))
                    AddUpdateLogin(Doctor.EmplyeeID);

                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Doctor.Cause.ToString(), "Error");
            }

        }



        override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsDoctors Doctor = new clsDoctors();

                AddNewDoctor(Doctor);
            }
            else
            {

                clsDoctors Doctor = clsDoctors.FindByID(ID);
                UpdateDoctor(Doctor);





            }
        }
        private void ctrlAddEditDoctor_Load(object sender, EventArgs e)
        {

        }

     override   protected void btnInheritedInfo_Click(object sender, EventArgs e)
        {
            frmEmployeeSelectList frmEmployeeList = new frmEmployeeSelectList(clsDeparmtments.FindDepartmentByID(9).DepartmentName);
            frmEmployeeList.EmployeeIDSelected += FillEmployeeInfo;

            frmEmployeeList.MdiParent = clsMDIParent.MDIPARENT;
            frmEmployeeList.Dock = DockStyle.Fill;
            try
            {
                frmEmployeeList.Show();
                if (InheritedID != -1)
                {
                    int EmployeeID = InheritedID;
                    clsEmployees Employee = clsEmployees.FindByID(EmployeeID);
                    FillPersonInfo(Employee.PersonID);
                    InheritedID = Employee.PersonID;
                }
            }
            catch { }

        }

        private void btnInheritedInfo_Click_1(object sender, EventArgs e)
        {

        }

     
    }
}
