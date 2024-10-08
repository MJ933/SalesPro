using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Customers;
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

namespace SalesPro_PresentationLayer.Customers_Guarantors_Suppliers
{
    public partial class frmManageSuppliers : Form
    {
        public frmManageSuppliers()
        {
            InitializeComponent();
        }

        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvSuppliers.Columns.Count > 0)
            {
                int totalWidth = dgvSuppliers.Width;
                int totalColumns = dgvSuppliers.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvSuppliers.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void frmManageSuppliers_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
            dgvSuppliers.AutoGenerateColumns = false;

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Supplier ID");
            //cbFilterBy.Items.Add("Person ID");
            cbFilterBy.Items.Add("Person Name");
            cbFilterBy.Items.Add("Address");
            cbFilterBy.Items.Add("Phone1");
            //cbFilterBy.Items.Add("Phone2");
            //cbFilterBy.Items.Add("Phone3");
            //cbFilterBy.Items.Add("Phone4");
            cbFilterBy.Items.Add("Email");
            //cbFilterBy.Items.Add("Notes");
            cbFilterBy.SelectedIndex = 0; // Set a default selected item
        }

        private void dgvSuppliers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvSuppliers.Rows[rowIndex];
                    DataGridViewCell cell = dgvSuppliers.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvSuppliers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvSuppliers, collection);
                    contextMenuStrip1.Tag = row;
                }
            }
        }

        private void RefreshDataGridView()
        {
            dgvSuppliers.DataSource = null; // Clear the existing data source
            dgvSuppliers.DataSource = clsSuppliersBL.GetAllSuppliers(); // Reload data from the business layer
            lblRecorsCount.Text = (dgvSuppliers.RowCount).ToString();
            ResizeColumnsToFill();

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
            DataTable dt = clsSuppliersBL.GetAllSuppliers();
            string filterColumn = cbFilterBy.SelectedItem?.ToString() ?? "";
            string filterValue = txtFilterValue.Text;

            if (!string.IsNullOrEmpty(filterColumn) && !string.IsNullOrEmpty(filterValue))
            {
                string FilterExpresion = BuildFilterExpretion(filterColumn, filterValue);
                if (!string.IsNullOrEmpty(FilterExpresion))
                {
                    DataRow[] filterRows = dt.Select(FilterExpresion);

                    if (filterRows.Length > 0) // Check if filterRows has any rows
                    {
                        dgvSuppliers.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvSuppliers.DataSource = null; // Or an empty DataTable: new DataTable();
                                                        // Optionally display a message to the user:
                                                        // MessageBox.Show("No records found that match the filter.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                }
            }
            else
                dgvSuppliers.DataSource = dt;
        }
        private string BuildFilterExpretion(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Supplier ID":
                    if (int.TryParse(filterValue, out int SupplierID))
                        return $"SupplierID = {SupplierID}";
                    break;

                default:
                    return $"{filterColumn.Replace(" ", "")} LIKE '%{filterValue}%'";
            }
            return "";

        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow != null && dgvSuppliers.CurrentRow.Cells[0].Value != null && int.TryParse(dgvSuppliers.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsSuppliersBL Supplier = clsSuppliersBL.FindSupplierByID(id);
                Form frm = new frmShowPersonInfo(Supplier.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Supplier ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.CurrentRow != null && dgvSuppliers.CurrentRow.Cells[0].Value != null && int.TryParse(dgvSuppliers.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsSuppliersBL Supplier = clsSuppliersBL.FindSupplierByID(id);
                Form frm = new frmAddUpdatePerson(Supplier.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Supplier ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateSupplier();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateSupplier();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void frmManageSuppliers_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();

        }
    }
}
