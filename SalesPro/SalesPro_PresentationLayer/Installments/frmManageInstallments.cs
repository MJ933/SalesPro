using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Installments
{
    public partial class frmManageInstallments : Form
    {
        public frmManageInstallments()
        {
            InitializeComponent();
        }

        private void frmManageInstallments_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
            UpdateDataGridViewHeaders();
            lblRecorsCount.Text = (dgvManageInstallments.RowCount).ToString();

            // Initialize the cbFilterBy ComboBox with column names
            cbFilterBy.Items.Add("Installment ID");
            cbFilterBy.Items.Add("Customer Name");
            //cbFilterBy.Items.Add("Product Name");
            //cbFilterBy.Items.Add("Sales Invoice ID");
            //cbFilterBy.Items.Add("Installment Range");
            //cbFilterBy.Items.Add("Installment Amount");
            //cbFilterBy.Items.Add("Due Date");
            //cbFilterBy.Items.Add("Payment Date");
            //cbFilterBy.Items.Add("Installment Status");
            cbFilterBy.SelectedIndex = 0; // Set a default selected item
        }

        private void RefreshDataGridView()
        {
            dgvManageInstallments.DataSource = null;
            dgvManageInstallments.DataSource = clsInstallmentsBL.GetAllInstallmentsByIfPaidOrNot(chkIsPaid.Checked);
            UpdateDataGridViewHeaders();
            lblRecorsCount.Text = (dgvManageInstallments.RowCount).ToString();
            ResizeColumnsToFill();
        }
        private void ResizeColumnsToFill()
        {
            // Assuming your DataGridView is named dataGridView1
            if (dgvManageInstallments.Columns.Count > 0)
            {
                int totalWidth = dgvManageInstallments.Width;
                int totalColumns = dgvManageInstallments.Columns.Count;
                int widthPerColumn = totalWidth / totalColumns;

                foreach (DataGridViewColumn column in dgvManageInstallments.Columns)
                {
                    column.Width = widthPerColumn;
                }
            }
        }
        private void dgvManageInstallments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = dgvManageInstallments.Rows[rowIndex];
                    DataGridViewCell cell = dgvManageInstallments.Rows[rowIndex].Cells[e.ColumnIndex];
                    Point collection = dgvManageInstallments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;

                    contextMenuStrip1.Show(dgvManageInstallments, collection);
                    contextMenuStrip1.Tag = row;

                }
            }
        }

        private void UpdateDataGridViewHeaders()
        {
            if (dgvManageInstallments.Columns.Count > 0)
            {
                dgvManageInstallments.Columns[0].HeaderText = "Installment ID";
                dgvManageInstallments.Columns[1].HeaderText = "Customer Name";
                //dgvManageInstallments.Columns[2].HeaderText = "Product Name";
                //dgvManageInstallments.Columns[3].HeaderText = "Quantity";
                dgvManageInstallments.Columns[2].HeaderText = "Sales Invoice ID";
                dgvManageInstallments.Columns[3].HeaderText = "Installment Range";
                dgvManageInstallments.Columns[4].HeaderText = "Installment Amount";
                dgvManageInstallments.Columns[5].HeaderText = "Due Date";
                //dgvManageInstallments.Columns[8].HeaderText = "Payment Date";
                //dgvManageInstallments.Columns[9].HeaderText = "Installment Status";
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
            DataTable dt = clsInstallmentsBL.GetAllInstallmentsByIfPaidOrNot(chkIsPaid.Checked);
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
                        dgvManageInstallments.DataSource = filterRows.CopyToDataTable();
                    }
                    else
                    {
                        dgvManageInstallments.DataSource = null; // Or an empty DataTable: new DataTable();
                                                                 // Optionally display a message to the user:
                                                                 // MessageBox.Show("No records found that match the filter.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                }
            }
            else
                dgvManageInstallments.DataSource = dt;
        }
        private string BuildFilterExpression(string filterColumn, string filterValue)
        {
            switch (filterColumn)
            {
                case "Installment ID":
                    if (int.TryParse(filterValue, out int InstallmentID))
                        return $"InstallmentID = {InstallmentID}";
                    break;

                case "Customer Name":
                    return $"PersonName LIKE '%{filterValue}%'";

                case "Product Name":
                    return $"ProductName LIKE '%{filterValue}%'";

                default:
                    return $"{filterColumn.Replace(" ", "")} LIKE '%{filterValue}%'";
            }

            return ""; // Return an empty string if no filter expression is built
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageInstallments.CurrentRow != null && dgvManageInstallments.CurrentRow.Cells[4].Value != null &&
                int.TryParse(dgvManageInstallments.CurrentRow.Cells[2].Value.ToString(), out int invoice_id))
            {


                Form frm = new frmShowInstallmentInfo(invoice_id);
                frm.ShowDialog();

                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Installment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recordPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageInstallments.CurrentRow != null && dgvManageInstallments.CurrentRow.Cells[0].Value != null &&
                int.TryParse(dgvManageInstallments.CurrentRow.Cells[0].Value.ToString(), out int installment_id))
            {


                Form frm = new frmAddUpdatePayment(installment_id);
                frm.ShowDialog();

                RefreshDataGridView();
            }
            else
            {
                // Handle the case where the cell doesn't contain a valid integer ID
                MessageBox.Show("Invalid Installment selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateSalesInvoices();
            frm.ShowDialog();
        }

        private void frmManageInstallments_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();
        }

        private void chkIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //    // 1. Get data from DataGridView
            //    DataTable dt = (DataTable)dgvManageInstallments.DataSource;
            //    //string filePath = @"E:\SalesPro\Reports";
            //    // i need you to use this path as the static path for every report 
            //    // and also i need to use the headers of the dgvManageInstallments that has
            //    // been used in private void UpdateDataGridViewHeaders()

            //    // 2. Check if data exists
            //    if (dt == null || dt.Rows.Count == 0)
            //    {
            //        MessageBox.Show("لا توجد بيانات للطباعة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    // 3. Specify file path
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            //    saveFileDialog.FileName = "InstallmentsReport.pdf";

            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string filePath = saveFileDialog.FileName;

            //        try
            //        {
            //            // 4. Generate PDF report
            //            PdfReportGeneratorBL.GeneratePdfReport(
            //                dt,
            //                filePath,
            //                headerText: "تقرير الأقساط", // Example header
            //                footerText: "تاريخ التقرير: " + DateTime.Now.ToShortDateString(), // Example footer
            //                addPageNumbers: true
            //            );

            //            MessageBox.Show("تم إنشاء التقرير بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            // Optional: Open the generated PDF file
            //            System.Diagnostics.Process.Start(filePath);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("حدث خطأ أثناء إنشاء التقرير: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
        }
    }
}
