using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.PersonsDAL.EmployeesDAL
{
    static public class clsAccountantDAL

    {

        static public bool GetAccountatntInfoByID(int AccountantID, ref int EmployeeID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
SELECT 
       *
  FROM Accountants
  where AccountantID=@AccountantID
";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountantID", AccountantID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {


                    EmployeeID = Convert.ToInt32(Reader["EmployeeID"]);
                    IsFound = true;

                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return IsFound;







        }


        static public int AddNewAccountant(int EmployeeID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int AccountantID = -1;
            if (!clsEmployeeDAL.IsExist(EmployeeID))
                return AccountantID;
            if (IsAlreadyAsigned(EmployeeID))
                return AccountantID;
            string Query = @"INSERT INTO Accountants
           (EmployeeID)
     VALUES
           (@EmployeeID)
		   select SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    AccountantID = InsertedID;



                }


            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return AccountantID;













        }
        static public bool IsExist(int AccountantID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Accountants 
                          where AccountantID=@AccountantID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@AccountantID", AccountantID);
            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Exist = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Exist;


        }

        static public bool DeleteAccountant(int AccountantID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(AccountantID))
                return Deleteed;

            string Querey = @"DELETE FROM Accountants
                            WHERE AccountantID=@AccountantID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@AccountantID", AccountantID);
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

        static public DataTable GetAllAccountantsForAdmin()
        {
            DataTable dtAccountants = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Accountants.AccountantID, Persons.FirstName, Persons.LastName, Persons.Phone, Employees.Salery, 
                  Employees.WorkingDays, Employees.EmployementDate, Employees.DueDate, EmployeeStates.State
FROM     Accountants INNER JOIN
                  Employees ON Accountants.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Departments ON Employees.DepartmentID = Departments.DepartmentID INNER JOIN
                  EmployeeStates ON Employees.StateID = EmployeeStates.StateID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtAccountants.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtAccountants;











        }


        static public DataTable GetAllAccountantsForOthers()
        {
            DataTable dtAccountants = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Accountants.AccountantID, Persons.FirstName, Persons.LastName, Persons.Phone
FROM     Accountants INNER JOIN
                  Employees ON Accountants.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID
                 where Employees.StateID !=2";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtAccountants.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtAccountants;











        }
        static bool IsAlreadyAsigned(int EmployeeID)
        {
            bool Assigned = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select found=1 from Accountants where EmployeeID=@employeeID


";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@employeeID", EmployeeID);
            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Assigned = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Assigned;



        }

    }
}
