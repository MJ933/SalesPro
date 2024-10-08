using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsPaymentStatusesBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PaymentStatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }

        public clsPaymentStatusesBL()
        {
            this.PaymentStatusID = -1;
            this.StatusName = string.Empty;
            this.StatusDescription = string.Empty;
            this.Mode = enMode.AddNew;
        }

        private clsPaymentStatusesBL(int paymentStatusID, string statusName, string statusDescription)
        {
            this.PaymentStatusID = paymentStatusID;
            this.StatusName = statusName;
            this.StatusDescription = statusDescription;
            this.Mode = enMode.Update;
        }


        // Find a payment status by PaymentStatusID
        public static clsPaymentStatusesBL FindPaymentStatusByID(int PaymentStatusID)
        {
            string statusName = string.Empty;
            string statusDescription = string.Empty;

            if (clsPaymentStatusesDAL.GetPaymentStatusByID(PaymentStatusID, ref statusName, ref statusDescription))
            {
                return new clsPaymentStatusesBL(PaymentStatusID, statusName, statusDescription);
            }
            else
            {
                return null;
            }
        }

        // Add a new payment status
        private bool _AddNewPaymentStatus()
        {
            this.PaymentStatusID = clsPaymentStatusesDAL.AddNewPaymentStatus(this.StatusName, this.StatusDescription);
            return this.PaymentStatusID != -1;
        }

        // Update an existing payment status
        private bool _UpdatePaymentStatus()
        {
            return clsPaymentStatusesDAL.UpdatePaymentStatus(this.PaymentStatusID, this.StatusName, this.StatusDescription);
        }

        // Save (add or update) the payment status
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewPaymentStatus())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdatePaymentStatus();
                default:
                    return false;
            }
        }

        // Get all payment statuses
        public static DataTable GetAllPaymentStatuses()
        {
            return clsPaymentStatusesDAL.GetAllPaymentStatuses();
        }

        // Delete a payment status
        public static bool DeletePaymentStatus(int PaymentStatusID)
        {
            return clsPaymentStatusesDAL.DeletePaymentStatus(PaymentStatusID);
        }
    }
}