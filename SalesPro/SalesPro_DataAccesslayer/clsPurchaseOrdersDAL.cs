using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsPurchaseOrdersDAL
    {
        // Get a purchase order by PurchaseOrderID
        public static bool GetPurchaseOrderByID(int PurchaseOrderID, ref int SupplierID, ref DateTime PurchaseOrderDate,
            ref double PurchaseOrderTotal, ref string PurchaseOrderPaymentType, ref int UserID)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM PurchaseOrders WHERE PurchaseOrderID = @PurchaseOrderID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            SupplierID = Convert.ToInt32(reader["SupplierID"]);
                            PurchaseOrderDate = Convert.ToDateTime(reader["PurchaseOrderDate"]);
                            PurchaseOrderTotal = Convert.ToDouble(reader["PurchaseOrderTotal"]);
                            PurchaseOrderPaymentType = reader["PurchaseOrderPaymentType"].ToString();
                            UserID = Convert.ToInt32(reader["UserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving purchase order: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all purchase orders
        public static DataTable GetAllPurchaseOrders()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM PurchaseOrders";

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
                    Console.WriteLine("Error retrieving purchase orders: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new purchase order
        public static int AddNewPurchaseOrder(int SupplierID, DateTime PurchaseOrderDate, double PurchaseOrderTotal,
            string PurchaseOrderPaymentType, int UserID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO PurchaseOrders (SupplierID, PurchaseOrderDate, PurchaseOrderTotal, 
                                         PurchaseOrderPaymentType, UserID)
                VALUES (@SupplierID, @PurchaseOrderDate, @PurchaseOrderTotal, 
                        @PurchaseOrderPaymentType, @UserID);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", SupplierID);
                command.Parameters.AddWithValue("@PurchaseOrderDate", PurchaseOrderDate);
                command.Parameters.AddWithValue("@PurchaseOrderTotal", PurchaseOrderTotal);
                command.Parameters.AddWithValue("@PurchaseOrderPaymentType", PurchaseOrderPaymentType);
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
                    Console.WriteLine("Error adding new purchase order: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing purchase order
        public static bool UpdatePurchaseOrder(int PurchaseOrderID, int SupplierID, DateTime PurchaseOrderDate,
            double PurchaseOrderTotal, string PurchaseOrderPaymentType, int UserID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE PurchaseOrders SET
                    SupplierID = @SupplierID,
                    PurchaseOrderDate = @PurchaseOrderDate,
                    PurchaseOrderTotal = @PurchaseOrderTotal,
                    PurchaseOrderPaymentType = @PurchaseOrderPaymentType,
                    UserID = @UserID
                WHERE PurchaseOrderID = @PurchaseOrderID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                command.Parameters.AddWithValue("@SupplierID", SupplierID);
                command.Parameters.AddWithValue("@PurchaseOrderDate", PurchaseOrderDate);
                command.Parameters.AddWithValue("@PurchaseOrderTotal", PurchaseOrderTotal);
                command.Parameters.AddWithValue("@PurchaseOrderPaymentType", PurchaseOrderPaymentType);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating purchase order: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a purchase order
        public static bool DeletePurchaseOrder(int PurchaseOrderID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM PurchaseOrders WHERE PurchaseOrderID = @PurchaseOrderID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PurchaseOrderID", PurchaseOrderID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting purchase order: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }
    }
}