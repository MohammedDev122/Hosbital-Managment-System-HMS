using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer;
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
    ///Manages patient medical records.
    /// </summary>
    [Documentation("it Is Used To Manage Patient's Medical Record and is Used To Get A Prescription or have Operation")]
    public class clsMedicalRecords
    {
        public int RecordID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int PatientID { get; set; }
        public string DiagnosticNotes { get; set; }

        public enum enState { enCancelled=1,enWorking=2}
        [Documentation("it Is Used To get The State Of This MR Whether it can be used to have operations and Prescription or cancelled")]

        public enState State = enState.enWorking;
        /// <summary>
        /// Indicates why saving the Medical Record failed.
        /// </summary>
        public clsFailCauses.enLogsAndRecFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }

        enum enMode { enUpdate,enAddNew}
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode _Mode = enMode.enAddNew;
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        private int _PatientID = -1;
        [Documentation("this is used to assign the object from the Code")]

        public clsMedicalRecords()
        {
            this.RecordID = -1;
            this.PatientID = -1;
            this.DiagnosticNotes = "";
            this._PatientID = -1;
            this.State = enState.enWorking;
            this._Mode = enMode.enAddNew;

            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsMedicalRecords(int RecordID, int PatientID, string DiagnosticNotes,enState State)
        {
            this.RecordID = RecordID;
            this.PatientID = PatientID;
            this.DiagnosticNotes = DiagnosticNotes;
            this._PatientID = this.PatientID;
            this._Mode = enMode.enUpdate;
            this.State=State;
         Cause= clsFailCauses.enLogsAndRecFailCause.enUnkownError;

        }
        static public clsMedicalRecords FindMedicalRecordByID(int RecordID)
        {

            int PatientID = -1;
            string DiagnosticNotes = "";
            int StateID = -1;
            if (clsMedicalRecordDAL.GetMedicalRecordInfoByID(RecordID, ref PatientID, ref DiagnosticNotes,ref StateID))
            {
                return new clsMedicalRecords(RecordID, PatientID, DiagnosticNotes,(enState)StateID);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {
            if (this.RecordID == -1)
            {
                clsPatients patient=clsPatients.FindByID(this.PatientID);
                if (patient == null) {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enWrongPatientID;
                    return false;
                }

                if (patient.PatientState == clsPatients.enState.enDead)
                {
                    Cause = clsFailCauses.enLogsAndRecFailCause.enPatientIsDead;
                    return false;
                }
                
                    
            }
            else
            {
                if (clsPatients.FindByID(PatientID).PatientState == clsPatients.enState.enDead)
                {
                    State = enState.enCancelled;
                    return true;
                }
                else
                {
                    if (this.DiagnosticNotes.Length == 0)
                    {

                        Cause = clsFailCauses.enLogsAndRecFailCause.enThereIsNoDiagnsticNotes;
                        return false;
                    }
                }
            }

                return true;
        }
        bool _AddNew()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.State = enState.enWorking;
                this.RecordID = clsMedicalRecordDAL.AddNewMedicalRecord(this.PatientID, this.DiagnosticNotes, Convert.ToInt32(this.State));
            }
            return this.RecordID != -1;



        }
        bool _Update()
        {

            if (_CheckIfDataIsCorrect())
            {
               
                    return clsMedicalRecordDAL.UpdateRecordInfo(this.RecordID
                      , this._PatientID, this.DiagnosticNotes, Convert.ToInt32(this.State));
             
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
        /// Get All Records Depending on View Level
        /// </summary>
        /// <param name="Showing"></param>
        /// <param name="ID"></param>
        /// <returns>All Records For Patient By ID If View Level For Patient ,All Records Written by Doctor by ID if View Level For Doctor, get All Records If ViewLevel For Admin</returns>
        [Documentation("get All Medical Record According To the View Level Required and Given ID")]
        static public DataTable GetAllRecords(clsViews.enShowing Showing,int ID)
        {
            switch (Showing)
            {
                case(clsViews.enShowing.enPatientOwner):

                    return clsMedicalRecordDAL.GetAllRecordsForPatient(ID);
                case (clsViews.enShowing.enInfoEmployeeOwner):
                    return clsMedicalRecordDAL.GetAllRecordsForDoctor(ID);

                default:
                    return clsMedicalRecordDAL.GetAllRecords();





            }
        }
        static public bool Exist(int RecordID)
        {
            return clsMedicalRecordDAL.IsExist(RecordID);
        }
     

    }

}
