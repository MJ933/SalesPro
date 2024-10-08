using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsInstallmentsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int InstallmentID { get; set; }
        public int SalesInvoiceID { get; set; }
        public int InstallmentNumber { get; set; }
        public double InstallmentAmount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int StatusID { get; set; }
        public int UserID { get; set; }
        public int? GuarantorID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public clsUsersBL UserInfo { get; set; }
        public clsGuarantorsBL GuarantorInfo { get; set; }

        public clsSalesInvoiceItemsBL SalesInvoiceItemsInfo { get; set; }

        public clsInstallmentsBL()
        {
            this.InstallmentID = -1;
            this.SalesInvoiceID = -1;
            this.InstallmentNumber = 0;
            this.InstallmentAmount = 0;
            this.DueDate = DateTime.Now;
            this.PaymentDate = null;
            this.StatusID = 0;
            this.UserID = -1;
            this.GuarantorID = null;
            this.Mode = enMode.AddNew;
            this.Quantity = 1;
            this.ProductID = -1;
        }

        private clsInstallmentsBL(int installmentID, int salesInvoiceID, int installmentNumber, double installmentAmount,
            DateTime dueDate, DateTime? paymentDate, int statusID, int userID, int? guarantorID, int quantity, int productID)
        {
            this.InstallmentID = installmentID;
            this.SalesInvoiceID = salesInvoiceID;
            this.InstallmentNumber = installmentNumber;
            this.InstallmentAmount = installmentAmount;
            this.DueDate = dueDate;
            this.PaymentDate = paymentDate;
            this.StatusID = statusID;
            this.UserID = userID;
            this.GuarantorID = guarantorID;
            this.UserInfo = clsUsersBL.FindUserByID(userID);
            this.GuarantorInfo = clsGuarantorsBL.FindGuarantorByID(Convert.ToInt16(guarantorID));
            this.SalesInvoiceItemsInfo = clsSalesInvoiceItemsBL.FindSalesInvoiceItemByInvoiceID(salesInvoiceID);
            this.Mode = enMode.Update;
            this.Quantity = quantity;
            this.ProductID = productID;
        }


        public static clsInstallmentsBL FindInstallmentByID(int InstallmentID)
        {
            int salesInvoiceID = -1;
            int installmentNumber = 0;
            double installmentAmount = 0;
            DateTime dueDate = DateTime.Now;
            DateTime? paymentDate = null;
            int statusID = 0;
            int userID = -1;
            int? guarantorID = null;
            int quantity = 1;
            int productID = -1;

            if (clsInstallmentsDAL.GetInstallmentByID(InstallmentID, ref salesInvoiceID, ref installmentNumber,
                ref installmentAmount, ref dueDate, ref paymentDate, ref statusID, ref userID, ref guarantorID, ref quantity, ref productID))
            {
                return new clsInstallmentsBL(InstallmentID, salesInvoiceID, installmentNumber, installmentAmount,
                    dueDate, paymentDate, statusID, userID, guarantorID, quantity, productID);
            }
            else
            {
                return null;
            }
        }
        public static clsInstallmentsBL FindInstallmentByInvoiceID(int salesInvoiceID)
        {
            int InstallmentID = -1;
            int installmentNumber = 0;
            double installmentAmount = 0;
            DateTime dueDate = DateTime.Now;
            DateTime? paymentDate = null;
            int statusID = 0;
            int userID = -1;
            int? guarantorID = null;
            int quantity = 1;
            int productID = -1;

            if (clsInstallmentsDAL.GetInstallmentByInvoiceID(ref InstallmentID, salesInvoiceID, ref installmentNumber,
                ref installmentAmount, ref dueDate, ref paymentDate, ref statusID, ref userID, ref guarantorID, ref quantity, ref productID))
            {
                return new clsInstallmentsBL(InstallmentID, salesInvoiceID, installmentNumber, installmentAmount,
                    dueDate, paymentDate, statusID, userID, guarantorID, quantity, productID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewInstallment()
        {
            this.InstallmentID = clsInstallmentsDAL.AddNewInstallment(this.SalesInvoiceID, this.InstallmentNumber,
                this.InstallmentAmount, this.DueDate, this.PaymentDate, this.StatusID, this.UserID, this.GuarantorID, this.Quantity, this.ProductID);
            return this.InstallmentID != -1;
        }


        private bool _UpdateInstallment()
        {
            return clsInstallmentsDAL.UpdateInstallment(this.InstallmentID, this.SalesInvoiceID, this.InstallmentNumber,
                this.InstallmentAmount, this.DueDate, this.PaymentDate, this.StatusID, this.UserID, this.GuarantorID, this.Quantity, this.ProductID);
        }


        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewInstallment())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateInstallment();
                default:
                    return false;
            }
        }


        public static DataTable GetAllInstallments()
        {
            return clsInstallmentsDAL.GetAllInstallments();
        }
        public static DataTable GetAllInstallmentsByIfPaidOrNot(bool IsPaid)
        {
            return clsInstallmentsDAL.GetAllInstallmentsByIfPaidOrNot(IsPaid);
        }

        public static DataTable GetAllInstallmentsByInvoiceId(int SalesInvoiceID)
        {
            return clsInstallmentsDAL.GetAllInstallmentsByInvoiceId(SalesInvoiceID);
        }
        public static bool DeleteInstallment(int InstallmentID)
        {
            return clsInstallmentsDAL.DeleteInstallment(InstallmentID);
        }

        public static int GetOutstandingBalanceByInvoiceID(int SalesInvoiceID)
        {
            return clsInstallmentsDAL.GetOutstandingBalanceByInvoiceID(SalesInvoiceID);
        }

        public static int GetTotalPaymentsByInvoiceID(int SalesInvoiceID)
        {
            return clsInstallmentsDAL.GetTotalPaymentsByInvoiceID(SalesInvoiceID);
        }
    }
}