using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosbitalDataAccessLayer.MediationsDAL
{
    static public class clsPrescripedMedDAL
    {
        //PrescripedMedications
        static public int AddNewPrescripedMedication(
              double Dosage, DateTime StartDate,DateTime EndDate,int PrescriptionID,string Instructions,int MedicationID,int PMStateID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            int PrescriptionMedID = -1;
            string Query = @"
INSERT INTO PrescripedMedications
           (Dosage
           ,StartDate
,EndDate
,PrescriptionID
,Instructions
,MedicationID
,PMStateID)
     VALUES
              (@Dosage
           ,@StartDate
,@EndDate
,@PrescriptionID
,@Instructions
,@MedicationID
,@PMStateID)
			 select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Dosage", Dosage);
            Command.Parameters.AddWithValue("@StartDate", StartDate);
            Command.Parameters.AddWithValue("@EndDate", EndDate);
            Command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
            Command.Parameters.AddWithValue("@Instructions", Instructions);
            Command.Parameters.AddWithValue("@MedicationID", MedicationID);
            Command.Parameters.AddWithValue("@PMStateID", PMStateID);



            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Convert.ToString(Result), out int InsertedID))
                {
                    PrescriptionMedID = InsertedID;
                }



            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();

            }

            return PrescriptionMedID;


        }

        static public bool GetPrescripedMedicationInfoByID(int PrescriptionMedID,ref double Dosage,ref DateTime StartDate,ref DateTime EndDate,
           ref int PrescriptionID,ref string Instructions,ref int MedicationID,ref int PMStateID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT *
     
  FROM PrescripedMedications
where PrescriptionMedID=@PrescriptionMedID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PrescriptionMedID", PrescriptionMedID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    Dosage = Convert.ToDouble(Reader["Dosage"]);
                    StartDate = Convert.ToDateTime(Reader["StartDate"]);
                    EndDate = Convert.ToDateTime(Reader["EndDate"]);
                    PrescriptionID = Convert.ToInt32(Reader["PrescriptionID"]);
                    Instructions = Convert.ToString(Reader["Instructions"]);
                    MedicationID = Convert.ToInt32(Reader["MedicationID"]);
                    PMStateID = Convert.ToInt32(Reader["PMStateID"]);

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

        static public bool UpdatePrescripedMedicationInfo(int PrescriptionMedID,  double Dosage,  DateTime StartDate,  DateTime EndDate,
            int PrescriptionID,  string Instructions,  int MedicationID,  int PMStateID)
        {
            bool Updated = false;
            if (!IsExist(PrescriptionMedID))
                return Updated;
            SqlConnection connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"UPDATE PrescripedMedications
                           SET Dosage = @Dosage
                           ,StartDate =@StartDate
                           ,EndDate =@EndDate
                           ,PrescriptionID =@PrescriptionID
                           ,Instructions =@Instructions
                           ,MedicationID =@MedicationID
                           ,PMStateID =@PMStateID

                           WHERE PrescriptionMedID=@PrescriptionMedID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PrescriptionMedID", PrescriptionMedID);
            command.Parameters.AddWithValue("@Dosage", Dosage);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
            command.Parameters.AddWithValue("@Instructions", Instructions);
            command.Parameters.AddWithValue("@MedicationID", MedicationID);
            command.Parameters.AddWithValue("@PMStateID", PMStateID);

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
        static public bool IsExist(int PrescriptionMedID)
        {

            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool IsFound = false;
            string Query = @"SELECT Found=1
  FROM PrescripedMedications
where PrescriptionMedID=@PrescriptionMedID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PrescriptionMedID", PrescriptionMedID);

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

        static public bool DeletePrescripedMedication(int PrescriptionMedID)
        {
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            bool Deleteed = false;
            if (!IsExist(PrescriptionMedID))
                return Deleteed;
            string Querey = @"DELETE FROM PrescripedMedications
                            WHERE PrescriptionMedID=@PrescriptionMedID";
            SqlCommand command = new SqlCommand(Querey, Connection);
            command.Parameters.AddWithValue("@PrescriptionMedID", PrescriptionMedID);
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



        static public DataTable GetAllPrescripedMedications()
        {
            DataTable dtPrescripedMedications = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT PrescripedMedications.PrescriptionMedID, PrescripedMedications.Dosage, PrescripedMedications.StartDate, PrescripedMedications.EndDate, PrescripedMedications.Instructions, PrescripedMedications.MedicationID, 
                  Medications.MedicationName, Medications.Price, Prescriptions.PrescriptionID, PrescripedMedState.State
FROM     PrescripedMedications INNER JOIN
                  PrescripedMedState ON PrescripedMedications.PMStateID = PrescripedMedState.ID INNER JOIN
                  Prescriptions ON PrescripedMedications.PrescriptionID = Prescriptions.PrescriptionID INNER JOIN
                  Medications ON PrescripedMedications.MedicationID = Medications.MedicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPrescripedMedications.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPrescripedMedications;











        }
        static public DataTable GetAllPrescripedMedicationsForPrescription(int PrescriptionID)
        {
            DataTable dtPrescripedMedications = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataConnection.ConnectionString);
            string Query = @"SELECT PrescripedMedications.PrescriptionMedID, PrescripedMedications.Dosage, PrescripedMedications.StartDate, PrescripedMedications.EndDate, PrescripedMedications.Instructions, PrescripedMedications.MedicationID, 
                  Medications.MedicationName, Medications.Price, Prescriptions.PrescriptionID, PrescripedMedState.State
FROM     PrescripedMedications INNER JOIN
                  PrescripedMedState ON PrescripedMedications.PMStateID = PrescripedMedState.ID left JOIN
                  Prescriptions ON PrescripedMedications.PrescriptionID = Prescriptions.PrescriptionID INNER JOIN
                  Medications ON PrescripedMedications.MedicationID = Medications.MedicationID
				  where Prescriptions.PrescriptionID=@PrescriptionID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dtPrescripedMedications.Load(Reader);
                }
                Reader.Close();



            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return dtPrescripedMedications;











        }

    }
}
