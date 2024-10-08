// clsUsersBL.cs
using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsUsersBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } // Add IsActive property

        public clsPeopleBL PersonInfo { get; set; }

        public clsUsersBL()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = true; // Default to active
            this.Mode = enMode.AddNew;
        }

        private clsUsersBL(int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.PersonInfo = clsPeopleBL.FindPersonByID(personID);
            this.Mode = enMode.Update;
        }


        // Find a user by UserID
        public static clsUsersBL FindUserByID(int UserID)
        {
            int personID = -1;
            string userName = string.Empty;
            string password = string.Empty;
            bool isActive = false;

            if (clsUsersDAL.GetUserByID(UserID, ref personID, ref userName, ref password, ref isActive))
            {
                return new clsUsersBL(UserID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        // Find a user by UserName
        public static clsUsersBL FindUserByUserName(string userName)
        {
            int userID = -1;
            int personID = -1;
            string password = string.Empty;
            bool isActive = false;

            if (clsUsersDAL.GetUserByUserName(userName, ref userID, ref personID, ref password, ref isActive))
            {
                return new clsUsersBL(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        // Find a user by PersonName
        public static clsUsersBL FindUserByPersonName(string personName)
        {
            int userID = -1;
            int personID = -1;
            string userName = string.Empty;
            string password = string.Empty;
            bool isActive = false;

            if (clsUsersDAL.GetUserByPersonName(personName, ref userID, ref personID, ref userName, ref password, ref isActive))
            {
                return new clsUsersBL(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        // Find a user by PersonID
        public static clsUsersBL FindUserByPersonID(int personID)
        {
            int userID = -1;
            string userName = string.Empty;
            string password = string.Empty;
            bool isActive = false;

            if (clsUsersDAL.GetUserByPersonID(personID, ref userID, ref userName, ref password, ref isActive))
            {
                return new clsUsersBL(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        // Check if a user with the given username exists
        public static bool CheckUserName(string UserName)
        {
            return clsUsersDAL.CheckUserName(UserName);
        }

        // Add a new user
        private bool _AddNewUser()
        {
            this.UserID = clsUsersDAL.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return this.UserID != -1;
        }

        // Update an existing user
        private bool _UpdateUser()
        {
            return clsUsersDAL.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        // Save (add or update) the user
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewUser())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateUser();
                default:
                    return false;
            }
        }

        // Get all users
        public static DataTable GetAllUsers()
        {
            return clsUsersDAL.GetAllUsers();
        }

        // Delete a user
        public static bool DeleteUser(int UserID)
        {
            return clsUsersDAL.DeleteUser(UserID);
        }


        // ... existing code in clsUsersBL.cs ...

        public static clsUsersBL FindUserByUserNameAndPassword(string userName, string password)
        {
            int userID = -1;
            int personID = -1;
            bool isActive = false;

            if (clsUsersDAL.GetUserInfoByUsernameAndPassword(userName, password, ref userID, ref personID, ref isActive))
            {
                return new clsUsersBL(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        // ... rest of the clsUsersBL.cs code ...
    }
}