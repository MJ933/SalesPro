using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsCustomersBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public clsPeopleBL PersonInfo { get; set; }
        // ... other customer-specific properties

        public clsCustomersBL()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            // ... initialize other properties
            this.Mode = enMode.AddNew;
        }

        private clsCustomersBL(int customerID, int personID /*, ... other fields */)
        {
            this.CustomerID = customerID;
            this.PersonID = personID;
            this.PersonInfo = clsPeopleBL.FindPersonByID(personID);
            // ... assign values to other properties
            this.Mode = enMode.Update;
        }

        // Find a customer by CustomerID
        public static clsCustomersBL FindCustomerByID(int CustomerID)
        {
            int personID = -1;
            // ... declare variables for other fields

            if (clsCustomersDAL.GetCustomerByID(CustomerID, ref personID /*, ref ... other fields */))
            {
                return new clsCustomersBL(CustomerID, personID /*, ... other field values */);
            }
            else
            {
                return null;
            }
        }

        // Check if a customer exists by name
        public static bool CustomerExists(string customerName)
        {
            return clsCustomersDAL.CustomerExists(customerName);
        }


        // Get all customers with PersonName, Address, etc.
        public static DataTable GetAllCustomersWithDetails()
        {
            return clsCustomersDAL.GetAllCustomersWithDetails();
        }

        // Find a customer by their name (similar to FindCustomerByID)
        public static clsCustomersBL FindCustomerByName(string customerName)
        {
            int customerID = -1;
            int personID = -1;
            string address = "";
            string phone1 = "";
            string phone2 = "";
            string phone3 = "";
            string phone4 = "";
            string email = "";
            string notes = "";

            if (clsCustomersDAL.GetCustomerByName(customerName, ref customerID, ref personID,
                                                 ref address, ref phone1, ref phone2, ref phone3,
                                                 ref phone4, ref email, ref notes))
            {
                clsCustomersBL foundCustomer = new clsCustomersBL(customerID, personID);
                // Set other properties of foundCustomer if needed
                return foundCustomer;
            }
            else
            {
                return null;
            }
        }
        // Add a new customer
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomersDAL.AddNewCustomer(this.PersonID /*, ... other field values */);
            return this.CustomerID != -1;
        }

        // Update an existing customer
        private bool _UpdateCustomer()
        {
            return clsCustomersDAL.UpdateCustomer(this.CustomerID, this.PersonID /*, ... other field values */);
        }

        // Save (add or update) the customer
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewCustomer())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateCustomer();
                default:
                    return false;
            }
        }

        // Get all customers
        public static DataTable GetAllCustomers()
        {
            return clsCustomersDAL.GetAllCustomers();
        }

        // Delete a customer
        public static bool DeleteCustomer(int CustomerID)
        {
            return clsCustomersDAL.DeleteCustomer(CustomerID);
        }

        public static DataTable GetAllCustomerIDsAsDataTable()
        {
            return clsCustomersDAL.GetAllCustomerIDsAsDataTable();
        }

        public static DataTable GetAllCustomersNames()
        {
            return clsCustomersDAL.GetAllCustomersNames();
        }
    }
}