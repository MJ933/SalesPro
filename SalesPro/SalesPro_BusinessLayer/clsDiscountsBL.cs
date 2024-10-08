using SalesPro_DataAccessLayer;
using System;
using System.Data;
using System.Data.SQLite;

namespace SalesPro_BusinessLayer
{
    public class clsDiscountsBL
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int DiscountID { get; set; }
        public int SalesInvoiceID { get; set; }
        public string DiscountType { get; set; }
        public double DiscountValue { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsSalesInvoicesBL SalesInvoiceInfo { get; set; }
        public clsUsersBL CreatedUserInfo { get; set; }

        public clsDiscountsBL()
        {
            this.DiscountID = -1;
            this.SalesInvoiceID = -1;
            this.DiscountType = "Percentage"; // Default discount type
            this.DiscountValue = 0;
            this.CreatedBy = -1;
            this.CreatedDate = DateTime.Now;
            this.Mode = enMode.AddNew;
        }

        private clsDiscountsBL(int discountID, int salesInvoiceID, string discountType, double discountValue, int createdBy, DateTime createdDate)
        {
            this.DiscountID = discountID;
            this.SalesInvoiceID = salesInvoiceID;
            this.DiscountType = discountType;
            this.DiscountValue = discountValue;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.SalesInvoiceInfo = clsSalesInvoicesBL.FindSalesInvoiceByID(salesInvoiceID);
            this.CreatedUserInfo = clsUsersBL.FindUserByID(createdBy);
            this.Mode = enMode.Update;
        }

        public static clsDiscountsBL FindDiscountByID(int discountID)
        {
            int salesInvoiceID = -1;
            string discountType = "";
            double discountValue = 0;
            int createdBy = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDiscountsDAL.GetDiscountByID(discountID, ref salesInvoiceID, ref discountType, ref discountValue, ref createdBy, ref createdDate))
            {
                return new clsDiscountsBL(discountID, salesInvoiceID, discountType, discountValue, createdBy, createdDate);
            }
            else
            {
                return null;
            }
        }

        public static clsDiscountsBL FindDiscountBySalesInvoiceID(int salesInvoiceID)
        {
            int discountID = -1;
            string discountType = "";
            double discountValue = 0;
            int createdBy = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDiscountsDAL.GetDiscountBySalesInvoiceID(salesInvoiceID, ref discountID, ref discountType, ref discountValue, ref createdBy, ref createdDate))
            {
                return new clsDiscountsBL(discountID, salesInvoiceID, discountType, discountValue, createdBy, createdDate);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewDiscount()
        {
            this.DiscountID = clsDiscountsDAL.AddNewDiscount(this.SalesInvoiceID, this.DiscountType, this.DiscountValue, this.CreatedBy);
            return this.DiscountID != -1;
        }

        private bool _UpdateDiscount()
        {
            return clsDiscountsDAL.UpdateDiscount(this.DiscountID, this.SalesInvoiceID, this.DiscountType, this.DiscountValue, this.CreatedBy);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (this._AddNewDiscount())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return this._UpdateDiscount();
                default:
                    return false;
            }
        }

        public static DataTable GetAllDiscounts()
        {
            return clsDiscountsDAL.GetAllDiscounts();
        }

        public static bool DeleteDiscount(int discountID)
        {
            return clsDiscountsDAL.DeleteDiscount(discountID);
        }

        public static bool IsDiscountExist(int discountID)
        {
            return clsDiscountsDAL.IsDiscountExist(discountID);
        }
    }
}