using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.DerivedTables
{
    [Documentation("this Class Is Used To Manage All The Countries That users in the system are from")]
    public  class clsCountries
    {
        public int CountryID { get; [Documentation("This Var Is Private To Make It only readable.")]
            private set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
      
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        [Documentation("this is used to assign the object from the Code")]
        public clsCountries()
        {
            this.CountryID = -1;
            this.CountryName = "";
            this.CountryCode = "";
           
            Mode = enMode.enAddNew;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsCountries(int CountryID, string CountryName, string CountryCode)
        {
            this.CountryID =     CountryID;
            this.CountryName = CountryName;
            this.CountryCode = CountryCode;
          

            Mode = enMode.enUpdate;

        }
        static public clsCountries FindCountryByID(int CountryID)
        {
            string  CountryName= "";
            string CountryCode = "";
            if (clsCountriesDAL.GetCountryInfoByID(CountryID, ref CountryName, ref CountryCode))
            {
                return new clsCountries(CountryID, CountryName, CountryCode);
            }

            return null;



        }
        static public clsCountries FindCountryByName(string CountryName)
        {
            int CountryID = -1;
            string CountryCode = "";
            if (clsCountriesDAL.GetCountryInfoByName(CountryName, ref CountryID, ref CountryCode))
            {
                return new clsCountries(CountryID, CountryName, CountryCode);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {


            if (CountryName.Length == 0 )
            {
                return false;
            }

            if (this.CountryCode.Length == 0)
            {
                return false;
            }
          
            return true;

        }
        bool _AddNewCountry()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.CountryID = clsCountriesDAL.AddNewCountry(this.CountryName, this.CountryCode);
            }
            return this.CountryID != -1;



        }
        /// <summary>
        ///  Used To Save The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>
        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewCountry())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateCountry())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdateCountry()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsCountriesDAL.UpdateCountryInfo(this.CountryID, this.CountryName, this.CountryCode);
            }
            return false;
        }
        static public DataTable GetAllCountries()
        {

            return clsCountriesDAL.GetAllCountries();
        }
        static public bool Exist(int CountryID)
        {
            return clsCountriesDAL.IsExist(CountryID);
        }

    }
}
