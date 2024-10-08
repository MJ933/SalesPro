using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsPurchaseOrdersBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PurchaseOrderID { get; set; }
        public int SupplierID { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
        public double PurchaseOrderTotal { get; set; }
        public string PurchaseOrderPaymentType { get; set; }
        public int UserID { get; set; }


        clsSuppliersBL suppliersInfo { get; set; }
        clsUsersBL UserInfo { get; set; }


        public clsPurchaseOrdersBL()
        {
            this.PurchaseOrderID = -1;
            this.SupplierID = -1;
            this.PurchaseOrderDate = DateTime.Now;
            this.PurchaseOrderTotal = 0;
            this.PurchaseOrderPaymentType = string.Empty;
            this.UserID = -1;
            this.Mode = enMode.AddNew;
        }

        private clsPurchaseOrdersBL(int purchaseOrderID, int supplierID, DateTime purchaseOrderDate,
            double purchaseOrderTotal, string purchaseOrderPaymentType, int userID)
        {
            this.PurchaseOrderID = purchaseOrderID;
            this.SupplierID = supplierID;
            this.PurchaseOrderDate = purchaseOrderDate;
            this.PurchaseOrderTotal = purchaseOrderTotal;
            this.PurchaseOrderPaymentType = purchaseOrderPaymentType;
            this.UserID = userID;
            this.suppliersInfo = clsSuppliersBL.FindSupplierByID(supplierID);
            this.UserInfo = clsUsersBL.FindUserByID(userID);
            this.Mode = enMode.Update;
        }


        // Find a purchase order by PurchaseOrderID
        public static clsPurchaseOrdersBL FindPurchaseOrderByID(int PurchaseOrderID)
        {
            int supplierID = -1;
            DateTime purchaseOrderDate = DateTime.Now;
            double purchaseOrderTotal = 0;
            string purchaseOrderPaymentType = string.Empty;
            int userID = -1;

            if (clsPurchaseOrdersDAL.GetPurchaseOrderByID(PurchaseOrderID, ref supplierID, ref purchaseOrderDate,
                ref purchaseOrderTotal, ref purchaseOrderPaymentType, ref userID))
            {
                return new clsPurchaseOrdersBL(PurchaseOrderID, supplierID, purchaseOrderDate,
                    purchaseOrderTotal, purchaseOrderPaymentType, userID);
            }
            else
            {
                return null;
            }
        }

        // Add a new purchase order
        private bool _AddNewPurchaseOrder()
        {
            this.PurchaseOrderID = clsPurchaseOrdersDAL.AddNewPurchaseOrder(this.SupplierID, this.PurchaseOrderDate,
                this.PurchaseOrderTotal, this.PurchaseOrderPaymentType, this.UserID);
            return this.PurchaseOrderID != -1;
        }

        // Update an existing purchase order
        private bool _UpdatePurchaseOrder()
        {
            return clsPurchaseOrdersDAL.UpdatePurchaseOrder(this.PurchaseOrderID, this.SupplierID, this.PurchaseOrderDate,
                this.PurchaseOrderTotal, this.PurchaseOrderPaymentType, this.UserID);
        }

        // Save (add or update) the purchase order
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewPurchaseOrder())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdatePurchaseOrder();
                default:
                    return false;
            }
        }

        // Get all purchase orders
        public static DataTable GetAllPurchaseOrders()
        {
            return clsPurchaseOrdersDAL.GetAllPurchaseOrders();
        }

        // Delete a purchase order
        public static bool DeletePurchaseOrder(int PurchaseOrderID)
        {
            return clsPurchaseOrdersDAL.DeletePurchaseOrder(PurchaseOrderID);
        }
    }
}