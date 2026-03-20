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
    ///Manages Medical Catorgies
    /// </summary>
    [Documentation("used to manage and organize each medicine signed in the system under spacific catogry")]
    public  class clsMedicalCatorgies

    {
        public int CatorgyID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public string Catorgy { get; set; }
        
        public int NumOfMedication { get; set; }
      
        enum enMode { enAddNew, enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode = enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Catorgy failed.
         /// </summary>
        public clsFailCauses.enCatorgiesFailCause FailCause
        {
            [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
            get; private set; }
        [Documentation("this is used to assign the object from the Code")]
        public clsMedicalCatorgies()
        {
            this.CatorgyID = -1;
            this.Catorgy = "";
           
            this.NumOfMedication = 0;
            Mode = enMode.enAddNew;
            FailCause = clsFailCauses.enCatorgiesFailCause.enUknownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]
        private clsMedicalCatorgies(int CatorgyID, string Catorgy, int NumOfMedication)
        {
            this.NumOfMedication = NumOfMedication;
            this.CatorgyID = CatorgyID;
            this.Catorgy = Catorgy;
            

            Mode = enMode.enUpdate;
            FailCause = clsFailCauses.enCatorgiesFailCause.enUknownError;

        }
        static public clsMedicalCatorgies FindCatorgyByID(int CatorgyID)
        {
            string Catorgy = "";
            int NumOfMedication = 0;
            if (clsMedicationCatorgyDAL.GetCatorgyInfoByID(CatorgyID, ref Catorgy, ref NumOfMedication))
            {
                return new clsMedicalCatorgies(CatorgyID, Catorgy, NumOfMedication);
            }

            return null;



        }
        static public clsMedicalCatorgies FindCatorgyByName(string CatorgyName)
        {
            int CatorgyID = -1;
           
            int NumOfMedication = 0;
            if (clsMedicationCatorgyDAL.GetCatorgyInfoByName(CatorgyName, ref CatorgyID, ref NumOfMedication))
            {
                return new clsMedicalCatorgies(CatorgyID, CatorgyName, NumOfMedication);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {


            if (Catorgy.Length == 0 )
            {
                FailCause = clsFailCauses.enCatorgiesFailCause.enVeryShortCatorgyName;
                return false;
            }

            if (this.NumOfMedication < 0)
            {
                FailCause = clsFailCauses.enCatorgiesFailCause.enMedicationNumBellowZero;
                return false;
            }
          
            return true;

        }
        bool _AddNewCatorgy()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.CatorgyID = clsMedicationCatorgyDAL.AddNewCatorgy( this.Catorgy, this.NumOfMedication);
            }
            return this.CatorgyID != -1;



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

                    if (_AddNewCatorgy())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;
                case (enMode.enUpdate):
                    if (UpdateCatorgey())
                    {
                        return true;
                    }
                    return false;


            }
            return false;
        }
        bool UpdateCatorgey()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsMedicationCatorgyDAL.UpdateCatorgieInfo(this.CatorgyID, this.Catorgy, this.NumOfMedication);
            }
            return false;
        }
        static public DataTable GetAllCatorgies()
        {

            return clsMedicationCatorgyDAL.GetAllCatorgiess();
        }
        static public bool Exist(int CattorgyID)
        {
            return clsMedicationCatorgyDAL.IsExist(CattorgyID);
        }

    }
}
