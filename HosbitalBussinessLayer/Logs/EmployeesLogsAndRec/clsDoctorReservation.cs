using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.LogsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Logs
{
    /// <summary>
    ///manages doctor reservations and ensure there are no overlapping schedules.
    /// </summary>
    [Documentation("this class Is Used To Manage all Doctors Schedual Making Sure There Is No Overlaps Services")]
    public class clsDoctorReservation

    {
        public int ReservationID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int DoctorID { get; set; }
        
        public int ServiceID { get; set; }
       
        public DateTime Date_Time {  get; set; }
        enum enMode { enUpdate, enAddNew }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]
        enMode _Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Doctor Reservation failed.
        /// </summary>
        
        public clsFailCauses.enLogsAndRecFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]private set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]
        private int _DoctorID = -1;
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]
        private int _ServiceID = -1;
        public clsServices.enState State {  get;private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsDoctorReservation()
        {
            this.DoctorID = -1;
            this.ServiceID = -1;
            this.ReservationID =-1;
            _DoctorID = -1;
            this._ServiceID = -1;
            Date_Time = DateTime.Now;
            State = clsServices.enState.enBending;
            this._Mode = enMode.enAddNew;
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsDoctorReservation(int ReservationID, int DoctorID, int ServiceID,DateTime date, DateTime time)
        {
            this.ReservationID = ReservationID;
            this.DoctorID = DoctorID;
            _DoctorID = DoctorID;
            this.ServiceID = ServiceID;
            _ServiceID=ServiceID;
            this.Date_Time = new DateTime(date.Year,date.Month,date.Day,time.Hour,time.Minute,time.Second);
            this.State =clsServices.GetServiceInfoByID(this.ServiceID).State;
            this._Mode = enMode.enUpdate;
            Cause= clsFailCauses.enLogsAndRecFailCause.enUnkownError;


        }
        static public clsDoctorReservation FindReservationRecordByID(int ReservationID)
        {

            int DoctorID = -1;
            int ServiceID = -1;
          DateTime  Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsDoctorReservationDAL.GetReservationInfoByID(ReservationID, ref DoctorID, ref ServiceID,ref Date,ref Time))
            {
                return new clsDoctorReservation(ReservationID, DoctorID, ServiceID, Date, Time);
            }

            return null;



        }
        /// <summary>
        ///Only Use This Method With Diagnosis Option
        /// </summary>
        /// <param name="ServiceID"></param>
        /// <returns></returns>
        [Documentation(@"We only Use This Method With Diagnosis option Cause the Diagnosis have 1 doctor in it so we can check the reservation of 1 doctor
on the other hand the operation has many members assossiated with it so it will be impossible to check the reservation With It")]
        static public clsDoctorReservation FindReservationRecordByServiceID(int ServiceID)
        {

            int DoctorID = -1;
            int ReservationsID = -1;
            DateTime Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsDoctorReservationDAL.GetReservationInfoByServiceID(ServiceID, ref ReservationsID, ref DoctorID, ref Date, ref Time))
            {
                return new clsDoctorReservation(ReservationsID, DoctorID, ServiceID, Date, Time);
            }

            return null;



        }
        /// <summary>
        ///Use This Method With Diagnosis or Operation Options
        /// </summary>
        /// <param name="ServiceID"></param>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        [Documentation(@"We  Use This Method With both Diagnosis option & operation Option  Cause it find the reservation not only with the service it's related to but also by the employee acossiated with it")]
        static public clsDoctorReservation FindReservationRecordByServiceIDandDoctorID(int ServiceID,int DoctorID)
        {

            int ReservationsID = -1;
            DateTime Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsDoctorReservationDAL.GetReservationInfoByServiceIDAndDoctorID(ServiceID, DoctorID, ref ReservationsID,   ref Date, ref Time))
            {
                return new clsDoctorReservation(ReservationsID, DoctorID, ServiceID, Date, Time);
            }

            return null;



        }
        bool _CheckData()
        {
            if (!clsDoctors.Exist(this.DoctorID))
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enWrongDoctorID;
                return false;

            }
            if (!clsServices.Exist(this.ServiceID))
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enWrongServiceID;
                return false;
            }
            if (this.Date_Time.Date < DateTime.Now.Date)
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enWrongDate;
                return false;
            }
            if (this.Date_Time.Date == DateTime.Now.Date)
            {
                if (this.Date_Time.Hour < DateTime.Now.Hour)
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enWrongTime;
                    return false; }
            }
             return true;



        }
        bool _AddNew()
        {
           
            if(_CheckData())
            this.ReservationID = clsDoctorReservationDAL.AddNewReservation(this.DoctorID, this.ServiceID,this.Date_Time,this.Date_Time);

            return this.ReservationID != -1;


            
        }
        bool _Update()
        {

           if( _CheckData())
            return clsDoctorReservationDAL.UpdateReservationInfo(this.ReservationID
                  , this._DoctorID, this._ServiceID,this.Date_Time,this.Date_Time);
            else return false;

        }
        /// <summary>
        ///Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>
        public bool Save()
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
        /// <summary>
        ///retrieves all doctor reservations, or reservations for a specific doctor, based on the view level.
        /// </summary>
        /// <param name="showing"></param>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        static public DataTable GetDoctorReservations(clsViews.enShowing showing, int DoctorID)
        {
            switch (showing)
            {
                case(clsViews.enShowing.enAdmin):
                    return clsDoctorReservationDAL.GetAllReservations();
                default:
                    return clsDoctorReservationDAL.GetAllReservationForDoctor(DoctorID);


            }

             
        }
        static public DataTable GetServiceReservations(int ServiceID)
        {
            
                    return clsDoctorReservationDAL.GetAllServiceReservations(ServiceID);
               


            


        }
        static public bool Exist(int ReservationID)
        {
            return clsDoctorReservationDAL.IsExist(ReservationID);
        }
        [Documentation("this Method Is Used to Check if The Diagnosis dosent OverLaps it give Diagnosis Estimated time about 30 minutes once it's finished or cancelled You can assign another in the same period")]
           static public bool CheckDiagnosisReservationDosentOverLap(int DoctorID,DateTime date,DateTime Time,int ServiceID)
        {

            DateTime Time1 = Time.AddMinutes(-15);
            DateTime Time2 = Time.AddMinutes(15);
            return clsDoctorReservationDAL.CheckReservationDosentOverLap(DoctorID,date, Time1 ,Time2,ServiceID);



        }
        [Documentation("this Method Is Used to Check if The Operation dosent OverLaps it give Operation Estimated time about 8 hours once it's finished or cancelled You can assign another in the same period")]

        static public bool CheckOperationReservationDosentOverLap(int DoctorID, DateTime date, DateTime Time, int ServiceID)
        {

            DateTime Time1 = Time.AddHours(-4);
            DateTime Time2 = Time.AddHours(4);
            return clsDoctorReservationDAL.CheckReservationDosentOverLap(DoctorID, date, Time1, Time2, ServiceID);



        }
     



    }
}
