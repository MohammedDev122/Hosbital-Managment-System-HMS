using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.LogsDAL;
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
    ///Manages All the Services That Patient UnderGoes In The Hospital
    /// </summary>
    [Documentation("Manages and store all Patient's Service History")]
    public class clsPatientLogs
    {  
       public int LogID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int ServiceID { get; set; }
        public int PatientID { get; set; }

        public clsPatients PatientInfo { get;[Documentation("You can't Update Or change the Patient's info Through this Class So We Made It Read Only")]private set; }
        public clsServices ServiceInfo { get; [Documentation("You can't Update Or change the service's info Through this Class So We Made It Read Only")] private set;}
        /// <summary>
        /// Indicates why saving the Patient Log failed.
        /// </summary>
        public clsFailCauses.enLogsAndRecFailCause Cause {  get; [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")] private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsPatientLogs()
        {
            this.LogID = -1;
            this.ServiceID = -1;
            this.PatientID = -1;
            this.PatientInfo = new clsPatients();
            this.ServiceInfo = new clsServices();
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;

        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsPatientLogs(int LogID, int ServiceID, int PatientID)
        {
            this.LogID = LogID;
            this.ServiceID = ServiceID;
            this.PatientID = PatientID;
            this.PatientInfo = clsPatients.FindByID(PatientID);
            this.ServiceInfo = clsServices.GetServiceInfoByID(ServiceID);
            if (this.PatientInfo.PatientState == clsPatients.enState.enDead &&this.ServiceInfo.State!=clsServices.enState.enCancelled)
            {
                this.ServiceInfo.State = clsServices.enState.enCancelled;
                this.Save();

            }
            Cause = clsFailCauses.enLogsAndRecFailCause.enUnkownError;


        }
        static public clsPatientLogs FindPatientLogByID(int LogID)
        {
            
            int PatientID =-1;
            int ServiceID = -1;
            if (clsPatientLogDAL.GetPatientLogInfoByID(LogID, ref PatientID, ref ServiceID))
            {
                return new clsPatientLogs(LogID, ServiceID ,PatientID);
            }

            return null;



        }
        static public clsPatientLogs FindPatientLogByServiceID(int ServiceID)
        {

            int PatientID = -1;
            int LogID = -1;
            if (clsPatientLogDAL.GetPatientLogInfoByID(ServiceID, ref PatientID, ref LogID))
            {
                return new clsPatientLogs(LogID, ServiceID, PatientID);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {
            clsPatients Patient = clsPatients.FindByID(this.PatientID);
            if (Patient == null)
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enWrongPatientID;
                return false;
            }
            if (!clsServices.Exist(this.ServiceID)) {
                Cause = clsFailCauses.enLogsAndRecFailCause.enWrongServiceID;
                return false;
            }


                if (Patient.PatientState == clsPatients.enState.enDead)
            {
                Cause = clsFailCauses.enLogsAndRecFailCause.enPatientIsDead;
                return false;
            }
              return true;
            


        }
        bool _AddNewLog()
        {

            if (_CheckIfDataIsCorrect())
            {
                this.LogID = clsPatientLogDAL.AddNewPatientLog(this.PatientID, this.ServiceID);
            }
            return this.LogID != -1;



        }
        /// <summary>
        ///Saves The new log  to DB
        /// </summary>
        /// <returns>true if the new log stored successfully</returns>
        [Documentation("in this Class There is only One Mode Which is Add New once the log is added You Can't Remove nor change it")]
        public bool Save()
        {
           

                    if (_AddNewLog())
                    {
                        return true;
                    }
              return false;
        }
        static public DataTable GetAllLogs()
        {

            return clsPatientLogDAL.GetAllLogs();
        }
        static public bool Exist(int LogID)
        {
            return clsPatientLogDAL.IsExist(LogID);
        }

    }

}

