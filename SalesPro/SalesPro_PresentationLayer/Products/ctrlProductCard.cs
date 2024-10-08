using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Products
{
    public partial class ctrlProductCard : UserControl
    {
        public delegate void DataBackEventHandler(object sender, int person_id);

        public event DataBackEventHandler DataBack;

        clsProductsBL _Product;
        private int _ProductID = -1;
        public int ProductID { get { return _ProductID; } }
        public clsProductsBL ProductInfo { get { return _Product; } }

        public ctrlProductCard()
        {
            InitializeComponent();
        }
        public void LoadInfo(int product_id)
        {
            _Product = clsProductsBL.FindProductByID(product_id);

            if (_Product == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with Product ID = " + product_id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadInfo(string product_name)
        {
            _Product = clsProductsBL.FindProductByName(product_name);

            if (_Product == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with Name = " + product_name.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            LLUpdateProductInfo.Enabled = true;
            lblProductID.Text = _Product.ProductID.ToString();
            txtName.Text = _Product.ProductName;
            txtDescription.Text = _Product.ProductDescription;
            txtPurshesPrice.Text = _Product.PurchasePrice.ToString();
            txtSellingPrice.Text = _Product.SellingPrice.ToString();
            txtStockQuantity.Text = _Product.StockQuantity.ToString();
            txtSupplierName.Text = _Product.SuppliersInfo.PersonInfo.PersonName;
            txtInstallmentPrice.Text = _Product.InstallmentPrice.ToString();
            lblDateAdded.Text = _Product.DateAdded.ToString();
            lblLastStatusDate.Text = _Product.LastStatusDate.ToString();
        }

        public void ResetPersonInfo()
        {
            _ProductID = -1;
            lblProductID.Text = "";
            txtDescription.Text = "";
            txtPurshesPrice.Text = "";
            txtSellingPrice.Text = "";
            txtStockQuantity.Text = "";
            txtSupplierName.Text = "";
            txtInstallmentPrice.Text = "";
            lblDateAdded.Text = "";
            lblLastStatusDate.Text = "";
        }

        private void LLUpdateProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Product != null)
            {
                frmAddUpdateProduct frm = new frmAddUpdateProduct(_Product.ProductID);
                LoadInfo(_Product.ProductID);
                frm.DataBack += frm_DataBack;
                frm.ShowDialog();
            }
            else MessageBox.Show("Please enter a valid ID or name!");
        }
        private void frm_DataBack(object sender, int product_id)
        {
            LoadInfo(product_id);
            DataBack?.Invoke(this, product_id);
        }

        private void txtStockQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
