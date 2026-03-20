using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.DerivedTables
{
    static public class clsMedicationCatorgyDAL
    {





        static public int AddNewCatorgy(
               string Catorgy,int NumOfMedications=0)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ID = -1;
            string Query = @"
INSERT INTO MedicationCatorgies
           (Catorgy
           ,NumOfMedications)
     VALUES
           (@Catorgy
           ,@NumOfMedications)
			 select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Catorgy", Catorgy);
            Command.Parameters.AddWithValue("@NumOfMedications", NumOfMedications);

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

        static public bool GetCatorgyInfoByID(int ID, ref string Catorgy, ref int NumOfMedications)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Catorgy
      ,NumOfMedications
     
  FROM MedicationCatorgies
where ID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    Catorgy = Convert.ToString(Reader["Catorgy"]);
                    NumOfMedications = Convert.ToInt16(Reader["NumOfMedications"]);

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
        static public bool GetCatorgyInfoByName(string Catorgy, ref int ID, ref int NumOfMedications)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT ID
      ,NumOfMedications
     
  FROM MedicationCatorgies
where 
Catorgy=@Catorgy";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Catorgy", Catorgy);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    ID = Convert.ToInt32(Reader["ID"]);
                    NumOfMedications = Convert.ToInt16(Reader["NumOfMedications"]);

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

        static public bool UpdateCatorgieInfo(int ID, string Catorgy, int NumOfMedications)
        {
            bool Updated = false;
            if (!IsExist(ID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE MedicationCatorgies
                           SET Catorgy = @Catorgy
                           ,NumOfMedications =@NumOfMedications
                          
                           WHERE ID=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NumOfMedications", NumOfMedications);
            command.Parameters.AddWithValue("@Catorgy", Catorgy);
            command.Parameters.AddWithValue("@ID", ID);
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
        static public bool IsExist(int ID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM MedicationCatorgies
where ID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", ID);

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

        static public bool DeleteCatorgie(int ID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ID))
                return Deleteed;
            string Querey = @"DELETE FROM MedicationCatorgies
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



        static public DataTable GetAllCatorgiess()
        {
            DataTable dtCatorgies = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from MedicationCatorgies";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtCatorgies.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtCatorgies;











        }





















    }
}
