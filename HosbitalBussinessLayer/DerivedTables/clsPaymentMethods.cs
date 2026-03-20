using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.DerivedTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    [Documentation("this Class Is Used to Manage All the payment Methods")]
    public class clsPaymentMethods
    {

       public int PaymentMethodID {  get; [Documentation("This Var Is Private To Make It only readable.")]
            private set; }
        public string PaymentMethod {  get;set; }
        enum enMode { enAddNew,enUpdate};
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]
        enMode Mode = enMode.enAddNew;

        public clsFailCauses.enPaymentMethodsFailCause Cause
        {
            [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            get; private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsPaymentMethods()
        {
            Mode = enMode.enAddNew;
            PaymentMethodID = -1;
            PaymentMethod = "";
            Cause= clsFailCauses.enPaymentMethodsFailCause.enUnknownError;
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsPaymentMethods(int PaymentMethodID,string PaymentMethod)
        {

            Mode=enMode.enUpdate;
            this.PaymentMethodID = PaymentMethodID;
            this.PaymentMethod=PaymentMethod;
Cause= clsFailCauses.enPaymentMethodsFailCause.enUnknownError;



        }
     static  public clsPaymentMethods GetPaymentMethodInfoByID(int Id)
        {
            string Method = "";
          if(clsPaymentMethodDAL.GetPaymentMethodInfoByID(Id,ref Method))
            {


                return new clsPaymentMethods(Id,Method);

            }
          return null;

        }
        static public bool DeleteMethod(int Id) { 
        
        return clsPaymentMethodDAL.DeleteMethod(Id);
        }
        static public DataTable GetAllMethods()
        {

            return clsPaymentMethodDAL.GetAllMethods();
        }
        bool _CheckIfDataIsCorrect()
        {

            if (PaymentMethod.Length == 0) {
                Cause = clsFailCauses.enPaymentMethodsFailCause.enPaymentMethodNameIsTooShort;
            return false;}
            return true;
        }
        bool _AddNew()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.PaymentMethodID = clsPaymentMethodDAL.AddNewPaymentMethod(PaymentMethod);
            }
            return this.PaymentMethodID!=-1;

        }
        bool _Update()
        {
            if (_CheckIfDataIsCorrect())
            {

                return clsPaymentMethodDAL.UpdateMethod(this.PaymentMethodID, this.PaymentMethod);
            }
            return false;
        }
        public bool Save()
        {

            switch (Mode)
            {

                case (enMode.enAddNew):
                    if (_AddNew()) { 
                        Mode= enMode.enUpdate;
                        return true; }
                    else return false;
                case (enMode.enUpdate):
                    if (_Update()) return true;
                    else return false;

            }
            return false;


        }
        public static bool Exist(int Id) { 
        return clsPaymentMethodDAL.IsExist(Id);
        }
    }
}
