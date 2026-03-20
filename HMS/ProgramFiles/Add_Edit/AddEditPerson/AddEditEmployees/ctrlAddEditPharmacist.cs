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

namespace HMS.Add_Edit.AddEditPerson.AddEditEmployees
{
    public partial class ctrlAddEditPharmacist : ctrlAddEditEmployee
    {
        public ctrlAddEditPharmacist()
        {
            InitializeComponent();
        }
        private void ctrlAddEditPharmacist_Load(object sender, EventArgs e)
        {

        }
        override protected void FillInfo(int ID)
        {
            clsPharmacists Pharmacist = clsPharmacists.FindByID(ID);

            if (ID != -1)
            {
                if (Pharmacist != null)
                {

                    setAddEdit("Edit Pharmacist");
                    _Mode = enMode.enUpdate;
                    FillPersonInfo(Pharmacist.PersonID);
                    FillEmployeeInfo(Pharmacist.EmplyeeID);
                    lblID.Text = Pharmacist.PharmacistID.ToString();
                    btnLoginInfo.Visible = true;
                    btnInheritedInfo.Visible = false;


                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Pharmacist");
                    _Mode = enMode.enAddNew;
                    btnLoginInfo.Visible = false;
                    btnInheritedInfo.Visible = true;
                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Pharmacist");
                _Mode = enMode.enAddNew;
                //new Record
                btnLoginInfo.Visible = false;


            }






        }

     
        protected void AddNewPharmacist(clsPharmacists Pharmacist)
        {
            if (InheritedID == -1)
            {
                Pharmacist.FirstName = txtFirstName.Text;
                Pharmacist.LastName = txtLastName.Text;
                Pharmacist.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
                Pharmacist.Phone = txtPhone.Text;
                Pharmacist.DateofBirth = dtpDateOfBirth.Value;
                Pharmacist.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
                Pharmacist.Account.AccountNum = txtAccountName.Text;
                if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
                {
                    Pharmacist.Account.AmmountOfMoney = Ammount;
                }
                Pharmacist.Account.Password = txtPassword.Text;
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Pharmacist.Salery = salery;
                }

                Pharmacist.EmploymentDate = dtpEmploymentDate.Value;

                if (Pharmacist.SavePharmacist())
                {
                    ID = Pharmacist.PharmacistID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Pharmacist.Cause.ToString(), "Error");
                }

            }
            else
            {
                if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
                {
                    Pharmacist.Salery = salery;
                }
                //do not forget to modefy DepartmentID Access level to Protected


                if (Pharmacist.SavePharmacist(InheritedID))
                {
                    ID = Pharmacist.PharmacistID;


                    FillInfo(ID);

                }
                else
                {
                    MessageBox.Show(Pharmacist.Cause.ToString(), "Error");
                }



            }


        }

        protected void UpdatePharmacist(clsPharmacists Pharmacist)
        {

            Pharmacist.FirstName = txtFirstName.Text;
            Pharmacist.LastName = txtLastName.Text;
            Pharmacist.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Pharmacist.Phone = txtPhone.Text;
            Pharmacist.DateofBirth = dtpDateOfBirth.Value;
            Pharmacist.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Pharmacist.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text), out double Ammount))
            {
                Pharmacist.Account.AmmountOfMoney = Ammount;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                Pharmacist.Account.Password = txtPassword.Text;
            }
            if (double.TryParse(Convert.ToString(txtSalery.Text), out double salery))
            {
                Pharmacist.Salery = salery;
            }
            //do not forget to modefy DepartmentID Access level to Protected

            Pharmacist.EmployeeState = setEmployeeState();

            if (Pharmacist.SavePharmacist())
            {
                ID = Pharmacist.PharmacistID;
                if (!string.IsNullOrWhiteSpace(txtLoginName.Text))
                    AddUpdateLogin(Pharmacist.EmplyeeID);

                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Pharmacist.Cause.ToString(), "Error");
            }

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
        override protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsPharmacists Pharmacist = new clsPharmacists();

                AddNewPharmacist(Pharmacist);
            }
            else
            {

                clsPharmacists Pharmacist = clsPharmacists.FindByID(ID);
                UpdatePharmacist(Pharmacist);





            }
        }

    }
}
