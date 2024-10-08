using System;
using System.Data;
using System.Data.SQLite;


namespace SalesPro_DataAccessLayer
{
    public class clsPeopleDAL
    {
        // Get a person by PersonID
        public static bool GetPersonByID(int PersonID, ref string PersonName, ref string Address,
            ref string Phone1, ref string Phone2, ref string Phone3, ref string Phone4, ref string Email,
            ref string Notes)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM People WHERE PersonID = @PersonID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonName = reader["PersonName"].ToString();
                            Address = reader["Address"].ToString();
                            Phone1 = reader["Phone1"].ToString();
                            Phone2 = reader["Phone2"].ToString();
                            Phone3 = reader["Phone3"].ToString();
                            Phone4 = reader["Phone4"].ToString();
                            Email = reader["Email"].ToString();
                            Notes = reader["Notes"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving person: " + ex.Message);
                }
            }
            return IsFound;
        }
        public static bool GetPersonByName(ref int PersonID, string PersonName, ref string Address,
            ref string Phone1, ref string Phone2, ref string Phone3, ref string Phone4, ref string Email,
            ref string Notes)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM People WHERE PersonName = @PersonName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonName", PersonName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            if (reader["PersonID"] != DBNull.Value)
                            {
                                PersonID = Convert.ToInt32(reader["PersonID"]);
                            }
                            else
                            {
                                PersonID = -1; // Or any default value you want to use for null PersonID
                            }
                            Address = reader["Address"].ToString();
                            Phone1 = reader["Phone1"].ToString();
                            Phone2 = reader["Phone2"].ToString();
                            Phone3 = reader["Phone3"].ToString();
                            Phone4 = reader["Phone4"].ToString();
                            Email = reader["Email"].ToString();
                            Notes = reader["Notes"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving person: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Check if a person with the given name exists
        public static bool CheckPersonName(string PersonName)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM People WHERE PersonName = @PersonName LIMIT 1";  // Added LIMIT 1
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonName", PersonName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        IsFound = reader.Read(); // Just check if a row was read
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking person name: " + ex.Message);
                }
            }
            return IsFound;
        }
        // Get all people
        public static DataTable GetAllPeople()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select * from vw_PeopleInfo";

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
                    Console.WriteLine("Error retrieving people: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new person
        public static int AddNewPerson(string PersonName, string Address,
            string Phone1, string Phone2, string Phone3, string Phone4, string Email,
            string Notes)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO People (PersonName, Address, Phone1, Phone2, 
                                     Phone3, Phone4, Email, Notes)
                VALUES (@PersonName, @Address, @Phone1, @Phone2, 
                        @Phone3, @Phone4, @Email, @Notes);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonName", PersonName);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone1", Phone1);
                command.Parameters.AddWithValue("@Phone2", Phone2);
                command.Parameters.AddWithValue("@Phone3", Phone3);
                command.Parameters.AddWithValue("@Phone4", Phone4);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Notes", Notes);

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
                    Console.WriteLine("Error adding new person: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing person
        public static bool UpdatePerson(int PersonID, string PersonName, string Address,
            string Phone1, string Phone2, string Phone3, string Phone4, string Email,
            string Notes)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE People SET
                    PersonName = @PersonName,
                    Address = @Address,
                    Phone1 = @Phone1,
                    Phone2 = @Phone2,
                    Phone3 = @Phone3,
                    Phone4 = @Phone4,
                    Email = @Email,
                    Notes = @Notes
                WHERE PersonID = @PersonID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@PersonName", PersonName);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone1", Phone1);
                command.Parameters.AddWithValue("@Phone2", Phone2);
                command.Parameters.AddWithValue("@Phone3", Phone3);
                command.Parameters.AddWithValue("@Phone4", Phone4);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Notes", Notes);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating person: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a person
        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM People WHERE PersonID = @PersonID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting person: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }

        public static DataTable GetAllPeopleNames()
        {
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT PersonName FROM People";
                SQLiteCommand command = new SQLiteCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving people names: " + ex.Message);
                }
            }

            return dataTable;
        }
    }
}