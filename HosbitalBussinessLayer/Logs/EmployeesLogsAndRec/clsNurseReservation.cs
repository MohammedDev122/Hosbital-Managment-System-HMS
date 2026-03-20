using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.LogsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Logs
{
    /// <summary>
    ///manages Nurse reservations and ensure there are no overlapping schedules.
    /// </summary>
    [Documentation("this class Is Used To Manage all Nurses Schedual Making Sure There Is No Overlaps Services")]
    public class clsNurseReservation


    {
        public int ReservationID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int NurseID { get; set; }
        public int ServiceID { get; set; }
        public DateTime Date_Time { get; set; }
        enum enMode { enUpdate, enAddNew }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode _Mode = enMode.enAddNew;
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _NurseID = -1;
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _ServiceID = -1;
        /// <summary>
        /// Indicates why saving the Nurse Reservation failed.
        /// </summary>

        public clsFailCauses.enLogsAndRecFailCause Cause {  get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        public clsServices.enState State { get; private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsNurseReservation()
        {
            this.NurseID = -1;
            this.ServiceID = -1;
            this.ReservationID = -1;
            _NurseID = -1;
            this._ServiceID = -1;
            Date_Time = DateTime.Now;
            State = clsServices.enState.enBending;
            this._Mode = enMode.enAddNew;
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsNurseReservation(int ReservationID, int NurseID, int ServiceID, DateTime date, DateTime time)
        {
            this.ReservationID = ReservationID;
            this.NurseID = NurseID;
            _NurseID = NurseID;
            this.ServiceID = ServiceID;
            _ServiceID = ServiceID;
            this.Date_Time = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            this.State = clsServices.GetServiceInfoByID(this.ServiceID).State;
            this._Mode = enMode.enUpdate;
            Cause= clsFailCauses.enLogsAndRecFailCause.enUnkownError;


        }
        static public clsNurseReservation FindReservationRecordByID(int ReservationID)
        {

            int NurseID = -1;
            int ServiceID = -1;
            DateTime Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsNurseReservationsDAL.GetReservationInfoByID(ReservationID, ref NurseID, ref ServiceID, ref Date, ref Time))
            {
                return new clsNurseReservation(ReservationID, NurseID, ServiceID, Date, Time);
            }

            return null;



        }
        static public clsNurseReservation FindReservationRecordByServiceIDAndNurseID(int ServiceID,int NurseID)
        {

            int ReservationsID = -1;
            DateTime Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsNurseReservationsDAL.GetReservationInfoByServiceIDAndNurseID(ServiceID, NurseID, ref ReservationsID,  ref Date, ref Time))
            {
                return new clsNurseReservation(ReservationsID, NurseID, ServiceID, Date, Time);
            }

            return null;



        }
        static public DataTable GetServiceReservations(int ServiceID)
        {

            return clsNurseReservationsDAL.GetAllServiceReservations(ServiceID);






        }

        bool _CheckData()
        {
            if (!clsNurses.Exist(this.NurseID))
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enWrongNurseID;
                return false;
            }
            if (clsNurses.FindByID(this.NurseID).EmployeeState == clsEmployees.enState.enFired)
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enNurseIsFired;
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
                    return false;
                }
            }
            return true;



        }
        bool _AddNew()
        {

            if (_CheckData())

            this.ReservationID = clsNurseReservationsDAL.AddNewReservation(this.NurseID, this.ServiceID, this.Date_Time, this.Date_Time);

            return this.ReservationID != -1;



        }
        bool _Update()
        {

            if(_CheckData())
            return clsNurseReservationsDAL.UpdateReservationInfo(this.ReservationID
                  , this._NurseID, this._ServiceID, this.Date_Time, this.Date_Time);
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
        ///retrieves all Nurse reservations, or reservations for a specific Nurse, based on the view level.
        /// </summary>
        /// <param name="showing"></param>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        static public DataTable GetAllReservations(clsViews.enShowing Showing,int ID)
        {
            switch (Showing)
            {


                case (clsViews.enShowing.enAdmin):


                    return clsNurseReservationsDAL.GetAllReservations();

                default:
                    return clsNurseReservationsDAL.GetAllReservationForNurse(ID);


            }

        }
        static public bool Exist(int ReservationID)
        {
            return clsNurseReservationsDAL.IsExist(ReservationID);
        }
        [Documentation("this Method Is Used to Check if The Operation dosent OverLaps it give Operation Estimated time about 8 hours once it's finished or cancelled You can assign another in the same period")]

        static public bool CheckOperationReservationDosentOverLap(int NurseID, DateTime date, DateTime Time, int ServiceID)
        {

            DateTime Time1 = Time.AddHours(-4);
            DateTime Time2 = Time.AddHours(4);
            return clsNurseReservationsDAL.CheckReservationDosentOverLap(NurseID, date, Time1, Time2, ServiceID);



        }
    }
}
