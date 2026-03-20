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
    public partial class ctrlAddEditPerson : ctrlAddEditBase
    {
        string AccountPassword = "";
        protected int InheritedID=-1;
        public ctrlAddEditPerson()
        {
            InitializeComponent();
            _FillCountryComboBox();
            cmbGender.SelectedIndex = 0;    
        }
        void _FillCountryComboBox()
        {

            cmbCountry.Items.Clear();
            DataTable dt = clsCountries.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {

                cmbCountry.Items.Add(dr["CountryName"]);

            }
            cmbCountry.SelectedIndex = 0;
        }
        protected void SelectCountry(string CountryName)
        {
           cmbCountry.SelectedIndex= cmbCountry.Items.IndexOf(CountryName);

        }
        protected void SelectGender(char Gender)
        {
            cmbGender.SelectedIndex = cmbGender.Items.IndexOf(Convert.ToString(Gender));

        }
        protected void FillPersonInfo(int PersonID)
        {
            clsPerson person=clsPerson.FindByID(PersonID);
            InheritedID = person.PersonID;
            lblID.Text = Convert.ToString(ID);
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtPhone.Text = person.Phone;
            txtAmmountOfMoney.Text = Convert.ToString(person.Account.AmmountOfMoney);
            SelectCountry(clsCountries.FindCountryByID(person.CountryID).CountryName);
            dtpDateOfBirth.Value = person.DateofBirth;
            //txtPassword.Text = person.Account.Password.Trim();
            AccountPassword = person.Account.Password;
            txtAccountName.Text = person.Account.AccountNum;
            lblAccountID.Text = Convert.ToString(person.Account.AccountID);
            SelectGender(person.Gender);
            




        }
   override      protected void FillInfo(int ID)
        {
            clsPerson person = clsPerson.FindByID(ID);

            if (ID != -1)
            {
                if (person != null)
                {

                    setAddEdit("Edit Person");
                        _Mode = enMode.enUpdate;
                    FillPersonInfo(person.PersonID);
                    //FillInfo

                }
                else
                {
                    setAddEdit("Add New Person");
                        _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Person");
                _Mode = enMode.enAddNew;
                //new Record


            }






        }
        private void ctrlAddEditPerson_Load(object sender, EventArgs e)
        {
            
            FillInfo(ID);


        }
       protected void AddNewPerson(clsPerson Person)
        {
            Person.FirstName = txtFirstName.Text;
            Person.LastName = txtLastName.Text;
            Person.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Person.Phone = txtPhone.Text;
            Person.DateofBirth = dtpDateOfBirth.Value;
            Person.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Person.Account.AccountNum = txtAccountName.Text;
            if (double.TryParse(Convert.ToString(txtAmmountOfMoney.Text),out double Ammount))
            {
                Person.Account.AmmountOfMoney = Ammount;
            }
            Person.Account.Password = txtPassword.Text;
            if (Person.SavePerson())
            {
                ID = Person.PersonID;
                FillInfo(ID);

            }
            else
            {
                MessageBox.Show(Person.Cause.ToString(), "Error");
            }
        }
        protected void UpdatePerson(clsPerson Person)
        {
            Person.FirstName = txtFirstName.Text;
            Person.LastName = txtLastName.Text;
            Person.Gender = Convert.ToChar(cmbGender.SelectedItem.ToString());
            Person.Phone = txtPhone.Text;
            Person.DateofBirth = dtpDateOfBirth.Value;
            Person.CountryID = clsCountries.FindCountryByName(cmbCountry.SelectedItem.ToString()).CountryID;
            Person.Account.AccountNum = txtAccountName.Text;
            if (!string.IsNullOrWhiteSpace(txtAmmountOfMoney.Text))
            {
                Person.Account.AmmountOfMoney = Convert.ToDouble(txtAmmountOfMoney.Text);
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            { Person.Account.Password = txtPassword.Text; }
            if (Person.SavePerson())
            {
                FillInfo(Person.PersonID);

            }
            else
            {
                MessageBox.Show(Person.Cause.ToString(), "Error");
            }
        }

        virtual protected void btnSave_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.enAddNew)
            {
                clsPerson Person=new clsPerson();

                AddNewPerson(Person);
            }
            else
            {

                clsPerson Person =clsPerson.FindByID(ID);
                UpdatePerson(Person);





            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenAccountInfo_Click(object sender, EventArgs e)
        {

            if (ID == -1)
            {
                if (gbAccountInfo.Visible)
                {

                    gbAccountInfo.Visible = false;


                }
                else
                {
                    gbAccountInfo.Visible = true;
                }
            }
            else
            {
                if (clsProtect1.Compute(txtPasswordCheck.Text) ==AccountPassword )
                {

                    if (gbAccountInfo.Visible)
                    {

                        gbAccountInfo.Visible = false;


                    }
                    else
                    {
                        gbAccountInfo.Visible = true;
                    }


                }



            }
        }
    }
}
