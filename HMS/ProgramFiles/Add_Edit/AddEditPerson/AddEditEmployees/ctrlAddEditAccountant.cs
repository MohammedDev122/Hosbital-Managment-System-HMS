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

namespace HMS.Add_Edit.AddEditPerson.AddEditEmployees
{
    public partial class ctrlAddEditAccountant : ctrlAddEditEmployee
    {
        public ctrlAddEditAccountant()
        {
            InitializeComponent();
        }
        override protected void FillInfo(int ID)
        {
            clsAccountant Accountant = clsAccountant.FindByID(ID);

            if (ID != -1)
            {
                if (Accountant != null)
                {

                    setAddEdit("Edit Accountant");
                    _Mode = enMode.enUpdate;
                    FillPersonInfo(Accountant.PersonID);
                    FillEmployeeInfo(Accountant.EmplyeeID);
                    lblID.Text = Accountant.AccountantID.ToString();
                    btnLoginInfo.Visible = true;
                    btnInheritedInfo.Visible = false;


                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Accountant");
                    _Mode = enMode.enAddNew;
                    btnLoginInfo.Visible = false;
                    btnInheritedInfo.Visible = true;
                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Accountant");
                _Mode = enMode.enAddNew;
                //new Record
                btnLoginInfo.Visible = false;


            }






        }


        protected void AddNewAccountant(clsAccountant Accountant)
        {
            if (InheritedID == -1)
            {
                Accountant.FirstName = txtFirstName.Text;
                Accountant.LastName = txtLastName.Text;
                Accountant.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
                Accountant.Phone = txtPhone.Text;
                Accountant.DateofBirth = dtpDateOfBirth.Value;
                Accountant.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
                Accountant.Account.AccountNum = txtAccountName.Text;
                if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
                {
                    Accountant.Account.AmmountOfMoney = Ammount;
                }
                Accountant.Account.Password = txtPassword.Text;
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Accountant.Salery = salery;
                }

                Accountant.EmploymentDate = dtpEmploymentDate.Value;

                if (Accountant.SaveAccountant())
                {
                    ID = Accountant.AccountantID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Accountant.Cause.ToString(), "Error");
                }

            }
            else
            {
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Accountant.Salery = salery;
                }
                //do not forget to modefy DepartmentID Access level to Protected


                if (Accountant.SaveAccountant(InheritedID))
                {
                    ID = Accountant.AccountantID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Accountant.Cause.ToString(), "Error");
                }



            }


        }

        protected void UpdateAccountant(clsAccountant Accountant)
        {

            Accountant.FirstName = txtFirstName.Text;
            Accountant.LastName = txtLastName.Text;
            Accountant.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Accountant.Phone = txtPhone.Text;
            Accountant.DateofBirth = dtpDateOfBirth.Value;
            Accountant.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Accountant.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
            {
                Accountant.Account.AmmountOfMoney = Ammount;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                Accountant.Account.Password = txtPassword.Text;
            }
            if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
            {
                Accountant.Salery = salery;
            }
            //do not forget to modefy DepartmentID Access level to Protected

            Accountant.EmployeeState = setEmployeeState();

            if (Accountant.SaveAccountant())
            {
                ID = Accountant.AccountantID;
                if (!string.IsNullOrWhiteSpace(txtLoginName.Text))
                    AddUpdateLogin(Accountant.EmplyeeID);

                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Accountant.Cause.ToString(), "Error");
            }

        }



        override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsAccountant Accountant = new clsAccountant();

                AddNewAccountant(Accountant);
            }
            else
            {

                clsAccountant Accountant = clsAccountant.FindByID(ID);
                UpdateAccountant(Accountant);





            }
        }
        private void ctrlAddEditAccountant_Load(object sender, EventArgs e)
        {

        }
        override protected void btnInheritedInfo_Click(object sender, EventArgs e)
        {
            frmEmployeeSelectList frmEmployeeList = new frmEmployeeSelectList(clsDeparmtments.FindDepartmentByID(10).DepartmentName);
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
    }
}
