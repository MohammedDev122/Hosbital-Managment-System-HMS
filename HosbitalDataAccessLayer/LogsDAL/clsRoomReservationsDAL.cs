using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HosbitalDataAccessLayer.LogsDAL
{
    public static class clsRoomReservationsDAL


    {
        //RoomsReservations
        static public int AddNewReservation(int RoomID, DateTime Date,
              DateTime StartTime,int ServiceID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int ReservationID = -1;
            string Query = @"
    INSERT INTO RoomsReservations
               (RoomID
               ,Date
               ,StartTime,ServiceID)
         VALUES
               (@RoomID
               ,@Date
               ,@StartTime,@ServiceID)
    		   select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RoomID", RoomID);
            Command.Parameters.AddWithValue("@Date", Date.Date);
            Command.Parameters.AddWithValue("@StartTime", StartTime.TimeOfDay);
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

        static public bool GetReservationInfoByID(int ReservationID, ref int RoomID, ref DateTime Date, ref DateTime StartTime,ref int ServiceID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM RoomsReservations
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

                    RoomID = Convert.ToInt32(Reader["RoomID"]);
                    Date = Convert.ToDateTime(Reader["Date"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["StartTime"]), out DateTime time))
                        StartTime = time;
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
      FROM RoomsReservations
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


        static public bool DeleteRoomReservation(int ReservationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(ReservationID))
                return Deleteed;
            string Querey = @"DELETE FROM RoomsReservations
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



        static public DataTable GetAllReservations()
        {

            DataTable dtReservations = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT RoomsReservations.ReservationID, RoomsReservations.RoomID, OperationRooms.RoomNum, RoomsReservations.Date, RoomsReservations.StartTime,RoomsReservations.ServiceID,ServiceState.State
FROM     RoomsReservations INNER JOIN
                  OperationRooms ON RoomsReservations.RoomID = OperationRooms.OperationRoomID INNER JOIN
Services on Services.ServiceID=RoomsReservations.ServiceID inner join
ServiceState on Services.ServiceStateID=ServiceState.StateID

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
        static public DataTable GetAllReservationForRoom(int RoomID)
        {
            DataTable dtRecords = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT RoomsReservations.ReservationID, RoomsReservations.RoomID, OperationRooms.RoomNum, RoomsReservations.Date, RoomsReservations.StartTime
FROM     RoomsReservations INNER JOIN
                  OperationRooms ON RoomsReservations.RoomID = OperationRooms.OperationRoomID
    where RoomsReservations.RoomID=@RoomID
    ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@RoomID", RoomID);

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
        static public bool UpdateReservationInfo(int ReservationID,  int RoomID,  DateTime Date,  DateTime StartTime,int ServiceID)
        {
            bool Updated = false;
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE RoomsReservations
   SET RoomID = @RoomID
      ,Date = @Date
      ,StartTime = @StartTime
,ServiceID=@ServiceID
	  WHERE ReservationID=@ReservationID

    ";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);

            command.Parameters.AddWithValue("@StartTime", StartTime.TimeOfDay);

            command.Parameters.AddWithValue("@Date", Date.Date);
            
            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);


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

        static public bool GetReservationInfoByServiceID(int ServiceID, ref int ReservationID, ref int RoomID, ref DateTime Date, ref DateTime StartTime)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"
    SELECT *
      FROM RoomsReservations
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

                    RoomID = Convert.ToInt32(Reader["RoomID"]);
                    if (DateTime.TryParse(Convert.ToString(Reader["StartTime"]), out DateTime time))
                        StartTime = time;
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
        static SqlCommand _PrepareCommand(SqlConnection Connection, int RoomID, DateTime Date, DateTime Time1, DateTime Time2, int ServiceID)
        {
            string Query = "";
            if (Time1.Hour >= 16 && Time1.Hour <= 19)
            {
                Query = @"				SELECT 1 AS found
FROM     RoomsReservations INNER JOIN
                  OperationRooms ON RoomsReservations.RoomID = OperationRooms.OperationRoomID INNER JOIN
                  Services ON RoomsReservations.ServiceID = Services.ServiceID
				    WHERE   ((RoomsReservations.Date = @Date1) AND (RoomsReservations.RoomID = @RoomID) AND (RoomsReservations.StartTime BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((RoomsReservations.Date = @Date2) AND (RoomsReservations.RoomID = @RoomID) AND (RoomsReservations.StartTime BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
					";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Date1", Date.Date);
                Command.Parameters.AddWithValue("@Date2", Date.Date.AddDays(1));
                Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                Command.Parameters.AddWithValue("@RoomID", RoomID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                return Command;
            }
            else if (Time1.Hour >= 20 )
            {
                Query = @"				SELECT 1 AS found
FROM     RoomsReservations INNER JOIN
                  OperationRooms ON RoomsReservations.RoomID = OperationRooms.OperationRoomID INNER JOIN
                  Services ON RoomsReservations.ServiceID = Services.ServiceID
				    WHERE   ((RoomsReservations.Date = @Date1) AND (RoomsReservations.RoomID = @RoomID) AND (RoomsReservations.StartTime BETWEEN @Time1  AND '23:59') AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
or 				       ((RoomsReservations.Date = @Date2) AND (RoomsReservations.RoomID = @RoomID) AND (RoomsReservations.StartTime BETWEEN '00:00'  AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID)
					";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Date1", Date.Date.AddDays(-1));
                Command.Parameters.AddWithValue("@Date2", Date.Date);
                Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                Command.Parameters.AddWithValue("@RoomID", RoomID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);
                return Command;
            }
            else
            {
                Query = @"
				SELECT 1 AS found
FROM     RoomsReservations INNER JOIN
                  OperationRooms ON RoomsReservations.RoomID = OperationRooms.OperationRoomID INNER JOIN
                  Services ON RoomsReservations.ServiceID = Services.ServiceID
				    WHERE  (RoomsReservations.Date = @Date) AND (RoomsReservations.RoomID = @RoomID) AND (RoomsReservations.StartTime BETWEEN @Time1 AND @Time2) AND (Services.ServiceStateID = 2) and Services.ServiceID!=@ServiceID

";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Date", Date.Date);
                Command.Parameters.AddWithValue("@Time1", Time1.TimeOfDay);
                Command.Parameters.AddWithValue("@Time2", Time2.TimeOfDay);
                Command.Parameters.AddWithValue("@RoomID", RoomID);
                Command.Parameters.AddWithValue("@ServiceID", ServiceID);
return Command; 

            }



        }
        static public bool CheckReservationDosentOverLap(int RoomID, DateTime Date, DateTime Time1, DateTime Time2, int ServiceID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsOK = false;
            //look at hours if u are in the range from 4 AM to 8 PM 
            //if u are in 1 ,2 or 3 u btter to check if there is operation with the same room ID at the previous day 
            //if u are in 9 ,10 or 11 u btter to check if there is operation with the same room ID at the following day 


            SqlCommand Command = _PrepareCommand(Connection, RoomID, Date, Time1, Time2, ServiceID); ;
          


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
