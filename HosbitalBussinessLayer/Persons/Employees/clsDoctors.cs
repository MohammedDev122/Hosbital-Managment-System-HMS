using HosbitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using static HosbitalBussinessLayer.clsEmployees;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    /// <summary>
    /// Manages Doctors Info
    /// </summary>
    [Documentation("this class is used to Manage Doctor's info and it inherits it's props & methods from clsEmployee Class")]

    public class clsDoctors : clsEmployees
    {
        public int DoctorID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int SpecilizationID { get; set; }
        [Documentation("this is used to assign the object from the Code also it automatically asign this employee Department to 9 -Doctor- By Default")]

        public clsDoctors() : base() {

            Mode = enMode.enAddNew;
            this.DoctorID = -1;
            this.SpecilizationID = -1;
            this.DepartmentID = 9;



        }
        [Documentation(@"this Is Used to Assign The object After Geting It's Data from Database,it sends all the Data the clsemployee 
class need to create an object & by default sends the department ID=9 (Doctor) which make it impossiple to assign employee to different department within this class")]
        clsDoctors(int DoctorID, int SpecilizationID, int EmployeeID, double Salery, byte WorkingDays
            , int PersonID, string FirstName,
            string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account, enState EmployeeState, DateTime EmploymentDate, DateTime? DueDate, int CountryID)
            : base(EmployeeID, Salery, WorkingDays
            , 9, PersonID, FirstName,
             LastName, Phone, DateofBirth, Gender, account, EmployeeState, EmploymentDate, DueDate, CountryID)
        {

            this.DoctorID = DoctorID;
            this.SpecilizationID = SpecilizationID;

        }
        static public clsDoctors FindByID(int DoctorID)

        {
            int SpecilizationID = -1;
            int EmployeeID = -1;
            clsEmployees employee;
            if (clsDoctorDAL.GetDoctorInfoByID(DoctorID, ref EmployeeID, ref SpecilizationID))
            {
                employee = clsEmployees.FindByID(EmployeeID);
                return new clsDoctors(DoctorID, SpecilizationID, employee.EmplyeeID, employee.Salery, employee.WorkingDays, employee.PersonID
                    , employee.FirstName, employee.LastName, employee.Phone, employee.DateofBirth, employee.Gender, employee.Account, employee.EmployeeState, employee.EmploymentDate, employee.DueDate, employee.CountryID);
            }
            return null;

        }
        bool _IsDataCorrect()
        {

            if (!clsSpecilization.Exist(this.SpecilizationID))
            {
                Cause = clsFailCauses.enPersonsFailCauses.enWrongSpecID;
                return false;

            }
            else
            {
                return true;
            }

        }
        bool _AddNew(int PersonID = -1)
        {
            if (_IsDataCorrect())
            {
                this.PersonID = PersonID;

                if (clsPerson.Exist(this.PersonID))
                {
                    this.EmplyeeID = clsEmployees.FindEmployeeByPersonID(this.PersonID).EmplyeeID;
                    if (this.EmplyeeID != -1)
                    {

                        this.DoctorID = clsDoctorDAL.AddNewDoctor(this.EmplyeeID, this.SpecilizationID);
                    }
                    else
                    {

                        if (SaveEmployee())
                        {

                            this.DoctorID = clsDoctorDAL.AddNewDoctor(this.EmplyeeID, this.SpecilizationID);
                            if (this.DoctorID == -1)
                            {
                                clsRoleBack.DeleteEmployee(this.EmplyeeID);

                            }

                        }


                    }
                }
                else
                {

                    if (SaveEmployee())

                        this.DoctorID = clsDoctorDAL.AddNewDoctor(
                           this.EmplyeeID, this.SpecilizationID);
                    if (this.DoctorID == -1)
                    {
                        clsRoleBack.DeleteEmployee(this.EmplyeeID);
                        clsRoleBack.DeletePerson(this.PersonID);
                        clsRoleBack.DeleteAccount(this.Account.AccountID);

                    }

                }
            }
            return this.DoctorID != -1;


        }
        bool _Update()
        {
            if (_IsDataCorrect())
            {
                if (SaveEmployee())
                {
                    return clsDoctorDAL.UpdateDoctor(this.DoctorID
                          , this.SpecilizationID);
                }
            }

            return false;
        }
        /// <summary>
        /// Saves the Doctor information to the database.
        /// Supports creating a new Doctor with a new or existing Person record,
        /// depending on the provided <paramref name="PersonID"/>.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public bool SaveDoctor(int PersonID = -1)
        {
            switch (Mode)
            {
                case enMode.enAddNew:

                    if (_AddNew(PersonID))
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;
                case enMode.enUpdate:
                    if (_Update())
                        return true;
                    else
                        return false;
            }
            return false;

        }

        //static public bool Delete(int DoctorID)
        //{

        //    if (Exist(DoctorID))
        //    {
        //        clsDeparmtments deparmtment = clsDeparmtments.FindDepartmentByID(clsDoctors.FindByID(DoctorID).DepartmentID);
        //        deparmtment.NumOfEmployees--;
        //        return clsDoctorDAL.DeleteDoctor(DoctorID)&&deparmtment.Save();
        //    }
        //    return false;
        //}
        public static bool Exist(int DoctorID)
        {

            return clsDoctorDAL.IsExist(DoctorID);
        }
        /// <summary>
        /// Retrieves Doctor records based on the requested view level (Admin or standard view).
        /// </summary>
        /// <param name="showing"></param>
        /// <returns>All Doctor's Info For Admin if View Level Is Admin,IF not return Some of The Info</returns>
                [Documentation("gets  all Doctors info depending on view level ")]

        public static DataTable GetAll(clsViews.enShowing showing)
        {
            switch (showing)
            {
                case (clsViews.enShowing.enAdmin):
                    return clsDoctorDAL.GetAllDoctorsforAdmin();
                default:
                    return clsDoctorDAL.GetAllDoctorsforOthers();
            }
        }

   




    }
}
