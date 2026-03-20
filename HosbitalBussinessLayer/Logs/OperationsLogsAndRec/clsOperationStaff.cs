using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.DerivedTables;
using HosbitalDataAccessLayer.LogsDAL;
using HosbitalDataAccessLayer.procedures;
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
    ///manages operation staff and ensure there is no overlapping time in any member's schedule.
    /// </summary>
    [Documentation("Responsiple for Managing the staff member Assigning them to operations Making Sure they dont Have overlapped Service With It")]
    public class clsOperationStaff


    {
        public int ID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int EmployeeID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _EmployeeID = -1;
        public int OperationID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _OperationID = -1;
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _DepartmentID = -1;
        internal DateTime StartDateTime;
        enum enMode { enUpdate, enAddNew }

        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode _Mode = enMode.enAddNew;
        [Documentation("it Is Used To get The State Of The Operation And to get The State of the Current Reservation Depending on it")]
        clsOperations.enState State = clsOperations.enState.enBending;
        /// <summary>
        /// Indicates why saving the Operation Staff failed.
        /// </summary>
        public clsFailCauses.enLogsAndRecFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }

        [Documentation("this is used to assign the object from the Code")]
        public clsOperationStaff()
        {
            this.ID = -1;
            this.EmployeeID = -1;
            this._EmployeeID = -1;
            _OperationID = -1;
            this.OperationID = -1;
            State = clsServices.enState.enBending;
            this._Mode = enMode.enAddNew;
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;
            StartDateTime = DateTime.Now;
        }

        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsOperationStaff(int StaffID, int EmployeeID, int OperationID, clsOperations.enState State)
        {
            this.ID = StaffID;
            this.EmployeeID = EmployeeID;
            _EmployeeID = EmployeeID;
            this.OperationID = OperationID;
            _OperationID = OperationID;
            this.State = State;
            this._Mode = enMode.enUpdate;
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;
            _DepartmentID=clsEmployees.FindByID(this.EmployeeID).DepartmentID;
            StartDateTime = clsOperations.GetOperationInfoByID(_OperationID).ServiceStartDateTime;
        }
        static public clsOperationStaff FindStaffRecordByID(int StaffID)
        {

            int EmployeeID = -1;
            int OperationID = -1;
          
            if (clsOperationStaffDAL.GetOperationStaffInfoByID(StaffID, ref EmployeeID, ref OperationID))
            {

                clsOperations operations = clsOperations.GetOperationInfoByID(OperationID);

                return new clsOperationStaff(StaffID, EmployeeID, OperationID,operations.State);
            }

            return null;



        }
        bool _CheckData()
        {
            if (ID == -1) {
                if (!clsEmployees.Exist(this.EmployeeID))
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enWrongEmployeeID;
                    return false;

                }
                if (!clsOperationsDAL.ISExist(this.OperationID))
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enWrongOperationID;
                    return false;
                }
                clsOperations operation = clsOperations.GetOperationInfoByID(OperationID);

                StartDateTime = operation.ServiceStartDateTime;

                if (!CheckStaffReservationDosentOverLap(EmployeeID, OperationID))
                {
                    Cause =clsFailCauses.enLogsAndRecFailCause.enOverLapTime;
                    return false;

                }
            
            if(Exist(EmployeeID, OperationID))
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enAlreadyAssignedStaff;

                    return false;


                }





            }
            else
            {

                if (!CheckStaffReservationDosentOverLap(_EmployeeID, _OperationID))
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enOverLapTime;
                    return false;

                }

            }
            return true;



        }
        bool _AddNew()
        {

            if (_CheckData())
            {
                _DepartmentID = clsEmployees.FindByID(this.EmployeeID).DepartmentID;
                clsOperations operation = clsOperations.GetOperationInfoByID(OperationID);

                {
                    if (_DepartmentID == 9)
                    {

                        clsDoctorReservation Dreserv = new clsDoctorReservation();
                        Dreserv.DoctorID = clsEmployees.GetEmployeeRoleID(this.EmployeeID);
                        Dreserv.ServiceID = operation.ServiceID;
                        Dreserv.Date_Time = operation.ServiceStartDateTime;
                        if (Dreserv.Save())
                        {
                            this.ID = clsOperationStaffDAL.AddNewOperationStaff(this.EmployeeID, this.OperationID);


                        }

                    }
                    if (_DepartmentID == 5)
                    {

                        clsNurseReservation Nreserv = new clsNurseReservation();
                        Nreserv.NurseID = clsEmployees.GetEmployeeRoleID(this.EmployeeID);
                        Nreserv.ServiceID = operation.ServiceID;
                        Nreserv.Date_Time = operation.ServiceStartDateTime;
                        if (Nreserv.Save())
                        {
                            this.ID = clsOperationStaffDAL.AddNewOperationStaff(this.EmployeeID, this.OperationID);


                        }

                    }

                }
            }
            return this.ID != -1;



        }
        bool _Update()
        {

            if (_CheckData())
            {
                if (_DepartmentID == 9)
                {
                    clsOperations operation = clsOperations.GetOperationInfoByID(OperationID);

                    clsDoctorReservation Dreserv = clsDoctorReservation.FindReservationRecordByServiceIDandDoctorID(operation.ServiceID,clsEmployees.GetEmployeeRoleID(_EmployeeID));

                    Dreserv.Date_Time =StartDateTime;
                    if (Dreserv.Save())
                    {
                        return clsOperationStaffDAL.UpdateOperationStaffInfo(this.ID
                      , this._EmployeeID, this._OperationID);
                    }
                }
                else if (_DepartmentID == 5)
                {

                    clsOperations operation = clsOperations.GetOperationInfoByID(OperationID);

                    clsNurseReservation Nreserv = clsNurseReservation.FindReservationRecordByServiceIDAndNurseID(operation.ServiceID,clsEmployees.GetEmployeeRoleID(_EmployeeID));

                    Nreserv.Date_Time = StartDateTime;
                    if (Nreserv.Save())
                    {
                        return clsOperationStaffDAL.UpdateOperationStaffInfo(this.ID
                 , this._EmployeeID, this._OperationID);

                    }

                }
            }
             return false;

            
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
        ///Gets The Staff Member For One Operation By it's ID or To Get All Operation's Member's
        /// </summary>
        /// <param name="OperationID"></param>
        /// <returns></returns>
        static public DataTable GetAllOperationsStaff(int OperationID=-1)
        {
           
                    if(OperationID != -1)
                        return clsOperationStaffDAL.GetAllOperationStaffByOperationID(OperationID);
else
                        return clsOperationStaffDAL.GetAllOperationsStaff();


            
           
        }
        static public bool Exist(int StaffID)
        {
            return clsOperationStaffDAL.IsExist(StaffID);
        }
        [Documentation("this Method Is Used To Make Sure That the staff member We Want to assign to this Operation Isn't Already in it")]
        static public bool Exist(int EmployeeID,int OperationID)
        {
            return clsOperationStaffDAL.IsExist(OperationID,EmployeeID);
        }
        [Obsolete("This method will be updated later to make the data persistent in the database and use the operation state instead of deleting the record.")]
        static public bool DeleteStaff(int StaffID)
        {
            clsOperationStaff staff = FindStaffRecordByID(StaffID);
            int ID= staff.EmployeeID;
            int ServiceID = clsOperations.GetOperationInfoByID(staff.OperationID).ServiceID;
            if (clsOperationStaffDAL.DeleteOperationStaff(StaffID))
            {
                clsEmployees employee = clsEmployees.FindByID(ID);
                if (employee.DepartmentID == 9)
                {

                return    clsRoleBack.DeleteDoctorReservation(clsEmployees.GetEmployeeRoleID(ID), ServiceID);
                }
                else if (employee.DepartmentID == 5)
                {
                    return clsRoleBack.DeleteNurseReservation(clsEmployees.GetEmployeeRoleID(ID), ServiceID);
                }



                return false;



            }
            else
            {
                return false;
            }
        }
        [Documentation("Used To Make Sure That the Staff member whether he/she is nurse/doctor dosent have overlapped time with another services")]
        public bool CheckStaffReservationDosentOverLap(int EmployeeID,int OperationID)
        {

            clsEmployees employee = clsEmployees.FindByID(EmployeeID);
            clsOperations operation = clsOperations.GetOperationInfoByID(OperationID);
            if (employee.DepartmentID == 9)
            {
             int DoctorID=   clsDoctors.GetEmployeeRoleID(EmployeeID);
                return clsDoctorReservation.CheckOperationReservationDosentOverLap(DoctorID, StartDateTime, StartDateTime, operation.ServiceID);
            }
            else if(employee.DepartmentID == 5)
            {
                int NurseID = clsNurses.GetEmployeeRoleID(EmployeeID);
                return clsNurseReservation.CheckOperationReservationDosentOverLap(NurseID, StartDateTime, StartDateTime, operation.ServiceID);
            }

        
            else
            {
                return false;
            }

        }
       

        static public DataTable GetAllStaffForOperation(int OperationID)
        {

            return clsOperationStaffDAL.GetAllOperationStaffByOperationID(OperationID);
        }

    }
}
