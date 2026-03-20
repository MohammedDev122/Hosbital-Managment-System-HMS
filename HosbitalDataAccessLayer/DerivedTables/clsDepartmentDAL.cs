using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer
{
    static public class clsDepartmentDAL
    {



        static public bool GetDepartmentInfoByID(int id, ref string DepartmentName,
          ref int DepartmentManagerID, ref int NumOfEmployees)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
     *
  FROM Departments
  where DepartmentID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {                 
                    NumOfEmployees = Convert.ToInt32(Reader["NumOfEmployees"]);
                    if (DBNull.Value != Reader["DepartmentManagerID"])
                    {
                        DepartmentManagerID = Convert.ToInt32(Reader["DepartmentManagerID"]);

                    }
                    else
                        DepartmentManagerID = -1;
                    DepartmentName = Convert.ToString(Reader["DepartmentName"]);


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
        static public bool GetDepartmentInfoByName(string DepartmentName, ref int DepartmentID,
     ref int DepartmentManagerID, ref int NumOfEmployees)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
     *
  FROM Departments
  where DepartmentName=@DepartmentName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    NumOfEmployees = Convert.ToInt32(Reader["NumOfEmployees"]);
                    if (DBNull.Value != Reader["DepartmentManagerID"])
                    {
                        DepartmentManagerID = Convert.ToInt32(Reader["DepartmentManagerID"]);

                    }
                    else
                        DepartmentManagerID = -1;
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]);


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

        static public bool GetDepartmentNameByID(int id, ref string DepartmentName)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
      DepartmentName
  FROM Departments
  where DepartmentID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader != null)
                {
                    DepartmentName = (string)Reader["DepartmentName"];
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

        static public int AddNewDepartment( string DepartmentName,
           int DepartmentManagerID,  int NumOfEmployees)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int DepartmentID = -1;
           
            string Query = @"INSERT INTO Departments
           (DepartmentName
           ,DepartmentManagerID
           ,NumOfEmployees)
     VALUES
           (@DepartmentName,
           @DepartmentManagerID,
           @NumOfEmployees)

		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            if (DepartmentManagerID != -1)
            {
                Command.Parameters.AddWithValue("@DepartmentManagerID", DepartmentManagerID);
            }
            else
            {
                Command.Parameters.AddWithValue("@DepartmentManagerID", DBNull.Value);

            }

            Command.Parameters.AddWithValue("@NumOfEmployees", NumOfEmployees);
            

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    DepartmentID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return DepartmentID;













        }
        static public bool UpdateDepartment(int DepartmentID, string DepartmentName,
      int DepartmentManagerID, int NumOfEmployees)
        {
            bool Updated = false;

            if (!IsExist(DepartmentID)) return Updated;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);


            string Query = @"
UPDATE Departments
   SET DepartmentName = @DepartmentName
      ,DepartmentManagerID =@DepartmentManagerID
      ,NumOfEmployees = @NumOfEmployees
 WHERE DepartmentID=@DepartmentID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            if(DepartmentManagerID!=-1)
            Command.Parameters.AddWithValue("@DepartmentManagerID", DepartmentManagerID);
            else
                Command.Parameters.AddWithValue("@DepartmentManagerID", DBNull.Value);

            Command.Parameters.AddWithValue("@NumOfEmployees", NumOfEmployees);
            Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);

            try
            {
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Updated = true;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return Updated;

        }


        static public bool IsExist(int DepartmentID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Departments 
                          where DepartmentID=@DepartmentID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Exist = true;
                    Reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Exist;


        }
        static public bool IsExist(string DepartmentName)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Departments 
                          where DepartmentName=@DepartmentName";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
            try
            {

                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Exist = true;
                    Reader.Close ();
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Exist;


        }
        static public bool DeleteDepartment(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ID))
                return Deleteed;
            string Querey = @"DELETE FROM Departments
                            WHERE DepartmentID=@DepartmentID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@DepartmentID", ID);
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


        static public DataTable GetAllDepartments()
        {

            DataTable dtDepartments = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from Departments";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtDepartments.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtDepartments;
        }
    }
}
