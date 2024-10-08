using SalesPro_DataAccessLayer;
using System;
using System.Data;

namespace SalesPro_BusinessLayer
{
    public class clsProductsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? LastStatusDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public double? InstallmentPrice { get; set; }


        public clsSuppliersBL SuppliersInfo { get; set; }


        public clsProductsBL()
        {
            this.ProductID = -1;
            this.ProductName = string.Empty;
            this.ProductDescription = string.Empty;
            this.PurchasePrice = 0;
            this.SellingPrice = 0;
            this.StockQuantity = 0;
            this.SupplierID = null;
            this.LastStatusDate = DateTime.Now; // Set to current DateTime
            this.DateAdded = DateTime.Now; // Set to current DateTime
            this.InstallmentPrice = null;
            this.Mode = enMode.AddNew;
        }

        private clsProductsBL(int productID, string productName, string productDescription,
            double purchasePrice, double sellingPrice, int stockQuantity, int? supplierID,
            DateTime? lastStatusDate, DateTime? dateAdded, double? installmentPrice)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.PurchasePrice = purchasePrice;
            this.SellingPrice = sellingPrice;
            this.StockQuantity = stockQuantity;
            this.SupplierID = supplierID;
            this.LastStatusDate = lastStatusDate;
            this.DateAdded = dateAdded;
            this.InstallmentPrice = installmentPrice;
            this.SuppliersInfo = clsSuppliersBL.FindSupplierByID(Convert.ToInt16(supplierID));
            this.Mode = enMode.Update;
        }

        // Find a product by ProductID (Updated to include new columns)
        public static clsProductsBL FindProductByID(int ProductID)
        {
            string productName = string.Empty;

            string productDescription = string.Empty;
            double purchasePrice = 0;
            double sellingPrice = 0;
            int stockQuantity = 0;
            int? supplierID = null;
            DateTime? lastStatusDate = null;
            DateTime? dateAdded = null;
            double? installmentPrice = null;

            if (clsProductsDAL.GetProductByID(ProductID, ref productName, ref productDescription,
                ref purchasePrice, ref sellingPrice, ref stockQuantity, ref supplierID,
                ref lastStatusDate, ref dateAdded, ref installmentPrice))
            {
                return new clsProductsBL(ProductID, productName, productDescription,
                    purchasePrice, sellingPrice, stockQuantity, supplierID,
                    lastStatusDate, dateAdded, installmentPrice);
            }
            else
            {
                return null;
            }
        }
        // Find a product by ProductName (Updated to include new columns)
        public static clsProductsBL FindProductByName(string ProductName)
        {
            int ProductID = -1;
            string productDescription = string.Empty;
            double purchasePrice = 0;
            double sellingPrice = 0;
            int stockQuantity = 0;
            int? supplierID = null;
            DateTime? lastStatusDate = null;
            DateTime? dateAdded = null;
            double? installmentPrice = null;

            if (clsProductsDAL.GetProductByName(ProductName, ref ProductID, ref productDescription,
                ref purchasePrice, ref sellingPrice, ref stockQuantity, ref supplierID,
                ref lastStatusDate, ref dateAdded, ref installmentPrice))
            {
                return new clsProductsBL(ProductID, ProductName, productDescription,
                    purchasePrice, sellingPrice, stockQuantity, supplierID,
                    lastStatusDate, dateAdded, installmentPrice);
            }
            else
            {
                return null;
            }
        }
        // Check if product exists by ID
        public static bool ProductExistsByID(int ProductID)
        {
            return clsProductsDAL.ProductExistsByID(ProductID);
        }

        // Check if a product with the given name exists
        public static bool CheckProductName(string ProductName)
        {
            return clsProductsDAL.CheckProductName(ProductName);
        }

        // Add a new product
        private bool _AddNewProduct()
        {
            this.ProductID = clsProductsDAL.AddNewProduct(
                this.ProductName,
                this.ProductDescription,
                this.PurchasePrice,
                this.SellingPrice,
                this.StockQuantity,
                this.SupplierID,
                this.InstallmentPrice,
                this.LastStatusDate,
                this.DateAdded
            );
            return this.ProductID != -1;
        }

        // Update an existing product
        private bool _UpdateProduct()
        {
            return clsProductsDAL.UpdateProduct(
                this.ProductID,
                this.ProductName,
                this.ProductDescription,
                this.PurchasePrice,
                this.SellingPrice,
                this.StockQuantity,
                this.SupplierID,
                this.InstallmentPrice,
                this.LastStatusDate,
                this.DateAdded
            );
        }

        // Save (add or update) the product
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewProduct())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateProduct();
                default:
                    return false;
            }
        }

        // Get all products
        public static DataTable GetAllProducts()
        {
            return clsProductsDAL.GetAllProducts();
        }

        // Delete a product
        public static bool DeleteProduct(int ProductID)
        {
            return clsProductsDAL.DeleteProduct(ProductID);
        }

        public bool UpdateProductQuantity(int productId, int quantityTaken)
        {
            // Validate inputs if needed (e.g., productId > 0, quantityTaken >= 0)

            // Get the current quantity from the database
            clsProductsBL product = clsProductsBL.FindProductByID(productId);
            if (product == null)
            {
                // Product not found
                return false;
            }

            // Calculate the new quantity
            int newQuantity = product.StockQuantity - quantityTaken;

            // Check if the new quantity is valid (e.g., not negative)
            if (newQuantity < 0)
            {
                // Not enough stock available
                return false;
            }

            // Update the quantity in the database using clsProductsDAL
            return clsProductsDAL.UpdateProductQuantity(productId, newQuantity);
        }
        public static DataTable GetProductNames()
        {
            return clsProductsDAL.GetProductNames();
        }
    }
}