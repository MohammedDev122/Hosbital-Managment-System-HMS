using HosbitalDataAccessLayer;
using HosbitalDataAccessLayer.PersonsDAL.EmployeesDAL;
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
    /// Manages Nurse Info
    /// </summary>
     [Documentation("this class is used to Manage Nurse's info and it inherits it's props & methods from clsEmployee Class")]
    public class clsNurses : clsEmployees
    {

        public int NurseID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        [Documentation("this is used to assign the object from the Code also it automatically assign this employee Department to 5 -Nursing- By Default")]

        public clsNurses() : base()
        {

            Mode = enMode.enAddNew;
            this.NurseID = -1;
            this.DepartmentID = 5;



        }
        [Documentation(@"this Is Used to Assign The object After Geting It's Data from Database,it sends all the Data the clsemployee 
class need to create an object & by default sends the department ID=5 (Nursing) which make it impossible to assign employee to different department within this class")]
        clsNurses(int NurseID, int EmployeeID, double Salery, byte WorkingDays
            , int PersonID, string FirstName,
            string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account,enState EmployeeState, DateTime EmploymentDate, DateTime? DueDate,int CountryID) : base(EmployeeID, Salery, WorkingDays
            , 5, PersonID, FirstName,
             LastName, Phone, DateofBirth, Gender, account, EmployeeState,EmploymentDate,DueDate,CountryID)
        {

            this.NurseID = NurseID;

        }






        static public clsNurses FindByID(int NurseID)

        {
            int EmployeeID = -1;
            clsEmployees employee;
            if (clsNursesDAL.GetNurseInfoByID(NurseID, ref EmployeeID))
            {
                employee = clsEmployees.FindByID(EmployeeID);
                return new clsNurses(NurseID, employee.EmplyeeID, employee.Salery, employee.WorkingDays, employee.PersonID
                    , employee.FirstName, employee.LastName, employee.Phone, employee.DateofBirth, employee.Gender, employee.Account, employee.EmployeeState,employee.EmploymentDate,employee.DueDate,employee.CountryID);
            }
            return null;

        }
        bool _AddNew(int PersonID = -1)
        {

            this.PersonID = PersonID;
            if (clsPerson.Exist(this.PersonID))
            {
                this.EmplyeeID = clsEmployees.FindEmployeeByPersonID(this.PersonID).EmplyeeID;
                if (this.EmplyeeID != -1)
                {

                    this.NurseID = clsNursesDAL.AddNewNurse(this.EmplyeeID);
                }
                else
                {
                    
                        if (SaveEmployee())
                        {
                            this.NurseID = clsNursesDAL.AddNewNurse(this.EmplyeeID);
                        if (this.NurseID == -1)
                        {
                            clsRoleBack.DeleteEmployee(this.EmplyeeID);
                        }

                        }
                    
                }
            }
            else
            {
                
                    if (SaveEmployee())

                        this.NurseID = clsNursesDAL.AddNewNurse(
                           this.EmplyeeID);
                if (this.NurseID == -1)
                {
                    clsRoleBack.DeleteEmployee(this.EmplyeeID);
                    clsRoleBack.DeletePerson(this.PersonID);
                    clsRoleBack.DeleteAccount(this.Account.AccountID);
                }

            }
            return this.NurseID != -1;


        }
        bool _Update()
        {
           
             return   SaveEmployee();
            
           
        }
        /// <summary>
        /// Saves the Nurse information to the database.
        /// Supports creating a new Nurse with a new or existing Person record,
        /// depending on the provided <paramref name="PersonID"/>.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public bool SaveNurse(int PersonID = -1)
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

        //static public bool Delete(int NurseID)
        //{

        //    if (Exist(NurseID))
        //    {
        //        clsDeparmtments deparmtment = clsDeparmtments.FindDepartmentByID(clsNurses.FindByID(NurseID).DepartmentID);
        //        deparmtment.NumOfEmployees--;
        //        return clsNursesDAL.DeleteNurse(NurseID) && deparmtment.Save();
        //    }
        //    return false;
        //}
        public static bool Exist(int NurseID)
        {

            return clsNursesDAL.IsExist(NurseID);
        }
        /// <summary>
        /// Retrieves Nurse records based on the requested view level (Admin or standard view).
        /// </summary>
        /// <param name="showing"></param>
        /// <returns>All Nurse's Info For Admin if View Level Is Admin,IF not return Some of The Info</returns>
        [Documentation("gets  all Nurses info depending on view level ")]

        public static DataTable GetAll(clsViews.enShowing showing)
        {
            switch (showing)
            {
                case (clsViews.enShowing.enAdmin):
                    return clsNursesDAL.GetAllNursesForAdmin();
                default:
                    return clsNursesDAL.GetAllNursesForOthers();
            }
        }

   





    }

}
