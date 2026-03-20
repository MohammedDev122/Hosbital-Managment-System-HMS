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
    /// <summary>
    ///manages operation rooms
    /// </summary>
    [Documentation("this Class IS Used to Manage Rooms in the Hospital")]
    public class clsOperationRoom

    {
        public int RoomID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public string RoomNum { get; set; }
      
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;

        /// <summary>
        /// Indicates why saving the Operation Room failed.
        /// /// </summary>.
        
        public clsFailCauses.enOperationRoomsFailCause FailCause
        {
            [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            get; private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsOperationRoom()
        {
            this.RoomID = -1;
            this.RoomNum = "";
           
            Mode = enMode.enAddNew;
            FailCause = clsFailCauses.enOperationRoomsFailCause.enUnKnownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsOperationRoom(int RoomID, string RoomNum)
        {
            this.RoomID = RoomID;
            this.RoomNum = RoomNum;
            

            Mode = enMode.enUpdate;
            FailCause = clsFailCauses.enOperationRoomsFailCause.enUnKnownError;

        }
        static public clsOperationRoom FindRoomByID(int RoomID)
        {
            string RoomNum = "";
            
            if (clsOperationRoomsDAL.GetOperationRoomInfoByID(RoomID, ref RoomNum))
            {
                return new clsOperationRoom(RoomID, RoomNum);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {


            if (RoomNum.Length == 0 || RoomNum.Length > 10)
            {
                FailCause = clsFailCauses.enOperationRoomsFailCause.enVeryShortOrLongOperationRoomNum;
                return false;
            }

         

          
            return true;

        }
        bool _AddNewOperationRoom()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.RoomID = clsOperationRoomsDAL.AddNewOperationRoom(this.RoomNum);
            }
            return this.RoomID != -1;



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

                    if (_AddNewOperationRoom())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdateOperationRoom())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdateOperationRoom()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsOperationRoomsDAL.UpdateOperationRoomInfo(this.RoomID, this.RoomNum);
            }
            return false;
        }
        static public DataTable GetAllOperationRooms()
        {

            return clsOperationRoomsDAL.GetAllOperationRoom();
        }
        static public bool Exist(int RoomID)
        {
            return clsOperationRoomsDAL.IsExist(RoomID);
        }

    }
}
