using HosbitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Documentationattribute;

namespace HosbitalBussinessLayer
{

    /// <summary>
    /// Manages Bank Info For  Users
    /// </summary>
    [Documentation("manages all bank Accounts of Users within the system")]
    public class clsBankAccount
    {






        public int AccountID
        {
            get;
            [Documentation("This Var Is Private To Make It only readable.")]
            private set; }

        public string AccountNum {  get; set; }
        
        private string _AccountNum {[Documentation("this var is used to make Sure The Account Number Remain Unchanged once it is assigned")] get; set; }
        public string Password {  get; set; }
        public double AmmountOfMoney {  get; set; }
        
        enum enMode { enAddNew,enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]
        enMode Mode=enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the account failed.
        /// /// </summary>
        public clsFailCauses.enBankAccountsFailCause FailCause
        {
            [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            get; private set; }
        [Documentation("this is used to assign the object from the Code")]
        public clsBankAccount()
        {

           this.AccountID = -1;
            this.AccountNum = "";
            this._AccountNum = "";
            this.Password = "";
            this.AmmountOfMoney = 0;
            Mode = enMode.enAddNew;
            FailCause= clsFailCauses.enBankAccountsFailCause.enUnkownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]
        private clsBankAccount(int AccountID, string AccountNum,double AmmountOfMoney, string Password)
        {
            this.AccountID = AccountID;
            this.AccountNum = AccountNum;
            this._AccountNum = AccountNum;
            this.Password = Password;
            this.AmmountOfMoney = AmmountOfMoney;

            Mode = enMode.enUpdate;
            FailCause= clsFailCauses.enBankAccountsFailCause.enUnkownError;

        }
        
        static public clsBankAccount FindAccountByID(int AccountID)
        {
            
            string AccountNum = "";
            string Password = "";
            double AmmountOfMoney = 0;
            if (clsBanckAcountDAL.GetBankAccountInfoByID(AccountID, ref AccountNum, ref AmmountOfMoney, ref Password))
            {
                return new clsBankAccount(AccountID, AccountNum, AmmountOfMoney, Password);
            }

            return null;



        }
       
        bool _CheckIfDataIsCorrect()
        {
         
             
                if (AccountNum.Length == 0 || AccountNum.Length > 10)
                {
                FailCause = clsFailCauses.enBankAccountsFailCause.enAccountNumIsTooShortOrTooLong;
                    return false;
                }
            
            if (this.AmmountOfMoney < 0)
            {
                FailCause = clsFailCauses.enBankAccountsFailCause.enAmmountOfMoneyIsBellowZero;
                return false;
            }
            if (Password.Length != 64)
            {
                if (Password.Length == 0 || Password.Length > 10)
                {
                    FailCause = clsFailCauses.enBankAccountsFailCause.enPasswordIsTooShortOrTooLong;
                    return false;
                }

                if (!int.TryParse(Password, out int Pass))
                {
                    FailCause = clsFailCauses.enBankAccountsFailCause.enPasswordCantHoldAnyChar;
                    return false;
                }
            }
            return true;

        }
      
        bool _AddNewAccount()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.AccountID = clsBanckAcountDAL.AddNewBankAccount(this.AccountNum, clsProtect1.Compute(this.Password), this.AmmountOfMoney);
            }
            return this.AccountID != -1;



        }
        /// <summary>
        ///Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>
        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewAccount())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateAccount())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
      
        bool _UpdateAccount()
        {
            if (_CheckIfDataIsCorrect())
            {
                if (Password.Length != 64)
                {
                    Password=clsProtect1.Compute(this.Password);
                }
                return clsBanckAcountDAL.UpdateBankAccountInfo(this.AccountID, this._AccountNum, this.AmmountOfMoney, this.Password);
            }
            return false;
        }
      
        static public DataTable GetAllAccounts()
        {

            return clsBanckAcountDAL.GetAllBankAccounts();
        }
        
        static public bool Exist(int AccountID)
        {
            return clsBanckAcountDAL.IsExist(AccountID);
        }

    }
}
