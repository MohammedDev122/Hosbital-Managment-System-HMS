using HosbitalBussinessLayer.DerivedTables;
using HosbitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    /// <summary>
    /// Manages Person's Info
    /// </summary>
    [Documentation("this class is used to Manage person's info and it is the Base Class for all the Users in the system")]

    public class clsPerson
    {
        public int PersonID { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateofBirth { get; set; }
        public char Gender { get; set; }
        [Documentation("every person in the system has his own Account info and You Can Reach it and update it's info from this class or it's Spacific Class")]
        public clsBankAccount Account;
        [Documentation("sets the view level on which you want to retrive the data")]

        public clsViews.enShowing Showing;

        public int CountryID {  get;  set; }
        /// <summary>
        /// Indicates why saving the Person Info failed.
        /// </summary>
        public clsFailCauses.enPersonsFailCauses Cause {  get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] protected set; }
        protected enum enMode { enUpdate, enAddNew };
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        protected enMode Mode = enMode.enAddNew;
        [Documentation("this is used to assign the object from the Code")]

        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Phone = "";
            this.DateofBirth = DateTime.Now;
            this.Gender = ' ';
            this.Account = new clsBankAccount();
            CountryID = -1;
            Mode = enMode.enAddNew;

        }
        [Documentation(@"this Is Used to Assign The object After Getting It's Data from Database,it Manages most of the Data for all the classes that inherits from it 
")]
        protected clsPerson(int PersonID, string FirstName, string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account,int CountryID)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.DateofBirth = DateofBirth;
            this.Gender = Gender;
            this.Account = account;
            this.CountryID = CountryID;
            Mode = enMode.enUpdate;

        }
        public static clsPerson FindByID(int PersonID)
        {


            string FirstName = "";
            string LastName = "";
            string Phone = "";
            DateTime DateofBirth = DateTime.Now;
            char Gender = ' ';
            int AccountID = -1;
            int CountryID = -1;
            if (clsPersonDAL.GetPersonInfoByID(PersonID, ref FirstName, ref LastName, ref Phone, ref DateofBirth, ref Gender, ref AccountID,ref CountryID))
            {

                return new clsPerson(PersonID, FirstName, LastName, Phone, DateofBirth, Gender, clsBankAccount.FindAccountByID(AccountID), CountryID);
            }
            else
                return null;

        }
       
        public static DataTable GetAll(clsViews.enShowing showing)
        {
            return clsPersonDAL.GetAllPersons();
        }
      


        bool _CheckIfDataIsCorrect()
        {


            if (FirstName.Length == 0)
            {
                Cause = clsFailCauses.enPersonsFailCauses.enFirstNameIsTooShort;
                return false;
            }
            if (LastName.Length == 0)
            {
                Cause = clsFailCauses.enPersonsFailCauses.enLastNameIsTooShort;
                return false;
            }
            if(!Int64.TryParse(Phone,out Int64 PhoneNum))
            {
                Cause = clsFailCauses.enPersonsFailCauses.enPhoneNumCantHoldAnyChar;
                return false;

            }
            if (DateofBirth > DateTime.Now)
            {
                Cause = clsFailCauses.enPersonsFailCauses.enDateOfBirthIsWrong;
                return false;
            }
            if (!clsCountries.Exist(CountryID))
            {
                return false;
            }
            
            return true;

            }
        bool _AddNew()
        {
            if (_CheckIfDataIsCorrect())
            {
                if (Account.Save())
                {

                    this.PersonID = clsPersonDAL.AddNewPerson(this.FirstName, this.LastName, this.Phone, this.DateofBirth, this.Gender
                        , this.Account.AccountID,this.CountryID);
                }
                else
                {
                    Cause = (clsFailCauses.enPersonsFailCauses)Account.FailCause; 
                }
            }
            
            if(this.PersonID == -1)
            {
                clsRoleBack.DeleteAccount(this.Account.AccountID);
                return false;
            }
            else
            {
                return true;
            }

        }
        bool _Update()
        {
            if (_CheckIfDataIsCorrect()) { 
                if (Account.Save())
                {
                    return clsPersonDAL.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.Phone, this.DateofBirth, this.Gender,this.CountryID
                        );
                }
                else
                {
                    Cause= (clsFailCauses.enPersonsFailCauses)Account.FailCause;
                }
       }
            return false;
        }
        /// <summary>
        /// Saves the Person's information to the database.
        /// </summary>
        /// <returns></returns>
        [Documentation("we didnt override the method in the child classes to make them save only thier data and to make this class take responsiblity of it's data")]

        public bool SavePerson()
        {

            switch (Mode)
            {
                case (enMode.enAddNew):
                    if (_AddNew())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_Update())
                        return true;
                    else
                        return false;
            }

            return false;
        }
        public static bool Exist(int personID)
        {
            return clsPersonDAL.IsExist(personID);
        }
       
    }
}
