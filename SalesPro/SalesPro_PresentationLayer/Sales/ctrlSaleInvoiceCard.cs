using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.People;
using SalesPro_PresentationLayer.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Sales
{
    public partial class ctrlSaleInvoiceCard : UserControl
    {
        public delegate void DataBackEventHandler(object sender, int person_id);

        public event DataBackEventHandler DataBack;

        private int _SaleInvoiceID = -1;
        clsSalesInvoicesBL _SaleInvoice;
        private int _SaleInvoiceItemID = -1;
        clsSalesInvoiceItemsBL _SaleInvoiceItem;
        public int SalesInvoiceID { get { return _SaleInvoiceID; } }
        public clsSalesInvoicesBL SaleInvoice { get { return _SaleInvoice; } }


        public ctrlSaleInvoiceCard()
        {
            InitializeComponent();
        }

        public void LoadInfo(int sale_invoice_id, int sale_invoice_item_id)
        {
            _SaleInvoice = clsSalesInvoicesBL.FindSalesInvoiceByID(sale_invoice_id);
            _SaleInvoiceItem = clsSalesInvoiceItemsBL.FindSalesInvoiceItemByItemID(sale_invoice_item_id);

            if (_SaleInvoice == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with sale_invoice_id = " + sale_invoice_id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_SaleInvoiceItem == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Item with sale_invoice_item_id = " + sale_invoice_item_id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
            ctrlPersonCard1.LoadInfo(_SaleInvoice.customersInfo.PersonID);
        }

        private void _FillPersonInfo()
        {
            llShowProductInfo.Enabled = true;
            lblInvoiceID.Text = _SaleInvoice.SalesInvoiceID.ToString();
            txtCustomerName.Text = _SaleInvoice.customersInfo.PersonInfo.PersonName;
            txtInvoiceDate.Text = _SaleInvoice.SalesInvoiceDate.ToString();
            txtInvoiceTotal.Text = _SaleInvoice.SalesInvoiceTotal.ToString();
            txtSalesPerson.Text = _SaleInvoice.userInfo.PersonInfo.PersonName;
            lblPaid.Text = clsSalesInvoicesBL.GetPaidAsString(_SaleInvoice.IsPaid);
            lblPaymentMethod.Text = clsSalesInvoicesBL.GetPaymentMethodAsString(_SaleInvoice.SalesInvoicePaymentType);
            txtProductName.Text = _SaleInvoiceItem.productsInfo.ProductName;
            lblQuantity.Text = _SaleInvoiceItem.Quantity.ToString();
            lblUnitPrice.Text = _SaleInvoiceItem.UnitPrice.ToString();
            lblInvoiceStatus.Text = clsSalesInvoicesBL.GetInvoiceStatusAsString(_SaleInvoice.InvoiceStatus);
        }

        public void ResetPersonInfo()
        {
            _SaleInvoiceID = -1;
            lblInvoiceID.Text = "";
            txtCustomerName.Text = "";
            txtInvoiceDate.Text = "";
            txtInvoiceTotal.Text = "";
            txtSalesPerson.Text = "";
            lblPaid.Text = "";
            lblPaymentMethod.Text = "";
            txtProductName.Text = "";
            lblQuantity.Text = "";
            lblUnitPrice.Text = "";
            lblInvoiceStatus.Text = "";
        }
        private void ctrlSaleInvoiceCard_Load(object sender, EventArgs e)
        {

        }

        private void llShowProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_SaleInvoiceItem != null)
            {
                //frmAddUpdatePerson frm = new frmAddUpdatePerson(_Person.PersonID);
                //LoadInfo(_SaleInvoice.SalesInvoiceID, _SaleInvoiceItem.SalesInvoiceID);
                //frm.DataBack += frm_DataBack;
                //frm.ShowDialog();
                Form frm = new frmShowProductInfo(_SaleInvoiceItem.ProductID);
                frm.ShowDialog();
            }
            else MessageBox.Show("Please enter a valid ID or Name!");
        }
    }
}
