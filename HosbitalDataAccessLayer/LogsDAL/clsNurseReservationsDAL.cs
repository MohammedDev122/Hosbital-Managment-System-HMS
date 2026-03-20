using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.LogsDAL
{
    static public class clsNurseReservationsDAL

    {
        static public bool GetReservationInfoByServiceID(int ServiceID, ref int ReservationID, ref int NurseID, ref DateTime Date, ref DateTime Time)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM NurseReservations
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

                    NurseID = Convert.ToInt32(Reader["NurseID"]);
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
        static public bool GetReservationInfoByServiceIDAndNurseID(int ServiceID, int NurseID, ref int ReservationID, ref DateTime Date, ref DateTime Time)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM NurseReservations
      where ServiceID=@ServiceID
and NurseID=@NurseID

    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            Command.Parameters.AddWithValue("@NurseID", NurseID);

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

        static public int AddNewReservation(int NurseID, int ServiceID,
              DateTime Date, DateTime Time)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ReservationID = -1;
            string Query = @"
   
INSERT INTO NurseReservations
           (NurseID
           ,Date
           ,Time
           ,ServiceID)
     VALUES
(@NurseID
           ,@Date
           ,@Time
           ,@ServiceID)
		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NurseID", NurseID);
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

        static public bool GetReservationInfoByID(int ReservationID, ref int NurseID, ref int ServiceID, ref DateTime Date, ref DateTime Time)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM NurseReservations
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

                    NurseID = Convert.ToInt32(Reader["NurseID"]);
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


        static public bool IsExist(int ReservationID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT found=1
      FROM NurseReservations
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


        static public bool DeleteNurseReservation(int ReservationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ReservationID))
                return Deleteed;
            string Querey = @"DELETE FROM NurseReservations
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

        static public bool DeleteNurseReservation(int NurseID, int ServiceID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
          
            string Querey = @"DELETE FROM NurseReservations
          WHERE NurseID=@NurseID
and
ServiceID=@ServiceID
    ";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@NurseID", NurseID);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);

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
            string Query = @"SELECT NurseReservations.ReservationID, NurseReservations.NurseID, Persons.FirstName+' '+ Persons.LastName as NurseName, Services.ServiceID, NurseReservations.Date, NurseReservations.Time,ServiceState.State
FROM     NurseReservations INNER JOIN
                  Nurses ON NurseReservations.NurseID = Nurses.NurseID INNER JOIN
                  Employees ON Nurses.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID inner join
    Services ON NurseReservations.ServiceID = Services.ServiceID
inner join ServiceState on Services.ServiceStateID=ServiceState.StateID


";
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
        static public DataTable GetAllReservationForNurse(int NurseID)
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT NurseReservations.ReservationID, NurseReservations.NurseID, Persons.FirstName+' '+ Persons.LastName as NurseName, Services.ServiceID, NurseReservations.Date, NurseReservations.Time,ServiceState.State
FROM     NurseReservations INNER JOIN
                  Nurses ON NurseReservations.NurseID = Nurses.NurseID INNER JOIN
                  Employees ON Nurses.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID inner join
    Services ON NurseReservations.ServiceID = Services.ServiceID
inner join ServiceState on Services.ServiceStateID=ServiceState.StateID
    where NurseReservations.NurseID=@NurseID
    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NurseID", NurseID);

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
            string Query = @"SELECT NurseReservations.ReservationID, NurseReservations.NurseID, Persons.FirstName+' '+ Persons.LastName as NurseName, Services.ServiceID, NurseReservations.Date, NurseReservations.Time,ServiceState.State
FROM     NurseReservations INNER JOIN
                  Nurses ON NurseReservations.NurseID = Nurses.NurseID INNER JOIN
                  Employees ON Nurses.EmployeeID = Employees.EmployeeID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID inner join
    Services ON NurseReservations.ServiceID = Services.ServiceID
inner join ServiceState on Services.ServiceStateID=ServiceState.StateID
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

        static public bool UpdateReservationInfo(int ReservationID, int NurseID, int ServiceID, DateTime Date, DateTime Time)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE NurseReservations
   SET NurseID = @NurseID
      ,Date = @Date
      ,Time = @Time
      ,ServiceID =@ServiceID
	  WHERE ReservationID=@ReservationID

    ";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);

            command.Parameters.AddWithValue("@NurseID", NurseID);

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
        static SqlCommand _PrepareCommand(SqlConnection Connection, int NurseID, DateTime Date, DateTime Time1, DateTime Time2, int ServiceID)
        {
            string Query = "";
            if (Time1.Hour >= 16 && Time1.Hour <= 19)
            {
                Query = @"SELECT 1 AS found
FROM     NurseReservations INNER JOIN
                  Services ON NurseReservations.ServiceID = Services.ServiceID INNER JOIN
                  Nurses ON NurseReservations.NurseID = Nurses.NurseID
				 				    WHERE   ((NurseReservations.Date = @Date1) AND (NurseReservations.NurseID = @NurseID) AND (NurseReservations.Time BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((NurseReservations.Date = @Date2) AND (NurseReservations.NurseID = @NurseID) AND (NurseReservations.Time BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Date1", Date.Date);
                Command.Parameters.AddWithValue("@Date2", Date.Date.AddDays(1));
                Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                Command.Parameters.AddWithValue("@NurseID", NurseID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                return Command;
            }
            else if (Time1.Hour >= 20)
            {
                Query = @"SELECT 1 AS found
FROM     NurseReservations INNER JOIN
                  Services ON NurseReservations.ServiceID = Services.ServiceID INNER JOIN
                  Nurses ON NurseReservations.NurseID = Nurses.NurseID
				 				    WHERE   ((NurseReservations.Date = @Date1) AND (NurseReservations.NurseID = @NurseID) AND (NurseReservations.Time BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((NurseReservations.Date = @Date2) AND (NurseReservations.NurseID = @NurseID) AND (NurseReservations.Time BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Date1", Date.Date.AddDays(-1));
                Command.Parameters.AddWithValue("@Date2", Date.Date);
                Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                Command.Parameters.AddWithValue("@NurseID", NurseID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                return Command;
            }
            else
            {
                Query = @"SELECT 1 AS found
FROM     NurseReservations INNER JOIN
                  Services ON NurseReservations.ServiceID = Services.ServiceID INNER JOIN
                  Nurses ON NurseReservations.NurseID = Nurses.NurseID
				  WHERE  (NurseReservations.Date = @Date) AND (NurseReservations.NurseID = @NurseID) AND (NurseReservations.Time BETWEEN @Time1 AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID
";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Date", Date.Date);
                Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                Command.Parameters.AddWithValue("@NurseID", NurseID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                return Command;


            }



        }

        static public bool CheckReservationDosentOverLap(int NurseID, DateTime Date, DateTime Time1, DateTime Time2, int ServiceID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsOK = false;

         

            SqlCommand Command = _PrepareCommand(Connection,NurseID,Date,Time1,Time2,ServiceID);


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

    }
}
