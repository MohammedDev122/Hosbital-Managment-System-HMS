using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace HosbitalDataAccessLayer.LogsDAL
{
    static public class clsDoctorReservationDAL

    {

        static public int AddNewReservation(int DoctorID, int ServiceID,
              DateTime Date, DateTime Time)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ReservationID = -1;
            string Query = @"
    INSERT INTO DoctorReservations
               (DoctorID
               ,Date
               ,Time
               ,ServiceID)
         VALUES
               (@DoctorID
               ,@Date
               ,@Time
               ,@ServiceID)
    		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DoctorID", DoctorID);
            Command.Parameters.AddWithValue("@Date", Date);
            Command.Parameters.AddWithValue("@Time", Time);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    ReservationID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return ReservationID;


        }

        static public bool GetReservationInfoByID(int ReservationID, ref int DoctorID, ref int ServiceID,ref DateTime Date,ref DateTime Time)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM DoctorReservations
      where ReservationID=@ReservationID

    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ReservationID", ReservationID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    DoctorID = Convert.ToInt32(Reader["DoctorID"]);
                    Date = Convert.ToDateTime(Reader["Date"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["Time"]), out DateTime time))
                        Time = time;
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
        static public bool GetReservationInfoByServiceID(int ServiceID,  ref int ReservationID, ref int DoctorID, ref DateTime Date, ref DateTime Time)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM DoctorReservations
      where ServiceID=@ServiceID

    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    DoctorID = Convert.ToInt32(Reader["DoctorID"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["Time"]), out DateTime time))
                        Time = time;
                  Date = Convert.ToDateTime(Reader["Date"]);
                  
                    ReservationID = Convert.ToInt32(Reader["ReservationID"]);
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
        static public bool GetReservationInfoByServiceIDAndDoctorID(int ServiceID, int DoctorID, ref int ReservationID,  ref DateTime Date, ref DateTime Time)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM DoctorReservations
      where ServiceID=@ServiceID
and DoctorID=@DoctorID

    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    if (DateTime.TryParse(Convert.ToString(Reader["Time"]), out DateTime time))
                        Time = time;
                    Date = Convert.ToDateTime(Reader["Date"]);

                    ReservationID = Convert.ToInt32(Reader["ReservationID"]);
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

        static public bool IsExist(int ReservationID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT found=1
      FROM DoctorReservations
      where ReservationID=@ReservationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ReservationID", ReservationID);

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
        static SqlCommand _PrepareCommand(SqlConnection Connection, int DoctorID, DateTime Date, DateTime Time1, DateTime Time2, int ServiceID)
        {
            string Query = "";
            int value = Time2.Hour - Time1.Hour;
            if (value == 1 || value == 0 | value == -23)
            {
                //diagnosis


                if (value == -23)
                {
                    Query = @"SELECT found =1
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
				 				    WHERE   ((DoctorReservations.Date = @Date1) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((DoctorReservations.Date = @Date2) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
		";
                    SqlCommand Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@Date1", Date.Date);
                    Command.Parameters.AddWithValue("@Date2", Date.Date.AddDays(1));
                    Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                    Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                    Command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    return Command;
                }
                else
                {
                    Query = @"SELECT found =1
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
WHERE  (DoctorReservations.Date = @Date) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN @Time1 AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID
";

                    SqlCommand Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@Date", Date.Date);
                    Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                    Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                    Command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    return Command;


                }

            }
            else
            {
                //operation
                if (Time1.Hour >= 16 && Time1.Hour <= 19)
                {
                    Query = @"SELECT found =1
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
				 				    WHERE   ((DoctorReservations.Date = @Date1) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((DoctorReservations.Date = @Date2) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
		";
                    SqlCommand Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@Date1", Date.Date);
                    Command.Parameters.AddWithValue("@Date2", Date.Date.AddDays(1));
                    Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                    Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                    Command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    return Command;
                }
                else if (Time1.Hour >= 20)
                {
                    Query = @"SELECT found =1
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
				 				    WHERE   ((DoctorReservations.Date = @Date1) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((DoctorReservations.Date = @Date2) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
		";
                    SqlCommand Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@Date1", Date.Date.AddDays(-1));
                    Command.Parameters.AddWithValue("@Date2", Date.Date);
                    Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                    Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                    Command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    return Command;
                }
                else
                {
                    Query = @"SELECT found =1
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
WHERE  (DoctorReservations.Date = @Date) AND (DoctorReservations.DoctorID = @DoctorID) AND (DoctorReservations.Time BETWEEN @Time1 AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID
";

                    SqlCommand Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@Date", Date.Date);
                    Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                    Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                    Command.Parameters.AddWithValue("@DoctorID", DoctorID);
                    Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    return Command;


                }



            }
        }
        static public bool CheckReservationDosentOverLap(int DoctorID, DateTime Date,DateTime Time1,DateTime Time2,int ServiceID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsOK = false;
            
         
              SqlCommand Command = _PrepareCommand(Connection,DoctorID,Date,Time1,Time2,ServiceID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (!Reader.HasRows)
                {

                    IsOK = true;

                }

            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return IsOK;




        }

        static public bool DeleteDoctorReservation(int ReservationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ReservationID))
                return Deleteed;
            string Querey = @"DELETE FROM DoctorReservations
          WHERE ReservationID=@ReservationID
    ";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);
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

        static public bool DeleteDoctorReservation(int DoctorID, int ServiceID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
          
            string Querey = @"DELETE FROM DoctorReservations
          WHERE DoctorID=@DoctorID
and serviceID=@serviceID
    ";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@DoctorID", DoctorID);
            command.Parameters.AddWithValue("@serviceID", ServiceID);

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


        static public DataTable GetAllReservations()
        {
            
            DataTable dtReservations = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT DoctorReservations.ReservationID, DoctorReservations.DoctorID, Persons.FirstName+' '+ Persons.LastName as DoctorName, Services.ServiceID, DoctorReservations.Date, 
DoctorReservations.Time, ServiceState.State,ServicesTypes.ServiceName as Type
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
inner join ServiceState on Services.ServiceStateID=ServiceState.StateID
inner join ServicesTypes on Services.ServiceTypeID=ServicesTypes.TypeId";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtReservations.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtReservations;













        }
        static public DataTable GetAllReservationForDoctor(int DoctorID)
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT DoctorReservations.ReservationID, DoctorReservations.DoctorID, Persons.FirstName+' '+ Persons.LastName as DoctorName, Services.ServiceID, DoctorReservations.Date, 
DoctorReservations.Time, ServiceState.State,ServicesTypes.ServiceName as Type
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
inner join ServiceState on Services.ServiceStateID=ServiceState.StateID
inner join ServicesTypes on Services.ServiceTypeID=ServicesTypes.TypeId
    where Doctors.DoctorID=@DoctorID
    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DoctorID", DoctorID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtRecords.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRecords;













        }


        static public DataTable GetAllServiceReservations(int ServiceID)
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT DoctorReservations.ReservationID, DoctorReservations.DoctorID, Persons.FirstName+' '+ Persons.LastName as DoctorName, Services.ServiceID, DoctorReservations.Date, 
DoctorReservations.Time, ServiceState.State,ServicesTypes.ServiceName as Type
FROM     DoctorReservations INNER JOIN
                  Doctors ON DoctorReservations.DoctorID = Doctors.DoctorID INNER JOIN
                  Employees ON Doctors.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Services ON DoctorReservations.ServiceID = Services.ServiceID
inner join ServiceState on Services.ServiceStateID=ServiceState.StateID
inner join ServicesTypes on Services.ServiceTypeID=ServicesTypes.TypeId
    where Services.ServiceID=@ServiceID
    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtRecords.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtRecords;













        }








        
        static public bool UpdateReservationInfo(int ReservationID,int DoctorID, int ServiceID, DateTime Date,DateTime Time)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE DoctorReservations
   SET DoctorID = @DoctorID
      ,Date = @Date
      ,Time = @Time
      ,ServiceID =@ServiceID
	  WHERE ReservationID=@ReservationID

    ";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);

            command.Parameters.AddWithValue("@DoctorID", DoctorID);

            command.Parameters.AddWithValue("@ServiceID", ServiceID);
            command.Parameters.AddWithValue("@Date", Date);

            command.Parameters.AddWithValue("@Time", Time);

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
   


    }
}
