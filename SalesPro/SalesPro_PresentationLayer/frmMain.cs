using SalesPro_PresentationLayer.Customers;
using SalesPro_PresentationLayer.Customers_Guarantors_Suppliers;
using SalesPro_PresentationLayer.Global_Classes;
using SalesPro_PresentationLayer.Installments;
using SalesPro_PresentationLayer.Login;
using SalesPro_PresentationLayer.People;
using SalesPro_PresentationLayer.Products;
using SalesPro_PresentationLayer.Sales;
using SalesPro_PresentationLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }


        private void msMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void manageProductInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new ManageProductInventory();
            frm.ShowDialog();
        }

        private void showPeopleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManagePeopleList();
            frm.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Update = true;
            Form frm = new frmFindPerson(Update);

            frm.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmFindPerson();
            frm.ShowDialog();
        }

        private void addNewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateProduct();
            frm.ShowDialog();
        }

        private void searchForProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmFindProduct();
            frm.ShowDialog();
        }

        private void editProductInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Update = true;
            Form frm = new frmFindProduct(Update);
            frm.ShowDialog();
        }

        private void ManageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageCustomers();
            frm.ShowDialog();
        }

        private void createNewSalesInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateSalesInvoices();
            frm.ShowDialog();
        }

        private void manageSalesDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageSalesInvoices();
            frm.ShowDialog();
        }

        private void viewInstallmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageInstallments();
            frm.ShowDialog();
        }

        private void guarantorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageGuarantorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageGuarantors();
            frm.ShowDialog();
        }

        private void addNewGuarantorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateGuarantors();
        }

        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageSuppliers();
            frm.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateSupplier();
            frm.ShowDialog();
        }

        private void createNewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // Only close _frmLogin if the user clicked the "X" button
            {
                if (_frmLogin != null)
                {
                    _frmLogin.Show();
                }
            }

            // You can also add any necessary cleanup code here if needed.
        }
    }
}
