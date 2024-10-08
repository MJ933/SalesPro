using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsInstallmentPaymentsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PaymentID { get; set; }
        public int InstallmentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public int UserID { get; set; }
        public string PaymentNotes { get; set; }
        public int PaymentStatusID { get; set; }

        public clsUsersBL UserInfo { get; set; }
        public clsInstallmentsBL InstallmentsInfo { get; set; }
        public clsInstallmentPaymentsBL()
        {
            this.PaymentID = -1;
            this.InstallmentID = -1;
            this.PaymentDate = DateTime.Now;
            this.PaymentAmount = 0;
            this.PaymentType = string.Empty;
            this.UserID = -1;
            this.PaymentNotes = string.Empty;
            this.PaymentStatusID = 1; // Default Payment Status
            this.Mode = enMode.AddNew;
        }

        private clsInstallmentPaymentsBL(int paymentID, int installmentID, DateTime paymentDate, double paymentAmount,
            string paymentType, int userID, string paymentNotes, int paymentStatusID)
        {
            this.PaymentID = paymentID;
            this.InstallmentID = installmentID;
            this.PaymentDate = paymentDate;
            this.PaymentAmount = paymentAmount;
            this.PaymentType = paymentType;
            this.UserID = userID;
            this.PaymentNotes = paymentNotes;
            this.PaymentStatusID = paymentStatusID;
            this.UserInfo = clsUsersBL.FindUserByID(userID);
            this.InstallmentsInfo = clsInstallmentsBL.FindInstallmentByID(installmentID);
            this.Mode = enMode.Update;
        }


        // Find an installment payment by PaymentID
        public static clsInstallmentPaymentsBL FindInstallmentPaymentByPaymentID(int PaymentID)
        {
            int installmentID = -1;
            DateTime paymentDate = DateTime.Now;
            double paymentAmount = 0;
            string paymentType = string.Empty;
            int userID = -1;
            string paymentNotes = string.Empty;
            int paymentStatusID = 1; // Default Payment Status

            if (clsInstallmentPaymentsDAL.GetInstallmentPaymentByPaymentID(PaymentID, ref installmentID, ref paymentDate,
                ref paymentAmount, ref paymentType, ref userID, ref paymentNotes, ref paymentStatusID))
            {
                return new clsInstallmentPaymentsBL(PaymentID, installmentID, paymentDate, paymentAmount,
                    paymentType, userID, paymentNotes, paymentStatusID);
            }
            else
            {
                return null;
            }
        }


        public static clsInstallmentPaymentsBL FindInstallmentPaymentByInstallmentID(int installmentID)
        {
            int PaymentID = -1;
            DateTime paymentDate = DateTime.Now;
            double paymentAmount = 0;
            string paymentType = string.Empty;
            int userID = -1;
            string paymentNotes = string.Empty;
            int paymentStatusID = 1; // Default Payment Status

            if (clsInstallmentPaymentsDAL.GetInstallmentPaymentByInstallmentID(ref PaymentID, installmentID, ref paymentDate,
                ref paymentAmount, ref paymentType, ref userID, ref paymentNotes, ref paymentStatusID))
            {
                return new clsInstallmentPaymentsBL(PaymentID, installmentID, paymentDate, paymentAmount,
                    paymentType, userID, paymentNotes, paymentStatusID);
            }
            else
            {
                return null;
            }
        }

        // Add a new installment payment
        private bool _AddNewInstallmentPayment()
        {
            this.PaymentID = clsInstallmentPaymentsDAL.AddNewInstallmentPayment(this.InstallmentID, this.PaymentDate,
                this.PaymentAmount, this.PaymentType, this.UserID, this.PaymentNotes, this.PaymentStatusID);
            return this.PaymentID != -1;
        }

        // Update an existing installment payment
        private bool _UpdateInstallmentPayment()
        {
            return clsInstallmentPaymentsDAL.UpdateInstallmentPayment(this.PaymentID, this.InstallmentID, this.PaymentDate,
                this.PaymentAmount, this.PaymentType, this.UserID, this.PaymentNotes, this.PaymentStatusID);
        }

        // Save (add or update) the installment payment
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewInstallmentPayment())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateInstallmentPayment();
                default:
                    return false;
            }
        }

        // Get all installment payments
        public static DataTable GetAllInstallmentPayments()
        {
            return clsInstallmentPaymentsDAL.GetAllInstallmentPayments();
        }

        // Delete an installment payment
        public static bool DeleteInstallmentPayment(int PaymentID)
        {
            return clsInstallmentPaymentsDAL.DeleteInstallmentPayment(PaymentID);
        }
    }
}