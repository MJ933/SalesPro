using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.People;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;

using System.Windows.Forms;

namespace SalesPro_PresentationLayer
{
    public partial class frmManagePeopleList : Form
    {
        private FontFamily arabicFontFamily;
        public frmManagePeopleList()
        {
            InitializeComponent();
            AddCustomFont();
        }
        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvPeople.Columns.Count > 0)
            {
                int totalWidth = dgvPeople.Width;
                int totalColumns = dgvPeople.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvPeople.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void AddCustomFont()
        {
            // 1. Construct the path safely using Path.Combine:
            string fontPath = "E:/SalesPro/IBMPlexSansArabic-Medium.ttf";

            // 2. Check if the font file exists:
            if (!File.Exists(fontPath))
            {
                MessageBox.Show($"Font file not found: {fontPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Load the font (no need for extra quotes ""):
            PrivateFontCollection customFonts = new PrivateFontCollection();
            customFonts.AddFontFile(fontPath);

            // 4. Store the FontFamily for later use:
            arabicFontFamily = customFonts.Families[0];

            // 5. Apply the font to the label (done in the Load event):
            //     label1.Font = new Font(arabicFontFamily, 16, FontStyle.Regular);
        }
        private void RefreshDataGridView()
        {
            dgvPeople.DataSource = null; // Clear the existing data source
            dgvPeople.DataSource = clsPeopleBL.GetAllPeople(); // Reload data from the business layer
            lblRecorsCount.Text = (dgvPeople.RowCount).ToString();
            ChangeDataGridViewStyle();
            ResizeColumnsToFill();
        }

        private void ChangeDataGridViewStyle()
        {
            if (dgvPeople.DataSource != null)
            {
                //dgvPeople.Columns["Address"].Width = 450;
                //dgvPeople.Columns["Person Name"].Width = 450;
                //dgvPeople.Columns["Phone1"].Width = 450;
                dgvPeople.RowTemplate.Height = 50;
                lblRecorsCount.Text = (dgvPeople.RowCount).ToString();

            }
        }
        private void ShowPeopleList_Load(object sender, EventArgs e)
        {
            //dgvPeople.DataSource = clsPeopleBL.GetAllPeople();
            RefreshDataGridView();
            //lblRecorsCount.Text = (dgvPeople.RowCount).ToString();

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Person ID");
            cbFilterBy.Items.Add("Person Name");
            cbFilterBy.Items.Add("Address");
            cbFilterBy.Items.Add("Phone1");
            cbFilterBy.SelectedIndex = 0; // Set a default selected item
            if (arabicFontFamily != null)
            {

                dgvPeople.DefaultCellStyle.Font = new Font(arabicFontFamily, 14, FontStyle.Regular);
            }
            else
            {
                // Handle the case where the font loading failed (e.g., log an error)
            }
        }





        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form frm = new frmFindPerson(true);
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvPeople.CurrentRow != null &&
                dgvPeople.CurrentRow.Cells[0].Value != null &&
                int.TryParse(dgvPeople.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                Form frm = new frmAddUpdatePerson(id);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
                MessageBox.Show("Invalid Person ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow != null && dgvPeople.CurrentRow.Cells[0].Value != null && int.TryParse(dgvPeople.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                Form frm = new frmShowPersonInfo(id);
                frm.ShowDialog();
                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Person ID selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            RefreshDataGridView();
        }




        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void FilterDataGridView()
        {
            DataTable dt = clsPeopleBL.GetAllPeople();
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
                        dgvPeople.DataSource = filterRows.CopyToDataTable();
                        ChangeDataGridViewStyle();

                    }
                    else
                    {
                        dgvPeople.DataSource = null; // Or an empty DataTable: new DataTable();
                        ChangeDataGridViewStyle();
                        // Optionally display a message to the user:
                        // MessageBox.Show("No records found that match the filter.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                }
            }
            else
            {
                dgvPeople.DataSource = dt;

                ChangeDataGridViewStyle();
            }

        }
        private string BuildFilterExpretion(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Person ID":
                    if (int.TryParse(filterValue, out int PersonID))

                        return $"[Person ID] = {PersonID}";
                    break;
                case "Phone1":
                    if (int.TryParse(filterValue, out int Phone1))
                        return $"CONVERT([Phone1], 'System.String') LIKE '%{Phone1}%'";

                    //return $"Phone1 = {Phone1}";
                    break;
                default:
                    //return $"{filterColumn.Replace(" ", "")} LIKE '%{filterValue}%'";
                    return $"[{filterColumn}] LIKE '%{filterValue}%'";
            }
            return "";

        }

        private void dgvPeople_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvPeople.Rows[rowIndex];
                    DataGridViewCell cell = dgvPeople.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvPeople.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvPeople, collection);
                    contextMenuStrip1.Tag = row;

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            RefreshDataGridView();
        }

        private void frmManagePeopleList_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();
        }
    }
}