using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Logs;
using HosbitalDataAccessLayer.LogsDAL;
using HosbitalDataAccessLayer.procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HosbitalBussinessLayer.clsViews;
using Documentationattribute;

namespace HosbitalBussinessLayer.Procedures
{
    /// <summary>
    /// Manages diagnosis services.
    /// </summary>
    [Documentation("this class is used to Manage Diagnosis's info,set Medical Record If Needed, booking an appointment and it inherits it's props & methods from clsServices Class")]
    public class clsDiagnosis : clsServices

    {

        public int DiagnosisID { get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }

        public int DoctorID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _DoctorID = -1;

        public clsMedicalRecords MedicalRecord { get; set; }
        public int SpecilizationID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _specilizationID = -1;

        [Documentation("this is used to assign the object from the Code, we set the service type to 2 -diagnosis- by default. note:you can't change it.")]

        public clsDiagnosis() : base()
        {
            this.DiagnosisID = -1;
            this.DoctorID = -1;
            this.MedicalRecord = new clsMedicalRecords();
            this.SpecilizationID = -1;
            this.ServiceTypeID = 2;


        }
        [Documentation(@"this Is Used to Assign The object After Getting It's Data from Database,it sends all the Data the clsServices 
class need to create an object. also it does auto assign service type
into 2 to make the system knows it's a diagnosis service and set it's price automatically -also we made it this way to make it impossible to change the price of the service from here")]
        private clsDiagnosis(int DiagnosisID, int DoctorID, int MedicalRecordID, int SpecilizationID,
            int ServiceID, DateTime Date, DateTime ServiceStartTime,
            DateTime? ServiceEndTime, int PatientID, int PaymentID, enState State) :
            base(ServiceID, Date, ServiceStartTime, ServiceEndTime, PatientID, PaymentID, 2, State)
        {

            this.DiagnosisID = DiagnosisID;
            this.DoctorID = DoctorID;
            this.MedicalRecord = clsMedicalRecords.FindMedicalRecordByID(MedicalRecordID);
            if (this.MedicalRecord == null)
            {
                MedicalRecord = new clsMedicalRecords();
            }

            this.SpecilizationID = SpecilizationID;
            this._DoctorID = DoctorID;
            this._specilizationID = SpecilizationID;


        }
        static public clsDiagnosis GetDiagnosisInfoByID(int DiagnosisID)
        {




            int DoctorID = -1;
            int MedicalRecordID = -1;
            int SpecilizationID = -1;
            int ServiceID = -1;
            if (clsDiagnosisDAL.GetDiagnosisInfo(DiagnosisID, ref DoctorID, ref MedicalRecordID, ref SpecilizationID, ref ServiceID))
            {
                clsServices service = GetServiceInfoByID(ServiceID);

                return new clsDiagnosis(DiagnosisID, DoctorID, MedicalRecordID, SpecilizationID, ServiceID, service.ServiceStartDateTime,
                    service.ServiceStartDateTime, service.ServiceEndTime, service.PatientID, service.PaymentID, service.State);


            }
            return null;




        }






        static public bool Exist(int DiagnosisID)
        {
            return clsDiagnosisDAL.ISExist(DiagnosisID);
        }

        bool _CheckIfDataISCorrect()

        {
            if (this.DiagnosisID == -1)
            {

                if (clsDoctors.FindByID(this.DoctorID) == null)
                {
                    Cause = clsFailCauses.enServicesFailCause.enWrongDoctorID;
                    return false;
                }
                if (clsDoctors.FindByID(this.DoctorID).EmployeeState == clsDoctors.enState.enFired)
                {
                    Cause = clsFailCauses.enServicesFailCause.enPassedDoctorDueDate;
                    return false;
                }
                if (clsSpecilization.FindSpecilizationByID(this.SpecilizationID) == null)
                {
                    Cause = clsFailCauses.enServicesFailCause.enWrongSpecilization;
                    return false;
                }
                if (clsDoctors.FindByID(DoctorID).SpecilizationID != SpecilizationID)
                {
                    Cause = clsFailCauses.enServicesFailCause.enIncompatiblespec;
                    return false;
                }
                if (!clsDoctorReservation.CheckDiagnosisReservationDosentOverLap(this.DoctorID, this.ServiceStartDateTime, this.ServiceStartDateTime, this.ServiceID))
                {

                    Cause = clsFailCauses.enServicesFailCause.enOverLappedTime;
                    return false;

                }
            }
            else
            {
                if (!clsDoctorReservation.CheckDiagnosisReservationDosentOverLap(this._DoctorID, this.ServiceStartDateTime, this.ServiceStartDateTime, this.ServiceID))
                {
                    Cause = clsFailCauses.enServicesFailCause.enOverLappedTime;

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


            if (SaveServices())
            {

                clsDoctorReservation doctorReservation = new clsDoctorReservation();
                doctorReservation.DoctorID = this.DoctorID;
                doctorReservation.ServiceID = this.ServiceID;
                doctorReservation.Date_Time = this.ServiceStartDateTime;
                if (doctorReservation.Save())
                {
                    this.DiagnosisID = clsDiagnosisDAL.AddNewDiagnosis(this.DoctorID, this.MedicalRecord.RecordID, this.SpecilizationID, this.ServiceID);
                    if (this.DiagnosisID == -1)
                    {
                        Cause = clsFailCauses.enServicesFailCause.enFailedtoAddDiagnosisDB;
                        clsRoleBack.DeleteService(this.ServiceID);
                        clsRoleBack.DeletePayment(this.PaymentID);
                        clsRoleBack.DeletePatientLog(clsPatientLogs.FindPatientLogByServiceID(this.ServiceID).LogID);
                        clsRoleBack.DeleteDoctorReservation(doctorReservation.ReservationID);



                    }
                }
                else
                {
                    Cause = clsFailCauses.enServicesFailCause.enFailedToAddReservation;
                    clsRoleBack.DeleteService(this.ServiceID);
                    clsRoleBack.DeletePayment(this.PaymentID);
                    clsRoleBack.DeletePatientLog(clsPatientLogs.FindPatientLogByServiceID(this.ServiceID).LogID);
                }

            }

            return this.DiagnosisID != -1;
        }



        bool _Update()
        {
            if (!_CancceldOrFinished)
            {
                if (_CheckIfDataISCorrect())
                {
                    clsDoctors Doctor = clsDoctors.FindByID(_DoctorID);
                    if (Doctor.EmployeeState == clsEmployees.enState.enFired)
                    {

                        if (DateTime.Compare((DateTime)this.ServiceStartDateTime, (DateTime)Doctor.DueDate) > 0)
                        {
                            Cause = clsFailCauses.enServicesFailCause.enPassedDoctorDueDate;
                            return false;
                        }

                    }


                    if (SaveServices())
                    {
                        clsDoctorReservation Reserv = clsDoctorReservation.FindReservationRecordByServiceID(this.ServiceID);
                        Reserv.Date_Time = this.ServiceStartDateTime;
                        Reserv.Save();

                        if (State == enState.enFinished)
                        {

                            if (!string.IsNullOrEmpty(this.MedicalRecord.DiagnosticNotes))
                            {
                                MedicalRecord.PatientID = this._PatientID;
                                MedicalRecord.State = clsMedicalRecords.enState.enWorking;



                                if (MedicalRecord.Save())
                                {


                                    return clsDiagnosisDAL.UpdateDiagnosisInfo(DiagnosisID, _DoctorID, MedicalRecord.RecordID, _specilizationID, ServiceID);
                                }
                            }
                            else
                            {

                                return clsDiagnosisDAL.UpdateDiagnosisInfo(DiagnosisID, _DoctorID, MedicalRecord.RecordID, _specilizationID, ServiceID);

                            }

                        }
                        else
                        {
                            return true;
                        }

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
        public bool SaveDiagnnosis()
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
        /// Returns the diagnosis ID linked to a specific medical record.
        /// </summary>
        /// <param name="MedRecID"></param>
        /// <returns></returns>
        [Documentation("every Medical Record Is A result of a Diagnosis but not every diagnosis could lead to medical Record so we can search the diagnosis by the medical record")]
        public static int GetDiagnosisIDbyMedicalRecordID(int MedRecID)
        {
            return clsDiagnosisDAL.GetDiagnosisIDByMedicalRecID(MedRecID);
        }





        /// <summary>
        /// Returns all diagnosis records based on view level.
        /// /// </summary>
        /// <param name="ID"></param>
        /// <param name="Showing"></param>
        /// <returns> diagnosis data for admin, doctor, or patient depending on view level.
        /// </returns>
        [Documentation("gets  Diagnosis info depending on view level ")]

        static public DataTable GetAll(int ID, clsViews.enShowing Showing)
        {
            switch (Showing)
            {
                case (clsViews.enShowing.enAdmin):
                    return clsDiagnosisDAL.GetAllDiagnosis();
                case (clsViews.enShowing.enInfoEmployeeOwner):
                    return clsDiagnosisDAL.GetAllDoctorDiagnosis(ID);
                default:
                    return clsDiagnosisDAL.GetAllPatientDiagnosis(ID);




            }
        }
     
     
      
     
    }
}
