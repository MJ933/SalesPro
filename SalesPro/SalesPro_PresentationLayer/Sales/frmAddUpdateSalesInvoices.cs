using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Global_Classes;
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
    public partial class frmAddUpdateSalesInvoices : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private string _Name;

        private int _CustomerID;
        private int _SalesInvoiceID;
        private clsSalesInvoicesBL _SalesInvoice;

        private int _ProductID;
        private clsProductsBL _ProductInfo;

        private int _SalesInvoiceItemID;
        private clsSalesInvoiceItemsBL _SalesInvoiceItem;

        private int _GuarontorID;
        private clsGuarantorsBL _Guarantor;

        private int _InstallmentsID;
        private clsInstallmentsBL _Installment;

        //string filterText;

        private bool _IsPaid;
        private int _PaymentMethodType;



        DataTable dtCustomersNames = clsCustomersBL.GetAllCustomersNames();
        DataTable dtGuarantorsNames = clsGuarantorsBL.GetGuarantorsNames();
        DataTable dtProductsNames = clsProductsBL.GetProductNames();

        public frmAddUpdateSalesInvoices()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            txtQuantity.Text = "1";
            cbPeriod.SelectedIndex = 0;
            nudNumberOfInstallments.Value = 10;
            initializeDataGridViewInstallment();
        }
        public frmAddUpdateSalesInvoices(int customer_id)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CustomerID = customer_id;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            txtQuantity.Text = "1";
            cbPeriod.SelectedIndex = 0;
            nudNumberOfInstallments.Value = 10;
            initializeDataGridViewInstallment();
        }
        private void frmAddUpdateSalesInvoices_Load(object sender, EventArgs e)
        {
            //       FillTheCustomersCB();
            FillCustomersCB();
            FillProductsCB();
            FillGuaranotsCB();
            cbProducts.SelectedIndex = 0;



            _IsPaid = true;
            _PaymentMethodType = 1;
            btnNext.Enabled = false;
            tabInstallmetPage.Enabled = false;

        }


        private void FillCustomersCB()
        {
            DataTable dt = clsCustomersBL.GetAllCustomersNames();
            cbCustomers.DataSource = dt;
            cbCustomers.DisplayMember = "PersonName";
            cbCustomers.ValueMember = "PersonName";
        }
        private void FillGuaranotsCB()
        {
            DataTable dt = clsGuarantorsBL.GetGuarantorsNames();
            cbGuarantors.DataSource = dt;
            cbGuarantors.DisplayMember = "PersonName";
            cbGuarantors.ValueMember = "PersonName";
        }
        private void FillProductsCB()
        {
            DataTable dt = clsProductsBL.GetAllProducts();
            cbProducts.DataSource = dt;
            cbProducts.DisplayMember = "ProductName";
            cbProducts.ValueMember = "ProductID";
        }


        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Text = "1";
            GetProductID();
            _ProductInfo = clsProductsBL.FindProductByID(_ProductID);
            ctrlProductCard1.LoadInfo(_ProductID);
            Load_dgvInstallments();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }


            _SalesInvoice = new clsSalesInvoicesBL();
            _SalesInvoice.CustomerID = _CustomerID;
            _SalesInvoice.SalesInvoiceDate = DateTimePicker1.Value;
            if (_PaymentMethodType == 1)
                _SalesInvoice.SalesInvoiceTotal = Convert.ToInt16(txtQuantity.Text) * _ProductInfo.SellingPrice;
            else
                _SalesInvoice.SalesInvoiceTotal = Convert.ToInt16(txtQuantity.Text) * Convert.ToInt16(_ProductInfo.InstallmentPrice);
            _SalesInvoice.SalesInvoicePaymentType = _PaymentMethodType;
            _SalesInvoice.UserID = clsGlobal.CurrentUser.UserID;
            _SalesInvoice.IsPaid = _IsPaid;
            _SalesInvoice.SalesInvoiceTotalAfterDiscount = _SalesInvoice.SalesInvoiceTotal;
            if (_SalesInvoice.Save())
            {
                _SalesInvoiceID = _SalesInvoice.SalesInvoiceID;

                if (_PaymentMethodType == 1)
                {

                    SaveInvoiceItems();
                    //_ProductInfo.UpdateProductQuantity(_ProductID, _SalesInvoiceItem.Quantity);
                }
                else
                {
                    SaveInvoiceItems();
                    SaveInstallemtsItems();
                    //_ProductInfo.UpdateProductQuantity(_ProductID, Convert.ToInt16(txtQuantity.Text));
                }
                lblInvoiceID.Text = _SalesInvoiceID.ToString();
                lblInvoiceID2.Text = _SalesInvoice.SalesInvoiceID.ToString();
                btnSave.Enabled = false;

            }
            else MessageBox.Show("The Sales invoice has NOT saved!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SaveInstallemtsItems()
        {
            //for (int i = 1; i < nudNumberOfInstallments.Value; i++)
            //{
            //    _Installment.InstallmentNumber = i;
            //    _Installment.DueDate = (dtpDateOfFirstIns.Value);
            //};

            if (string.IsNullOrEmpty(txtQuantity.Text))
                return;
            if (_ProductInfo == null)
                return;
            int totalAmount = Convert.ToInt16(_ProductInfo.InstallmentPrice) * Convert.ToInt16(txtQuantity.Text);
            int NumberOfInstallments = Convert.ToInt16(nudNumberOfInstallments.Value);
            DateTime FirstInstallmentDate = dtpDateOfFirstIns.Value;
            string InstallmentPeriod = (cbPeriod.SelectedItem).ToString();
            int InstallmentAmount = totalAmount / NumberOfInstallments;
            for (int i = 1; i <= NumberOfInstallments; i++)
            {
                DateTime dueDate = FirstInstallmentDate;
                switch (InstallmentPeriod)
                {
                    case "Month":
                        dueDate = dueDate.AddMonths(i - 1);
                        break;
                    case "Week":
                        dueDate = dueDate.AddDays((i - 1) * 7);
                        break;
                    default:
                        dueDate = dueDate.AddMonths(i - 1);
                        break;

                }
                _Installment = new clsInstallmentsBL();
                _Installment.SalesInvoiceID = _SalesInvoice.SalesInvoiceID;
                _Installment.InstallmentNumber = i;
                _Installment.InstallmentAmount = InstallmentAmount;
                _Installment.DueDate = dueDate;
                _Installment.StatusID = 1;
                _Installment.UserID = clsGlobal.CurrentUser.UserID;
                _Installment.GuarantorID = _GuarontorID;
                _Installment.ProductID = _ProductID;
                _Installment.Quantity = Convert.ToInt16(txtQuantity.Text);
                if (!_Installment.Save())
                {
                    MessageBox.Show($"The Installment is Not Saved Correctly due to Unknown reason!!!!", "ERROR", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    break;
                }
            }

        }

        private void SaveInvoiceItems()
        {


            if (_SalesInvoice != null)
            {

                _SalesInvoiceItem = new clsSalesInvoiceItemsBL();
                _SalesInvoiceItem.SalesInvoiceID = _SalesInvoiceID;
                _SalesInvoiceItem.ProductID = _ProductID;
                _SalesInvoiceItem.Quantity = Convert.ToInt16(txtQuantity.Text);
                if (_PaymentMethodType == 1)
                    _SalesInvoiceItem.UnitPrice = _ProductInfo.SellingPrice;
                else
                    _SalesInvoiceItem.UnitPrice = Convert.ToInt16(_ProductInfo.InstallmentPrice);
                _SalesInvoiceItem.UserID = clsGlobal.CurrentUser.UserID;
                if (_SalesInvoiceItem.Save())
                {
                    MessageBox.Show("The Item Has Been Saved!");

                }
                else
                {
                    MessageBox.Show("The Item Has NOT saved!", "Not Saved!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

            // here i  want the user to only enter numbers
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantity.Text = txtQuantity.Text.Remove(txtQuantity.Text.Length - 1);
                }
                Load_dgvInstallments();

            }
            catch
            {
                MessageBox.Show("Please enter only numbers.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaymnetMethodChanged(object sender, EventArgs e)
        {
            // here to check if the Radio buttons is changed and change the _IsPaid variable
            if (rbtnInstallments.Checked == true)
            {
                _IsPaid = false;
                _PaymentMethodType = 2;
                btnNext.Enabled = true;
                tabInstallmetPage.Enabled = true;
                txtCustomerName2.Text = (cbCustomers.SelectedValue).ToString();
                Load_dgvInstallments();

            }
            else
            {
                _IsPaid = true;
                _PaymentMethodType = 1;
                btnNext.Enabled = false;
                tabInstallmetPage.Enabled = false;


            }
        }


        private void GetCustomerID()
        {
            // Assuming you're trying to access selected customer ID from a ComboBox named cmbCustomer
            if (cbCustomers.SelectedItem != null)
            {
                // Correctly cast the SelectedItem to DataRowView before accessing row values
                DataRowView selectedRow = cbCustomers.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    // Now you can access the "CustomerID" column safely.
                    string PersonName = selectedRow["PersonName"].ToString();

                    // Use the customerID (example: display in a TextBox)
                    _CustomerID = clsCustomersBL.FindCustomerByName(PersonName).CustomerID;
                }
                else
                {
                    // Handle the case where selectedRow is null (no item selected)
                    // For example, you could clear the Customer ID field:
                }
            }
        }
        private void GetProductID()
        {
            // Assuming you're trying to access selected customer ID from a ComboBox named cmbCustomer
            if (cbProducts.SelectedItem != null)
            {
                // Correctly cast the SelectedItem to DataRowView before accessing row values
                DataRowView selectedRow = cbProducts.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    // Now you can access the "CustomerID" column safely.
                    string ProductName = selectedRow["ProductName"].ToString();

                    // Use the customerID (example: display in a TextBox)
                    _ProductID = clsProductsBL.FindProductByName(ProductName).ProductID;
                }
                else
                {
                    // Handle the case where selectedRow is null (no item selected)
                    // For example, you could clear the Customer ID field:
                }
            }
        }

        private void GetGuarantorID()
        {
            // Assuming you're trying to access selected customer ID from a ComboBox named cmbCustomer
            if (cbGuarantors.SelectedItem != null)
            {
                // Correctly cast the SelectedItem to DataRowView before accessing row values
                DataRowView selectedRow = cbGuarantors.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    // Now you can access the "CustomerID" column safely.
                    string PersonName = selectedRow["PersonName"].ToString();

                    // Use the customerID (example: display in a TextBox)
                    _GuarontorID = clsGuarantorsBL.FindGuarantorByName(PersonName).GuarantorID;
                }
                else
                {
                    // Handle the case where selectedRow is null (no item selected)
                    // For example, you could clear the Customer ID field:
                }
            }
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustomerID();
            txtCustomerName2.Text = (cbCustomers.SelectedValue).ToString();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFindCustomerName.Text;
            if (!string.IsNullOrEmpty(filterText))
            {

                DataRow[] filteredRows = dtCustomersNames.Select($"[PersonName] LIKE '%{filterText}%'");

                if (filteredRows.Length > 0)
                {
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    cbCustomers.DataSource = filteredDataTable;

                    cbCustomers.DisplayMember = "PersonName";
                    cbCustomers.ValueMember = "PersonName";

                    //cbCustomers.SelectedIndex = -1; // Prevent selection
                }
                else
                {
                    cbCustomers.DataSource = dtCustomersNames; // Reset to original if no matches
                }
            }
            else
            {
                cbCustomers.DataSource = dtCustomersNames; // Reset to original if no filter
            }
            txtCustomerName2.Text = (cbCustomers.SelectedValue).ToString();
        }

        private void initializeDataGridViewInstallment()
        {
            dgvInstallments.AutoGenerateColumns = false;

            dgvInstallments.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ins. Number",
                DataPropertyName = "InstallmentNumber",
                ReadOnly = true
            });

            dgvInstallments.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Installment Amount",
                DataPropertyName = "InstallmentAmount"
            });
            dgvInstallments.Columns.Add(new DataGridViewTextBoxColumn

            {
                HeaderText = "Due Date",
                DataPropertyName = "DueDate"
            });
            dgvInstallments.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "Status"
            });


        }

        private void Load_dgvInstallments()
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
                return;
            if (_ProductInfo == null)
                return;
            int totalAmount = Convert.ToInt16(_ProductInfo.InstallmentPrice) * Convert.ToInt16(txtQuantity.Text);
            lblAmountOfInstallment.Text = totalAmount.ToString();
            lblInvoiceID2.Text = lblInvoiceID.Text;
            int NumberOfInstallments = Convert.ToInt16(nudNumberOfInstallments.Value);
            DateTime FirstInstallmentDate = dtpDateOfFirstIns.Value;
            string InstallmentPeriod = (cbPeriod.SelectedItem).ToString();
            int InstallmentAmount = totalAmount / NumberOfInstallments;

            DataTable dtInstallments = new DataTable();
            dtInstallments.Columns.Add("InstallmentNumber", typeof(int));
            dtInstallments.Columns.Add("InstallmentAmount", typeof(int));
            dtInstallments.Columns.Add("DueDate", typeof(DateTime));
            dtInstallments.Columns.Add("Status", typeof(int));
            for (int i = 1; i <= NumberOfInstallments; i++)
            {
                DateTime dueDate = FirstInstallmentDate;
                switch (InstallmentPeriod)
                {
                    case "Month":
                        dueDate = dueDate.AddMonths(i - 1);
                        break;
                    case "Week":
                        dueDate = dueDate.AddDays((i - 1) * 7);
                        break;
                    default:
                        dueDate = dueDate.AddMonths(i - 1);
                        break;

                }
                DataRow dr = dtInstallments.NewRow();
                dr["InstallmentNumber"] = i;
                dr["InstallmentAmount"] = InstallmentAmount;
                dr["DueDate"] = dueDate;
                dr["Status"] = 1;
                dtInstallments.Rows.Add(dr);
            }
            dgvInstallments.DataSource = dtInstallments;
            dgvInstallments.Columns[1].Width = 300;
            dgvInstallments.Columns[2].Width = 300;
            ResizeColumnsToFill();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // here i need to open the   tabInstallmetPage  how is that?

            tabControl1.SelectedTab = tabInstallmetPage;
            txtCustomerName2.Text = (cbCustomers.SelectedValue).ToString();

            Load_dgvInstallments();
        }


        private void nudNumberOfInstallments_ValueChanged(object sender, EventArgs e)
        {
            Load_dgvInstallments();
        }

        private void dtpDateOfFirstIns_ValueChanged(object sender, EventArgs e)
        {
            Load_dgvInstallments();

        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_dgvInstallments();

        }

        private void txtGuarantorName_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFindGuarantorName.Text;
            if (!string.IsNullOrEmpty(filterText))
            {

                DataRow[] filteredRows = dtGuarantorsNames.Select($"[PersonName] LIKE '%{filterText}%'");

                if (filteredRows.Length > 0)
                {
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    cbGuarantors.DataSource = filteredDataTable;

                    cbGuarantors.DisplayMember = "PersonName";
                    cbGuarantors.ValueMember = "PersonName";

                    //cbCustomers.SelectedIndex = -1; // Prevent selection
                }
                else
                {
                    cbGuarantors.DataSource = dtGuarantorsNames; // Reset to original if no matches
                }
            }
            else
            {
                cbGuarantors.DataSource = dtGuarantorsNames; // Reset to original if no filter
            }
        }


        private void cbGuarantors_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGuarantorID();

        }

        private void ctrlProductCard1_Load(object sender, EventArgs e)
        {

        }

        private void cbCustomers_Click(object sender, EventArgs e)
        {

        }

        private void txtFindProduct_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFindProduct.Text;
            if (!string.IsNullOrEmpty(filterText))
            {

                DataRow[] filteredRows = dtProductsNames.Select($"[ProductName] LIKE '%{filterText}%'");

                if (filteredRows.Length > 0)
                {
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    cbProducts.DataSource = filteredDataTable;

                    cbProducts.DisplayMember = "ProductName";
                    cbProducts.ValueMember = "ProductName";

                    //cbCustomers.SelectedIndex = -1; // Prevent selection
                }
                else
                {
                    cbProducts.DataSource = dtProductsNames; // Reset to original if no matches
                }
            }
            else
            {
                cbProducts.DataSource = dtProductsNames; // Reset to original if no filter
            }
        }

        private void frmAddUpdateSalesInvoices_Resize(object sender, EventArgs e)
        {
            ResizeColumnsToFill();
        }
    }
}
