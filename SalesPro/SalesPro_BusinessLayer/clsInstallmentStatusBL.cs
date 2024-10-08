using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsInstallmentStatusBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }

        public clsInstallmentStatusBL()
        {
            this.StatusID = -1;
            this.StatusName = string.Empty;
            this.StatusDescription = string.Empty;
            this.Mode = enMode.AddNew;
        }

        private clsInstallmentStatusBL(int statusID, string statusName, string statusDescription)
        {
            this.StatusID = statusID;
            this.StatusName = statusName;
            this.StatusDescription = statusDescription;
            this.Mode = enMode.Update;
        }


        // Find an installment status by StatusID
        public static clsInstallmentStatusBL FindInstallmentStatusByID(int StatusID)
        {
            string statusName = string.Empty;
            string statusDescription = string.Empty;

            if (clsInstallmentStatusDAL.GetInstallmentStatusByID(StatusID, ref statusName, ref statusDescription))
            {
                return new clsInstallmentStatusBL(StatusID, statusName, statusDescription);
            }
            else
            {
                return null;
            }
        }

        // Add a new installment status
        private bool _AddNewInstallmentStatus()
        {
            this.StatusID = clsInstallmentStatusDAL.AddNewInstallmentStatus(this.StatusName, this.StatusDescription);
            return this.StatusID != -1;
        }

        // Update an existing installment status
        private bool _UpdateInstallmentStatus()
        {
            return clsInstallmentStatusDAL.UpdateInstallmentStatus(this.StatusID, this.StatusName, this.StatusDescription);
        }

        // Save (add or update) the installment status
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewInstallmentStatus())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateInstallmentStatus();
                default:
                    return false;
            }
        }

        // Get all installment statuses
        public static DataTable GetAllInstallmentStatuses()
        {
            return clsInstallmentStatusDAL.GetAllInstallmentStatuses();
        }

        // Delete an installment status
        public static bool DeleteInstallmentStatus(int StatusID)
        {
            return clsInstallmentStatusDAL.DeleteInstallmentStatus(StatusID);
        }
    }
}