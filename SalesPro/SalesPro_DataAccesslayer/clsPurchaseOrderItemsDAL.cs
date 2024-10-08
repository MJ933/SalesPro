using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsPurchaseOrderItemsDAL
    {
        // Get a purchase order item by PurchaseOrderItemID
        public static bool GetPurchaseOrderItemByID(int PurchaseOrderItemID, ref int PurchaseOrderID, ref int ProductID,
            ref int Quantity, ref double UnitPrice, ref int UserID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM PurchaseOrderItems WHERE PurchaseOrderItemID = @PurchaseOrderItemID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderItemID", PurchaseOrderItemID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PurchaseOrderID = Convert.ToInt32(reader["PurchaseOrderID"]);
                            ProductID = Convert.ToInt32(reader["ProductID"]);
                            Quantity = Convert.ToInt32(reader["Quantity"]);
                            UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                            UserID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving purchase order item: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all purchase order items
        public static DataTable GetAllPurchaseOrderItems()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM PurchaseOrderItems";

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
                    Console.WriteLine("Error retrieving purchase order items: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new purchase order item
        public static int AddNewPurchaseOrderItem(int PurchaseOrderID, int ProductID, int Quantity,
            double UnitPrice, int UserID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO PurchaseOrderItems (PurchaseOrderID, ProductID, Quantity, 
                                             UnitPrice, UserID)
                VALUES (@PurchaseOrderID, @ProductID, @Quantity, 
                        @UnitPrice, @UserID);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                command.Parameters.AddWithValue("@UserID", UserID);

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
                    Console.WriteLine("Error adding new purchase order item: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing purchase order item
        public static bool UpdatePurchaseOrderItem(int PurchaseOrderItemID, int PurchaseOrderID, int ProductID,
            int Quantity, double UnitPrice, int UserID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE PurchaseOrderItems SET
                    PurchaseOrderID = @PurchaseOrderID,
                    ProductID = @ProductID,
                    Quantity = @Quantity,
                    UnitPrice = @UnitPrice,
                    UserID = @UserID
                WHERE PurchaseOrderItemID = @PurchaseOrderItemID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderItemID", PurchaseOrderItemID);
                command.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                command.Parameters.AddWithValue("@ProductID", ProductID);
                command.Parameters.AddWithValue("@Quantity", Quantity);
                command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating purchase order item: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a purchase order item
        public static bool DeletePurchaseOrderItem(int PurchaseOrderItemID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM PurchaseOrderItems WHERE PurchaseOrderItemID = @PurchaseOrderItemID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderItemID", PurchaseOrderItemID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting purchase order item: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }
    }
}