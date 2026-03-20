using HosbitalBussinessLayer.DerivedTables;
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
    ///checks room availability and ensure there are no overlapping times.
    ////// </summary>
    [Documentation("this Class Is Used To organize room's Scheduals to make sure that the room is available and don't have overlap operations")]
    public class clsOperationRoomReservation

    {
        public int ReservationID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int RoomID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _RoomID = -1;
        public int ServiceID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _ServiceID = -1;
        public DateTime Date_Time { get; set; }
        enum enMode { enUpdate, enAddNew }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode _Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Roon Reservation failed.
        /// </summary>
        public clsFailCauses.enLogsAndRecFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        [Documentation("it Is Used To get The State Of The Operation And to get The State of the Current Reservation Depending on it")]

        public clsServices.enState State { get; private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsOperationRoomReservation()
        {
            this.ReservationID = -1;

            this.RoomID = -1;
            this.ServiceID = -1;
            _RoomID = -1;
            this._ServiceID = -1;
            Date_Time = DateTime.Now;
            State = clsServices.enState.enBending;
            this._Mode = enMode.enAddNew;
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsOperationRoomReservation(int ReservationID, int RoomID, int ServiceID, DateTime date, DateTime time)
        {
            this.ReservationID = ReservationID;
            this.RoomID = RoomID;
            _RoomID = RoomID;
            this.ServiceID = ServiceID;
            _ServiceID = ServiceID;
            this.Date_Time = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            this.State = clsServices.GetServiceInfoByID(this.ServiceID).State;
            this._Mode = enMode.enUpdate;
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;


        }
        static public clsOperationRoomReservation FindReservationRecordByID(int ReservationID)
        {

            int RoomID = -1;
            int ServiceID = -1;
            DateTime Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsRoomReservationsDAL.GetReservationInfoByID(ReservationID, ref RoomID, ref Date, ref Time, ref ServiceID))
            {
                return new clsOperationRoomReservation(ReservationID, RoomID, ServiceID, Date, Time);
            }

            return null;



        }
        static public clsOperationRoomReservation FindReservationRecordByServiceID(int ServiceID)
        {

            int RoomID = -1;
            int ReservationsID = -1;
            DateTime Date = DateTime.Now;
            DateTime Time = DateTime.Now;
            if (clsRoomReservationsDAL.GetReservationInfoByServiceID(ServiceID, ref ReservationsID, ref RoomID, ref Date, ref Time))
            {
                return new clsOperationRoomReservation(ReservationsID, RoomID, ServiceID, Date, Time);
            }

            return null;



        }
        bool _CheckData()
        {
            if (this.ReservationID == -1)
            {
                if (!clsOperationRoom.Exist(this.RoomID))
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enWrongRoomID;
                    return false;

                }
                if (!clsServices.Exist(this.ServiceID))
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enWrongServiceID;
                    return false;
                }
               
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
                this.ReservationID = clsRoomReservationsDAL.AddNewReservation(this.RoomID, this.Date_Time, this.Date_Time, this.ServiceID);

            return this.ReservationID != -1;



        }
        bool _Update()
        {

            if (_CheckData())
                return clsRoomReservationsDAL.UpdateReservationInfo(this.ReservationID
                      , this._RoomID, this.Date_Time, this.Date_Time, this._ServiceID);
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
        static public DataTable GetAllReservations()
        {

            return clsRoomReservationsDAL.GetAllReservations();
        }
        static public bool Exist(int ReservationID)
        {
            return clsRoomReservationsDAL.IsExist(ReservationID);
        }
        [Documentation("this Method Is Used to Check if The Operation dosent OverLaps it give Operation Estimated time about 8 hours once it's finished or cancelled You can assign another in the same period")]

        static public bool CheckRoomsReservationDosentOverLap(int RoomID, DateTime date, DateTime Time, int ServiceID)
        {
            
            DateTime Time1 = Time.AddHours(-4);
            DateTime Time2 = Time.AddHours(4);
            return clsRoomReservationsDAL.CheckReservationDosentOverLap(RoomID, date, Time1, Time2, ServiceID);



        }
        static public DataTable GetAllRoomReservationRecordsByID(int RoomID)
        {

            return clsRoomReservationsDAL.GetAllReservationForRoom(RoomID);
        }



    }
}
