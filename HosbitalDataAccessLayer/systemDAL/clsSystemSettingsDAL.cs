using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.systemDAL
{
    public static class clsSystemSettingsDAL

    {


    

        static public bool GetSystemSettingsInfoByID(int id, ref int CurrentLangID, ref int CurrentThemeID
          )
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT CurrentLangID
      ,CurrentThemeID
  FROM SystemSettings
where id=@id";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CurrentLangID = Convert.ToInt32(Reader["CurrentLangID"]);
                    CurrentThemeID = Convert.ToInt32(Reader["CurrentThemeID"]);

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

        static public bool UpdateSystemSettingsInfo(int id, int CurrentLangID, int CurrentThemeID)
        {
            bool Updated = false;
            
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE SystemSettings
                           SET CurrentLangID = @CurrentLangID
                           ,CurrentThemeID =@CurrentThemeID
                           WHERE id=@id";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CurrentLangID", CurrentLangID);
            command.Parameters.AddWithValue("@CurrentThemeID", CurrentThemeID);
            command.Parameters.AddWithValue("@id", id);
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
     
     

    }
}
