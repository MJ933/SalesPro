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
    public partial class frmManageGuarantors : Form
    {
        public frmManageGuarantors()
        {
            InitializeComponent();
        }
        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvGuarantors.Columns.Count > 0)
            {
                int totalWidth = dgvGuarantors.Width;
                int totalColumns = dgvGuarantors.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvGuarantors.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void frmManageGuarantors_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Guarantor ID");
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
        private void dgvCustomers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvGuarantors.Rows[rowIndex];
                    DataGridViewCell cell = dgvGuarantors.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvGuarantors.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvGuarantors, collection);
                    contextMenuStrip1.Tag = row;
                }
            }
        }
        private void RefreshDataGridView()
        {
            dgvGuarantors.DataSource = null; // Clear the existing data source
            dgvGuarantors.DataSource = clsGuarantorsBL.GetAllGuarantors(); // Reload data from the business layer
            lblRecorsCount.Text = (dgvGuarantors.RowCount).ToString();
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
            DataTable dt = clsGuarantorsBL.GetAllGuarantors();
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
                        dgvGuarantors.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvGuarantors.DataSource = null; // Or an empty DataTable: new DataTable();
                                                         // Optionally display a message to the user:
                                                         // MessageBox.Show("No records found that match the filter.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                }
            }
            else
                dgvGuarantors.DataSource = dt;
        }
        private string BuildFilterExpretion(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Guarantor ID":
                    if (int.TryParse(filterValue, out int GuarantorID))
                        return $"GuarantorID = {GuarantorID}";
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



        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGuarantors.CurrentRow != null && dgvGuarantors.CurrentRow.Cells[0].Value != null && int.TryParse(dgvGuarantors.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsGuarantorsBL Guarantor = clsGuarantorsBL.FindGuarantorByID(id);
                Form frm = new frmShowPersonInfo(Guarantor.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Guarantor ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGuarantors.CurrentRow != null && dgvGuarantors.CurrentRow.Cells[0].Value != null && int.TryParse(dgvGuarantors.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsGuarantorsBL Guarantor = clsGuarantorsBL.FindGuarantorByID(id);
                Form frm = new frmAddUpdatePerson(Guarantor.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Guarantor ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateGuarantors();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateGuarantors();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void frmManageGuarantors_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();

        }
    }
}
