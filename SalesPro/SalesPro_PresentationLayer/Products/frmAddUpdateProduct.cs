using SalesPro_BusinessLayer;
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
    public partial class frmAddUpdateProduct : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private string _Name;
        private int _ProductID;
        clsProductsBL _Product;

        public frmAddUpdateProduct()
        {
            InitializeComponent();
            lblTitle.Text = "Add Product";
            _Mode = enMode.AddNew;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            FillTheSuppliersNames();

        }
        public frmAddUpdateProduct(string name)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _Name = name;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            FillTheSuppliersNames();
        }
        public frmAddUpdateProduct(int product_id)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _ProductID = product_id;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            FillTheSuppliersNames();
        }


        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
                _Product = new clsProductsBL();
            lblProductID.Text = "[????]";
            txtName.Text = "";
            txtDescription.Text = "";
            txtPurshesPrice.Text = "";
            txtSellingPrice.Text = "";
            txtStockQuantity.Text = "";
            txtInstallmentPrice.Text = "";
        }

        private void _LoadData()
        {
            if (_Name != null)
                _Product = clsProductsBL.FindProductByID(_ProductID);
            else if (_ProductID != 0)
                _Product = clsProductsBL.FindProductByID(_ProductID);

            if (_Product == null)
            {
                MessageBox.Show($"Person Name = {_Name}, was NOT Found");
                return;
            }
            lblProductID.Text = _Product.ProductID.ToString();
            txtName.Text = _Product.ProductName;
            txtDescription.Text = _Product.ProductDescription;
            txtPurshesPrice.Text = _Product.PurchasePrice.ToString();
            txtSellingPrice.Text = _Product.SellingPrice.ToString();
            txtStockQuantity.Text = _Product.StockQuantity.ToString();
            txtInstallmentPrice.Text = _Product.InstallmentPrice.ToString();
            FillTheSuppliersNames();

        }
        private void FillTheSuppliersNames()
        {
            cbSuppliersNames.DataSource = null; // Clear existing data source
            DataTable dtSuppliers = clsSuppliersBL.GetAllSuppliersNames();
            cbSuppliersNames.DataSource = dtSuppliers; // Set the new data source
            cbSuppliersNames.DisplayMember = "PersonName"; // Column to display in ComboBox
            cbSuppliersNames.ValueMember = "SupplierID";
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void frmAddUpdateNewProduct_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_Mode == enMode.AddNew)
            {
                if (clsProductsBL.CheckProductName(txtName.Text))
                {
                    MessageBox.Show($"The Product with Name = {txtName} is Already added");
                    return;
                }
                _Product.DateAdded = DateTime.Now;

            }
            _Product.ProductName = txtName.Text;
            _Product.ProductDescription = txtDescription.Text; if (!string.IsNullOrEmpty(txtPurshesPrice.Text))
                _Product.PurchasePrice = Convert.ToInt16(txtPurshesPrice.Text);
            else
                _Product.PurchasePrice = 0;

            if (!string.IsNullOrEmpty(txtSellingPrice.Text))
                _Product.SellingPrice = Convert.ToInt16(txtSellingPrice.Text);
            else
                _Product.SellingPrice = 0;

            if (!string.IsNullOrEmpty(txtStockQuantity.Text))
                _Product.StockQuantity = Convert.ToInt16(txtStockQuantity.Text);
            else
                _Product.StockQuantity = 0;

            if (cbSuppliersNames.SelectedValue != null && !string.IsNullOrEmpty(cbSuppliersNames.SelectedValue.ToString()))
                _Product.SupplierID = Convert.ToInt16(cbSuppliersNames.SelectedValue);
            else
                MessageBox.Show("Please chose a supplier!");
            _Product.LastStatusDate = DateTime.Now;

            if (!string.IsNullOrEmpty(txtInstallmentPrice.Text))
                _Product.InstallmentPrice = Convert.ToInt16(txtInstallmentPrice.Text);
            else
                _Product.InstallmentPrice = 0;
            if (_Product.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("The Person has Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblProductID.Text = _Product.ProductID.ToString();
                DataBack?.Invoke(this, _Product.ProductID);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
