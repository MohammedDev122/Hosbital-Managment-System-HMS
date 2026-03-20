using HosbitalBussinessLayer.DerivedTables;
using HosbitalDataAccessLayer.DerivedTables;
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
    /// Manages Medications Info
    /// </summary>
    [Documentation("Used To Manage the Medication")]
    public class clsMedications

    {
        public int MedicationID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public string MedicationName { get; set; }
        public string Notes { get; set; }
        public int Quantity {  get; set; }
        public double Price {  get; set; }

        public int CatorgyID { get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _CatorgyID;
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Medication info failed.
        /// </summary>
        public clsFailCauses.enMedicationsFailCause FailCause { get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsMedications()
        {
            this.CatorgyID = -1;
            this.MedicationID = -1;
            this.Price = 0;
            this.Notes = "";
            this.Quantity = 0;
            this.MedicationName = "";
            Mode = enMode.enAddNew;
            FailCause = clsFailCauses.enMedicationsFailCause.enUknownError;
            _CatorgyID= -1;
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsMedications(int MedicationID, int CatorgyID, double Price,string Notes,string MedicationName,int Quantity)
        {
            this.CatorgyID = CatorgyID;
            this.MedicationID = MedicationID;
            this.Price = Price;
            this.Notes = Notes;
            this.Quantity = Quantity;
            this.MedicationName = MedicationName;

            _CatorgyID= CatorgyID;
            Mode = enMode.enUpdate;
            FailCause = clsFailCauses.enMedicationsFailCause.enUknownError;

        }
        static public clsMedications FindMedicationByID(int MedicationID)
        {

            int CatorgyID = -1;
            double Price = 0;
            string Notes = "";
            string MedicationName = "";
            int Quantity = 0;

            if (clsMedIcationDAL.GetMedicationInfoByID(MedicationID,ref MedicationName,ref Notes, ref Quantity, ref Price, ref CatorgyID))
            {
                return new clsMedications(MedicationID, CatorgyID, Price, Notes, MedicationName, Quantity);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {


            if (MedicationName.Length == 0)
            {
                FailCause = clsFailCauses.enMedicationsFailCause.enVeryShortMedName;
                return false;
            }
            if (Notes.Length == 0)
            {
                FailCause = clsFailCauses.enMedicationsFailCause.enVeryShortNotes;
                return false;
            }
            if (this.Quantity < 0)
            {
                FailCause = clsFailCauses.enMedicationsFailCause.enMedQuantityBellowZero;
                return false;
            }
            if (this.Price < 0)
            {
                FailCause = clsFailCauses.enMedicationsFailCause.enMedPriceBellowZero;
                return false;
            }
            if (clsMedicalCatorgies.FindCatorgyByID(this.CatorgyID)==null)
            {
                FailCause = clsFailCauses.enMedicationsFailCause.enWrongMedCatorgy;
                return false;
            }
            return true;

        }
        bool _AddNewMedication()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.MedicationID = clsMedIcationDAL.AddNewMedication(this.MedicationName,this.Notes,this.Quantity,this.Price, this.CatorgyID);
                if(this.MedicationID != -1)
                {
                  clsMedicalCatorgies catorgy=  clsMedicalCatorgies.FindCatorgyByID(this.CatorgyID);
                    catorgy.NumOfMedication++;
                    catorgy.Save();
                    return true;
                }
            }
            return false;



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

                    if (_AddNewMedication())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (UpdateMedication())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool UpdateMedication()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsMedIcationDAL.UpdateMedicationInfo(this.MedicationID,this.MedicationName, this.Notes, this.Quantity,this.Price,this._CatorgyID);
            }
            return false;
        }
        /// <summary>
        /// Gets  Medications Info And Some Info Depend On View Level 
        /// </summary>
        /// <param name="showing"></param>
        /// <returns> All Medications With Full Info If View Level Is Admin ,else if not</returns>
        [Documentation("Gets  Medications Info And Some Info Depend On View Level if the Admin/Pharmacist is calling it will get all Med info if any other it will get the important info only")]
        static public DataTable GetAllMedication(clsViews.enShowing showing)
        {

            switch (showing)
            {

                case (clsViews.enShowing.enAdmin):
                    return clsMedIcationDAL.GetAllMedicationsForAdmin();
                default:
                    return clsMedIcationDAL.GetAllMedicationsForOthers();




            }


        }
        static public bool Exist(int MedIcationID)
        {
            return clsMedIcationDAL.IsExist(MedIcationID);
        }

       
    }
}
