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
    public partial class ctrlPersonInfo : UserControl
    {
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }


     protected   void FillPersonInfo(clsPerson person)
        {
            lblAccount.Text = Convert.ToString(person.Account.AccountID);
            lblPersonID.Text = Convert.ToString(person.PersonID);
            lblName.Text = Convert.ToString(person.FirstName) + " " + Convert.ToString(person.LastName);
            lblPhone.Text = Convert.ToString(person.Phone);
            lblDateOfBirth.Text = Convert.ToString(person.DateofBirth);
            lblGender.Text = Convert.ToString(person.Gender);
            lblCountryID.Text = Convert.ToString(person.CountryID);


        }
        protected void EmptyAllPersonRec()
        {
            lblAccount.Text ="-";
            lblPersonID.Text = "-";
            lblName.Text = "-";
            lblPhone.Text = "-";
            lblDateOfBirth.Text = "-";
            lblGender.Text = "-";
            lblCountryID.Text = "-";


        }
        virtual  protected void lblSearch_Click(object sender, EventArgs e)
        {
            int personID = -1;
            if (int.TryParse(Convert.ToString(txtSearch.Text), out int ID))
            {
                personID = ID;
                clsPerson person = clsPerson.FindByID(personID);
                if (person != null)
                {


                    FillPersonInfo(person);



                }
                else
                {
                    EmptyAllPersonRec();
                }




            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
