using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.DerivedTables
{
    public static class clsCountriesDAL

    {
        //Countries

        static public int AddNewCountry(string CountryName,
             string CountryCode)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int CountryID = -1;
            string Query = @"INSERT INTO Countries
           (CountryName
           ,CountryCode)
     VALUES
           (@CountryName
           ,@CountryCode
           )
select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);
            Command.Parameters.AddWithValue("@CountryCode", CountryCode);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    CountryID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return CountryID;


        }

        static public bool GetCountryInfoByID(int CountryID, ref string CountryName, 
           ref string CountryCode)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT CountryID
      ,CountryName
      ,CountryCode
  FROM Countries
where CountryID=@CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CountryName = Convert.ToString(Reader["CountryName"]);
                    CountryCode = Convert.ToString(Reader["CountryCode"]);

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
        static public bool GetCountryInfoByName(  string CountryName,
      ref int CountryID,  ref string CountryCode)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT CountryID
      ,CountryName
      ,CountryCode
  FROM Countries
where CountryName=@CountryName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CountryID = Convert.ToInt32(Reader["CountryID"]);
                    CountryCode = Convert.ToString(Reader["CountryCode"]);

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
        static public bool UpdateCountryInfo(int CountryID, string CountryName,
            string CountryCode)
        {
            bool Updated = false;
            if (!IsExist(CountryID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Countries
                           SET CountryName = @CountryName
                           ,CountryCode =@CountryCode
                          
                           WHERE CountryID=@CountryID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@CountryCode", CountryCode);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                int RowsAffected = command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Updated = true;
                }

            }
            catch (Exception ex)
            {

            }
            finally { connection.Close(); }

            return Updated;

        }
        static public bool IsExist(int CountryID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM Countries
where CountryID=@CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    IsFound = true;

                }

            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return IsFound;




        }

        static public bool IsExist(string CountryCode)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM Countries
where CountryCode=@CountryCode";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryCode", CountryCode);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    IsFound = true;

                }

            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return IsFound;




        }
        static public bool DeleteCountry(int CountryID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(CountryID))
                return Deleteed;
            string Querey = @"DELETE FROM Countries
                            WHERE CountryID=@CountryID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
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



        static public DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from Countries";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtCountries.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtCountries;











        }

    }
}
