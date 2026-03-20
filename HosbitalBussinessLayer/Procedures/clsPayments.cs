using HosbitalBussinessLayer.DerivedTables;
using HosbitalDataAccessLayer.DerivedTables;
using HosbitalDataAccessLayer.procedures;
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
    /// Manages Payment's info.
    /// </summary>
    [Documentation("this Class Is Used To Manage All Payment records in the system")]
    public class clsPayments
    {

        public int PaymentID {  get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }
        public double PayedAmmount {  get;set; }
        public enum enPaymentStatus { enPayed=1,enBending=2,enCancelled=3}
        [Documentation("used to Make sure that the Payment Is not updated if already Paied/Cancelled")]

        bool _IsCancceledOrPayed = false;

       public enPaymentStatus status = enPaymentStatus.enBending;
        public DateTime? PaymentDate { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int AccountantID {  get;set; }
        public int AccountID {  get;set; }
        public enum enMethod { enCash = 1, enVisa = 2 }
        public enMethod PaymentMethod=enMethod.enCash;
        /// <summary>
        /// Indicates why saving the Payment failed.
        /// </summary>
        public clsFailCauses.enPaymentFailCause Cause {  get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        enum enMode { enAddNew,enUpdate}
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode _Mode = enMode.enAddNew;
        [Documentation("this is used to assign the object from the Code")]

        public clsPayments()
        {

            this.PaymentID = -1;
            this.PayedAmmount = 0;
            this.PaymentDate=null;
            this.AccountantID = -1;
            this.AccountantID= -1;
            this.status = enPaymentStatus.enBending;
            this.PaymentMethod = enMethod.enCash;
            _Mode = enMode.enAddNew;
            Cause = clsFailCauses.enPaymentFailCause.enUnkownError;



        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsPayments(int PaymentID, enMethod PaymentMethod, double PayedAmmount,DateTime? PaymentDate,int AccountantID,int AccountID, enPaymentStatus PaymentStatus)
        {

            this.PaymentID = PaymentID;
            this.PayedAmmount = PayedAmmount;
            this.PaymentDate = PaymentDate;
            this.AccountantID = AccountantID;
            this.AccountID = AccountID;
           
            this.status = PaymentStatus;
            if (this.status == enPaymentStatus.enCancelled|| this.status==enPaymentStatus.enPayed)
                _IsCancceledOrPayed = true;
            this.PaymentMethod = PaymentMethod;
            _Mode = enMode.enUpdate;

            Cause = clsFailCauses.enPaymentFailCause.enUnkownError;


        }
       static public clsPayments GetPaymentInfoByID(int PaymentID) {

            double PayedAmmount = 0;
            DateTime? PaymentDate = null;
            int AccountantID = -1;
            int AccountID = -1;
            int PaymentStatus = -1;
            int PaymentMethodID = -1;
        if(clsPaymentsDAL.GetPaymentInfo(PaymentID,ref PaymentMethodID,ref PayedAmmount,ref PaymentDate,ref AccountantID,ref AccountID,ref PaymentStatus))
            {

                return new clsPayments(PaymentID,(enMethod) PaymentMethodID,PayedAmmount,PaymentDate,AccountantID,AccountID,(enPaymentStatus)PaymentStatus);


            }
        return null;
        
        
        
        
        
        
        
        
        
        }


        
        static public DataTable GetAll()
        {
            return clsPaymentsDAL.GetAllPayments();
        }
      

        static public bool Exist(int PaymentID) { 
        return clsPaymentsDAL.ISExist(PaymentID);
        }

        bool _CheckIfDataISCorrect()
        {
            if (this.PaymentID != -1)
            { 
              
                if (status == enPaymentStatus.enPayed)
                {
                    clsAccountant accountant = clsAccountant.FindByID(AccountantID);
                    if (accountant == null)
                    {
                        Cause = clsFailCauses.enPaymentFailCause.enWrongAccountantID;
                        return false;
                    }
                    if (accountant.EmployeeState == clsEmployees.enState.enFired)
                    {
                        Cause = clsFailCauses.enPaymentFailCause.enAccountantIsFired;
                        return false;
                    }
                    if (PaymentMethod == enMethod.enVisa)
                    {
                        clsBankAccount Account = clsBankAccount.FindAccountByID(this.AccountID);
                        if (Account == null) {
                            Cause = clsFailCauses.enPaymentFailCause.enWrongAccountID;
                            return false; }
                        if (Account.AmmountOfMoney < PayedAmmount) {
                            Cause = clsFailCauses.enPaymentFailCause.enInSufficentMoney;
                            return false; }

                    }
                    else
                    {
                        AccountID = -1;
                    }
                }
            
            }
            if (PayedAmmount < 0)
            {

                Cause = Cause = clsFailCauses.enPaymentFailCause.enPayedAmmountBellowZero;
                return false;
            }
            return true;
        }

        bool _AddNew()
        {


            if (_CheckIfDataISCorrect())
            {
                this.AccountID = -1;
                this.AccountantID = -1;
                this.status = enPaymentStatus.enBending;
                this.PaymentMethod = enMethod.enCash;
                this.PaymentDate = null;
                this.PaymentID = clsPaymentsDAL.AddNewPayment(Convert.ToInt32(this.PaymentMethod), this.PayedAmmount, this.PaymentDate, this.AccountantID, this.AccountID, Convert.ToInt32(this.status));
            }
            return this.PaymentID != -1;
        }
        bool _Update()
        {
            if (!_IsCancceledOrPayed)
            {
                if (_CheckIfDataISCorrect())
                {
                    if (this.status == enPaymentStatus.enPayed)
                    {
                        this.PaymentDate = DateTime.Now;

                      
                        if (_TransferMoney())
                        {
                            return clsPaymentsDAL.UpdatePaymentInfo(this.PaymentID, Convert.ToInt32(this.PaymentMethod), this.PayedAmmount, this.PaymentDate, this.AccountantID, this.AccountID, Convert.ToInt32(this.status));
                        }


                    }
                    else if (this.status == enPaymentStatus.enCancelled)
                    {
                        this.PaymentDate = null;
                        this.AccountantID = -1;
                        this.AccountID = -1;
                        this.PaymentMethod = enMethod.enCash;
                        return clsPaymentsDAL.UpdatePaymentInfo(this.PaymentID, Convert.ToInt32(this.PaymentMethod), this.PayedAmmount, this.PaymentDate, this.AccountantID, this.AccountID, Convert.ToInt32(this.status));


                    }
                    else
                    {

                        this.PaymentDate = null;
                        this.AccountantID = -1;
                        this.AccountID = -1;
                        this.PaymentMethod = enMethod.enCash;
                        return clsPaymentsDAL.UpdatePaymentInfo(this.PaymentID, Convert.ToInt32(this.PaymentMethod), this.PayedAmmount, this.PaymentDate, this.AccountantID, this.AccountID, Convert.ToInt32(this.status));



                    }
                }
            }
        return false;
        }
        [Documentation("this operation is used to check the payment method and if it by visa it checks the ammount of money in visa is equal/bigger to the ammount needed  if true it substitute it from the ammount in visa")]
        bool _TransferMoney()
        {

            if (this.PaymentMethod == enMethod.enCash)
                return true;
            else
            {
                clsBankAccount account=clsBankAccount.FindAccountByID(this.AccountID);
                if (account == null) { 
                return false;
                }
                if (account.AmmountOfMoney >= this.PayedAmmount)
                {
                    account.AmmountOfMoney-=this.PayedAmmount;
                    if (account.Save())
                    {
                        return true;
                    }

                }

            }
            return false;


        }

        /// <summary>
        /// Saves the changes into DB
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            switch (_Mode)
            {

                case(enMode.enAddNew):
                    if(_AddNew())
                return true;
                    else
                        return false;
                case(enMode.enUpdate):
                    if (_Update()) {
                     
                        return true; }
                    else return false;



            }
            return false;



        }

    }
}
