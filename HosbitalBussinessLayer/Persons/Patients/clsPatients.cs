using HosbitalBussinessLayer.Logs;
using HosbitalBussinessLayer.Medications;
using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.DerivedTables;
using HosbitalDataAccessLayer.procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    /// <summary>
    /// Manages Patient's Info
    /// </summary>
    [Documentation("this class is used to Manage Patient's info and it inherits it's props & methods from clsPerson Class")]

    public class clsPatients : clsPerson
    {

        public int PatientID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public enum enState { enAlive = 1, enDead = 2, enEmergency = 3 }
        [Documentation("used To Manage Patient State,crucial info for any service the patient will have in the Hospital")]

        public enState PatientState = enState.enAlive;
        public string PatientAccessKey {  get;  set; }


        [Documentation(@"this Is Used to Assign The object After Geting It's Data from Database,it sends all the Data the clsPerson 
class need to create an object")]

        protected clsPatients(int PatientID, enState PatientState, int PersonID, string FirstName,
             string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account,int CountryID, string patientAccessKey)
             : base(PersonID, FirstName, LastName, Phone, DateofBirth, Gender, account, CountryID)
        {

            this.PatientID = PatientID;
            this.PatientState = PatientState;
            Mode = enMode.enUpdate;
            PatientAccessKey = patientAccessKey;
        }
        [Documentation("this is used to assign the object from the Code")]

        public clsPatients() : base()
        {
            PatientID = -1;
            this.PatientState = enState.enAlive;
            Mode = enMode.enAddNew;
            PatientAccessKey = "";
        }



        static public clsPatients FindByID(int PatientID)

        {
            int PatientStateID = -1;
            int PersonID = -1;
            string AccessKey = "";

            clsPerson Person;


            if (clsPatientDAL.GetPatientInfoByID(PatientID, ref PatientStateID, ref PersonID,ref AccessKey))
            {
                Person = clsPerson.FindByID(PersonID);

                return new clsPatients(PatientID, (enState)PatientStateID, PersonID, Person.FirstName, Person.LastName, Person.Phone, Person.DateofBirth, Person.Gender, Person.Account,Person.CountryID, AccessKey);
            }
            else
                return null;




        }



        bool _AddNew(int PersonID = -1)
        {


            this.PersonID = PersonID;
            this.PatientState = enState.enAlive;
            if (clsPerson.Exist(this.PersonID))
            {
                this.PatientID = clsPatientDAL.AddNewPatient(
                   Convert.ToInt32(this.PatientState), this.PersonID,this.PatientAccessKey);

            }
            else
            {
                if (SavePerson())
                {
                    this.PatientID = clsPatientDAL.AddNewPatient(Convert.ToInt32(this.PatientState), this.PersonID, this.PatientAccessKey);
                    if (this.PatientID == -1)
                    {
                        clsRoleBack.DeletePerson(this.PersonID);
                        clsRoleBack.DeleteAccount(this.PersonID);
                    }
                }
            }
            return this.PatientID != -1;


        }
        bool _Update()
        {
            if (SavePerson())
            {
                if (this.PatientState == enState.enDead)
                {
                    if (_CancelleAllPatientServices())
                    {
                        return clsPatientDAL.UpdatePatient(this.PatientID
                     , Convert.ToInt32(this.PatientState),this.PatientAccessKey);


                    }
                    return false;

                }
                return clsPatientDAL.UpdatePatient(this.PatientID
                      , Convert.ToInt32(this.PatientState), this.PatientAccessKey);
            }
            return false;
        }
        /// <summary>
        /// Saves the Patient's information to the database.
        /// Supports creating a new Patient with a new or existing Person record,
        /// depending on the provided <paramref name="PersonID"/>.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public bool SavePatient(int PersonID = -1)
        {
            switch (Mode)
            {
                case enMode.enAddNew:

                    if (_AddNew(PersonID))
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }



                    return false;
                case enMode.enUpdate:
                    if (_Update())
                        return true;
                    else
                        return false;
            }
            return false;

        }

        //static public bool Delete(int PatientID)
        //{

        //    if (Exist(PatientID))
        //    {
        //        return clsPatientDAL.DeletePatient(PatientID);
        //    }
        //    return false;
        //}
        public static bool Exist(int PatientID)
        {

            return clsPatientDAL.IsExist(PatientID);
        }
        /// <summary>
        ///Warning: Only Used When The Patient Dies
        /// </summary>
        /// <returns></returns>
        [Documentation("this Meethod Is Used To Cancel All Patient Services,Medical Records, payments & prescription. We Use it only when the Patient Dies.")]
        public bool _CancelleAllPatientServices()
        {

            if (this.PatientState == enState.enDead)
            {
                clsServices services;
                clsPrescription prescription;
                DataTable dtServices = clsServices.GetAllServicesForPatient(this.PatientID);
                foreach (DataRow dr in dtServices.Rows)
                {
                    services = clsServices.GetServiceInfoByID(Convert.ToInt32(dr["ServiceID"]));
                    services.State = clsServices.enState.enCancelled;
                    services.SaveServices();
                }
                DataTable dtPrescription = clsPrescription.GetAllPrescriptionsForPatient(this.PatientID);
                foreach (DataRow dr in dtPrescription.Rows)
                {
                    prescription = clsPrescription.FindPrescriptionByID(Convert.ToInt32(dr["PrescriptionID"]));
                    prescription.State = clsPrescription.enPrescriptionState.enCancelled;
                    prescription.Save();
                }
               //You Must Cancelle All Medical Record For This Patient When He Die
                return true;
            }
            return false;
        }



        /// <summary>
        /// Retrieves Patient records based on the requested view level (Admin or standard view).
        /// </summary>
        /// <param name="showing"></param>
        /// <returns>All Patient's Info For Admin if View Level Is Admin,IF not return Some of The Info</returns>
        [Documentation("gets  all Patients info depending on view level ")]

        public static DataTable GetAll(clsViews.enShowing showing)
        {
            switch (showing)
            {
                case (clsViews.enShowing.enAdmin):
                    return clsPatientDAL.GetAllPatientsForAdmin();
                default:
                    return clsPatientDAL.GetAllPatientsForOthers();
            }
        }



    }
}
