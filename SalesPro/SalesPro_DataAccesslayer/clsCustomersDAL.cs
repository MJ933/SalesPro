using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsCustomersDAL
    {
        // Get a customer by CustomerID
        public static bool GetCustomerByID(int CustomerID, ref int PersonID /*, ref ... other fields */)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            // ... retrieve other fields from the reader
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving customer: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all customers
        public static DataTable GetAllCustomers()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM Customers";

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
                    Console.WriteLine("Error retrieving customers: " + ex.Message);
                }
            }

            return dataTable1;
        }
        public static DataTable GetAllCustomersNames()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select PersonName from People p
                                inner join Customers c
                                on c.PersonID = p.PersonID";

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
                    Console.WriteLine("Error retrieving customers: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Check if a customer exists by name
        public static bool CustomerExists(string customerName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM People p 
                    INNER JOIN Customers c ON p.PersonID = c.PersonID 
                    WHERE p.PersonName = @CustomerName";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerName", customerName);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking customer existence: " + ex.Message);
                    return false;
                }
            }
        }


        // Get all customers with PersonName, Address, Phone1, Phone2, Phone3, Phone4, Email, notes
        public static DataTable GetAllCustomersWithDetails()
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    select c.CustomerID, PersonName, Address, Phone1, Phone2, Phone3, phone4,
                    Email, notes 
                    from People p 
                    inner join Customers c on p.PersonID = c.PersonID";

                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving customers with details: " + ex.Message);
                }
            }

            return dataTable;
        }
        // Get a customer by their name (similar to GetCustomerByID)
        public static bool GetCustomerByName(string customerName, ref int customerID, ref int personID,
                                             ref string address, ref string phone1, ref string phone2,
                                             ref string phone3, ref string phone4, ref string email,
                                             ref string notes)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT c.CustomerID, c.PersonID, p.Address, p.Phone1, p.Phone2, p.Phone3, p.phone4,
                           p.Email, p.notes 
                    FROM People p 
                    INNER JOIN Customers c ON p.PersonID = c.PersonID
                    WHERE p.PersonName = @CustomerName";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerName", customerName);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            customerID = Convert.ToInt32(reader["CustomerID"]);
                            personID = Convert.ToInt32(reader["PersonID"]);
                            address = reader["Address"]?.ToString();
                            phone1 = reader["Phone1"]?.ToString();
                            phone2 = reader["Phone2"]?.ToString();
                            phone3 = reader["Phone3"]?.ToString();
                            phone4 = reader["phone4"]?.ToString();
                            email = reader["Email"]?.ToString();
                            notes = reader["notes"]?.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving customer by name: " + ex.Message);
                }
            }

            return isFound;
        }


        // ... (Other methods)



        // Add a new customer
        public static int AddNewCustomer(int PersonID /*, ... other fields */)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Customers (PersonID /*, ... other fields */)
                VALUES (@PersonID /*, ... other field values */);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                // ... add parameters for other fields

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
                    Console.WriteLine("Error adding new customer: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing customer
        public static bool UpdateCustomer(int CustomerID, int PersonID /*, ... other fields */)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Customers SET
                    PersonID = @PersonID /*, ... other fields = @otherFieldValues */
                WHERE CustomerID = @CustomerID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                // ... add parameters for other fields

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating customer: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a customer
        public static bool DeleteCustomer(int CustomerID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", CustomerID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting customer: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }


        public static DataTable GetAllCustomerIDsAsDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CustomerID", typeof(int));

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT CustomerID FROM Customers";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow newRow = dataTable.NewRow();
                            newRow["CustomerID"] = reader.GetInt32(0);
                            dataTable.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving customer IDs: " + ex.Message);
                }
            }

            return dataTable;
        }
    }
}