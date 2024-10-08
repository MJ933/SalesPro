using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsPurchaseOrderItemsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int PurchaseOrderItemID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int UserID { get; set; }

        clsPurchaseOrdersBL purchaseOrdersInfo { get; set; }

        clsProductsBL productsInfo { get; set; }
        clsUsersBL UserInfo { get; set; }

        public clsPurchaseOrderItemsBL()
        {
            this.PurchaseOrderItemID = -1;
            this.PurchaseOrderID = -1;
            this.ProductID = -1;
            this.Quantity = 0;
            this.UnitPrice = 0;
            this.UserID = -1;
            this.Mode = enMode.AddNew;
        }

        private clsPurchaseOrderItemsBL(int purchaseOrderItemID, int purchaseOrderID, int productID,
            int quantity, double unitPrice, int userID)
        {
            this.PurchaseOrderItemID = purchaseOrderItemID;
            this.PurchaseOrderID = purchaseOrderID;
            this.ProductID = productID;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
            this.UserID = userID;
            this.purchaseOrdersInfo = clsPurchaseOrdersBL.FindPurchaseOrderByID(purchaseOrderID);
            this.productsInfo = clsProductsBL.FindProductByID(productID);
            this.UserInfo = clsUsersBL.FindUserByID(userID);

            this.Mode = enMode.Update;
        }


        // Find a purchase order item by PurchaseOrderItemID
        public static clsPurchaseOrderItemsBL FindPurchaseOrderItemByID(int PurchaseOrderItemID)
        {
            int purchaseOrderID = -1;
            int productID = -1;
            int quantity = 0;
            double unitPrice = 0;
            int userID = -1;

            if (clsPurchaseOrderItemsDAL.GetPurchaseOrderItemByID(PurchaseOrderItemID, ref purchaseOrderID, ref productID,
                ref quantity, ref unitPrice, ref userID))
            {
                return new clsPurchaseOrderItemsBL(PurchaseOrderItemID, purchaseOrderID, productID,
                    quantity, unitPrice, userID);
            }
            else
            {
                return null;
            }
        }

        // Add a new purchase order item
        private bool _AddNewPurchaseOrderItem()
        {
            this.PurchaseOrderItemID = clsPurchaseOrderItemsDAL.AddNewPurchaseOrderItem(this.PurchaseOrderID, this.ProductID,
                this.Quantity, this.UnitPrice, this.UserID);
            return this.PurchaseOrderItemID != -1;
        }

        // Update an existing purchase order item
        private bool _UpdatePurchaseOrderItem()
        {
            return clsPurchaseOrderItemsDAL.UpdatePurchaseOrderItem(this.PurchaseOrderItemID, this.PurchaseOrderID, this.ProductID,
                this.Quantity, this.UnitPrice, this.UserID);
        }

        // Save (add or update) the purchase order item
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewPurchaseOrderItem())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdatePurchaseOrderItem();
                default:
                    return false;
            }
        }

        // Get all purchase order items
        public static DataTable GetAllPurchaseOrderItems()
        {
            return clsPurchaseOrderItemsDAL.GetAllPurchaseOrderItems();
        }

        // Delete a purchase order item
        public static bool DeletePurchaseOrderItem(int PurchaseOrderItemID)
        {
            return clsPurchaseOrderItemsDAL.DeletePurchaseOrderItem(PurchaseOrderItemID);
        }
    }
}