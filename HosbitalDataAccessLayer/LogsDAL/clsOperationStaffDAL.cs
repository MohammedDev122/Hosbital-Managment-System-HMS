using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.DerivedTables
{
    static public class clsOperationStaffDAL
    {
        //OperationStaff
        static public int AddNewOperationStaff(int EmployeeID,int OperationID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int StaffID = -1;
            string Query = @"INSERT INTO OperationStaff
           (EmployeeID
    ,OperationID)
     VALUES
            (@EmployeeID
    ,@OperationID)
select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@OperationID", OperationID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    StaffID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return StaffID;


        }

        static public bool GetOperationStaffInfoByID(int StaffID, ref int EmployeeID,ref int OperationID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT EmployeeID
,OperationID
      
  FROM OperationStaff
where StaffID=@StaffID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@StaffID", StaffID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    EmployeeID = Convert.ToInt32(Reader["EmployeeID"]);
                    OperationID = Convert.ToInt32(Reader["OperationID"]);


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

        static public bool UpdateOperationStaffInfo(int StaffID, int EmployeeID,int OperationID)
        {
            bool Updated = false;
            if (!IsExist(StaffID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE OperationStaff
                           SET EmployeeID = @EmployeeID
                          ,OperationID=@OperationID
                           WHERE StaffID=@StaffID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@StaffID", StaffID);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@OperationID", OperationID);

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
        static public bool IsExist(int StaffID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM OperationStaff
where StaffID=@StaffID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@StaffID", StaffID);

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

        static public bool IsExist(int OperationID,int EmployeeID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM OperationStaff
where EmployeeID = @EmployeeID
                          and OperationID=@OperationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@OperationID", OperationID);

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
        static public bool DeleteOperationStaff(int StaffID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(StaffID))
                return Deleteed;
            string Querey = @"DELETE FROM OperationStaff
                            WHERE StaffID=@StaffID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@StaffID", StaffID);
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



        static public DataTable GetAllOperationsStaff()
        {
            DataTable dtOperationRooms = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT OperationStaff.StaffID, Operations.OperationID,Departments.DepartmentName as Department, OperationStaff.EmployeeID, Persons.FirstName+' '+ Persons.LastName as EmployeeName, Persons.Phone,  Services.Date, Services.ServiceStartTime, ServiceState.State, 
                  OperationRooms.RoomNum
FROM     OperationStaff INNER JOIN
                  Employees ON OperationStaff.EmployeeID = Employees.EmployeeID INNER JOIN
                  Operations ON OperationStaff.OperationID = Operations.OperationID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Departments ON Employees.DepartmentID = Departments.DepartmentID INNER JOIN
                  Services ON Operations.ServiceID = Services.ServiceID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN
                  OperationRooms ON Operations.RoomID = OperationRooms.OperationRoomID";
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

        static public DataTable GetAllOperationStaffByOperationID(int OperationID)
        {
            DataTable dtOperationRooms = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT OperationStaff.StaffID, Operations.OperationID,Departments.DepartmentName as Department, OperationStaff.EmployeeID, Persons.FirstName+' '+ Persons.LastName as EmployeeName, Persons.Phone,  Services.Date, Services.ServiceStartTime, ServiceState.State, 
                  OperationRooms.RoomNum
FROM     OperationStaff INNER JOIN
                  Employees ON OperationStaff.EmployeeID = Employees.EmployeeID INNER JOIN
                  Operations ON OperationStaff.OperationID = Operations.OperationID INNER JOIN
                  Persons ON Employees.PersonID = Persons.PersonID INNER JOIN
                  Departments ON Employees.DepartmentID = Departments.DepartmentID INNER JOIN
                  Services ON Operations.ServiceID = Services.ServiceID INNER JOIN
                  ServiceState ON Services.ServiceStateID = ServiceState.StateID INNER JOIN
                  OperationRooms ON Operations.RoomID = OperationRooms.OperationRoomID
where OperationStaff.OperationID=@OperationID
";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);

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
