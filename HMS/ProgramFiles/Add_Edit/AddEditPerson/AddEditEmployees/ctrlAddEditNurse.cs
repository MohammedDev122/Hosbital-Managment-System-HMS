using HosbitalBussinessLayer.DerivedTables;
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
using System.Threading;

namespace HMS.Add_Edit.AddEditPerson.AddEditEmployees
{
    public partial class ctrlAddEditNurse : ctrlAddEditEmployee
    {
        public ctrlAddEditNurse()
        {
            InitializeComponent();
        }
        override protected void FillInfo(int ID)
        {
            clsNurses Nurse = clsNurses.FindByID(ID);

            if (ID != -1)
            {
                if (Nurse != null)
                {

                    setAddEdit("Edit Nurse");
                    _Mode = enMode.enUpdate;
                    FillPersonInfo(Nurse.PersonID);
                    FillEmployeeInfo(Nurse.EmplyeeID);
                    lblID.Text = Nurse.NurseID.ToString();
                    btnLoginInfo.Visible = true;
                    btnInheritedInfo.Visible = false;


                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Nurse");
                    _Mode = enMode.enAddNew;
                    btnLoginInfo.Visible = false;
                    btnInheritedInfo.Visible = true;
                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Nurse");
                _Mode = enMode.enAddNew;
                //new Record
                btnLoginInfo.Visible = false;


            }






        }


        protected void AddNewNurse(clsNurses Nurse)
        {
            if (InheritedID == -1)
            {
                Nurse.FirstName = txtFirstName.Text;
                Nurse.LastName = txtLastName.Text;
                Nurse.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
                Nurse.Phone = txtPhone.Text;
                Nurse.DateofBirth = dtpDateOfBirth.Value;
                Nurse.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
                Nurse.Account.AccountNum = txtAccountName.Text;
                if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
                {
                    Nurse.Account.AmmountOfMoney = Ammount;
                }
                Nurse.Account.Password = txtPassword.Text;
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Nurse.Salery = salery;
                }

                Nurse.EmploymentDate = dtpEmploymentDate.Value;

                if (Nurse.SaveNurse())
                {
                    ID = Nurse.NurseID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Nurse.Cause.ToString(), "Error");
                }

            }
            else
            {
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Nurse.Salery = salery;
                }
                //do not forget to modefy DepartmentID Access level to Protected

                clsEmployees employee = clsEmployees.FindByID(InheritedID);
                if (Nurse.SaveNurse(employee.PersonID))
                {
                    ID = Nurse.NurseID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Nurse.Cause.ToString(), "Error");
                }



            }


        }

        protected void UpdateNurse(clsNurses Nurse)
        {

            Nurse.FirstName = txtFirstName.Text;
            Nurse.LastName = txtLastName.Text;
            Nurse.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Nurse.Phone = txtPhone.Text;
            Nurse.DateofBirth = dtpDateOfBirth.Value;
            Nurse.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Nurse.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
            {
                Nurse.Account.AmmountOfMoney = Ammount;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {       Nurse.Account.Password = txtPassword.Text;
        }
            if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
            {
                Nurse.Salery = salery;
            }
            //do not forget to modefy DepartmentID Access level to Protected

            Nurse.EmployeeState = setEmployeeState();

            if (Nurse.SaveNurse())
            {
                ID = Nurse.NurseID;
                if (!string.IsNullOrWhiteSpace(txtLoginName.Text))
                    AddUpdateLogin(Nurse.EmplyeeID);

                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Nurse.Cause.ToString(), "Error");
            }

        }



        override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsNurses Nurse = new clsNurses();

                AddNewNurse(Nurse);
            }
            else
            {

                clsNurses Nurse = clsNurses.FindByID(ID);
                UpdateNurse(Nurse);





            }
        }
        override protected void btnInheritedInfo_Click(object sender, EventArgs e)
        {
            frmEmployeeSelectList frmEmployeeList = new frmEmployeeSelectList(clsDeparmtments.FindDepartmentByID(5).DepartmentName);
            frmEmployeeList.EmployeeIDSelected += FillEmployeeInfo;
            frmEmployeeList.MdiParent = clsMDIParent.MDIPARENT;
            frmEmployeeList.Dock = DockStyle.Fill;
            try
            {
                frmEmployeeList.Show();
            }
            catch { }
            //if (InheritedID != -1)
            //{
            //    int EmployeeID = InheritedID;
            //    clsEmployees Employee = clsEmployees.FindByID(EmployeeID);
            //    FillPersonInfo(Employee.PersonID);
            //    InheritedID = Employee.PersonID;
            //}

        }

        private void ctrlAddEditNurse_Load(object sender, EventArgs e)
        {

        }
    }
}
