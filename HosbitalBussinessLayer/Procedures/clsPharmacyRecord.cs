using HosbitalBussinessLayer.DerivedTables;
using HosbitalBussinessLayer.Logs;
using HosbitalBussinessLayer.Medications;
using HosbitalDataAccessLayer.procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Procedures
{
    /// <summary>
    /// Manages Pharmecy Records
    /// </summary>
    [Documentation("this class is used to manage all patient_pharmacey processes")]
    public class clsPharmacyRecord

    {

        public int RecordID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int PatientID { get; private set; }
        public int PharmacistID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        protected int _PharmacistID = -1;
        public clsBasket Basket;
        public int PrescriptionID {  get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _PrescriptionID = -1;
        public DateTime? Date { get; private set; }

    

        public int PaymentID { get; private set; }
        [Documentation("it is used to check if the prescription we use is cancelled if so we can't procceed with the service")]
        protected bool _CancceldOrFinished = false;
        protected enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        protected enMode _Mode = enMode.enAddNew;
      public clsPrescription.enPrescriptionState prescriptionState { get; private set; }
        /// <summary>
        /// Indicates why saving the Pharmecy Record failed.
        /// </summary>
        public clsFailCauses.enPharmecyRecFailCause Cause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] protected set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsPharmacyRecord()
        {

            this.RecordID = -1;
            this.PatientID = -1;
            this.PaymentID = -1;
            this.Date = null;
            this.PharmacistID = -1;
            _PharmacistID = -1;
            this.PrescriptionID = -1;
            this._PrescriptionID = -1;
            _Mode = enMode.enAddNew;
            Basket = new clsBasket();
            Cause = clsFailCauses.enPharmecyRecFailCause.enUnkownError;
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        protected clsPharmacyRecord(int RecordID, DateTime? Date, int PatientID, int PaymentID, int PharmacistID, int PrescriptionID,clsBasket Basket)
        {

            this.RecordID = RecordID;
            this.Date = Date;
            this.PatientID = PatientID;
                this.PaymentID = PaymentID;
            this.PharmacistID = PharmacistID;
            this.PrescriptionID = PrescriptionID;
            this._PrescriptionID= PrescriptionID;
            _Mode = enMode.enUpdate;
            _PharmacistID = this.PharmacistID;
            prescriptionState = clsPrescription.FindPrescriptionByID(this.PrescriptionID).State;
            if(prescriptionState == clsPrescription.enPrescriptionState.enCancelled)
            {

                _CancceldOrFinished = true;

            }
            this.Basket = Basket;
            Basket.PrescriptionID= PrescriptionID;
          
            Cause = clsFailCauses.enPharmecyRecFailCause.enUnkownError;


        }
        static public clsPharmacyRecord GetPharmecyRecordInfoByID(int RecordID)
        {



         
            DateTime? Date = null;
            int PatientID = -1;
            int PaymentID = -1;
            int PharmacistID = -1;
            int PrescripedMedID = -1;
            int BasketID = -1;
            if (clsPharmacyRecordDAL.GetPharmacyRecInfo(RecordID, ref PharmacistID, ref PatientID, ref PrescripedMedID, ref PaymentID, ref Date,ref BasketID))
            {

                return new clsPharmacyRecord(RecordID,Date,PatientID,PaymentID,PharmacistID,PrescripedMedID,clsBasket.FindBasketByID(BasketID));


            }

            return null;









        }

        static public DataTable GetAll()
        {
            return clsPharmacyRecordDAL.GetAllPharmacyRecs();
        }

        static internal DataTable GetAllRecsForPatient(int PatientID)
        {
            return clsPharmacyRecordDAL.GetAllPharmacyRecsForPatient(PatientID);
        }
       

        static public bool Exist(int PharmacistID)
        {
            return clsPharmacyRecordDAL.ISExist(PharmacistID);
        }
      
        bool _CheckIfDataISCorrect()

        {
           
            
            clsPrescription prescription = clsPrescription.FindPrescriptionByID(this.PrescriptionID);


                if (prescription == null)
                {
                    Cause = clsFailCauses.enPharmecyRecFailCause.enWrongPrescriptionID;
                    return false;
                }


            this.prescriptionState = prescription.State;
            if (this.prescriptionState == clsPrescription.enPrescriptionState.enCancelled)
            {
                Cause = clsFailCauses.enPharmecyRecFailCause.enPrescriptionCancelled;

                return false;
            }
          

            PatientID = clsMedicalRecords.FindMedicalRecordByID(prescription.MedicalRecordID).PatientID;
                if (clsPatients.FindByID(this.PatientID).PatientState == clsPatients.enState.enDead)
                {
                    Cause = clsFailCauses.enPharmecyRecFailCause.enPatientIsDead;
                    return false;
                }

                clsPharmacists Pharmacist = clsPharmacists.FindByID(PharmacistID);
                if (Pharmacist == null)
                {
                    Cause = clsFailCauses.enPharmecyRecFailCause.enWrongPharmacistID;
                    return false;

                }
                if (Pharmacist.EmployeeState==clsEmployees.enState.enFired)
                {
                    Cause = clsFailCauses.enPharmecyRecFailCause.enPharmacistisFired;
                    return false;

                }
           
                clsPayments payment = new clsPayments();
                payment.PayedAmmount = Basket.TotalPrice;
                payment.Save();
                this.PaymentID = payment.PaymentID;
                if (this.PaymentID == -1)
                {
                    Cause = clsFailCauses.enPharmecyRecFailCause.enPaymentFailed;
                    return false;
                }
              
           
            return true;


        }
      
        bool _AddNew()
        {








            if (!_CheckIfDataISCorrect())
            {
                return false;
            }
            if (!Basket.Save()) { 
            
            return false;
            }

            this.RecordID = clsPharmacyRecordDAL.AddNewRecord(this.PharmacistID, this.PatientID, this.PrescriptionID, this.PaymentID, this.Date,Basket.BasketID);


            if (this.RecordID != -1)
            {
                _PharmacistID = this.PharmacistID;
                _PrescriptionID=this.PrescriptionID;
               
                return true;
            }
            else
            {

                clsRoleBack.DeletePayment(this.PaymentID);
                return false;
            }
        }
        bool _checkIFAllMedicineInPrescriptionIsDisspensed(int PrescID)
        {

            DataTable dtPrescMed = clsPrescripedMed.GetAllPrescripedMedForPrescription(PrescID);
            clsPrescripedMed PMed;
            foreach (DataRow dr in dtPrescMed.Rows)
            {


                PMed = clsPrescripedMed.FindPrescripedMedicationByID(Convert.ToInt32(dr["PrescriptionMedID"]));
                if (PMed.State != clsPrescripedMed.enState.enDispensed)
                {
                    return false;
                }



            }

            return true;

        }
        bool _Update()
        {
            if (!_CancceldOrFinished)
            {
               
                clsPayments Payment = clsPayments.GetPaymentInfoByID(this.PaymentID);
                switch (Payment.status)
                {
                    case (clsPayments.enPaymentStatus.enPayed):

                       this.Date = DateTime.Now;
                                _CancceldOrFinished = true;
                        if (Basket.Save())
                        {
                            clsPrescription presc = clsPrescription.FindPrescriptionByID(PrescriptionID);

                            if (_checkIFAllMedicineInPrescriptionIsDisspensed(presc.PrescriptionID))
                            {
                                presc.State = clsPrescription.enPrescriptionState.enFullydispensed;
                            }
                            else
                            {
                                presc.State = clsPrescription.enPrescriptionState.enPartiallydispensed;

                            }
                            if (presc.Save())
                            {
                                return clsPharmacyRecordDAL.UpdatePharmacyRecInfo(RecordID, _PharmacistID, PatientID, _PrescriptionID, PaymentID, Date,Basket.BasketID);

                            }
                        }
                      
                        return false;
                  

                 

                    default:
                        return false;

                }

            }
            Cause = clsFailCauses.enPharmecyRecFailCause.enCancelledOrFinished;
            return false;
        }
        /// <summary>
        /// Saves the Changes Into DB
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            switch (_Mode)
            {

                case (enMode.enAddNew):
                    if (_AddNew())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
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
