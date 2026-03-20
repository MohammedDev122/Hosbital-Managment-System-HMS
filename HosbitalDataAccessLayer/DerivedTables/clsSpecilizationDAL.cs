using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer
{
    static public class clsSpecilizationDAL
    {



        static public bool GetSpecilizationInfoByID(int id, ref string SpecilizationName)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
       Specilization
  FROM Specilizations
  where SpecilizationID=@SpecilizationID
";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@SpecilizationID", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    SpecilizationName =Convert.ToString(Reader["Specilization"]);
                    


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


        static public bool GetSpecilizationInfoByName(string SpecilizationName, ref int id)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT 
SpecilizationID
       
  FROM Specilizations
  where Specilization=@Specilization
";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Specilization", SpecilizationName);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    id = Convert.ToInt32(Reader["SpecilizationID"]);



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


        static public int AddNewSpecilization(string SpecilizationName)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int SpecilizationID = -1;

            string Query = @"INSERT INTO Specilizations
           (Specilization)
     VALUES
           (@Specilization)
		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Specilization", SpecilizationName);
           

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    SpecilizationID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return SpecilizationID;













        }
        static public bool UpdateSpecilization(int SpecilizationID, string SpecilizationName)
        {
            bool Updated = false;

            if (!IsExist(SpecilizationID)) return Updated;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);


            string Query = @"
UPDATE Specilizations
   SET Specilization = @Specilization
 WHERE SpecilizationID=@SpecilizationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@SpecilizationID", SpecilizationID);
            Command.Parameters.AddWithValue("@Specilization", SpecilizationName);
            

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


        static public bool IsExist(int SpecilizationID)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Specilizations 
                          where SpecilizationID=@SpecilizationID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@SpecilizationID", SpecilizationID);
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
        static public bool IsExist(string SpecilizationName)
        {
            bool Exist = false;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"select Found=1 from Specilizations 
                          where Specilization=@Specilization";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@Specilization", SpecilizationName);
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
        static public bool DeleteSpecilization(int SpecilizationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(SpecilizationID))
                return Deleteed;
            string Querey = @"DELETE FROM Specilizations
                            WHERE SpecilizationID=@SpecilizationID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@SpecilizationID", SpecilizationID);
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


        static public DataTable GetAllSpecilizations()
        {

            DataTable dtSpecilizations = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from Specilizations";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtSpecilizations.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtSpecilizations;
        }







    }
}
