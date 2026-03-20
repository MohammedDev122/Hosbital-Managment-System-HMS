using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.LogsDAL
{
    public static class clsPatientLogDAL

    {
    


            static public int AddNewPatientLog(int PatientID,
                 int ServiceID)
            {
                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                int LogID = -1;
                string Query = @"INSERT INTO PatientLogs
           (PatientID
           ,ServiceID)
     VALUES
           (@PatientID
           ,@ServiceID
          )
select SCOPE_IDENTITY();";
                SqlCommand Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@PatientID", PatientID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);

                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                    {
                        LogID = InsertedID;
                    }



                }
                catch (Exception ex) { }
                finally
                {
                    Connection.Close();

                }

                return LogID;


            }

            static public bool GetPatientLogInfoByID(int id, ref int PatientID, ref int ServiceID)
            {

                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                bool IsFound = false;
                string Query = @"SELECT *
  FROM PatientLogs
where LogID=@LogID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@LogID", id);
                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {

                        PatientID = Convert.ToInt32(Reader["PatientID"]);
                        ServiceID = Convert.ToInt32(Reader["ServiceID"]);

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

        static public bool GetPatientLogInfoByServiceID(int ServiceID, ref int PatientID, ref int ID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT *
  FROM PatientLogs
where ServiceID=@ServiceID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    PatientID = Convert.ToInt32(Reader["PatientID"]);
                    ID = Convert.ToInt32(Reader["LogID"]);

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

        static public bool IsExist(int ID)
            {

                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                bool IsFound = false;
                string Query = @"SELECT Found=1
  FROM PatientLogs
where LogID=@LogID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@LogID", ID);

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

          
            static public bool DeleteLog(int ID)
            {
                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                bool Deleteed = false;
                if (!IsExist(ID))
                    return Deleteed;
                string Querey = @"DELETE FROM PatientLogs
                            WHERE LogID=@LogID";
                SqlCommand command = new SqlCommand(Querey, Connection);
                command.Parameters.AddWithValue("@LogID", ID);
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



            static public DataTable GetAllLogs()
            {
                DataTable dtPatientLogs = new DataTable();
                SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
                string Query = @"SELECT PatientLogs.LogID, PatientLogs.PatientID, Persons.FirstName+' '+ Persons.LastName as PatientName, Persons.Phone, Services.ServiceID,ServicesTypes.ServiceName as Type, Services.ServiceStartTime, Services.ServiceEndTime, Services.Date, ServiceState.State
FROM     PatientLogs INNER JOIN
                  Patients ON PatientLogs.PatientID = Patients.PatientID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
                  Services ON PatientLogs.ServiceID = Services.ServiceID AND Patients.PatientID = Services.PatientID 
Inner Join ServiceState on Services.ServiceStateID=ServiceState.StateID
inner join ServicesTypes on services.ServiceTypeID=ServicesTypes.TypeId
";
                SqlCommand Command = new SqlCommand(Query, Connection);


                try
                {
                    Connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        dtPatientLogs.Load(Reader);
                    }
                    Reader.Close();



                }
                catch (Exception ex) { }
                finally { Connection.Close(); }
                return dtPatientLogs;











            

        }
    }
}
