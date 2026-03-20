using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.LogsDAL
{
    public static class clsLogsDAL


    {


        //Logs
        static public int AddNewLogRecord(int LoggedID,
             DateTime Date)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ID = -1;
            string Query = @"INSERT INTO Logs
           (LoggedID
           ,Date)
     VALUES
           (@LoggedID
           ,@Date
          )
select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LoggedID", LoggedID);
            Command.Parameters.AddWithValue("@Date", Date);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    ID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return ID;


        }

        static public bool GetLogRecordInfoByID(int ID, ref int LoggedID, ref DateTime Date)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT *
  FROM Logs
where ID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    LoggedID = Convert.ToInt32(Reader["LoggedID"]);
                    Date = Convert.ToDateTime(Reader["Date"]);

                    IsFound = true;
                    Reader.Close();
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return IsFound;







        }




        static public bool DeleteLog(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
         
            string Querey = @"DELETE FROM Logs
                            WHERE ID=@ID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {

                    Deleteed = true;

                }

            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Deleteed;


        }

        static public DataTable GetAllEmployeeLogs(int EmployeeID)
        {
            DataTable dtLogs = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Logs.ID, Logs.LoggedID, Logins.LoginName, Departments.DepartmentName,logs.Date
FROM     Logs INNER JOIN
                  Logins ON Logs.LoggedID = Logins.ID INNER JOIN
                  Employees ON Logins.EmployeeID = Employees.EmployeeID INNER JOIN
                  Departments ON Employees.DepartmentID = Departments.DepartmentID
where Logins.EmployeeID=@EmployeeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtLogs.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtLogs;













        }

        static public DataTable GetAllLogs()
        {
            DataTable dtLogs = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Logs.ID, Logs.LoggedID, Logins.LoginName, Departments.DepartmentName,logs.Date
FROM     Logs INNER JOIN
                  Logins ON Logs.LoggedID = Logins.ID INNER JOIN
                  Employees ON Logins.EmployeeID = Employees.EmployeeID INNER JOIN
                  Departments ON Employees.DepartmentID = Departments.DepartmentID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtLogs.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtLogs;













        }
    }
}
