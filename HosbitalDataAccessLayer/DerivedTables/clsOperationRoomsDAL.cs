using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.DerivedTables
{
    public static class clsOperationRoomsDAL

    {
        //OperationRooms

        static public int AddNewOperationRoom(string RoomNum)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int OperationRoomID = -1;
            string Query = @"INSERT INTO OperationRooms
           (RoomNum
          )
     VALUES
            (@RoomNum
          )
select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@RoomNum", RoomNum);
           

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    OperationRoomID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return OperationRoomID;


        }

        static public bool GetOperationRoomInfoByID(int OperationRoomID, ref string RoomNum)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT RoomNum
      
  FROM OperationRooms
where OperationRoomID=@OperationRoomID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationRoomID", OperationRoomID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    RoomNum = Convert.ToString(Reader["RoomNum"]);
                   

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

        static public bool UpdateOperationRoomInfo(int OperationRoomID, string RoomNum)
        {
            bool Updated = false;
            if (!IsExist(OperationRoomID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE OperationRooms
                           SET RoomNum = @RoomNum
                          
                           WHERE OperationRoomID=@OperationRoomID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@OperationRoomID", OperationRoomID);
            command.Parameters.AddWithValue("@RoomNum", RoomNum);
            
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
        static public bool IsExist(int OperationRoomID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM OperationRooms
where OperationRoomID=@OperationRoomID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationRoomID", OperationRoomID);

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

        static public bool IsExist(string RoomNum)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM OperationRoomID
where RoomNum=@RoomNum";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@RoomNum", RoomNum);

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
        static public bool DeleteOperationRoom(int OperationRoomID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(OperationRoomID))
                return Deleteed;
            string Querey = @"DELETE FROM OperationRooms
                            WHERE OperationRoomID=@OperationRoomID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@OperationRoomID", OperationRoomID);
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



        static public DataTable GetAllOperationRoom()
        {
            DataTable dtOperationRooms = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = "select * from OperationRooms";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtOperationRooms.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtOperationRooms;











        }

    }
}
