using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.People;
using SalesPro_PresentationLayer.Products;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer
{
    public partial class ManageProductInventory : Form
    {
        public ManageProductInventory()
        {
            InitializeComponent();
        }
        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvManageProductInventory.Columns.Count > 0)
            {
                int totalWidth = dgvManageProductInventory.Width;
                int totalColumns = dgvManageProductInventory.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvManageProductInventory.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void ManageProductInventory_Load(object sender, EventArgs e)
        {
            dgvManageProductInventory.DataSource = clsProductsBL.GetAllProducts();
            UpdateDataGridViewHeaders();
            lblRecorsCount.Text = (dgvManageProductInventory.RowCount).ToString();

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Product ID");
            cbFilterBy.Items.Add("Product Name");
            cbFilterBy.Items.Add("Product Description");
            cbFilterBy.Items.Add("Purchase Price");
            cbFilterBy.Items.Add("Selling Price");
            cbFilterBy.Items.Add("Stock Quantity");
            cbFilterBy.Items.Add("Supplier ID");
            cbFilterBy.Items.Add("Last Status Date");
            cbFilterBy.Items.Add("Date Added");
            cbFilterBy.Items.Add("Installment Price");
            cbFilterBy.SelectedIndex = 0; // Set a default selected item
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateProduct();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dgvManageProductInventory.DataSource = null;
            dgvManageProductInventory.DataSource = clsProductsBL.GetAllProducts();
            UpdateDataGridViewHeaders();
            lblRecorsCount.Text = (dgvManageProductInventory.RowCount).ToString();
            ResizeColumnsToFill();

        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageProductInventory.CurrentRow != null &&
               dgvManageProductInventory.CurrentRow.Cells[0].Value != null &&
               int.TryParse(dgvManageProductInventory.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                Form frm = new frmAddUpdateProduct(id);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Invalid Product ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
        }

        private void dgvManageProductInventory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvManageProductInventory.Rows[rowIndex];
                    DataGridViewCell cell = dgvManageProductInventory.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvManageProductInventory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvManageProductInventory, collection);
                    contextMenuStrip1.Tag = row;

                }
            }

        }


        private void UpdateDataGridViewHeaders()
        {
            if (dgvManageProductInventory.Columns.Count > 0)
            {
                dgvManageProductInventory.Columns[0].HeaderText = "Product ID";
                dgvManageProductInventory.Columns[1].HeaderText = "Product Name";
                dgvManageProductInventory.Columns[2].HeaderText = "Product Description";
                dgvManageProductInventory.Columns[3].HeaderText = "Purchase Price";
                dgvManageProductInventory.Columns[4].HeaderText = "Selling Price";
                dgvManageProductInventory.Columns[5].HeaderText = "Stock Quantity";
                dgvManageProductInventory.Columns[6].HeaderText = "Supplier ID";
                dgvManageProductInventory.Columns[7].HeaderText = "Last Status Date";
                dgvManageProductInventory.Columns[8].HeaderText = "Date Added";
                dgvManageProductInventory.Columns[9].HeaderText = "Installment Price";
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
            DataTable dt = clsProductsBL.GetAllProducts();
            string filterColumn = cbFilterBy.SelectedItem?.ToString() ?? "";
            string filterValue = txtFilterValue.Text;

            if (!string.IsNullOrEmpty(filterColumn) && !string.IsNullOrEmpty(filterValue))
            {
                string FilterExpresion = BuildFilterExpression(filterColumn, filterValue);
                if (!string.IsNullOrEmpty(FilterExpresion))
                {
                    DataRow[] filterRows = dt.Select(FilterExpresion);

                    if (filterRows.Length > 0) // Check if filterRows has any rows
                    {
                        dgvManageProductInventory.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvManageProductInventory.DataSource = null; // Or an empty DataTable: new DataTable();
                                                                     // Optionally display a message to the user:
                                                                     // MessageBox.Show("No records found that match the filter.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                }
            }
            else
                dgvManageProductInventory.DataSource = dt;
        }

        private string BuildFilterExpression(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Product ID":
                    if (int.TryParse(filterValue, out int productIDValue))
                        return $"ProductID = {productIDValue}";
                    break;

                case "Supplier ID":
                    if (int.TryParse(filterValue, out int supplierIDValue))
                        return $"SupplierID = {supplierIDValue}";
                    break;

                case "Stock Quantity":
                    if (int.TryParse(filterValue, out int stockQuantityValue))
                        return $"StockQuantity = {stockQuantityValue}";
                    break;

                case "Purchase Price":
                    if (double.TryParse(filterValue, out double purchasePriceValue))
                        return $"PurchasePrice = {purchasePriceValue}";
                    break;

                case "Selling Price":
                    if (double.TryParse(filterValue, out double sellingPriceValue))
                        return $"SellingPrice = {sellingPriceValue}";
                    break;

                case "Installment Price":
                    if (double.TryParse(filterValue, out double installmentPriceValue))
                        return $"InstallmentPrice = {installmentPriceValue}";
                    break;

                case "Last Status Date":
                case "Date Added":
                    // Attempt to parse the date with various formats (including milliseconds)
                    if (DateTime.TryParseExact(filterValue, "yyyy-MM-dd HH:mm:ss.ffffff", null, System.Globalization.DateTimeStyles.None, out DateTime dateTimeValue))
                    {
                        return $"{filterColumn} = '{dateTimeValue:yyyy-MM-dd HH:mm:ss.ffffff}'";
                    }
                    else if (DateTime.TryParseExact(filterValue, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out dateTimeValue))
                    {
                        return $"{filterColumn} = '{dateTimeValue:yyyy-MM-dd HH:mm:ss}'";
                    }
                    else if (DateTime.TryParse(filterValue, out dateTimeValue))
                    {
                        // Try parsing with a general date format if the above fails
                        return $"{filterColumn} = '{dateTimeValue:yyyy-MM-dd HH:mm:ss}'"; // Adjust format if needed
                    }
                    break;

                default:
                    return $"{filterColumn.Replace(" ", "")} LIKE '%{filterValue}%'";
            }

            return ""; // Return an empty string if no filter expression is built
        }

        private void ManageProductInventory_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();
        }
    }
}