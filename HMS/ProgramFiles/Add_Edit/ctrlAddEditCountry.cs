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

namespace HMS.Add_Edit
{
    public partial class ctrlAddEditCountry : ctrlAddEditBase
    {
        public ctrlAddEditCountry()
        {
            InitializeComponent();
        }
        protected void FillCountryInfo(int CountryID)
        {
            clsCountries Country = clsCountries.FindCountryByID(CountryID);
            if (Country != null)
            {
                lblID.Text = Convert.ToString(CountryID);

                txtCountryName.Text = Country.CountryName;
              
                txtCountryCode.Text = Country.CountryCode;

            }

        }

        override protected void FillInfo(int ID)
        {
            clsCountries Country = clsCountries.FindCountryByID(ID);

            if (ID != -1)
            {
                if (Country != null)
                {

                    setAddEdit("Edit Country");
                    _Mode = enMode.enUpdate;
                    FillCountryInfo(Country.CountryID);

                    //FillInfo


                }
                else
                {
                    setAddEdit("Add New Country");
                    _Mode = enMode.enAddNew;

                }

            }
            if (ID == -1)
            {
                setAddEdit("Add New Country");
                _Mode = enMode.enAddNew;

                //new Record


            }






        }

        protected void UpdateCountry(clsCountries Country)
        {

           


                Country.CountryName = txtCountryName.Text;

                Country.CountryCode = txtCountryCode.Text;

            

            if (Country.Save())
            {
                FillInfo(Country.CountryID);

            }
           
        }
        protected void AddNewCountry(clsCountries Country)
        {




            Country.CountryName = txtCountryName.Text;

            Country.CountryCode = txtCountryCode.Text;



            if (Country.Save())
            {
                FillInfo(Country.CountryID);

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enAddNew)
            {
                clsCountries Country =new clsCountries();
                AddNewCountry(Country);
                FillInfo(Country.CountryID);
            }
            else
            {

                clsCountries Country = clsCountries.FindCountryByID(ID);
                UpdateCountry(Country);
                FillInfo(Country.CountryID);




            }

           





        }






        private void ctrlAddEditDepartments_Load(object sender, EventArgs e)
        {

        }

    
        private void ctrlAddEditCountry_Load(object sender, EventArgs e)
        {

        }
    }
}
