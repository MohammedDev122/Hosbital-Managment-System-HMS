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
    /// Stores the system activity logs.
    /// </summary>
    [Documentation("used to Record who and when entered the system")]
    public class clsLogs

    {
        public int LogID { get; [Documentation("This Var Is Private To Make It only readable.")] private set; }
        public int LoginID { get; set; }
        public DateTime Date { get; private set; }
        [Documentation("this is used to assign the object from the Code")]

        public clsLogs()
        {
            this.LogID = -1;
            this.LoginID = -1;
            this.Date = DateTime.Now;
            
        }
        [Documentation("this Is Used to Assign The object After Geting It's Data from Database")]

        private clsLogs(int LogID, int LoginID, DateTime Date)
        {
            this.LogID = LogID;
            this.LoginID = LoginID;
            this.Date = Date;
           

        }
        static public clsLogs FindLogRecInfoByID(int LogID)
        {

            int LoginID = -1;
            DateTime Date = DateTime.Now;
            if (clsLogsDAL.GetLogRecordInfoByID(LogID, ref LoginID, ref Date))
            {
                return new clsLogs(LogID, LoginID, Date);
            }

            return null;



        }
        bool _CheckIfDataIsCorrect()
        {
            clsLogins Login = clsLogins.FindLoginInfoByID(this.LoginID);
            if (Login == null)
            {
                return false;
            }
           


            if (Date.Date.Day <DateTime.Now.Day)
            {
                return false;
            }
            return true;



        }
        bool _AddNewLog()
        {

            if (_CheckIfDataIsCorrect())
            {
                this.LogID = clsLogsDAL.AddNewLogRecord(this.LoginID, this.Date);
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

            return clsLogsDAL.GetAllLogs();
        }
        static public DataTable GetAllEmployeeLogs(int EmployeeID)
        {

            return clsLogsDAL.GetAllEmployeeLogs(EmployeeID);
        }

    }
}
