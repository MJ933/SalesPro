using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsInstallmentStatusDAL
    {
        // Get an installment status by StatusID
        public static bool GetInstallmentStatusByID(int StatusID, ref string StatusName, ref string StatusDescription)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InstallmentStatus WHERE StatusID = @StatusID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@StatusID", StatusID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            StatusName = reader["StatusName"].ToString();
                            StatusDescription = reader["StatusDescription"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving installment status: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all installment statuses
        public static DataTable GetAllInstallmentStatuses()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM InstallmentStatus";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable1.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving installment statuses: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new installment status
        public static int AddNewInstallmentStatus(string StatusName, string StatusDescription)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO InstallmentStatus (StatusName, StatusDescription)
                VALUES (@StatusName, @StatusDescription);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@StatusName", StatusName);
                command.Parameters.AddWithValue("@StatusDescription", StatusDescription);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        return InsertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error adding new installment status: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing installment status
        public static bool UpdateInstallmentStatus(int StatusID, string StatusName, string StatusDescription)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE InstallmentStatus SET
                    StatusName = @StatusName,
                    StatusDescription = @StatusDescription
                WHERE StatusID = @StatusID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@StatusID", StatusID);
                command.Parameters.AddWithValue("@StatusName", StatusName);
                command.Parameters.AddWithValue("@StatusDescription", StatusDescription);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating installment status: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete an installment status
        public static bool DeleteInstallmentStatus(int StatusID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM InstallmentStatus WHERE StatusID = @StatusID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@StatusID", StatusID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting installment status: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }
    }
}