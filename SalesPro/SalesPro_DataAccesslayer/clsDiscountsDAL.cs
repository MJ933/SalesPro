using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsDiscountsDAL
    {
        public static bool GetDiscountByID(int DiscountID, ref int SalesInvoiceID, ref string DiscountType, ref double DiscountValue, ref int CreatedBy, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Discounts WHERE DiscountID = @DiscountID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@DiscountID", DiscountID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            SalesInvoiceID = Convert.ToInt32(reader["SalesInvoiceID"]);
                            DiscountType = reader["DiscountType"].ToString();
                            DiscountValue = Convert.ToDouble(reader["DiscountValue"]);
                            CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving discount: " + ex.Message);
                }
            }
            return IsFound;
        }

        public static bool GetDiscountBySalesInvoiceID(int SalesInvoiceID, ref int DiscountID, ref string DiscountType, ref double DiscountValue, ref int CreatedBy, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Discounts WHERE SalesInvoiceID = @SalesInvoiceID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            DiscountID = Convert.ToInt32(reader["DiscountID"]);
                            DiscountType = reader["DiscountType"].ToString();
                            DiscountValue = Convert.ToDouble(reader["DiscountValue"]);
                            CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving discount by sales invoice ID: " + ex.Message);
                }
            }
            return IsFound;
        }


        public static DataTable GetAllDiscounts()
        {
            DataTable dataTable1 = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Discounts";
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
                    Console.WriteLine("Error retrieving discounts: " + ex.Message);
                }
            }
            return dataTable1;
        }

        public static int AddNewDiscount(int SalesInvoiceID, string DiscountType, double DiscountValue, int CreatedBy)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Discounts (SalesInvoiceID, DiscountType, DiscountValue, CreatedBy)
                VALUES (@SalesInvoiceID, @DiscountType, @DiscountValue, @CreatedBy);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@DiscountType", DiscountType);
                command.Parameters.AddWithValue("@DiscountValue", DiscountValue);
                command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

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
                    Console.WriteLine("Error adding new discount: " + ex.Message);
                }
            }
            return -1;
        }

        public static bool UpdateDiscount(int DiscountID, int SalesInvoiceID, string DiscountType, double DiscountValue, int CreatedBy)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Discounts SET
                    SalesInvoiceID = @SalesInvoiceID,
                    DiscountType = @DiscountType,
                    DiscountValue = @DiscountValue,
                    CreatedBy = @CreatedBy
                WHERE DiscountID = @DiscountID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@DiscountID", DiscountID);
                command.Parameters.AddWithValue("@SalesInvoiceID", SalesInvoiceID);
                command.Parameters.AddWithValue("@DiscountType", DiscountType);
                command.Parameters.AddWithValue("@DiscountValue", DiscountValue);
                command.Parameters.AddWithValue("@CreatedBy", CreatedBy);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating discount: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        public static bool DeleteDiscount(int DiscountID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Discounts WHERE DiscountID = @DiscountID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@DiscountID", DiscountID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting discount: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }

        public static bool IsDiscountExist(int DiscountID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Discounts WHERE DiscountID = @DiscountID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@DiscountID", DiscountID);
                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking discount existence: " + ex.Message);
                    return false;
                }
            }
        }
    }
}