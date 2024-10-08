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


namespace SalesPro_PresentationLayer.Sales
{
    public partial class frmManageSalesInvoices : Form
    {
        public frmManageSalesInvoices()
        {
            InitializeComponent();
        }
        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvManageSales.Columns.Count > 0)
            {
                int totalWidth = dgvManageSales.Width;
                int totalColumns = dgvManageSales.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvManageSales.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void frmManageSalesInvoices_Load(object sender, EventArgs e)
        {
            dgvManageSales.DataSource = clsSalesInvoicesBL.GetAllSalesInvoicesWithDetails();
            dgvManageSales.AllowUserToAddRows = false;
            UpdateDataGridViewHeaders();
            lblRecorsCount.Text = (dgvManageSales.RowCount).ToString();

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Invoice ID");
            cbFilterBy.Items.Add("Customer Name");
            cbFilterBy.Items.Add("Invoice Date");
            cbFilterBy.Items.Add("Invoice Total");
            cbFilterBy.Items.Add("Salesperson");
            cbFilterBy.Items.Add("Paid");
            cbFilterBy.Items.Add("Payment Method");
            cbFilterBy.Items.Add("Product Name");
            cbFilterBy.Items.Add("Item ID");
            cbFilterBy.Items.Add("Quantity");
            cbFilterBy.Items.Add("Unit Price");
            cbFilterBy.SelectedIndex = 0; // Set a default selected item

        }

        private void RefreshDataGridView()
        {
            dgvManageSales.DataSource = null;
            dgvManageSales.DataSource = clsSalesInvoicesBL.GetAllSalesInvoicesWithDetails();
            UpdateDataGridViewHeaders();
            lblRecorsCount.Text = (dgvManageSales.RowCount).ToString();
            dgvManageSales.AllowUserToAddRows = false;
            ResizeColumnsToFill();

        }

        private void dgvManageSales_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvManageSales.Rows[rowIndex];
                    DataGridViewCell cell = dgvManageSales.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvManageSales.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvManageSales, collection);
                    contextMenuStrip1.Tag = row;

                }
            }
        }

        private void UpdateDataGridViewHeaders()
        {
            if (dgvManageSales.Columns.Count > 0)
            {
                dgvManageSales.Columns[0].HeaderText = "Invoice ID";
                dgvManageSales.Columns[1].HeaderText = "Customer Name";
                dgvManageSales.Columns[2].HeaderText = "Invoice Date";
                dgvManageSales.Columns[3].HeaderText = "Invoice Total";
                dgvManageSales.Columns[4].HeaderText = "Salesperson";
                dgvManageSales.Columns[5].HeaderText = "Paid";
                dgvManageSales.Columns[6].HeaderText = "Payment Method";
                dgvManageSales.Columns[7].HeaderText = "Invoice Status";
                dgvManageSales.Columns[8].HeaderText = "Product Name";
                dgvManageSales.Columns[9].HeaderText = "Item ID";
                dgvManageSales.Columns[10].HeaderText = "Quantity";
                dgvManageSales.Columns[11].HeaderText = "Unit Price";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void FilterDataGridView()
        {
            DataTable dt = clsSalesInvoicesBL.GetAllSalesInvoicesWithDetails();
            string filterColumn = cbFilterBy.SelectedItem?.ToString() ?? "";
            string filterValue = txtFilterValue.Text;

            if (!string.IsNullOrEmpty(filterColumn) && !string.IsNullOrEmpty(filterValue))
            {
                string filterExpression = BuildFilterExpression(filterColumn, filterValue);
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    DataRow[] filterRows = dt.Select(filterExpression);

                    if (filterRows.Length > 0)
                    {
                        dgvManageSales.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvManageSales.DataSource = null;
                    }
                }
            }
            else
                dgvManageSales.DataSource = dt;
        }

        private string BuildFilterExpression(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Invoice ID":
                    if (int.TryParse(filterValue, out int invoiceIDValue))
                        return $"[Invoice ID] LIKE '%{invoiceIDValue}%'";
                    break;
                case "Customer Name":
                    return $"[Customer Name] LIKE '%{filterValue}%'";
                case "Invoice Date":
                    // Example:
                    //return $"[Invoice Date] LIKE '%{filterValue}%'"; // Error here 
                    break;
                case "Invoice Total":
                    if (decimal.TryParse(filterValue, out decimal invoiceTotalValue))
                        return $"CONVERT([Invoice Total], 'System.String') LIKE '%{invoiceTotalValue}%'";
                    break;
                case "Salesperson":
                    return $"[Salesperson] LIKE '%{filterValue}%'";
                case "Paid":
                    return $"[Paid] LIKE '%{filterValue}%'";
                case "Payment Method":
                    return $"[Payment Method] LIKE '%{filterValue}%'";
                case "Product Name":
                    return $"[Product Name] LIKE '%{filterValue}%'";
                case "Item ID":
                    if (int.TryParse(filterValue, out int ItemIDValue))
                        return $"CONVERT([Item ID], 'System.String') LIKE '%{ItemIDValue}%'";
                    break;
                case "Quantity":
                    if (int.TryParse(filterValue, out int quantityValue))
                        return $"CONVERT([Quantity], 'System.String') LIKE '%{quantityValue}%'";
                    break;
                case "Unit Price":
                    if (decimal.TryParse(filterValue, out decimal unitPriceValue))
                        return $"CONVERT([Unit Price], 'System.String') LIKE '%{unitPriceValue}%'";
                    break;
                default:
                    return string.Empty;
            }

            return string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateSalesInvoices();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageSales.CurrentRow != null && dgvManageSales.CurrentRow.Cells[0].Value != null &&
                int.TryParse(dgvManageSales.CurrentRow.Cells[0].Value.ToString(), out int invoice_id))
            {
                if (dgvManageSales.CurrentRow != null && dgvManageSales.CurrentRow.Cells[8].Value != null &&
                int.TryParse(dgvManageSales.CurrentRow.Cells[9].Value.ToString(), out int item_id))
                {
                    Form frm = new frmShowSaleInvoiceInfo(invoice_id, item_id);
                    frm.ShowDialog();
                    RefreshDataGridView();
                }
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("The Invoice ID or the Item ID is Wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this Sale Invoice???", "Cancel!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvManageSales.CurrentRow != null && dgvManageSales.CurrentRow.Cells[0].Value != null &&
            int.TryParse(dgvManageSales.CurrentRow.Cells[0].Value.ToString(), out int invoice_id))
                {
                    if (clsSalesInvoicesBL.GetInvoiceStatusAsNumber(invoice_id) == 2)
                    {
                        MessageBox.Show("The Invoice is already Retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (clsSalesInvoicesBL.IsSalesInvoiceActive(invoice_id))
                    {
                        if (clsSalesInvoicesBL.CancelSalesInvoice(invoice_id))
                            MessageBox.Show($"The Invoice with ID = {invoice_id} has been cancel.");
                        else
                            MessageBox.Show($"The Invoice with ID = {invoice_id} has NOT been cancel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshDataGridView();
                    }
                    else
                    {
                        // Handle the case where the cell doesn't contain a valid integer ID
                        MessageBox.Show("The Invoice is already Canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }


            }
        }

        private void retrieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this Sale Invoice???", "Cancel!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dgvManageSales.CurrentRow != null && dgvManageSales.CurrentRow.Cells[0].Value != null &&
            int.TryParse(dgvManageSales.CurrentRow.Cells[0].Value.ToString(), out int invoice_id))
                {
                    if (clsSalesInvoicesBL.GetInvoiceStatusAsNumber(invoice_id) == 3)
                    {
                        MessageBox.Show("The Invoice is already Canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!clsSalesInvoicesBL.IsSalesInvoiceRetrieved(invoice_id))
                    {

                        if (clsSalesInvoicesBL.RetrieveSalesInvoice(invoice_id))
                            MessageBox.Show($"The Invoice with ID = {invoice_id} has been Retrieved.");
                        else
                            MessageBox.Show($"The Invoice with ID = {invoice_id} has NOT been Retrieved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        RefreshDataGridView();
                    }
                    else
                    {
                        // Handle the case where the cell doesn't contain a valid integer ID
                        MessageBox.Show("The Invoice is already Retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void dgvManageSales_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();

        }
    }
}