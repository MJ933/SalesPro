using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsSuppliersBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int SupplierID { get; set; }
        public int PersonID { get; set; }

        public clsPeopleBL PersonInfo { get; set; }
        // ... other supplier-specific properties

        public clsSuppliersBL()
        {
            this.SupplierID = -1;
            this.PersonID = -1;
            // ... initialize other properties
            this.Mode = enMode.AddNew;
        }

        private clsSuppliersBL(int supplierID, int personID /*, ... other fields */)
        {
            this.SupplierID = supplierID;
            this.PersonID = personID;
            this.PersonInfo = clsPeopleBL.FindPersonByID(personID);
            // ... assign values to other properties
            this.Mode = enMode.Update;
        }

        // Find a supplier by SupplierID
        public static clsSuppliersBL FindSupplierByID(int SupplierID)
        {
            int personID = -1;
            // ... declare variables for other fields

            if (clsSuppliersDAL.GetSupplierByID(SupplierID, ref personID /*, ref ... other fields */))
            {
                return new clsSuppliersBL(SupplierID, personID /*, ... other field values */);
            }
            else
            {
                return null;
            }
        }

        // Find a supplier by Name
        public static clsSuppliersBL FindSupplierByName(string SupplierName)
        {
            int? SupplierID = clsSuppliersDAL.GetSupplierIDByName(SupplierName);

            if (SupplierID != null)
            {
                return FindSupplierByID(SupplierID.Value);
            }
            else
            {
                return null;
            }
        }


        // Add a new supplier
        private bool _AddNewSupplier()
        {
            this.SupplierID = clsSuppliersDAL.AddNewSupplier(this.PersonID /*, ... other field values */);
            return this.SupplierID != -1;
        }

        // Update an existing supplier
        private bool _UpdateSupplier()
        {
            return clsSuppliersDAL.UpdateSupplier(this.SupplierID, this.PersonID /*, ... other field values */);
        }

        // Save (add or update) the supplier
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewSupplier())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateSupplier();
                default:
                    return false;
            }
        }

        // Get all suppliers
        public static DataTable GetAllSuppliers()
        {
            return clsSuppliersDAL.GetAllSuppliers();
        }

        // Get all suppliers names 
        public static DataTable GetAllSuppliersNames()
        {
            return clsSuppliersDAL.GetSuppliersNames();
        }

        // Delete a supplier
        public static bool DeleteSupplier(int SupplierID)
        {
            return clsSuppliersDAL.DeleteSupplier(SupplierID);
        }

        // Check if Supplier Exists by Name
        public static bool SupplierExistsByName(string SupplierName)
        {
            return clsSuppliersDAL.SupplierExistsByName(SupplierName);
        }

        // Check if Supplier Exists by ID
        public static bool SupplierExistsByID(int SupplierID)
        {
            return clsSuppliersDAL.SupplierExistsByID(SupplierID);
        }
    }
}