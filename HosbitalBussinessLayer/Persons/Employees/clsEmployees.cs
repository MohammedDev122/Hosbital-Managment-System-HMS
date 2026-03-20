using HosbitalDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Documentationattribute;

namespace HosbitalBussinessLayer
{
    /// <summary>
    /// Manages Employee Info
    /// </summary>
    [Documentation("this class is used to Manage Employee's info and it inherits it's props & methods from clsPerson Class")]

    public class clsEmployees : clsPerson
    {
     public int EmplyeeID {  get; [Documentation("This Var Is Private To Make It only readable.")] protected set; }  
        public double Salery {  get;set; }
        public byte WorkingDays {  get;set; }
        public int DepartmentID {  get; set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        int _DepartmentID;
        public DateTime EmploymentDate { get;set;}
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        DateTime _EmploymentDate;
        public DateTime? DueDate { get;protected set;}
     public enum enState { enWorking=1,enFired=2}
      public  enState EmployeeState=enState.enWorking;
        [Documentation("this Is Used when We want to fire/unfire employee so we use it to get the previous state")]
         enState _PreviousEmployeeState = enState.enWorking;


        [Documentation(@"this Is Used to Assign The object After Geting It's Data from Database,it sends all the Data the clsPerson 
class need to create an object")]

        protected clsEmployees(int EmployeeID,double Salery,byte WorkingDays
            ,int DepartmentID,int PersonID, string FirstName,
            string LastName, string Phone, DateTime DateofBirth, char Gender, clsBankAccount account,enState EmployeeState,DateTime EmploymentDate,DateTime? DueDate,int CountryID)
            :base( PersonID,  FirstName,  LastName,  Phone,  DateofBirth,  Gender, account,CountryID)
        {

            this.EmplyeeID = EmployeeID;
            this.Salery = Salery;
            this.WorkingDays = WorkingDays;
            this.EmployeeState = EmployeeState;
            _PreviousEmployeeState = EmployeeState;
            if (EmployeeState == enState.enWorking)
            {
                if (this.WorkingDays == 30)
                {
                    account.AmmountOfMoney += this.Salery;
                    this.WorkingDays = 1;
                }
            }
            this.DepartmentID = DepartmentID;
            this.EmploymentDate= EmploymentDate;
            this.DueDate = DueDate;
            Mode = enMode.enUpdate;
            _DepartmentID = DepartmentID;
            _EmploymentDate= EmploymentDate;
        }
        [Documentation("this is used to assign the object from the Code")]

        public clsEmployees():base()
        {
            EmplyeeID = -1;
            Salery = 0;
            WorkingDays = 0;
            DepartmentID = -1;
            this.EmployeeState=enState.enWorking;
            Mode = enMode.enAddNew;
            this.EmploymentDate = DateTime.Now;
            this.DueDate = null;
            _DepartmentID = -1;
            this._EmploymentDate=DateTime.Now;
        }

        static public clsEmployees FindByID(int EmployeeID)

        {
            double Salery = 0; 
            byte WorkingDays = 0;
            int DepartmentID = -1;
            int PersonID = -1;
            int StateID = -1;
            DateTime EmplymentDate = DateTime.Now;
            DateTime? DueDate = null;
            clsPerson person;


            if (clsEmployeeDAL.GetEmployeeInfoByID(EmployeeID, ref Salery, ref DepartmentID, ref WorkingDays, ref PersonID,ref StateID,ref EmplymentDate,ref DueDate))
            {
                person =clsPerson.FindByID(PersonID);

                return new clsEmployees(EmployeeID, Salery, WorkingDays, DepartmentID,
                    PersonID, person.FirstName, person.LastName, person.Phone, person.DateofBirth, person.Gender, person.Account,(enState)StateID,EmplymentDate,DueDate,person.CountryID);
            }
            else
                return null;




        }

        static protected clsEmployees FindEmployeeByPersonID(int PersonID)

        {
            double Salery = 0;
            byte WorkingDays = 0;
            int DepartmentID = -1;
            int EmployeeID = -1;
            int EmployeeStateID = -1;
            DateTime EmploymentDate= DateTime.Now;
            DateTime? DueDate = null;

            clsPerson person;


            if (clsEmployeeDAL.GetEmployeeInfoByPersonID(PersonID, ref Salery, ref DepartmentID, ref WorkingDays, ref EmployeeID,ref EmployeeStateID,ref EmploymentDate,ref DueDate))
            {
                person = clsPerson.FindByID(PersonID);

                return new clsEmployees(EmployeeID, Salery, WorkingDays, DepartmentID,
                    PersonID, person.FirstName, person.LastName, person.Phone, person.DateofBirth, person.Gender, person.Account,(enState)EmployeeStateID,EmploymentDate,DueDate, person.CountryID);
            }
            else
                return null;




        }


        bool _IsDataIsCorrect()
        {
            if (this.EmplyeeID != -1)
            {

                if (WorkingDays < 0)
                {
                    Cause = clsFailCauses.enPersonsFailCauses.enWorkingDaysBellowZero;
                    return false;
                }
              
              


            }
            else
            {
                if (!clsDeparmtments.Exist(this.DepartmentID))
                {
                    Cause = clsFailCauses.enPersonsFailCauses.enWrongDepartmentID;
                    return false;
                }
                if (EmploymentDate.Date > DateTime.Now.Date) {
                    Cause = clsFailCauses.enPersonsFailCauses.enWrongEmploymentDate;
                    return false;
                }

            }
            if (Salery < 0)
            {
                Cause = clsFailCauses.enPersonsFailCauses.enSaleryBellowZero;
                return false;

            }
            return true;

        }
        bool _AddNew(int PersonID=-1)
        {
            if (_IsDataIsCorrect())
            {
                clsDeparmtments Department = clsDeparmtments.FindDepartmentByID(this.DepartmentID);
                if (PersonID != -1)
                {
                    if (clsPerson.Exist(PersonID))
                    {
                        this.PersonID = PersonID;
                        this.EmplyeeID = clsEmployeeDAL.AddNewEmployee(
                            this.Salery, this.DepartmentID, this.PersonID, this.EmploymentDate, this.DueDate, this.WorkingDays);
                        if (this.EmplyeeID != -1)
                        {
                            Department.NumOfEmployees++;


                        }
                    }
                    else
                    {
                        Cause = clsFailCauses.enPersonsFailCauses.enWrongPersonID;
                    }
                }
                else
                {
                    if (SavePerson())
                    {
                        this.WorkingDays = 0;
                        this.EmplyeeID = clsEmployeeDAL.AddNewEmployee(
                            this.Salery, this.DepartmentID, this.PersonID, this.EmploymentDate, this.DueDate, this.WorkingDays);
                        if (this.EmplyeeID != -1)
                        {
                            Department.NumOfEmployees++;
                        }
                        else
                        {
                            clsRoleBack.DeletePerson(this.PersonID);
                            clsRoleBack.DeleteAccount(this.Account.AccountID);
                        }
                    }
                   
                }

                return this.EmplyeeID != -1 && Department.Save();
            }
            return false;

        }

        bool _Update()
        {
            if (_IsDataIsCorrect())
            {
                if (SavePerson())
                {
                    if (EmployeeState == enState.enFired)
                    {
                        if (DepartmentID == 9)
                        {
                            this.DueDate = clsDoctorDAL.GetDoctorDueTime(this.EmplyeeID);
                        }
                        else
                        {
                            this.DueDate = DateTime.Now;
                        }
                    }
                    else if (DueDate != null && EmployeeState == enState.enWorking)
                    {
                        this.DueDate = null;


                    }
                    if (clsEmployeeDAL.UpdateEmployee(this.EmplyeeID
                             , this.Salery, this._DepartmentID, this.WorkingDays, Convert.ToInt32(this.EmployeeState), this._EmploymentDate, this.DueDate))
                    {

                        switch (_PreviousEmployeeState)
                        {
                            case (enState.enFired):
                                if (this.EmployeeState == enState.enWorking)
                                {
                                    clsDeparmtments deparmtment = clsDeparmtments.FindDepartmentByID(this._DepartmentID);
                                    deparmtment.NumOfEmployees++;
                                    return deparmtment.Save();
                                }
                                return true;
                            case (enState.enWorking):
                                if (this.EmployeeState == enState.enFired)
                                {
                                    clsDeparmtments deparmtment = clsDeparmtments.FindDepartmentByID(this._DepartmentID);
                                    deparmtment.NumOfEmployees--;
                                    return deparmtment.Save();
                                }
                                return true;

                        }
                    }


                }
               
            }
            return false;

        }
        /// <summary>
        /// Saves the Employee information to the database.
        /// Supports creating a new Employee with a new or existing Person record,
        /// depending on the provided <paramref name="PersonID"/>.
        /// </summary>
        /// <param name="PersonID"></param>
        /// <returns></returns>
        [Documentation("we didnt override the method in the child classes to make them save only thier data and to make this class take responsiplity of it's data")]
        public bool SaveEmployee(int PersonID=-1) {
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
      
   static public bool FireUnFireEmployee(int EmployeeID,enState State)
        {
            clsEmployees employee=FindByID(EmployeeID);
            if (employee == null)
            {
                return false;
            }
            enState PreviousState=employee.EmployeeState;
            employee.EmployeeState = State;
            return employee.SaveEmployee();

        }
      
        public static bool Exist(int employeeID) { 
        
        return clsEmployeeDAL.IsExist(employeeID);
        }
        public static DataTable GetAll(clsViews.enShowing showing)
        {
            return clsEmployeeDAL.GetAllEmployees();
        }
     
        public bool IncreaseWorkingDays(byte WorkingDays)
        {
           this.WorkingDays+=WorkingDays;
            return SaveEmployee();
        }

        /// <summary>
        /// Retrieves the role-specific ID associated with the employee,
        /// depending on the department the employee belongs to.
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns> 
        /// The role ID linked to the specified employee, or -1 if not found.
        /// </returns>
        [Documentation("this Method Is Used To get the ID of the spacific child/object in which the emplyee is assigned to")]
        static public int GetEmployeeRoleID(int EmployeeID)

        {
           
         clsEmployees employee=   clsEmployees.FindByID(EmployeeID);
            if (employee != null)
            {


              return      clsEmployeeDAL.GetEmployeeRoleIDByEmployeeID(EmployeeID,employee.DepartmentID);
                        
            }

            

            return -1;



        }


    }
}
