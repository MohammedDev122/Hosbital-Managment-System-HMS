using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.PersonsDAL.EmployeesDAL
{
    static public class clsNursesDAL
    {

        static public bool GetNurseInfoByID(int NurseID, ref int EmployeeID
          )
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
SELECT 
       *
  FROM Nurses
  where NurseID=@NurseID
";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NurseID", NurseID);
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


        static public int AddNewNurse(int EmployeeID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int NurseID = -1;
            if (!clsEmployeeDAL.IsExist(EmployeeID))
                return NurseID;
            if (IsAlreadyAsigned(EmployeeID))
                return NurseID;
            string Query = @"INSERT INTO Nurses
           (EmployeeID)
     VALUES
           (@EmployeeID
           )
		   select SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    NurseID = InsertedID;



                }


            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return NurseID;













        }
        static public bool IsExist(int NurseID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Nurses 
                          where NurseID=@NurseID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@NurseID", NurseID);
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
     
        static public bool DeleteNurse(int NurseID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(NurseID))
                return Deleteed;

            string Querey = @"DELETE FROM Nurses
                            WHERE NurseID=@NurseID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@NurseID", NurseID);
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

        static public DataTable GetAllNursesForAdmin()
        {
            DataTable dtNurses = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Nurses.NurseID, Persons.FirstName, Persons.LastName, Persons.Phone, Employees.Salery, Employees.WorkingDays,Employees.EmployementDate, 
                  Employees.DueDate, EmployeeStates.State
FROM     Nurses INNER JOIN
                  Employees ON Nurses.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  EmployeeStates ON Employees.StateID = EmployeeStates.StateID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtNurses.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtNurses;











        }
       
        static public DataTable GetAllNursesForOthers()
        {
            DataTable dtNurses = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Nurses.NurseID, Persons.FirstName, Persons.LastName,Persons.Phone
FROM     Nurses INNER JOIN
                  Employees ON Nurses.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID 
               where  Employees.StateID!=2";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtNurses.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtNurses;











        }

        static bool IsAlreadyAsigned(int EmployeeID)
        {
            bool Assigned = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select found=1 from Nurses where EmployeeID=@employeeID


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
