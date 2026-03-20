using HosbitalBussinessLayer.Procedures;
using HosbitalDataAccessLayer.LogsDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentationattribute;

namespace HosbitalBussinessLayer.Logs.SystemLoginsAndLogs
{
    /// <summary>
    ///Stores each employee's login info and permission level.
    /// </summary>
    [Documentation("this Class Is Used To Manage All Users Logins Account And Permissions And Roles-According to department- in the System Whether it's an Admin,Manager,Employee")]
    public class clsLogins

    {
        public int ID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public byte Permissions { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int EmployeeID { get;  set; }
        [Documentation("this Private var Is Used to Preserve the Orignal Value once it is assigned")]

        public int _EmployeeID;
        public clsEmployees Employee {  get; [Documentation("You can't Update Or change the Employee's info Through this Class So We Made It Read Only")] private set; }
        public string PhotoPath { get; set; }
enum enLoginStatus {enHaveAccess=1,enDenied=2 };
        [Documentation("Used to detrmine whether the user can enter the system or not. it changes when the user get fired")]
        enLoginStatus Status { get; set; }
        enum enMode { enUpdate = 1, enAddNew = 2 };
        [Documentation("we Use this Var to identify the state of the object whether it is a new Obj or Old One ")]

        enMode _Mode;


        /// <summary>
        /// Indicates why saving the user Login info failed.
        /// </summary>
        [Documentation("It Is Used To Detrmine The Reason the Process of saving the Data Failed Making it easir to fix/Debug")]
        public clsFailCauses.enLoginFailCause Cause;
        [Documentation("this is used to assign the object from the Code")]

        public clsLogins()
        {
            this.ID = -1;
            this.LoginName = "";
            this.Password = "";
            this.Permissions =0;
            this.EmployeeID = -1;
            this._EmployeeID = -1;
            this.PhotoPath = "";
            Status = enLoginStatus.enHaveAccess;
            _Mode = enMode.enAddNew;
            Cause = clsFailCauses.enLoginFailCause.enUnKnownError;
            Employee =new clsEmployees();
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsLogins(int ID, string LoginName, string Password,byte Permissions,int EmployeeID,string PhotoPath,enLoginStatus status)
        {
            this.ID = ID;
            this.LoginName = LoginName;
            this.Password = Password;
            this.Permissions = Permissions;
            this.EmployeeID = EmployeeID;
            this._EmployeeID = EmployeeID;
            Employee = clsEmployees.FindByID(EmployeeID);
            this.PhotoPath=PhotoPath;
            status = Status;
            _Mode = enMode.enUpdate;
            Cause = clsFailCauses.enLoginFailCause.enUnKnownError;


        }
        static public clsLogins FindLoginInfoByID(int LoginID)
        {

            string LoginName = "";
            string Password ="";
            byte Permissions = 0;
            int EmployeeID = -1;
            string PhotoPath = "";
            int status = -1;
            if (clsLoginsDAL.GetLoginInfoByID(LoginID, ref LoginName, ref Password,ref Permissions,ref EmployeeID,ref PhotoPath,ref status))
            {
                return new clsLogins(LoginID, LoginName, Password, Permissions, EmployeeID, PhotoPath,(enLoginStatus) status);
            }

            return null;



        }
        static public clsLogins FindLoginInfoByEmployeeID(int EmployeeID)
        {

            string LoginName = "";
            string Password = "";
            byte Permissions = 0;
            int LoginID = -1;
            string PhotoPath = "";
            int status = -1;
            if (clsLoginsDAL.GetLoginInfoByEmployeeID(EmployeeID, ref LoginName, ref Password, ref Permissions, ref LoginID, ref PhotoPath, ref status))
            {
                return new clsLogins(LoginID, LoginName, Password, Permissions, EmployeeID, PhotoPath, (enLoginStatus)status);
            }

            return null;



        }
        static public clsLogins FindLoginInfoByLohinName(string LoginName)
        {

            int EmployeeID = -1;
            string Password = "";
            byte Permissions = 0;
            int LoginID = -1;
            string PhotoPath = "";
            int status = -1;
            if (clsLoginsDAL.GetLoginInfoByLoginName(LoginName, ref EmployeeID, ref Password, ref Permissions, ref LoginID, ref PhotoPath, ref status))
            {
                return new clsLogins(LoginID, LoginName, Password, Permissions, EmployeeID, PhotoPath, (enLoginStatus)status);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {

            if (ID == -1)
            {
                Employee = clsEmployees.FindByID(EmployeeID);

                if (Employee == null)
                {
                    return false;
                }
                if (Employee.EmployeeState == clsEmployees.enState.enFired)
                {
                    Cause = clsFailCauses.enLoginFailCause.enEmployeeIsntInSystem;

                    return false;
                }
            }
            if (Password.Length != 64)
            {
                if (Password.Length < 5 || Password.Length > 10)
                {
                    Cause = clsFailCauses.enLoginFailCause.enLoginPasswordtooShortorLong;

                    return false;
                }

                if (!int.TryParse(Password, out int Pass))
                {
                    Cause = clsFailCauses.enLoginFailCause.enLoginPasswordCantHoldAnyChar;

                    return false;

                }
            }
            if (LoginName.Length < 5 || LoginName.Length > 10)
            {
                Cause = clsFailCauses.enLoginFailCause.enLoginNameIsTooShortorLong;


                return false;
            }
          
            return true;



        }
        bool _AddNew()
        {

            if (_CheckIfDataIsCorrect())
            {
                if (Employee.EmplyeeID == clsDeparmtments.FindDepartmentByID(Employee.DepartmentID).DepartmentManagerID)
                {
                    Permissions = 1;
                }
                else
                {
                    Permissions = 0;
                }

                this.ID = clsLoginsDAL.AddNewLogins(this.LoginName,clsProtect1.Compute(this.Password),this.Permissions,this.EmployeeID,this.PhotoPath,Convert.ToInt32(this.Status));
            }
            return this.ID != -1;



        }
        bool _Update()
        {

            if (_CheckIfDataIsCorrect())
            {

                if (Employee.EmplyeeID == clsDeparmtments.FindDepartmentByID(Employee.DepartmentID).DepartmentManagerID)
                {
                    Permissions = 1;
                }
                else
                {
                    Permissions = 0;
                }
                if (Employee.EmployeeState == clsEmployees.enState.enFired)
                {
                    this.Status = enLoginStatus.enDenied;
                }
                else
                {
                    this.Status = enLoginStatus.enHaveAccess;

                }
                if (this.Password.Length != 64)
                {
                    Password = clsProtect1.Compute(this.Password);
                }

                return clsLoginsDAL.UpdateLogins(this.ID
                  , this.LoginName,this.Password,this.Permissions,this._EmployeeID,this.PhotoPath,Convert.ToInt32(this.Status));

            }
            return false;
        }
        /// <summary>
        ///  Saves the login changes to the database.
        /// </summary>
        /// <returns>true if the changes stored successfully</returns>

        public bool Save()
        {
            switch (_Mode)
            {

                case (enMode.enAddNew):
                    if (_AddNew())
                        return true;
                    else
                        return false;
                case (enMode.enUpdate):
                    if (_Update())
                    {

                        return true;
                    }
                    else return false;



            }
            return false;




        }
        static public DataTable GetAllLogins()
        {

            return clsLoginsDAL.GetAllLogins();
        }
        static public bool Exist(int LoginID)
        {
            return clsLoginsDAL.IsExist(LoginID);
        }
        /// <summary>
        /// checks If User Have The Ability to Sign in the system
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
         static bool _CheckifUserHaveAccess(clsLogins Login)
        {
if(Login.Status == enLoginStatus.enDenied)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool _CheckIfLoginNameAndPasswordIsCorrect(clsLogins Login, string Password)
        {

            if(Login != null)
            {
                if (Login.Password ==clsProtect1.Compute(Password))
                {
                    return true;
                }

            }
            return false;



        }
        public static bool CheckLogedUserInfo(string LoginName, string Password)
        {
            clsLogins login = FindLoginInfoByLohinName(LoginName);
            if (login != null)
            {
                if (_CheckIfLoginNameAndPasswordIsCorrect(login, Password))
                {
                    if (_CheckifUserHaveAccess(login))
                    {

                        return true;
                    }


                }
            }
            return false;
        }

    }
}
