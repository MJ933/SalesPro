using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsPaymentStatusesDAL
    {
        // Get a payment status by PaymentStatusID
        public static bool GetPaymentStatusByID(int PaymentStatusID, ref string StatusName, ref string StatusDescription)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM PaymentStatuses WHERE PaymentStatusID = @PaymentStatusID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);
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
                    Console.WriteLine("Error retrieving payment status: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all payment statuses
        public static DataTable GetAllPaymentStatuses()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM PaymentStatuses";

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
                    Console.WriteLine("Error retrieving payment statuses: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new payment status
        public static int AddNewPaymentStatus(string StatusName, string StatusDescription)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO PaymentStatuses (StatusName, StatusDescription)
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
                    Console.WriteLine("Error adding new payment status: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing payment status
        public static bool UpdatePaymentStatus(int PaymentStatusID, string StatusName, string StatusDescription)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE PaymentStatuses SET
                    StatusName = @StatusName,
                    StatusDescription = @StatusDescription
                WHERE PaymentStatusID = @PaymentStatusID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);
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
                    Console.WriteLine("Error updating payment status: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a payment status
        public static bool DeletePaymentStatus(int PaymentStatusID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM PaymentStatuses WHERE PaymentStatusID = @PaymentStatusID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentStatusID", PaymentStatusID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting payment status: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }
    }
}