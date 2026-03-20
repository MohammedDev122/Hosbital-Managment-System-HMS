using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.MediationsDAL
{
    static public class clsMedIcationDAL

    { //Medications
        static public int AddNewMedication(
                 string MedicationName, string Notes, int Quantities,double Price,int CatorgyID)
    {
        SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
        int MedicationID = -1;
        string Query = @"
INSERT INTO Medications
           (MedicationName
           ,Notes
,Quantities
,Price
,CatorgyID)
     VALUES
               (@MedicationName
           ,@Notes
,@Quantities
,@Price
,@CatorgyID)
			 select SCOPE_IDENTITY();";
        SqlCommand Command = new SqlCommand(Query, Connection);

        Command.Parameters.AddWithValue("@MedicationName", MedicationName);
        Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@Quantities", Quantities);
            Command.Parameters.AddWithValue("@Price", Price);
            Command.Parameters.AddWithValue("@CatorgyID", CatorgyID);

            try
            {
            Connection.Open();
            object Result = Command.ExecuteScalar();
            if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
            {
                MedicationID = InsertedID;
            }



        }
        catch (Exception ex) { }
        finally
        {
            Connection.Close();

        }

        return MedicationID;


    }

    static public bool GetMedicationInfoByID(int MedicationID, ref string MedicationName, ref string Notes,ref int Quantities,ref double Price,ref int CatorgyID)
    {

        SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
        bool IsFound = false;
        string Query = @"SELECT MedicationName
      ,Notes
,Quantities
,Price
,CatorgyID
     
  FROM Medications
where MedicationID=@MedicationID";
        SqlCommand Command = new SqlCommand(Query, Connection);
        Command.Parameters.AddWithValue("@MedicationID", MedicationID);
        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {

                    MedicationName = Convert.ToString(Reader["MedicationName"]);
                    Notes = Convert.ToString(Reader["Notes"]);
                    Quantities = Convert.ToInt16(Reader["Quantities"]);
                    Price = Convert.ToDouble(Reader["Price"]);
                    CatorgyID = Convert.ToInt32(Reader["CatorgyID"]);


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

    static public bool UpdateMedicationInfo(int MedicationID,  string MedicationName,  string Notes, int Quantities, double Price, int CatorgyID)
    {
        bool Updated = false;
        if (!IsExist(MedicationID))
            return Updated;
        SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
        string Query = @"UPDATE Medications
                           SET MedicationName = @MedicationName
                           ,Notes =@Notes
                           ,Quantities =@Quantities
 ,Price =@Price
 ,CatorgyID =@CatorgyID
                           WHERE MedicationID=@MedicationID";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@MedicationName", MedicationName);
        command.Parameters.AddWithValue("@Notes", Notes);
        command.Parameters.AddWithValue("@Quantities", Quantities);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@CatorgyID", CatorgyID);
            command.Parameters.AddWithValue("@MedicationID", MedicationID);

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
    static public bool IsExist(int MedicationID)
    {

        SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
        bool IsFound = false;
        string Query = @"SELECT Found=1
  FROM Medications
where MedicationID=@MedicationID";
        SqlCommand Command = new SqlCommand(Query, Connection);
        Command.Parameters.AddWithValue("@MedicationID", MedicationID);

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

    static public bool DeleteMedication(int MedicationID)
    {
        SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
        bool Deleteed = false;
        if (!IsExist(MedicationID))
            return Deleteed;
        string Querey = @"DELETE FROM Medications
                            WHERE MedicationID=@MedicationID";
        SqlCommand command = new SqlCommand(Querey, Connection);
        command.Parameters.AddWithValue("@MedicationID", MedicationID);
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



    static public DataTable GetAllMedicationsForAdmin()
    {
        DataTable dtMedications = new DataTable();
        SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
        string Query = @"SELECT Medications.MedicationID, Medications.MedicationName, Medications.Notes, Medications.Quantities, Medications.Price, MedicationCatorgies.Catorgy
FROM     Medications INNER JOIN
                  MedicationCatorgies ON Medications.CatorgyID = MedicationCatorgies.ID";
        SqlCommand Command = new SqlCommand(Query, Connection);


        try
        {
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                dtMedications.Load(Reader);
            }
            Reader.Close();



        }
        catch (Exception ex) { }
        finally { Connection.Close(); }
        return dtMedications;











    }



        static public DataTable GetAllMedicationsForOthers()
        {
            DataTable dtMedications = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT Medications.MedicationID, Medications.MedicationName, Medications.Notes, MedicationCatorgies.Catorgy
FROM     Medications INNER JOIN
                  MedicationCatorgies ON Medications.CatorgyID = MedicationCatorgies.ID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtMedications.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtMedications;











        }









    }
}
