using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Discounts
{
    public partial class frmAddUpdateDiscounts : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private string _Name;


        private int _SalesInvoiceID;
        private clsSalesInvoicesBL _SalesInvoice;

        private int _DiscountID;
        private clsDiscountsBL _Discount;

        public frmAddUpdateDiscounts()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }
        public frmAddUpdateDiscounts(int sale_invoice_id)
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _SalesInvoiceID = sale_invoice_id;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        public frmAddUpdateDiscounts(int sale_invoice_id, bool update)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _SalesInvoiceID = sale_invoice_id;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
                _Discount = new clsDiscountsBL();
            lblInvoiceID.Text = "[????????]";
            cbDiscountTypes.SelectedIndex = 0;
            //cbUsers.SelectedIndex = 0;
            txtDiscountValue.Text = "";
            dtpDiscountDate.Value = DateTime.Now;

        }

        private void _LoadData()
        {
            if (_SalesInvoiceID != 0)
                _SalesInvoice = clsSalesInvoicesBL.FindSalesInvoiceByID(_SalesInvoiceID);
            if (_Mode == enMode.Update)
            {
                if (_SalesInvoiceID != 0)
                    _Discount = clsDiscountsBL.FindDiscountBySalesInvoiceID(_SalesInvoiceID);
                if (_Discount == null)
                {
                    MessageBox.Show($"Discount ID = {_DiscountID}, was NOT Found");
                    return;
                }
                cbDiscountTypes.SelectedValue = _Discount.DiscountType;
                txtDiscountValue.Text = _Discount.DiscountValue.ToString();
                dtpDiscountDate.Value = _Discount.CreatedDate;
            }
            if (_SalesInvoice == null)
            {
                MessageBox.Show($"Sale Invoice ID = {_SalesInvoiceID}, was NOT Found");
                return;
            }
            lblInvoiceID.Text = _SalesInvoice.SalesInvoiceID.ToString();

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
        private void frmAddUpdateDiscounts_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            //if (_Mode == enMode.Update)
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
            _Discount.SalesInvoiceID = _SalesInvoice.SalesInvoiceID;
            if (cbDiscountTypes.SelectedIndex == 0)
            {
                _Discount.DiscountType = "Fixed Amount";
            }
            else
                _Discount.DiscountType = "Percentage";

            //_Discount.DiscountType = cbDiscountTypes.ValueMember;
            _Discount.DiscountValue = Convert.ToInt32(txtDiscountValue.Text);
            _Discount.CreatedDate = DateTime.Now;
            _Discount.CreatedBy = clsGlobal.CurrentUser.UserID;
            if (_Discount.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("The Discount has Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _Discount.DiscountID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
