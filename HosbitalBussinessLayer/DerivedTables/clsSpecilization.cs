using HosbitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    /// <summary>
    ///Manages Medical Specilizations
    /// </summary>
    [Documentation("it is Used To Manage All Medical Specilization In the Hospital")]
    public class clsSpecilization
    {

        public int SpecilizationID {  get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public string SpecilizationName {  get; set; }
       enum enMode { enAddNew,enUpdate }
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode Mode =enMode.enAddNew;
        /// <summary>
        /// Indicates why saving the Specilization  failed.
        /// </summary>
        public clsFailCauses.enSpecFailCause Cause {  get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        [Documentation("this is used to assign the object from the Code")]
        public clsSpecilization()       
        {
        SpecilizationID = -1;
            SpecilizationName = "";
        Mode = enMode.enAddNew;
            Cause = clsFailCauses.enSpecFailCause.enUnkownError;


        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsSpecilization(int SpecilizationID,string SpecilizationName)
        {
            this.SpecilizationID = SpecilizationID;
           this.SpecilizationName = SpecilizationName;
            Mode = enMode.enUpdate;
            Cause = clsFailCauses.enSpecFailCause.enUnkownError;

        }
       static public  clsSpecilization FindSpecilizationByID(int SpecilizationID)
        {
            string SpecName = "";

            if(clsSpecilizationDAL.GetSpecilizationInfoByID(SpecilizationID,ref SpecName))
            {
                return new clsSpecilization(SpecilizationID, SpecName); 
            }

            return null;



        }
        static public clsSpecilization FindSpecilizationByName(string SpecName)
        {
            int SpecilizationID = -1;
            if (clsSpecilizationDAL.GetSpecilizationInfoByName(SpecName, ref SpecilizationID))
            {
                return new clsSpecilization(SpecilizationID, SpecName);
            }

            return null;



        }

        static public  bool DeleteSpecilization(int specilizationID) { 
        
        
        return clsSpecilizationDAL.DeleteSpecilization(specilizationID);
        
        }
        bool _CheckIfDataIsCorrect()
        {
            if (this.SpecilizationName.Length == 0)
            {
                Cause= clsFailCauses.enSpecFailCause.enVeryShortSpecName;
                return false;
            }
            return true;
            }
        bool _AddNewSpec()
        {
            if (_CheckIfDataIsCorrect())
            {
                this.SpecilizationID = clsSpecilizationDAL.AddNewSpecilization(this.SpecilizationName);
            }
            return this.SpecilizationID != -1;



        }



        /// <summary>
        ///Saves The Changes to DB
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>
        public bool Save()
        {
            switch (Mode) {
                case (enMode.enAddNew):

                    if (_AddNewSpec())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
            return false;
                    case (enMode.enUpdate):
                    if (_UpdateSpec()) { 
                    return true;
                    }
            return false;
            
            
            }
            return false;
        }
        bool _UpdateSpec()
        {
            if (_CheckIfDataIsCorrect())
            {
                return clsSpecilizationDAL.UpdateSpecilization(this.SpecilizationID, this.SpecilizationName);
            }
            return false;
        }
        static public  DataTable GetAllSpecilizations() { 
        
        return clsSpecilizationDAL.GetAllSpecilizations();
        }
      static  public bool Exist(int SpecilizationID)
        {
            return clsSpecilizationDAL.IsExist(SpecilizationID);
        }
    }
}
