using HosbitalBussinessLayer.DerivedTables;
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
    /// Links medications with prescriptions and manages prescribed medication details.
    /// </summary>
    [Documentation("used for linking the medication with the prescription as prescriped Med")]
    public class clsPrescripedMed


    {
        public int PrescripedMedID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public double Dosage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PrescriptionID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _PrescriptionID ;
        public string Instructions {  get; set; }
        public int MedicationID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _MedicationID;
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        public enum enState { enDispensed =1, enStill =2}
        [Documentation("used to detrmine If the Prescriped Medication Already Dispensed or still not")]
        public enState State = enState.enStill;
        [Documentation(@"used to Make sure that the Prescriped Med Is not updated if already dispensed 
and also to not proceed in any process whether it was adding new prescriped medication or update existing one if the prescription is already cancelled or dispensed")]

        bool _CancelledOrDispensed = false;
        /// <summary>
        /// Indicates why saving the Prescriped Medication failed.
        /// </summary>
        public clsFailCauses.enPrescripedMedFailCause FailCause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsPrescripedMed()
        {
            this.PrescripedMedID = -1;
            this.Dosage = 0;

            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.PrescriptionID = -1;
            this._PrescriptionID = -1;
            Instructions = "";
            this.MedicationID = -1;
            this._MedicationID = -1;


            Mode = enMode.enAddNew;
            FailCause = clsFailCauses.enPrescripedMedFailCause.enUnKnownError;
            State = enState.enStill;
            _CancelledOrDispensed = false;
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsPrescripedMed(int PrescripedMedID, double Dosage, DateTime StartDate, DateTime EndDate, int PrescriptionID, string Instructions,int MedicationID,enState State)
        {
            this.PrescripedMedID = PrescripedMedID;
            this.Dosage = Dosage;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.PrescriptionID = PrescriptionID;
            this.Instructions = Instructions;
            this.MedicationID = MedicationID;
            this.State = State;
            _MedicationID = MedicationID;
            this._PrescriptionID = PrescriptionID;
            Mode = enMode.enUpdate;
            FailCause = clsFailCauses.enPrescripedMedFailCause.enUnKnownError;
            if (this.State != enState.enStill)
            {
                _CancelledOrDispensed = true;
            }
            clsPrescription prescription = (clsPrescription.FindPrescriptionByID(this.PrescriptionID));
            if (prescription.State == clsPrescription.enPrescriptionState.enCancelled)
            {
                _CancelledOrDispensed = true;
            }
        }
        static public clsPrescripedMed FindPrescripedMedicationByID(int PrescripedMedID)
        {
            DateTime StartDate=DateTime.Now;
                DateTime EndDate = DateTime.Now;
            int PrescriptionID = -1;
            double Dosage = 0;
            string Instructions = "";
            int MedicationID = -1;
            int State = -1;
            if (clsPrescripedMedDAL.GetPrescripedMedicationInfoByID(PrescripedMedID, ref Dosage, ref StartDate, ref EndDate, ref PrescriptionID, ref Instructions,ref MedicationID,ref State))
            {
                return new clsPrescripedMed(PrescripedMedID, Dosage, StartDate, EndDate, PrescriptionID, Instructions, MedicationID,(enState)State);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {


            if (PrescripedMedID == -1)
            {
                if (StartDate.Date < DateTime.Now.Date)
                {
                    FailCause = clsFailCauses.enPrescripedMedFailCause.enWrongStartDate;
                    return false;
                }
                clsPrescription prescription = clsPrescription.FindPrescriptionByID(PrescriptionID);
                if (prescription == null)
                {
                    FailCause = clsFailCauses.enPrescripedMedFailCause.enWrongPrescriptionID;
                    return false;
                }
                if (prescription.State == clsPrescription.enPrescriptionState.enCancelled)
                {
                    FailCause = clsFailCauses.enPrescripedMedFailCause.enPrescriptionIsCancelled;
                    return false;
                }
                if (clsMedications.FindMedicationByID(MedicationID) == null)
                {
                    FailCause = clsFailCauses.enPrescripedMedFailCause.enWrongMedicationID; ;
                    return false;
                }
            }
          
          
         
          
            if (this.Dosage<0.00001)
            {
                FailCause = clsFailCauses.enPrescripedMedFailCause.enDosageIsBellowZero;
                return false;
            }
           
            if (EndDate.Date < StartDate.Date)
            {
                FailCause = clsFailCauses.enPrescripedMedFailCause.enWrongEndDate;
                return false;
            }




            if (Instructions.Length == 0)
            {
                FailCause = clsFailCauses.enPrescripedMedFailCause.enThereIsNoInstructions;
                return false;
            }



            return true;

        }
        bool _AddNewPrescripedMed()
        {
            if (!_CancelledOrDispensed)
            {
                if (_CheckIfDataIsCorrect())
                {
                    this.State = enState.enStill;
                    this.PrescripedMedID = clsPrescripedMedDAL.AddNewPrescripedMedication(this.Dosage, this.StartDate, this.EndDate, this.PrescriptionID, this.Instructions, this.MedicationID, Convert.ToInt32(this.State));
                    return PrescripedMedID != -1;
                }
            }
            return false;



        }

        /// <summary>
        /// Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>

        public bool Save()
        {
            switch (Mode)
            {
                case (enMode.enAddNew):

                    if (_AddNewPrescripedMed())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (_UpdatePrescripedMed())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool _UpdatePrescripedMed()
        {
            if (!_CancelledOrDispensed)
            {
                if (_CheckIfDataIsCorrect())
                {
                    return clsPrescripedMedDAL.UpdatePrescripedMedicationInfo(this.PrescripedMedID, this.Dosage, this.StartDate, this.EndDate, this._PrescriptionID, this.Instructions, this._MedicationID, Convert.ToInt32(State));
                }
            }
            else
            {
                FailCause = clsFailCauses.enPrescripedMedFailCause.enPrescripedMedIsDispensedOrCancelled;
            }
            return false;
        }
        static public DataTable GetAllPrescripedMed()
        {

            return clsPrescripedMedDAL.GetAllPrescripedMedications();
        }
        static public bool Exist(int PrescripedMedID)
        {
            return clsPrescripedMedDAL.IsExist(PrescripedMedID);
        }
        static public DataTable GetAllPrescripedMedForPrescription(int PrescriptionID)
        {

            return clsPrescripedMedDAL.GetAllPrescripedMedicationsForPrescription(PrescriptionID);
        }
    }
}
