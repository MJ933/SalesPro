using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsSalesInvoicesBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int SalesInvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime SalesInvoiceDate { get; set; }
        public double SalesInvoiceTotal { get; set; }
        public int SalesInvoicePaymentType { get; set; }
        public int UserID { get; set; }
        public bool IsPaid { get; set; }
        public int InvoiceStatus { get; set; }
        public double SalesInvoiceTotalAfterDiscount { get; set; }


        public clsCustomersBL customersInfo { get; set; }
        public clsUsersBL userInfo { get; set; }


        public clsSalesInvoicesBL()
        {
            this.SalesInvoiceID = -1;
            this.CustomerID = -1;
            this.SalesInvoiceDate = DateTime.Now;
            this.SalesInvoiceTotal = 0;
            this.SalesInvoicePaymentType = 0;
            this.UserID = -1;
            this.IsPaid = false;
            this.InvoiceStatus = 1;
            this.SalesInvoiceTotalAfterDiscount = 0;
            this.Mode = enMode.AddNew;
        }

        private clsSalesInvoicesBL(int salesInvoiceID, int customerID, DateTime salesInvoiceDate,
            double salesInvoiceTotal, int salesInvoicePaymentType, int userID, bool isPaid, int invoiceStatus, double salesInvoiceTotalAfterDiscount)
        {
            this.SalesInvoiceID = salesInvoiceID;
            this.CustomerID = customerID;
            this.SalesInvoiceDate = salesInvoiceDate;
            this.SalesInvoiceTotal = salesInvoiceTotal;
            this.SalesInvoicePaymentType = salesInvoicePaymentType;
            this.UserID = userID;
            this.IsPaid = isPaid;
            this.InvoiceStatus = invoiceStatus;
            this.SalesInvoiceTotalAfterDiscount = salesInvoiceTotalAfterDiscount;
            this.customersInfo = clsCustomersBL.FindCustomerByID(customerID);
            this.userInfo = clsUsersBL.FindUserByID(userID);
            this.Mode = enMode.Update;
        }



        public static clsSalesInvoicesBL FindSalesInvoiceByID(int SalesInvoiceID)
        {
            int customerID = -1;
            DateTime salesInvoiceDate = DateTime.Now;
            double salesInvoiceTotal = 0;
            int salesInvoicePaymentType = 0;
            int userID = -1;
            bool isPaid = false;
            int invoiceStatus = 0;
            double salesInvoiceTotalAfterDiscount = 0;

            if (clsSalesInvoicesDAL.GetSalesInvoiceByID(SalesInvoiceID, ref customerID, ref salesInvoiceDate,
                ref salesInvoiceTotal, ref salesInvoicePaymentType, ref userID, ref isPaid, ref invoiceStatus, ref salesInvoiceTotalAfterDiscount))
            {
                return new clsSalesInvoicesBL(SalesInvoiceID, customerID, salesInvoiceDate,
                    salesInvoiceTotal, salesInvoicePaymentType, userID, isPaid, invoiceStatus, salesInvoiceTotalAfterDiscount);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewSalesInvoice()
        {
            this.SalesInvoiceID = clsSalesInvoicesDAL.AddNewSalesInvoice(this.CustomerID, this.SalesInvoiceDate,
                this.SalesInvoiceTotal, this.SalesInvoicePaymentType, this.UserID, this.IsPaid, this.InvoiceStatus, this.SalesInvoiceTotalAfterDiscount);
            return this.SalesInvoiceID != -1;
        }


        private bool _UpdateSalesInvoice()
        {
            return clsSalesInvoicesDAL.UpdateSalesInvoice(this.SalesInvoiceID, this.CustomerID, this.SalesInvoiceDate,
                this.SalesInvoiceTotal, this.SalesInvoicePaymentType, this.UserID, this.IsPaid, this.InvoiceStatus, this.SalesInvoiceTotalAfterDiscount);
        }


        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewSalesInvoice())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateSalesInvoice();
                default:
                    return false;
            }
        }


        public static DataTable GetAllSalesInvoices()
        {
            return clsSalesInvoicesDAL.GetAllSalesInvoices();
        }


        public static bool DeleteSalesInvoice(int SalesInvoiceID)
        {
            return clsSalesInvoicesDAL.DeleteSalesInvoice(SalesInvoiceID);
        }


        public static bool IsSalesInvoiceExist(int CustomerID)
        {
            return clsSalesInvoicesDAL.IsSalesInvoiceExist(CustomerID);
        }


        public static clsSalesInvoicesBL FindSalesInvoiceByCustomerID(int CustomerID)
        {
            int salesInvoiceID = -1;
            DateTime salesInvoiceDate = DateTime.Now;
            double salesInvoiceTotal = 0;
            int salesInvoicePaymentType = 0;
            int userID = -1;
            bool isPaid = false;
            int invoiceStatus = 0;
            double salesInvoiceTotalAfterDiscount = 0;

            if (clsSalesInvoicesDAL.GetSalesInvoiceByCustomerID(CustomerID, ref salesInvoiceID, ref salesInvoiceDate,
                ref salesInvoiceTotal, ref salesInvoicePaymentType, ref userID, ref isPaid, ref invoiceStatus, ref salesInvoiceTotalAfterDiscount))
            {
                return new clsSalesInvoicesBL(salesInvoiceID, CustomerID, salesInvoiceDate,
                    salesInvoiceTotal, salesInvoicePaymentType, userID, isPaid, invoiceStatus, salesInvoiceTotalAfterDiscount);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllSalesInvoicesWithDetails()
        {
            return clsSalesInvoicesDAL.GetAllSalesInvoicesWithDetails();
        }

        public static string GetPaidAsString(bool is_payed)
        {
            if (is_payed)
                return "Yes";
            else return "No";
        }
        public static string GetPaymentMethodAsString(int payment_method)
        {
            if (payment_method == 1)
                return "Cash";
            else return "Installments";
        }

        public static string GetInvoiceStatusAsString(int invoiceStatus)
        {
            switch (invoiceStatus)
            {
                case 1:
                    return "Active";
                case 2:
                    return "Retrieved";
                default:
                    return "Cancel";
            }
        }


        public static bool IsSalesInvoiceActive(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.IsSalesInvoiceActive(salesInvoiceID);
        }
        public static bool IsSalesInvoiceRetrieved(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.IsSalesInvoiceRetrieved(salesInvoiceID);
        }
        public static bool CancelSalesInvoice(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.CancelSalesInvoice(salesInvoiceID);
        }

        public static bool RetrieveSalesInvoice(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.RetrieveSalesInvoice(salesInvoiceID);
        }

        public static int GetInvoiceStatusAsNumber(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.GetInvoiceStatusAsNumber(salesInvoiceID);
        }


        public static bool UpdateIsPaidIfOutstandingBalanceIsZero(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.UpdateIsPaidIfOutstandingBalanceIsZero(salesInvoiceID);
        }


        public static bool IsSalesInvoicePaid(int salesInvoiceID)
        {
            return clsSalesInvoicesDAL.IsSalesInvoicePaid(salesInvoiceID);
        }

        public static bool UpdateSalesInvoiceTotalAfterDiscount(int salesInvoiceID, double newTotalAfterDiscount)
        {
            return clsSalesInvoicesDAL.UpdateSalesInvoiceTotalAfterDiscount(salesInvoiceID, newTotalAfterDiscount);
        }

    }
}