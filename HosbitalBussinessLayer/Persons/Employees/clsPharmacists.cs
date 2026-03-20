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
    /// Manages Pharmacist's Info
    /// </summary>
    [Documentation("this class is used to Manage Pharmacist's info and it inherits it's props & methods from clsEmployee Class")]

    public class clsPharmacists : clsEmployees
    {

        public int PharmacistID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        [Documentation("this is used to assign the object from the Code also it automatically assign this employee Department to 6 -Pharmacy- By Default")]

        public clsPharmacists() : base()
        {

            Mode = enMode.enAddNew;
            this.PharmacistID = -1;
            this.DepartmentID = 6;



        }
        [Documentation(@"this Is Used to Assign The object After Geting It's Data from Database,it sends all the Data the clsemployee 
class need to create an object & by default sends the department ID=6 (Pharmacy) which make it impossible to assign employee to different department within this class")]
        clsPharmacists(int PharmacistID, int EmployeeID, double Salery, byte WorkingDays
           , int PersonID, string FirstName,
            string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account,enState EmployeeState, DateTime EmploymentDate, DateTime? DueDate,int CountryID) : base(EmployeeID, Salery, WorkingDays
            , 6, PersonID, FirstName,
             LastName, Phone, DateofBirth, Gender, account, EmployeeState, EmploymentDate, DueDate,CountryID)
        {

            this.PharmacistID = PharmacistID;
            

        }






        static public clsPharmacists FindByID(int PharmacistID)

        {
            int EmployeeID = -1;
            clsEmployees employee;
            if (clsPharmacistsDAL.GetPharmacistInfoByID(PharmacistID, ref EmployeeID))
            {
                employee = clsEmployees.FindByID(EmployeeID);
                return new clsPharmacists(PharmacistID, employee.EmplyeeID, employee.Salery, employee.WorkingDays, employee.PersonID
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

                    this.PharmacistID = clsPharmacistsDAL.AddNewPharmacist(this.EmplyeeID);
                }
                else
                {
                  
                        if (SaveEmployee())
                        {
                            this.PharmacistID = clsPharmacistsDAL.AddNewPharmacist(this.EmplyeeID);
                        if (this.PharmacistID == -1)
                        {

                            clsRoleBack.DeleteEmployee(this.EmplyeeID);


                        }

                        }
                    
                }
            }
            else
            {
                
                    if (SaveEmployee())

                        this.PharmacistID = clsPharmacistsDAL.AddNewPharmacist(
                           this.EmplyeeID);
                if(this.PharmacistID == -1)
                {
                    clsRoleBack.DeleteEmployee(this.EmplyeeID);
                    clsRoleBack.DeletePerson(this.EmplyeeID);
                    clsRoleBack.DeleteAccount(this.Account.AccountID);

                }
            }
            return this.PharmacistID != -1;


        }
        bool _Update()
        {
           
                return SaveEmployee();
          
        }
        /// <summary>
        /// Saves the Pharmacist information to the database.
        /// Supports creating a new Pharmacist with a new or existing Person record,
        /// depending on the provided <paramref name="PersonID"/>.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        public bool SavePharmacist(int PersonID = -1)
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

        //static public bool Delete(int PharmacistID)
        //{

        //    if (Exist(PharmacistID))
        //    {
        //        clsDeparmtments deparmtment = clsDeparmtments.FindDepartmentByID(clsPharmacists.FindByID(PharmacistID).DepartmentID);
        //        deparmtment.NumOfEmployees--;
        //        return clsPharmacistsDAL.DeletePharmacist(PharmacistID) && deparmtment.Save();
        //    }
        //    return false;
        //}
        public static bool Exist(int PharmacistID)
        {

            return clsPharmacistsDAL.IsExist(PharmacistID);
        }
        /// <summary>
        /// Retrieves Pharmacist records based on the requested view level (Admin or standard view).
        /// </summary>
        /// <param name="showing"></param>
        /// <returns>All Pharmacist's Info For Admin if View Level Is Admin,IF not return Some of The Info</returns>
        [Documentation("gets  all Pharmacists info depending on view level ")]

        public static DataTable GetAll(clsViews.enShowing showing)
        {
            switch (showing)
            {
                case (clsViews.enShowing.enAdmin):
                    return clsPharmacistsDAL.GetAllPharmacistssForAdmin();
                default:
                    return clsPharmacistsDAL.GetAllPharmacistsForOthers();
            }
        }

   






    }
}
