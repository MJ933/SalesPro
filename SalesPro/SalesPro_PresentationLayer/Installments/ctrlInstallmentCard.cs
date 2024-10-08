using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Discounts;
using SalesPro_PresentationLayer.People;
using SalesPro_PresentationLayer.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SalesPro_PresentationLayer.Installments
{
    public partial class ctrlInstallmentCard : UserControl
    {
        public delegate void DataBackEventHandler(object sender);

        public event DataBackEventHandler DataBack;

        clsSalesInvoicesBL _SaleInvoice;
        private int _InvoiceID { get; set; }


        clsSalesInvoiceItemsBL _SaleInvoiceItem;
        private int _InvoiceItemID { get; set; }


        clsInstallmentsBL _Installment;
        private int _InstallmentID { get; set; }

        clsDiscountsBL _Discount;
        private int _DiscountID;

        int newVauleAfterDiscount;
        public int InvoiceID { get { return _InvoiceID; } }
        public clsSalesInvoicesBL SaleInvoiceInfo { get { return _SaleInvoice; } }
        public ctrlInstallmentCard(int invoiceID)
        {
            InitializeComponent();
            if (invoiceID != 0)
                _InvoiceID = invoiceID;
        }
        public ctrlInstallmentCard()
        {
            InitializeComponent();
        }

        private void RefreshDataGridView()
        {
            dgvInstallments.DataSource = null;
            dgvInstallments.DataSource = clsInstallmentsBL.GetAllInstallmentsByInvoiceId(_InvoiceID);
            UpdateDataGridViewHeaders();
            ResizeColumnsToFill();
        }

        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvInstallments.Columns.Count > 0)
            {
                int totalWidth = dgvInstallments.Width;
                int totalColumns = dgvInstallments.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvInstallments.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void InstallmentCard_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void UpdateDataGridViewHeaders()
        {
            if (dgvInstallments.Columns.Count > 0)
            {
                dgvInstallments.Columns[0].HeaderText = "ID";
                dgvInstallments.Columns[1].HeaderText = "Ins. Number";
                dgvInstallments.Columns[2].HeaderText = "Amount";
                dgvInstallments.Columns[3].HeaderText = "Due Date";
                dgvInstallments.Columns[4].HeaderText = "Payment Date";
                dgvInstallments.Columns[5].HeaderText = "Payment Amount";
                dgvInstallments.Columns[6].HeaderText = "Status";
            }
        }

        public void LoadInfo(int invoice_id)
        {
            if (invoice_id != 0)
            {

                _InvoiceID = invoice_id;
                _SaleInvoice = clsSalesInvoicesBL.FindSalesInvoiceByID(invoice_id);
                _SaleInvoiceItem = clsSalesInvoiceItemsBL.FindSalesInvoiceItemByInvoiceID(_InvoiceID);
                _Installment = clsInstallmentsBL.FindInstallmentByInvoiceID(invoice_id);
                if (_SaleInvoice == null || _SaleInvoiceItem == null || _Installment == null)
                {
                    ResetInfo();
                    MessageBox.Show("No Installment with invoice_id = " + invoice_id.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //DataBack?.Invoke(this);
                    return;

                }
                _FillInfo();
            }
        }

        private void _FillInfo()
        {
            LLProductInfo.Enabled = true;
            LLCustomerInfo.Enabled = true;
            LLGuarantorInfo.Enabled = true;
            lblInvoiceID.Text = _SaleInvoice.SalesInvoiceID.ToString();
            txtInstallmentPrice.Text = _SaleInvoiceItem.UnitPrice.ToString();
            txtCustomerName.Text = _SaleInvoice.customersInfo.PersonInfo.PersonName;
            txtGuarantorName.Text = _Installment.GuarantorInfo.PersonInfo.PersonName;
            txtOutstandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_InvoiceID).ToString();
            txtProductName.Text = _Installment.SalesInvoiceItemsInfo.productsInfo.ProductName;
            txtQuantity.Text = _Installment.SalesInvoiceItemsInfo.Quantity.ToString();
            txtPriceBeforeDiscount.Text = _SaleInvoice.SalesInvoiceTotal.ToString();
            txtPriceAfterDiscount.Text = _SaleInvoice.SalesInvoiceTotalAfterDiscount.ToString();
            FillTheDiscountChanges();
        }
        private void FillTheDiscountChanges()
        {
            _Discount = clsDiscountsBL.FindDiscountBySalesInvoiceID(_Installment.SalesInvoiceID);
            if (_Discount != null)
            {
                newVauleAfterDiscount = Convert.ToInt16(_SaleInvoice.SalesInvoiceTotal - _Discount.DiscountValue);
                clsSalesInvoicesBL.UpdateSalesInvoiceTotalAfterDiscount(_InvoiceID, newVauleAfterDiscount);
                txtPriceAfterDiscount.Text = newVauleAfterDiscount.ToString();
                txtOutstandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_InvoiceID).ToString();
            }
            //else
            //    txtPriceAfterDiscount.Text = "";
            RefreshDataGridView();
        }

        public void ResetInfo()
        {
            _InvoiceID = 0;
            lblInvoiceID.Text = "";
            txtInstallmentPrice.Text = "";
            txtCustomerName.Text = "";
            txtGuarantorName.Text = "";
            txtOutstandingBalance.Text = "";
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtPriceBeforeDiscount.Text = "";
            txtPriceAfterDiscount.Text = "";
        }

        private void LLProductInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowProductInfo(_SaleInvoiceItem.ProductID);
            frm.ShowDialog();
        }

        private void LLCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonInfo(_SaleInvoice.customersInfo.PersonID);
            frm.ShowDialog();
        }

        private void LLGuarantorInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonInfo(Convert.ToInt16(_Installment.GuarantorID));
            frm.ShowDialog();
        }

        private void dgvInstallments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvInstallments.Rows[rowIndex];
                    DataGridViewCell cell = dgvInstallments.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvInstallments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvInstallments, collection);
                    contextMenuStrip1.Tag = row;
                    StyleContextMenu(row);

                }
            }
        }

        private void recordPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInstallments.CurrentRow != null && dgvInstallments.CurrentRow.Cells[0].Value != null &&
                int.TryParse(dgvInstallments.CurrentRow.Cells[0].Value.ToString(), out int installment_id))
            {


                Form frm = new frmAddUpdatePayment(installment_id);
                frm.ShowDialog();
                txtOutstandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_InvoiceID).ToString();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Installment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updatePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInstallments.CurrentRow != null && dgvInstallments.CurrentRow.Cells[0].Value != null &&
                int.TryParse(dgvInstallments.CurrentRow.Cells[0].Value.ToString(), out int installment_id))
            {


                Form frm = new frmAddUpdatePayment(installment_id, true);
                frm.ShowDialog();
                txtOutstandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_InvoiceID).ToString();

                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Installment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ctrlInstallmentCard_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();

        }
        private void StyleContextMenu(DataGridViewRow row)
        {
            // Initialize both menu items as disabled
            updatePaymentToolStripMenuItem.Enabled = false;
            recordPaymentToolStripMenuItem.Enabled = false;

            // Check if the "Payment Amount" cell is not null and not empty
            if ((row.Cells["PaymentAmount"].Value).ToString() != "none" /*&& !string.IsNullOrEmpty(row.Cells["PaymentAmount"].Value.ToString())*/)
            {
                // Enable the update payment menu item
                updatePaymentToolStripMenuItem.Enabled = true;
                // Disable the record payment menu item
                recordPaymentToolStripMenuItem.Enabled = false;
            }
            else
            {
                // Disable the update payment menu item
                updatePaymentToolStripMenuItem.Enabled = false;
                // Enable the record payment menu item
                recordPaymentToolStripMenuItem.Enabled = true;

                // Handle null or empty values: Leave it as null (or you can set a default value if needed)

                //row.Cells["PaymentAmount"].Value = null; // Or row.Cells["PaymentAmount"].Value = 0; 
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(lblInvoiceID.Text) > 0)
            {
                Form frm = new frmAddUpdateDiscounts(Convert.ToInt16(lblInvoiceID.Text));
                frm.ShowDialog();
                FillTheDiscountChanges();
                txtOutstandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_InvoiceID).ToString();

            }
        }

        private void btnUpdateDiscount_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(lblInvoiceID.Text) > 0)
            {
                Form frm = new frmAddUpdateDiscounts(Convert.ToInt16(lblInvoiceID.Text), true);
                frm.ShowDialog();
                FillTheDiscountChanges();
                txtOutstandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_InvoiceID).ToString();

            }
        }

        private void printPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string baseDirectory = "C:\\Users\\AL-MARIFA\\Downloads\\Reports"; // Fixed base directory
            string fileName = $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"; // Generate unique file name
            string filePath = Path.Combine(baseDirectory, fileName);

            if (dgvInstallments.CurrentRow != null && dgvInstallments.CurrentRow.Cells[0].Value != null &&
                int.TryParse(dgvInstallments.CurrentRow.Cells[0].Value.ToString(), out int installment_id))
            {
                clsInstallmentPaymentsBL InstallmentPayments = clsInstallmentPaymentsBL.FindInstallmentPaymentByInstallmentID(installment_id);
                if (InstallmentPayments != null)
                {
                    try
                    {
                        InvoiceGenerator.GenerateInvoice(InstallmentPayments, filePath);
                        MessageBox.Show("Invoice generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show($"Access to the path '{filePath}' is denied. Please check permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while generating the invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"There is no payment with Installment ID = {installment_id}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Invalid Installment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
