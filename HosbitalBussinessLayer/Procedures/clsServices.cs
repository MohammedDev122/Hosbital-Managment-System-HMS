using HosbitalBussinessLayer.DerivedTables;
using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Procedures
{
    /// <summary>
    /// Base Class For All Services
    /// </summary>
    [Documentation("this class is used to Manage Service's info and it is the Base Class for all the Services in the system")]

    public class clsServices
    {

        public int ServiceID { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }
        public DateTime ServiceStartDateTime { get; set; }
        public DateTime? ServiceEndTime { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }
        public int PatientID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        protected int _PatientID = -1;
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _ServiceTypeID = -1;

        public int PaymentID { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }
        public int ServiceTypeID { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }
     public   enum enState { enCancelled=1, enBending=2, enFinished=3 }
        [Documentation("this Var is Used To Manage The Service State")]
    public    enState State = enState.enBending;
        [Documentation("this Variable Is Used To cacelle any process on the service if the service already finished/cancelled")]
      protected  bool _CancceldOrFinished = false;
        protected enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        protected enMode _Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Services failed.
        /// </summary>
       
        public clsFailCauses.enServicesFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] protected set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsServices()
        {

            this.ServiceID = -1;
            this.PatientID = -1;
            this.PaymentID = -1;
            _PatientID = -1;
            _ServiceTypeID = -1;
            this.ServiceStartDateTime = DateTime.Now;
            this.ServiceEndTime = null;
            this.ServiceTypeID = -1;
            _Mode = enMode.enAddNew;

            State = enState.enBending;

            Cause= clsFailCauses.enServicesFailCause.enUnkownError;
        }
        [Documentation(@"this Is Used to Assign The object After Getting It's Data from Database,it Manages most of the Data for all the classes that inherits from it 
")]
        protected clsServices(int ServiceID, DateTime Date, DateTime ServiceStartTime, DateTime? ServiceEndTime, int PatientID, int PaymentID, int ServiceTypeID,enState State)
        {

            this.ServiceID = ServiceID;
            this.ServiceStartDateTime = new DateTime(Date.Year, Date.Month, Date.Day, ServiceStartTime.Hour, ServiceStartTime.Minute, ServiceStartTime.Second);
            if(ServiceEndTime!=null)
                this.ServiceEndTime = new DateTime(Date.Year, Date.Month, Date.Day,Convert.ToDateTime(ServiceEndTime).Hour, Convert.ToDateTime(ServiceEndTime).Minute, Convert.ToDateTime(ServiceEndTime).Second);
            else
            this.ServiceEndTime = ServiceEndTime;
            this.PatientID = PatientID;
            this.PaymentID = PaymentID;
            this.ServiceTypeID = ServiceTypeID;
            _Mode = enMode.enUpdate;
            this.State = State;
            _PatientID = this.PatientID;
            _ServiceTypeID = this.ServiceTypeID;
            if (this.State != enState.enBending)
            {
                _CancceldOrFinished=true;
            }
            //if (clsPatients.FindByID(PatientID).PatientState == clsPatients.enState.enDead)
            //{
            //    SaveServices();
            //}
            Cause = clsFailCauses.enServicesFailCause.enUnkownError;


        }
        static public clsServices GetServiceInfoByID(int ServiceID)
        {



            DateTime Date = DateTime.Now;
            DateTime ServiceStartTime = DateTime.Now;
            DateTime? ServiceEndTime =null;
            int PatientID = -1;
            int PaymentID = -1;
            int ServiceTypeID = -1;
            int ServiceStateID = -1;
            if (clsServicesDAL.GetServiceInfo(ServiceID, ref PatientID, ref PaymentID, ref ServiceStartTime, ref ServiceEndTime, ref Date, ref ServiceTypeID,ref ServiceStateID))
            {

                return new clsServices(ServiceID, Convert.ToDateTime(Date), Convert.ToDateTime(ServiceStartTime), ServiceEndTime, PatientID, PaymentID, ServiceTypeID,(enState)ServiceStateID);


            }
            
            return null;









        }

        static public DataTable GetAll(int ID,clsViews.enShowing Showing)
        {
            return clsServicesDAL.GetAllServices();
        }
       
        
     
        static  internal  DataTable GetAllServicesForPatient(int PatientID)
        {
            return clsServicesDAL.GetAllServicesForPatient(PatientID);
        }


        static public bool Exist(int ServiceID)
        {
            return clsServicesDAL.ISExist(ServiceID);
        }

        bool _CheckIfDataISCorrect()

        {
            if (this.ServiceID == -1)
            {
               
               
             
               
                clsServiceTypes Type = clsServiceTypes.FindServiceTypeByID(this.ServiceTypeID);
           

            if (Type == null)
            {
                    Cause = clsFailCauses.enServicesFailCause.enWrongServiceTypeID;
                return false;
            }
            if (!clsPatients.Exist(this.PatientID))
            {
                    Cause = clsFailCauses.enServicesFailCause.enWrongPatientID;
                return false;
            }
                if (clsPatients.FindByID(this.PatientID).PatientState == clsPatients.enState.enDead) {
                    Cause = clsFailCauses.enServicesFailCause.enPatientIsDead;
                    return false;
                }
                clsPayments payment = new clsPayments();
                payment.PayedAmmount = Type.ServiceCost;
                payment.Save();
                this.PaymentID = payment.PaymentID;
                if (this.PaymentID == -1)
                {
                    Cause = clsFailCauses.enServicesFailCause.enPaymentFailed;
                    return false;
                }
            }
            else
            {
                if (clsPatients.FindByID(this._PatientID).PatientState == clsPatients.enState.enDead)
                {
                    
                    this.State = enState.enCancelled;
                }

                
                //if(!clsServiceTypes.Exist(this.ServiceTypeID))
                //    return false;




            }
            if (this.ServiceStartDateTime.Date < DateTime.Now.Date)
            {
                Cause = clsFailCauses.enServicesFailCause.enWrongDate;
                return false;
            }
            if (this.ServiceStartDateTime.Date == DateTime.Now.Date)
            {
                if (this.ServiceStartDateTime.Hour < DateTime.Now.Hour)
                {
                    Cause = clsFailCauses.enServicesFailCause.enWrongTime;

                    return false;
                }
            }
            return true;


        }
      
        bool _AddNew()
        {

            if (!_CheckIfDataISCorrect())
            {
                return false;
            }
            this.ServiceEndTime = null;
            this.State = enState.enBending;
            this.ServiceStartDateTime = new DateTime(this.ServiceStartDateTime.Year, this.ServiceStartDateTime.Month, this.ServiceStartDateTime.Day,
                this.ServiceStartDateTime.Hour, this.ServiceStartDateTime.Minute, this.ServiceStartDateTime.Second);

            this.ServiceID = clsServicesDAL.AddNewService(this.PatientID, this.PaymentID,this.ServiceStartDateTime,this.ServiceEndTime,this.ServiceStartDateTime,this.ServiceTypeID,Convert.ToInt32(this.State));


         if(this.ServiceID != -1)
            {

               clsPatientLogs Log=new clsPatientLogs();
                Log.PatientID = this.PatientID;
                Log.ServiceID = this.ServiceID;
                Log.Save();
                if (Log.LogID != -1)
                {
                    return true;
                }
                else
                {
                    Cause = clsFailCauses.enServicesFailCause.enFailedToAddLog;

                    clsRoleBack.DeletePayment(this.PaymentID);
clsRoleBack.DeleteService(this.ServiceID);

                    this.ServiceID = -1;
                    return false;

                }
            }
            else
            {
                
                clsRoleBack.DeletePayment(this.PaymentID);
                return false;
            }
        }
        bool _UploadUpdated()
        {
            this.ServiceStartDateTime = new DateTime(this.ServiceStartDateTime.Year, this.ServiceStartDateTime.Month, this.ServiceStartDateTime.Day,
              this.ServiceStartDateTime.Hour, this.ServiceStartDateTime.Minute, this.ServiceStartDateTime.Second);
            return clsServicesDAL.UpdateServiceInfo(this.ServiceID, this._PatientID, this.PaymentID, this.ServiceStartDateTime,
                                  this.ServiceEndTime, Convert.ToDateTime(this.ServiceStartDateTime), this._ServiceTypeID, Convert.ToInt32(this.State));

        }
        bool _Update()
        {
            if (!_CancceldOrFinished)
            {
                if (!_CheckIfDataISCorrect())
                {
                    return false;
                }
                clsPayments Payment = clsPayments.GetPaymentInfoByID(this.PaymentID);
                switch (Payment.status)
                {
                    case (clsPayments.enPaymentStatus.enPayed):
                        if (this.State == enState.enFinished)
                        {
                           this.ServiceEndTime=new DateTime(this.ServiceStartDateTime.Year,this.ServiceStartDateTime.Month,this.ServiceStartDateTime.Day,DateTime.Now.Hour,DateTime.Now.Minute, DateTime.Now.Second);
                            _CancceldOrFinished = true;
                            return _UploadUpdated();


                        }
                        else if (this.State == enState.enBending)
                        {

                            this.ServiceEndTime = null;
                            return _UploadUpdated();


                        }
                        else
                        {
                            this.ServiceEndTime = null;
                            _CancceldOrFinished = true;
                            return _UploadUpdated();


                        }
                    case (clsPayments.enPaymentStatus.enBending):
                        {
                            if (this.State == enState.enFinished)
                            {
                                //    this.ServiceEndTime = null;
                                //    this.State = enState.enBending;
                                //return    _UploadUpdated();
                                Cause = clsFailCauses.enServicesFailCause.enUnPayed;
                                return false;
                            }
                            else if (this.State == enState.enBending)
                            {
                                this.ServiceEndTime = null;
                                return _UploadUpdated();
                            }
                            else
                            {
                                this.ServiceEndTime = null;
                                _CancceldOrFinished = true;
                                Payment.status = clsPayments.enPaymentStatus.enCancelled;
                                Payment.Save();
                                return _UploadUpdated();

                            }




                        }

                    default:
                        return false;

                }

            }
            Cause = clsFailCauses.enServicesFailCause.enCancelledOrFinished;
            return false;
        }
        /// <summary>
        /// Saves the Changes In DB
        /// </summary>
        /// <returns></returns>
        internal bool SaveServices()
        {
            switch (_Mode)
            {

                case (enMode.enAddNew):
                    if (_AddNew())
                        return true;
                    else
                        return false;
                case (enMode.enUpdate):
                    if (_Update())
                    {

                        return true;
                    }
                    else return false;



            }
            return false;



        }

    }

}
