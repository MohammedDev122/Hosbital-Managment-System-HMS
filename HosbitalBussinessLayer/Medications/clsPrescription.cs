using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Logs;
using HosbitalDataAccessLayer.MediationsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Medications
{


    /// <summary>
    /// Manages Prescriptions
    /// </summary>
    [Documentation("Used to Manage Prescriptions for Patient")]
    public class clsPrescription


    {
        public int PrescriptionID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int MedicalRecordID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _MedicalRecordID = -1;
        [Documentation("used to Make sure that the Prescription Is not updated if already fully dispensed/Cancelled")]
        bool _Cancelled = false;
      public  enum enPrescriptionState  { enPartiallydispensed = 1, enFullydispensed = 2, enStill=3, enCancelled=4 }
        [Documentation("detrmine the state of the prescription")]
        public enPrescriptionState State = enPrescriptionState.enStill;
       
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Prescription failed.
        /// </summary>
        public clsFailCauses.enPrescriptionFailCause FailCause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsPrescription()
        {
            this.PrescriptionID = -1;
            this.MedicalRecordID = -1;
            this.State = enPrescriptionState.enStill;
            _Cancelled = false;
               Mode = enMode.enAddNew;
            FailCause = clsFailCauses.enPrescriptionFailCause.enUnKnownError;
            _MedicalRecordID = -1;
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsPrescription(int PrescriptionID, int MedicalRecordID, enPrescriptionState State)
        {
            this.PrescriptionID = PrescriptionID;
            this.MedicalRecordID = MedicalRecordID;
            this.State = State;
            this._MedicalRecordID = MedicalRecordID;
            Mode = enMode.enUpdate;
            FailCause = clsFailCauses.enPrescriptionFailCause.enUnKnownError;

            //if (clsPatients.FindByID(clsMedicalRecords.FindMedicalRecordByID(MedicalRecordID).PatientID).PatientState == clsPatients.enState.enDead && State != enPrescriptionState.enCancelled){

            //    this.State = enPrescriptionState.enCancelled;
            //    Save();
            //}
            if (this.State == enPrescriptionState.enCancelled)
            {
                _Cancelled = true;
            }

        }
        static public clsPrescription FindPrescriptionByID(int PrescriptionID)
        {

            
           
            int MedicalRecordID = -1;
            int PrescriptionState = -1;

            if (clsPrescriptionDAL.GetPrescriptionInfoByID(PrescriptionID, ref MedicalRecordID, ref PrescriptionState))
            {
                return new clsPrescription(PrescriptionID, MedicalRecordID,(enPrescriptionState) PrescriptionState);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {

            if (PrescriptionID == -1)
            {
                if (clsMedicalRecords.FindMedicalRecordByID(this.MedicalRecordID) == null)
                {
                    FailCause = clsFailCauses.enPrescriptionFailCause.enWrongMedRecID;
                    return false;
                }
            
            if(clsPatients.FindByID(clsMedicalRecords.FindMedicalRecordByID(MedicalRecordID).PatientID).PatientState == clsPatients.enState.enDead)
                {
                    FailCause = clsFailCauses.enPrescriptionFailCause.enDeadPatient;
                    return false;
                }
            
            
            
            }
            return true;

        }
        bool _AddNewPrescription()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.State = enPrescriptionState.enStill;
                this.PrescriptionID = clsPrescriptionDAL.AddNewPrescription(this.MedicalRecordID,Convert.ToInt32(this.State));
               
            }
           return this.PrescriptionID != -1;



        }
        /// <summary>
        ///  Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>

        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewPrescription())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdatePrescription())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdatePrescription()
        {
            if (!_Cancelled)
            {
                return clsPrescriptionDAL.UpdatePrescriptionInfo(this.PrescriptionID, this._MedicalRecordID, Convert.ToInt32(this.State));
            }
            return false;

        }
        /// <summary>
        /// Gets All Prescriptions According To View Level
        /// </summary>
        /// <param name="Showing"></param>
        /// <param name="ID"></param>
        /// <returns>All Patient's Prescriptions By Patient ID If Viewed for Patient,All Doctor Writen Prescription by Doctor ID If Viewed For Employee,Get All Prescription If Viewed For Admin
        /// and return empty Table If Not View By Any</returns>
        [Documentation("gets all prescription According to view level requested")]
        static public DataTable GetAllPrescriptions(clsViews.enShowing Showing,int ID=-1)
        {
            switch (Showing)
            {

                case(clsViews.enShowing.enPatientOwner):
                    return clsPrescriptionDAL.GetAllPrescriptionsForPatient(ID);
                    case (clsViews.enShowing.enAdmin):
                    return clsPrescriptionDAL.GetAllPrescriptions();
                case (clsViews.enShowing.enInfoEmployeeOwner):
                    return clsPrescriptionDAL.GetAllPrescriptionsForDoctor(ID);

                default:
                    return new DataTable();



            }
        }
        static public DataTable GetAllPrescriptionsForPatient(int PatientID)
        {

            return clsPrescriptionDAL.GetAllPrescriptionsForPatient(PatientID);
        }
        static public bool Exist(int PrescriptionID)
        {
            return clsPrescriptionDAL.IsExist(PrescriptionID);
        }

    }
}
