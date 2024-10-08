// clsUsersDAL.cs
using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_DataAccessLayer
{
    public class clsUsersDAL
    {
        // Get a user by UserID
        public static bool GetUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            UserName = reader["UserName"].ToString();
                            Password = reader["Password"].ToString();
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving user: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Check if a user with the given username exists
        public static bool CheckUserName(string UserName)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", UserName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error checking user name: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get all users
        public static DataTable GetAllUsers()
        {
            DataTable dataTable1 = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select u.UserID , PersonName, Address, Phone1,
                    Email
                    from People p 
                    inner join Users u on p.PersonID = u.PersonID";

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
                    Console.WriteLine("Error retrieving users: " + ex.Message);
                }
            }

            return dataTable1;
        }

        // Add a new user
        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                INSERT INTO Users (PersonID, UserName, Password, IsActive)
                VALUES (@PersonID, @UserName, @Password, @IsActive);
                SELECT last_insert_rowid();";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

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
                    Console.WriteLine("Error adding new user: " + ex.Message);
                }
            }
            return -1;
        }

        // Update an existing user
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE Users SET
                    PersonID = @PersonID,
                    UserName = @UserName,
                    Password = @Password,
                    IsActive = @IsActive
                WHERE UserID = @UserID;";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error updating user: " + ex.Message);
                    return false;
                }
            }
            return RowsAffected > 0;
        }

        // Delete a user
        public static bool DeleteUser(int UserID)
        {
            int RowsAffected = 0;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error deleting user: " + ex.Message);
                }
            }
            return RowsAffected > 0;
        }

        // Get a user by UserName
        public static bool GetUserByUserName(string UserName, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", UserName);
                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            UserID = Convert.ToInt32(reader["UserID"]);
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            Password = reader["Password"].ToString();
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving user by username: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get a user by PersonName
        public static bool GetUserByPersonName(string PersonName, ref int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT u.UserID, u.PersonID, u.UserName, u.Password, u.IsActive
                    FROM Users u
                    INNER JOIN People p ON u.PersonID = p.PersonID
                    WHERE p.PersonName = @PersonName";

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
                            UserID = Convert.ToInt32(reader["UserID"]);
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            UserName = reader["UserName"].ToString();
                            Password = reader["Password"].ToString();
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving user by person name: " + ex.Message);
                }
            }
            return IsFound;
        }

        // Get a user by PersonID
        public static bool GetUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE PersonID = @PersonID";
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
                            UserID = Convert.ToInt32(reader["UserID"]);
                            UserName = reader["UserName"].ToString();
                            Password = reader["Password"].ToString();
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving user by person ID: " + ex.Message);
                }
            }
            return IsFound;
        }

        // ... existing code in clsUsersDAL.cs ...

        public static bool GetUserInfoByUsernameAndPassword(string userName, string password, ref int userID, ref int personID, ref bool isActive)
        {
            bool isFound = false;

            using (SQLiteConnection connection = new SQLiteConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            userID = Convert.ToInt32(reader["UserID"]);
                            personID = Convert.ToInt32(reader["PersonID"]);
                            isActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception (optional)
                    Console.WriteLine("Error retrieving user info: " + ex.Message);
                }
            }

            return isFound;
        }

        // ... rest of the clsUsersDAL.cs code ...
    }
}
