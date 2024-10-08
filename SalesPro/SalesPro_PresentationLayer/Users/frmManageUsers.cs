using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Customers_Guarantors_Suppliers;
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

namespace SalesPro_PresentationLayer.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvUsers.Columns.Count > 0)
            {
                int totalWidth = dgvUsers.Width;
                int totalColumns = dgvUsers.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvUsers.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
            dgvUsers.AutoGenerateColumns = false;

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("User ID");
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

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvUsers.Rows[rowIndex];
                    DataGridViewCell cell = dgvUsers.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvUsers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvUsers, collection);
                    contextMenuStrip1.Tag = row;
                }
            }
        }
        private void RefreshDataGridView()
        {
            dgvUsers.DataSource = null; // Clear the existing data source
            dgvUsers.DataSource = clsUsersBL.GetAllUsers(); // Reload data from the business layer
            lblRecorsCount.Text = (dgvUsers.RowCount).ToString();
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
            DataTable dt = clsUsersBL.GetAllUsers();
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
                        dgvUsers.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvUsers.DataSource = null;
                    }
                }
            }
            else
                dgvUsers.DataSource = dt;
        }
        private string BuildFilterExpretion(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "User ID":
                    if (int.TryParse(filterValue, out int UserID))
                        return $"UserID = {UserID}";
                    break;
                default:
                    return $"{filterColumn.Replace(" ", "")} LIKE '%{filterValue}%'";
            }
            return "";

        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.Cells[0].Value != null && int.TryParse(dgvUsers.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                //clsUsersBL User = clsUsersBL.FindUserByID(id);
                Form frm = new frmUserInfo(id);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid User ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null && dgvUsers.CurrentRow.Cells[0].Value != null && int.TryParse(dgvUsers.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                clsUsersBL User = clsUsersBL.FindUserByID(id);
                Form frm = new frmAddUpdatePerson(User.PersonInfo.PersonID);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid User ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void frmManageUsers_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();

        }
    }
}
