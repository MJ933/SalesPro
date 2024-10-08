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

namespace SalesPro_PresentationLayer.Customers
{
    public partial class frmManageCustomers : Form
    {
        public frmManageCustomers()
        {
            InitializeComponent();
        }
        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvCustomers.Columns.Count > 0)
            {
                int totalWidth = dgvCustomers.Width;
                int totalColumns = dgvCustomers.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvCustomers.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void frmManageCustomers_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Customer ID");
            //cbFilterBy.Items.Add("Person ID");
            cbFilterBy.Items.Add("Person Name");
            cbFilterBy.Items.Add("Address");
            cbFilterBy.Items.Add("Phone1");
            cbFilterBy.Items.Add("Phone2");
            cbFilterBy.Items.Add("Phone3");
            cbFilterBy.Items.Add("Phone4");
            cbFilterBy.Items.Add("Email");
            cbFilterBy.Items.Add("Notes");
            cbFilterBy.SelectedIndex = 0; // Set a default selected item
        }

        private void dgvCustomers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvCustomers.Rows[rowIndex];
                    DataGridViewCell cell = dgvCustomers.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvCustomers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvCustomers, collection);
                    contextMenuStrip1.Tag = row;
                }
            }
        }
        private void RefreshDataGridView()
        {
            dgvCustomers.DataSource = null; // Clear the existing data source
            dgvCustomers.DataSource = clsCustomersBL.GetAllCustomersWithDetails(); // Reload data from the business layer
            lblRecorsCount.Text = (dgvCustomers.RowCount).ToString();
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
            DataTable dt = clsCustomersBL.GetAllCustomersWithDetails();
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
                        dgvCustomers.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvCustomers.DataSource = null; // Or an empty DataTable: new DataTable();
                                                        // Optionally display a message to the user:
                                                        // MessageBox.Show("No records found that match the filter.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                }
            }
            else
                dgvCustomers.DataSource = dt;
        }
        private string BuildFilterExpretion(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Customer ID":
                    if (int.TryParse(filterValue, out int CustomerID))
                        return $"CustomerID = {CustomerID}";
                    break;
                //case "Person ID":
                //    if (int.TryParse(filterValue, out int PersonID))
                //        return $"PersonID = {PersonID}";
                //    break;
                //case "Phone1":
                //    if (int.TryParse(filterValue, out int Phone1))
                //        return $"Phone1 = {Phone1}";
                //    break;
                //case "Phone2":
                //    if (int.TryParse(filterValue, out int Phone2))
                //        return $"Phone2 = {Phone2}";
                //    break;
                //case "Phone3":
                //    if (int.TryParse(filterValue, out int Phone3))
                //        return $"Phone3 = {Phone3}";
                //    break;
                //case "Phone4":
                //    if (int.TryParse(filterValue, out int Phone4))
                //        return $"Phone4 = {Phone4}";
                //break;
                default:
                    return $"{filterColumn.Replace(" ", "")} LIKE '%{filterValue}%'";
            }
            return "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.Cells[0].Value != null && int.TryParse(dgvCustomers.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsCustomersBL Customer = clsCustomersBL.FindCustomerByID(id);
                Form frm = new frmShowPersonInfo(Customer.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Customer ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null && dgvCustomers.CurrentRow.Cells[0].Value != null && int.TryParse(dgvCustomers.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsCustomersBL Customer = clsCustomersBL.FindCustomerByID(id);
                Form frm = new frmAddUpdatePerson(Customer.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Customer ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void dgvCustomers_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();

        }
    }
}
