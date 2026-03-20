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
    /// Manages Accountants Info
    /// </summary>
    [Documentation("this class is used to Manage Accountant's info and it inherits it's props & methods from clsEmployee Class")]
    public class clsAccountant : clsEmployees
    {
        public int AccountantID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        [Documentation("this is used to assign the object from the Code also it automatically asign this employee Department to 10 -Accounting- By Default")]

        public clsAccountant() : base()
        {

            Mode = enMode.enAddNew;
            this.AccountantID = -1;
            this.DepartmentID = 10;



        }
        [Documentation(@"this Is Used to Assign The object After Geting It's Data from Database,it sends all the Data the clsemployee 
class need to create an object & by default sends the department ID=10 (Accounting) which make it impossiple to assign employee to different department within this class")]

        clsAccountant(int AccountantID, int EmployeeID, double Salery, byte WorkingDays
           , int PersonID, string FirstName,
            string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account, enState EmployeeState,DateTime EmploymentDate,DateTime? DueDate,int CountryID) : base(EmployeeID, Salery, WorkingDays
            ,10 , PersonID, FirstName,
             LastName, Phone, DateofBirth, Gender, account,EmployeeState, EmploymentDate, DueDate,CountryID)
        {

            this.AccountantID = AccountantID;

        }     

        static public clsAccountant FindByID(int AccountantID)

        {
            int EmployeeID = -1;
            clsEmployees employee;
            if (clsAccountantDAL.GetAccountatntInfoByID(AccountantID, ref EmployeeID))
            {
                employee = clsEmployees.FindByID(EmployeeID);
                return new clsAccountant(AccountantID, employee.EmplyeeID, employee.Salery, employee.WorkingDays, employee.PersonID
                    , employee.FirstName, employee.LastName, employee.Phone, employee.DateofBirth, employee.Gender, employee.Account,employee.EmployeeState,employee.EmploymentDate,employee.DueDate,employee.CountryID);
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

                    this.AccountantID = clsAccountantDAL.AddNewAccountant(this.EmplyeeID);
              
                }
                else
                {

                    if (SaveEmployee())
                    {
                        this.AccountantID = clsAccountantDAL.AddNewAccountant(this.EmplyeeID);
                        if (this.AccountantID == -1)
                        {
                            clsRoleBack.DeleteEmployee(this.EmplyeeID);
                           
                        }

                    }

                }
            }
            else
            {

                if (SaveEmployee())

                    this.AccountantID = clsAccountantDAL.AddNewAccountant(this.EmplyeeID);
                if (this.AccountantID == -1)
                {
                    clsRoleBack.DeleteEmployee(this.EmplyeeID);
                    clsRoleBack.DeletePerson(this.PersonID);
                    clsRoleBack.DeleteAccount(this.Account.AccountID);

                }

            }
            return this.AccountantID != -1;


        }
        bool _Update()
        {

            return SaveEmployee();

        }
        /// <summary>
        /// Saves the accountant information to the database.
        /// Supports creating a new accountant with a new or existing Person record,
        /// depending on the provided <paramref name="PersonID"/>.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public bool SaveAccountant(int PersonID = -1)
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

        //static public bool Delete(int AccountantID)
        //{

        //    if (Exist(AccountantID))
        //    {
        //        clsDeparmtments deparmtment = clsDeparmtments.FindDepartmentByID(clsAccountant.FindByID(AccountantID).DepartmentID);
        //        deparmtment.NumOfEmployees--;
        //        return clsAccountantDAL.DeleteAccountant(AccountantID) && deparmtment.Save();
        //    }
        //    return false;
        //}
        public static bool Exist(int AccountantID)
        {

            return clsAccountantDAL.IsExist(AccountantID);
        }
        /// <summary>
        /// Retrieves accountant records based on the requested view level (Admin or standard view).
        /// </summary>
        /// <param name="showing"></param>
        /// <returns>All Accountant's Info For Admin if View Level Is Admin,IF not return Some OF The Info</returns>
        [Documentation("gets  all Accountants info depending on view level ")]
        public static DataTable GetAll(clsViews.enShowing showing)
        {
            switch (showing)
            {
                case (clsViews.enShowing.enAdmin):
                    return clsAccountantDAL.GetAllAccountantsForAdmin();
                default:
                    return clsAccountantDAL.GetAllAccountantsForOthers();
            }
        }

  

    }

}
