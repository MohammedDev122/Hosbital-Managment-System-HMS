using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.procedures
{
    public static class clsServicesDAL
    {

        static public bool GetServiceInfo(int ServiceID, ref int PatientID, ref int PaymentID, ref DateTime ServiceStartTime, ref DateTime? ServiceEndTime,ref DateTime Date,ref int ServiceType,ref int ServiceStateID)
        {

          
            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
   *
  FROM Services
  where ServiceID=@ServiceID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    Date = Convert.ToDateTime(Reader["Date"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["ServiceStartTime"]), out DateTime StartTime))

                        ServiceStartTime = StartTime;

                    if (DateTime.TryParse(Convert.ToString(Reader["ServiceEndTime"]), out DateTime EndTime))
                        ServiceEndTime = EndTime;
                    else
                        ServiceEndTime = null;

                    PatientID = Convert.ToInt32(Reader["PatientID"]);
                    PaymentID = Convert.ToInt32(Reader["PaymentID"]);
                    ServiceType = Convert.ToInt32(Reader["ServiceTypeID"]);
                    ServiceStateID = Convert.ToInt32(Reader["ServiceStateID"]);
                    Found = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Found;




        }
        static public int AddNewService(int PatientID, int PaymentID, DateTime ServiceStartTime, DateTime? ServiceEndTime, DateTime Date,int ServiceTypeID,int ServiceStateID)
        {
            int ServiceID = -1;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
INSERT INTO Services
           (ServiceStartTime
           ,ServiceEndTime
           ,Date
           ,PatientID
           ,PaymentID,
ServiceTypeID,
ServiceStateID)
     VALUES
           (@ServiceStartTime
           ,@ServiceEndTime
           ,@Date
           ,@PatientID
           ,@PaymentID,
@ServiceTypeID,
@ServiceStateID)
		   select SCOPE_IDENTITY();
";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ServiceStartTime", ServiceStartTime);
           if(ServiceEndTime!=null)
                command.Parameters.AddWithValue("@ServiceEndTime", ServiceEndTime);
            else
                command.Parameters.AddWithValue("@ServiceEndTime", DBNull.Value);


            command.Parameters.AddWithValue("@Date", Date);
          
                command.Parameters.AddWithValue("@PatientID", PatientID);
           
            
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@ServiceTypeID", ServiceTypeID);
            command.Parameters.AddWithValue("@ServiceStateID", ServiceStateID);


            try
            {

                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null & int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    ServiceID = InsertedID;





                }





            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return ServiceID;




        }



        static public bool UpdateServiceInfo(int ServiceID, int PatientID, int PaymentID, DateTime ServiceStartTime, DateTime? ServiceEndTime, DateTime Date,int ServiceTypeID,int ServiceStateID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE Services
   SET PatientID = @PatientID
      ,PaymentID = @PaymentID
      ,ServiceStartTime = @ServiceStartTime
      ,ServiceEndTime = @ServiceEndTime
      ,Date = @Date
,ServiceTypeID=@ServiceTypeID
,ServiceStateID=@ServiceStateID
 WHERE ServiceID=@ServiceID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);
           
            command.Parameters.AddWithValue("@ServiceStartTime", ServiceStartTime);
            if(ServiceEndTime != null)
            command.Parameters.AddWithValue("@ServiceEndTime", ServiceEndTime);
            else
                command.Parameters.AddWithValue("@ServiceEndTime", DBNull.Value);

            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);
            command.Parameters.AddWithValue("@ServiceTypeID", ServiceTypeID);
            command.Parameters.AddWithValue("@ServiceStateID", ServiceStateID);


            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Updated = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Updated;




        }


        static public bool DeleteService(int ServiceID)
        {




            bool Delete = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"Delete from Services
 WHERE ServiceID=@ServiceID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);


            try
            {
                Connection.Open();
                int Result = command.ExecuteNonQuery();
                if (Result > 0)
                {

                    Delete = true;
                }
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return Delete;





        }


        static public DataTable GetAllServices()
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtPayments = new DataTable();
            string Query = @"SELECT Services.ServiceID, Services.ServiceStartTime, Services.ServiceEndTime, Services.Date, Services.PatientID, Persons.FirstName,
Persons.LastName, Persons.Phone, Payments.PaymentID, Payments.PaymentAmmount, 
                   PaymentStatus.Status,ServiceState.State
FROM     Services INNER JOIN
                  Patients ON Services.PatientID = Patients.PatientID INNER JOIN
                  Payments ON Services.PaymentID = Payments.PaymentID INNER JOIN
PaymentStatus on PaymentStatus.StatusID=Payments.PaymentStatusID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
ServiceState on Services.ServiceStateID=StateID";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtPayments.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPayments;




        }
       


        static public bool ISExist(int ServiceID)
        {
            bool Exist = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);

            string Query = @"
SELECT 
     Found=1 from Services
  where ServiceID=@ServiceID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    Exist = true;



                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return Exist;




        }



        static public DataTable GetAllServicesForPatient(int PatientID)

        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            DataTable dtPayments = new DataTable();
            string Query = @"SELECT Services.ServiceID, Services.ServiceStartTime, Services.ServiceEndTime, Services.Date, Services.PatientID, Persons.FirstName,
Persons.LastName, Persons.Phone, Payments.PaymentID, Payments.PaymentAmmount, 
                  Payments.PaymentStatusID,ServiceState.State
FROM     Services INNER JOIN
                  Patients ON Services.PatientID = Patients.PatientID INNER JOIN
                  Payments ON Services.PaymentID = Payments.PaymentID INNER JOIN
                  Persons ON Patients.PersonID = Persons.PersonID INNER JOIN
ServiceState on Services.ServiceStateID=StateID
where Services.PatientID=@PatientID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dtPayments.Load(Reader);


                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPayments;




        }



    }

}
