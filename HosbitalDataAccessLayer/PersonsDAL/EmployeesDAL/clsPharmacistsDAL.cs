using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.PersonsDAL.EmployeesDAL
{
    static public class clsPharmacistsDAL
    {

        static public bool GetPharmacistInfoByID(int PharmacistID, ref int EmployeeID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
SELECT 
       *
  FROM Pharmacists
  where PharmacistID=@PharmacistID
";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PharmacistID", PharmacistID);
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


        static public int AddNewPharmacist(int EmployeeID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int PharmacistID = -1;
            if (!clsEmployeeDAL.IsExist(EmployeeID))
                return PharmacistID;
            if (IsAlreadyAsigned(EmployeeID))
                return PharmacistID;
            string Query = @"INSERT INTO Pharmacists
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
                    PharmacistID = InsertedID;



                }


            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return PharmacistID;













        }
        static public bool IsExist(int PharmacistID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Pharmacists 
                          where PharmacistID=@PharmacistID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PharmacistID", PharmacistID);
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

        static public bool DeletePharmacist(int PharmacistID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(PharmacistID))
                return Deleteed;

            string Querey = @"DELETE FROM Pharmacists
                            WHERE PharmacistID=@PharmacistID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@PharmacistID", PharmacistID);
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



        static public DataTable GetAllPharmacistssForAdmin()
        {
            DataTable dtAccountants = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT  Pharmacists.PharmacistID, Persons.FirstName, Persons.LastName, Persons.Phone, Employees.Salery, 
                  Employees.WorkingDays, Employees.EmployementDate, Employees.DueDate, EmployeeStates.State
FROM     Pharmacists INNER JOIN
                  Employees ON Pharmacists.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
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
     

        static public DataTable GetAllPharmacistsForOthers()
        {
            DataTable dtAccountants = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT  Pharmacists.PharmacistID, Persons.FirstName, Persons.LastName,Persons.Phone
FROM     Pharmacists INNER JOIN
                  Employees ON Pharmacists.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID 
                  where Employees.StateID!=2";
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
            string Query = @"select found=1 from Pharmacists where EmployeeID=@employeeID



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
