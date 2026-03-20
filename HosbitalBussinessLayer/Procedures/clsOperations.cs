using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Logs;
using HosbitalDataAccessLayer.procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Procedures
{
    /// <summary>
    ///Manages Operation's services.
    /// </summary>
        [Documentation("this class is used to Manage Operation's info,Change patient State  If Operation Failed, booking a room and it inherits it's props & methods from clsServices Class")]

    public class clsOperations
   : clsServices

    {

        public int OperationID { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }

        public int MedicalRecordID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _MedicalRecordID = -1;

        public int SpecilizationID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _specilizationID = -1;
        public int OperationRoomID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _OperationRoomID = -1;
        public enum enOperationResult { enSucceded = 1, enFailed = 2, enUnknown = 3 }
        [Documentation("this Var is Used To record the result of the operation and it affects the state of the patient.")]
        public enOperationResult Result = enOperationResult.enUnknown;
        [Documentation("this is used to assign the object from the Code, we set the service type to 1 -Operation- by default. note:you can't change it.")]

        public clsOperations() : base()
        {
            OperationID = -1;
            this.MedicalRecordID = -1;
            _MedicalRecordID = -1;

            this.SpecilizationID = -1;
            _specilizationID = -1;
            this.OperationRoomID = -1;
            _OperationRoomID = -1;
            Result = enOperationResult.enUnknown;

            this.ServiceTypeID = 1;
        }
        [Documentation(@"this Is Used to Assign The object After Getting It's Data from Database,it sends all the Data the clsServices 
class need to create an object. also it does auto assign service type
into 1 to make the system knows it's an Operation service and set it's price automatically -also we made it this way to make it impossible to change the price of the service from here")]
        private clsOperations(int OperationID, int MedicalRecordID, int SpecilizationID, int OperationRoomID, enOperationResult result,
            int ServiceID, DateTime Date, DateTime ServiceStartTime,
            DateTime? ServiceEndTime, int PatientID, int PaymentID, enState State) :
            base(ServiceID, Date, ServiceStartTime, ServiceEndTime, PatientID, PaymentID, 1, State)
        {

            this.OperationID = OperationID;
            this.MedicalRecordID = MedicalRecordID;
            this.OperationRoomID = OperationRoomID;
            this.Result = result;
            this.SpecilizationID = SpecilizationID;
            this._OperationRoomID = OperationRoomID;
            this._specilizationID = SpecilizationID;
            _MedicalRecordID = MedicalRecordID;

        }
        static public clsOperations GetOperationInfoByID(int OperationID)
        {



            int OperationResult = -1;
            int OperationRoomID = -1;
            int MedicalRecordID = -1;
            int SpecilizationID = -1;
            int ServiceID = -1;
            if (clsOperationsDAL.GetOperationInfoByID(OperationID, ref MedicalRecordID, ref SpecilizationID, ref OperationResult, ref ServiceID, ref OperationRoomID))
            {
                clsServices service = GetServiceInfoByID(ServiceID);

                return new clsOperations(OperationID, MedicalRecordID, SpecilizationID, OperationRoomID, (enOperationResult)OperationResult, service.ServiceID, service.ServiceStartDateTime,
                    service.ServiceStartDateTime, service.ServiceEndTime, service.PatientID, service.PaymentID, service.State);


            }
            return null;




        }
        [Documentation("this Method Is used when we update the Operation date to check if all the member associated with the operation are available at this time if not it will automatically remove them from the operation")]
        bool _checkIfStaffMemberDontHaveOverLabTime()
        {

            DataTable dtoperationStaff= clsOperationStaff.GetAllStaffForOperation(OperationID);
            clsOperationStaff StaffMember;
            if (dtoperationStaff.Rows.Count > 0)
            {
                foreach (DataRow row in dtoperationStaff.Rows)
                {


                    StaffMember = clsOperationStaff.FindStaffRecordByID(Convert.ToInt32(row["StaffID"]));
                    StaffMember.StartDateTime = ServiceStartDateTime;
                    if (!StaffMember.Save())
                    {
                        if (clsEmployees.FindByID(StaffMember.EmployeeID).DepartmentID == 5)
                        {

                            clsRoleBack.DeleteNurseReservation(clsNurseReservation.FindReservationRecordByServiceIDAndNurseID(ServiceID,clsEmployees.GetEmployeeRoleID(StaffMember.EmployeeID)).ReservationID);


                        }
                        if (clsEmployees.FindByID(StaffMember.EmployeeID).DepartmentID == 9)
                        {

                            clsRoleBack.DeleteDoctorReservation(clsDoctorReservation.FindReservationRecordByServiceIDandDoctorID(ServiceID, clsEmployees.GetEmployeeRoleID(StaffMember.EmployeeID)).ReservationID);


                        }
                        clsOperationStaff.DeleteStaff(StaffMember.ID);
                    }


                }


            }
            return true;
        }
        bool _CheckIfDataISCorrect()

        {
            if (this.OperationID == -1)
            {
                clsMedicalRecords MedRec = clsMedicalRecords.FindMedicalRecordByID(this.MedicalRecordID);
                if ( MedRec== null)
                {
                    Cause = clsFailCauses.enServicesFailCause.enWrongMedicalRecordID;
                    return false;
                }
                if (MedRec.State == clsMedicalRecords.enState.enCancelled)
                {
                    Cause = clsFailCauses.enServicesFailCause.enWrongMedicalRecordID;
                    return false;

                }

                PatientID = clsMedicalRecords.FindMedicalRecordByID(MedicalRecordID).PatientID;
                SpecilizationID = clsDiagnosis.GetDiagnosisInfoByID(clsDiagnosis.GetDiagnosisIDbyMedicalRecordID(MedicalRecordID)).SpecilizationID;
                clsOperationRoom Room = clsOperationRoom.FindRoomByID(this.OperationRoomID);
                if (Room == null)
                {
                    Cause = clsFailCauses.enServicesFailCause.enWrongRoomID;
                    return false;
                }
             
               
                if (!clsOperationRoomReservation.CheckRoomsReservationDosentOverLap(this.OperationRoomID, this.ServiceStartDateTime, this.ServiceStartDateTime, this.ServiceID))
                {

                    Cause = clsFailCauses.enServicesFailCause.enOverLappedTime;
                    return false;

                }
            }
            else
            {
                if (!clsOperationRoomReservation.CheckRoomsReservationDosentOverLap(this._OperationRoomID, this.ServiceStartDateTime, this.ServiceStartDateTime, this.ServiceID))
                {
                    Cause = clsFailCauses.enServicesFailCause.enOverLappedTime;

                    return false;
                }
                if (!_checkIfStaffMemberDontHaveOverLabTime())
                {
                    Cause = clsFailCauses.enServicesFailCause.enOneOfStaffHasOverLappedTime;

                    return false;



                }
                //i want to check on every staff member if the time is suitable with each one of them before updating if no there will be no update to take!
            }
            return true;


        }

        /// <summary>
        /// Returns all Operation's records based on view level.
        /// /// </summary>
        /// <param name="ID"></param>
        /// <param name="showing"></param>
        /// <returns> diagnosis data for admin, Staff Member, or patient depending on view level.
        /// </returns>
        [Documentation("gets  operations info depending on view level ")]

        static public DataTable GetAll(int ID,clsViews.enShowing showing)
        {
            switch (showing)
            {
                case (clsViews.enShowing.enInfoEmployeeOwner):
                    return clsOperationsDAL.GetAllOperationsforStaffMember(ID);
                case (clsViews.enShowing.enPatientOwner):
                    return clsOperationsDAL.GetAllOperationsforPatient(ID);
                default:
                    return clsOperationsDAL.GetAllOperationsforAdmin();



            }
        }
    

      
        static public bool Exist(int OperationID)
        {
            return clsOperationsDAL.ISExist(OperationID);
        }

       
        void _RollBackFromFailedOperationAdd(clsOperationRoomReservation roomReservation)
        {
            Cause = clsFailCauses.enServicesFailCause.enFailedtoAddDiagnosisDB;
            clsRoleBack.DeletePatientLog(clsPatientLogs.FindPatientLogByServiceID(this.ServiceID).LogID);
            clsRoleBack.DeleteService(this.ServiceID);
            clsRoleBack.DeletePayment(this.PaymentID);

            clsRoleBack.DeleteRoomReservation(roomReservation.ReservationID);
        }
        void _RollBackFromFailedRoomReservationAddition()
        {

            Cause = clsFailCauses.enServicesFailCause.enFailedToAddReservation;
            clsRoleBack.DeletePatientLog(clsPatientLogs.FindPatientLogByServiceID(this.ServiceID).LogID);

            clsRoleBack.DeleteService(this.ServiceID);
            clsRoleBack.DeletePayment(this.PaymentID);

        }
        bool _AddNew()
        {

            if (!_CheckIfDataISCorrect())
            {
                return false;
            }


            if (SaveServices())
            {


                clsOperationRoomReservation roomReservation = new clsOperationRoomReservation();
                roomReservation.ServiceID = this.ServiceID;
                roomReservation.Date_Time = this.ServiceStartDateTime;
                roomReservation.RoomID = this.OperationRoomID;
                if (roomReservation.Save())
                {
                    Result = enOperationResult.enUnknown;
                    this.OperationID = clsOperationsDAL.AddNewOperation(this.MedicalRecordID, this.SpecilizationID, Convert.ToInt32(this.Result), this.ServiceID, this.OperationRoomID);

                    if (this.OperationID == -1)
                    {

                        _RollBackFromFailedOperationAdd(roomReservation);

                    }
                }
                else
                {
                    _RollBackFromFailedRoomReservationAddition();
                }
                

            }

            return this.OperationID != -1;
        }

        [Documentation("this Method is Used to get the result of the operation and updating the patient state")]
        bool _ReturnOperationResultAndState()
        {
            if (State == enState.enFinished)
            {
                clsPatients patient = clsPatients.FindByID(this.PatientID);

                if (Result == enOperationResult.enFailed)
                {
                    patient.PatientState = clsPatients.enState.enDead;
                    if (patient.SavePatient())
                    {



                        return clsOperationsDAL.UpdateOperationInfo(OperationID, _MedicalRecordID, _specilizationID, Convert.ToInt32(Result), ServiceID, _OperationRoomID);


                    }

                    else
                    {
                        Cause = clsFailCauses.enServicesFailCause.enFailedToSavePatient;

                        return false;
                    }
                }
                else if (Result == enOperationResult.enSucceded)
                {
                    {
                        patient.PatientState = clsPatients.enState.enAlive;
                        if (patient.SavePatient())
                        {
                            return clsOperationsDAL.UpdateOperationInfo(OperationID, _MedicalRecordID, _specilizationID, Convert.ToInt32(Result), ServiceID, _OperationRoomID);
                        }
                        else
                        {
                            Cause = clsFailCauses.enServicesFailCause.enFailedToSavePatient;

                            return false;
                        }
                    }


                }
                else
                {
                    return false;
                }

            }
            else if (State == enState.enBending)
            {

                Result = enOperationResult.enUnknown;
                return clsOperationsDAL.UpdateOperationInfo(OperationID, _MedicalRecordID, _specilizationID, Convert.ToInt32(Result), ServiceID, _OperationRoomID);



            }
            else
            {
                //clsRoleBack.DeleteAllDoctorsReservationForOperation(ServiceID);
                //clsRoleBack.DeleteAllNurseReservationForOperation(ServiceID);
                return true;
            }
        }
        bool _Update()
        {
            if (!_CancceldOrFinished)
            {
                if (_CheckIfDataISCorrect())
                {
                  

                    


                    if (SaveServices())
                    {
                        clsOperationRoomReservation Reserv = clsOperationRoomReservation.FindReservationRecordByServiceID(this.ServiceID);
                        Reserv.Date_Time = this.ServiceStartDateTime;
                        if (Reserv.Save())
                        {
                         return   _ReturnOperationResultAndState();
                        }

                    }
                    else
                    {
                        return false;
                    }

                }
            }
            else
            {
                Cause = clsFailCauses.enServicesFailCause.enCancelledOrFinished;
            }
            return false;
        }
        /// <summary>
        /// Saves Changes Into DB
        /// </summary>
        /// <returns></returns>
        public bool SaveOperation()
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
