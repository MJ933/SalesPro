using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsSalesInvoiceItemsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int SalesInvoiceItemID { get; set; }
        public int SalesInvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int UserID { get; set; }

        public clsSalesInvoicesBL salesInvoicesInfo { get; set; }

        public clsProductsBL productsInfo { get; set; }
        public clsUsersBL UserInfo { get; set; }

        public clsSalesInvoiceItemsBL()
        {
            this.SalesInvoiceItemID = -1;
            this.SalesInvoiceID = -1;
            this.ProductID = -1;
            this.Quantity = 0;
            this.UnitPrice = 0;
            this.UserID = -1;
            this.Mode = enMode.AddNew;
        }

        private clsSalesInvoiceItemsBL(int salesInvoiceItemID, int salesInvoiceID, int productID,
            int quantity, double unitPrice, int userID)
        {
            this.SalesInvoiceItemID = salesInvoiceItemID;
            this.SalesInvoiceID = salesInvoiceID;
            this.ProductID = productID;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.UserID = userID;
            this.salesInvoicesInfo = clsSalesInvoicesBL.FindSalesInvoiceByID(salesInvoiceID);
            this.productsInfo = clsProductsBL.FindProductByID(productID);
            this.UserInfo = clsUsersBL.FindUserByID(userID);
            this.Mode = enMode.Update;

        }


        // Find a sales invoice item by SalesInvoiceItemID
        public static clsSalesInvoiceItemsBL FindSalesInvoiceItemByItemID(int SalesInvoiceItemID)
        {
            int salesInvoiceID = -1;
            int productID = -1;
            int quantity = 0;
            double unitPrice = 0;
            int userID = -1;

            if (clsSalesInvoiceItemsDAL.GetSalesInvoiceItemBySalesInvoicesItemID(SalesInvoiceItemID, ref salesInvoiceID, ref productID,
                ref quantity, ref unitPrice, ref userID))
            {
                return new clsSalesInvoiceItemsBL(SalesInvoiceItemID, salesInvoiceID, productID,
                    quantity, unitPrice, userID);
            }
            else
            {
                return null;
            }
        }
        public static clsSalesInvoiceItemsBL FindSalesInvoiceItemByInvoiceID(int salesInvoiceID)
        {
            int SalesInvoiceItemID = -1;
            int productID = -1;
            int quantity = 0;
            double unitPrice = 0;
            int userID = -1;

            if (clsSalesInvoiceItemsDAL.GetSalesInvoiceItemBySaleInvoiceID(ref SalesInvoiceItemID, salesInvoiceID, ref productID,
                ref quantity, ref unitPrice, ref userID))
            {
                return new clsSalesInvoiceItemsBL(SalesInvoiceItemID, salesInvoiceID, productID,
                    quantity, unitPrice, userID);
            }
            else
            {
                return null;
            }
        }

        // Add a new sales invoice item
        private bool _AddNewSalesInvoiceItem()
        {
            this.SalesInvoiceItemID = clsSalesInvoiceItemsDAL.AddNewSalesInvoiceItem(this.SalesInvoiceID, this.ProductID,
                this.Quantity, this.UnitPrice, this.UserID);
            return this.SalesInvoiceItemID != -1;
        }

        // Update an existing sales invoice item
        private bool _UpdateSalesInvoiceItem()
        {
            return clsSalesInvoiceItemsDAL.UpdateSalesInvoiceItem(this.SalesInvoiceItemID, this.SalesInvoiceID, this.ProductID,
                this.Quantity, this.UnitPrice, this.UserID);
        }

        // Save (add or update) the sales invoice item
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewSalesInvoiceItem())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateSalesInvoiceItem();
                default:
                    return false;
            }
        }

        // Get all sales invoice items
        public static DataTable GetAllSalesInvoiceItems()
        {
            return clsSalesInvoiceItemsDAL.GetAllSalesInvoiceItems();
        }

        // Delete a sales invoice item
        public static bool DeleteSalesInvoiceItem(int SalesInvoiceItemID)
        {
            return clsSalesInvoiceItemsDAL.DeleteSalesInvoiceItem(SalesInvoiceItemID);
        }
        public static DataTable GetAllSalesInvoiceItemsByCustomerID(int CustomerID)
        {
            return clsSalesInvoiceItemsDAL.GetAllSalesInvoiceItemsByCustomerID(CustomerID);

        }



    }
}