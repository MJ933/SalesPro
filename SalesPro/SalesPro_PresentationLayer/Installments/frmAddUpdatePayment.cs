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
using System.Xml.Linq;

namespace SalesPro_PresentationLayer.Installments
{
    public partial class frmAddUpdatePayment : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        private int _InstallmentID;
        clsInstallmentsBL _Installment;


        private int _SaleInvoiceID;
        clsSalesInvoicesBL _SaleInvoice;


        private int _InstallmentPaymentsID;
        clsInstallmentPaymentsBL _InstallmentPayments;

        private int CurrentPayment = 0;

        public frmAddUpdatePayment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
        }


        public frmAddUpdatePayment(int installment_id)
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _InstallmentID = installment_id;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
        }
        public frmAddUpdatePayment(int installment_id, bool update)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _InstallmentID = installment_id;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
        }
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
                _InstallmentPayments = new clsInstallmentPaymentsBL();
            lblPaymentID.Text = "[??????????]";
            lblInvoiceID.Text = "[???????]";
            lblInstallmentPrice.Text = "[??????????]";
            txtCustomerName.Text = "";
            txtGuarantorName.Text = "";
            lblDueDate.Text = "";
            lblInstallmentAmount.Text = "";
            lblOutStandingBalance.Text = "";
            dtpPaymentDate.Value = DateTime.Now;
            txtPaymentAmount.Text = "";
            txtPaymentType.Text = "??????";
            txtPaymentStatus.Text = "?";
            rtxtPaymentNote.Text = "";
        }

        private void _LoadData()
        {
            if (_InstallmentID != 0)
                _Installment = clsInstallmentsBL.FindInstallmentByID(_InstallmentID);




            if (_Installment == null)
            {
                MessageBox.Show($"Installment ID = {_InstallmentID}, was NOT Found");
                return;
            }
            if (_Mode == enMode.Update)
            {
                _InstallmentPayments = clsInstallmentPaymentsBL.FindInstallmentPaymentByInstallmentID(_InstallmentID);
                CurrentPayment = Convert.ToInt16(_InstallmentPayments.PaymentAmount);
            }
            if (_InstallmentPayments != null)
            {
                lblPaymentID.Text = _InstallmentPayments.PaymentID.ToString();
                dtpPaymentDate.Value = _InstallmentPayments.PaymentDate;
                txtPaymentAmount.Text = _InstallmentPayments.PaymentAmount.ToString();
                txtPaymentType.Text = _InstallmentPayments.PaymentType.ToString();
                txtPaymentStatus.Text = _InstallmentPayments.PaymentStatusID.ToString();
                rtxtPaymentNote.Text = _InstallmentPayments.PaymentNotes;
            }
            _SaleInvoice = clsSalesInvoicesBL.FindSalesInvoiceByID(_Installment.SalesInvoiceID);


            lblInvoiceID.Text = _Installment.InstallmentID.ToString();
            lblInstallmentPrice.Text = _Installment.SalesInvoiceItemsInfo.UnitPrice.ToString();
            txtCustomerName.Text = _SaleInvoice.customersInfo.PersonInfo.PersonName.ToString();
            txtGuarantorName.Text = _Installment.GuarantorInfo.PersonInfo.PersonName.ToString();
            lblDueDate.Text = _Installment.DueDate.ToString();
            lblInstallmentAmount.Text = _Installment.SalesInvoiceItemsInfo.UnitPrice.ToString();
            lblOutStandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_Installment.SalesInvoiceID).ToString();


        }

        private void frmRecordInstallmentPayment_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            //if (_Mode == enMode.Update)
            _LoadData();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsValidatoin.IsNumber(txtPaymentAmount.Text))
            {
                if ((clsInstallmentsBL.GetTotalPaymentsByInvoiceID(_Installment.SalesInvoiceID) - CurrentPayment
                    + Convert.ToInt16(txtPaymentAmount.Text)) > _Installment.SalesInvoiceItemsInfo.UnitPrice)
                {
                    MessageBox.Show("Your Payment Amount is Higher than the Outstanding balance!\n" +
                        "Please inter a correct Payment Amount", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please inter an Integer Value");
                return;
            }

            _InstallmentPayments.InstallmentID = _InstallmentID;
            _InstallmentPayments.PaymentDate = dtpPaymentDate.Value;
            _InstallmentPayments.PaymentAmount = Convert.ToInt16(txtPaymentAmount.Text);
            _InstallmentPayments.PaymentType = "????";
            _InstallmentPayments.UserID = clsGlobal.CurrentUser.UserID;
            _InstallmentPayments.PaymentNotes = rtxtPaymentNote.Text;
            _InstallmentPayments.PaymentStatusID = 1;

            if (_InstallmentPayments.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("The Payment has Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPaymentID.Text = _InstallmentPayments.PaymentID.ToString();
                DataBack?.Invoke(this, _InstallmentPayments.PaymentID);

                clsSalesInvoicesBL.UpdateIsPaidIfOutstandingBalanceIsZero(_Installment.SalesInvoiceID);
                // lblOutStandingBalance.Text = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_Installment.SalesInvoiceID).ToString();



            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //DataBack?.Invoke(this, _InstallmentPayments.PaymentID);
            this.Close();
        }

        private void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        {
            //if (clsValidatoin.IsNumber(txtPaymentAmount.Text))
            //{
            //    if (Convert.ToInt16(txtPaymentAmount.Text) > clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_Installment.SalesInvoiceID))
            //    {
            //        MessageBox.Show("Please inter a correct Payment Amount");
            //        return;
            //    }

            //}
            //else
            //    MessageBox.Show("Please inter an Integer Value");

        }

        private void CheckPaymentAmout()
        {
            if (clsValidatoin.IsNumber(txtPaymentAmount.Text))
            {
                if (Convert.ToInt16(txtPaymentAmount.Text) > clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(_Installment.SalesInvoiceID))
                {
                    MessageBox.Show("Please inter a correct Payment Amount");
                    return;
                }

            }
            else
                MessageBox.Show("Please inter an Integer Value");
        }
    }
}
