namespace SalesPro_PresentationLayer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.peopleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPeopleListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProductInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProductInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstallmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInstallmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForInstallmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordInstallmentPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printInstallmentScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCustomerInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackCustomerTransactionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordCustomerDebtsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordCustomerDebtPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateCustomerDebtReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewPurchaseOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackPurchaseOrderStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePurchaseDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSalesInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSalesDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitAndLossReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productMovementReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debtReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashFlowReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guarantorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageGuarantorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewGuarantorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.SystemColors.Menu;
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.msMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem1,
            this.ProductToolStripMenuItem,
            this.InstallmentToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.userToolStripMenuItem,
            this.guarantorsToolStripMenuItem,
            this.suppliersToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(14, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(1431, 41);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            this.msMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.msMain_ItemClicked);
            // 
            // peopleToolStripMenuItem1
            // 
            this.peopleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.showPeopleListToolStripMenuItem});
            this.peopleToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.peopleToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.White;
            this.peopleToolStripMenuItem1.Name = "peopleToolStripMenuItem1";
            this.peopleToolStripMenuItem1.Size = new System.Drawing.Size(107, 33);
            this.peopleToolStripMenuItem1.Text = "People";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // showPeopleListToolStripMenuItem
            // 
            this.showPeopleListToolStripMenuItem.Name = "showPeopleListToolStripMenuItem";
            this.showPeopleListToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.showPeopleListToolStripMenuItem.Text = "Show People List";
            this.showPeopleListToolStripMenuItem.Click += new System.EventHandler(this.showPeopleListToolStripMenuItem_Click);
            // 
            // ProductToolStripMenuItem
            // 
            this.ProductToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductsToolStripMenuItem,
            this.editProductInformationToolStripMenuItem,
            this.searchForProductsToolStripMenuItem,
            this.manageProductInventoryToolStripMenuItem});
            this.ProductToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem";
            this.ProductToolStripMenuItem.Size = new System.Drawing.Size(112, 33);
            this.ProductToolStripMenuItem.Text = "Product";
            // 
            // addNewProductsToolStripMenuItem
            // 
            this.addNewProductsToolStripMenuItem.Name = "addNewProductsToolStripMenuItem";
            this.addNewProductsToolStripMenuItem.Size = new System.Drawing.Size(394, 38);
            this.addNewProductsToolStripMenuItem.Text = "Add New Products";
            this.addNewProductsToolStripMenuItem.Click += new System.EventHandler(this.addNewProductsToolStripMenuItem_Click);
            // 
            // editProductInformationToolStripMenuItem
            // 
            this.editProductInformationToolStripMenuItem.Name = "editProductInformationToolStripMenuItem";
            this.editProductInformationToolStripMenuItem.Size = new System.Drawing.Size(394, 38);
            this.editProductInformationToolStripMenuItem.Text = "Edit Product Information";
            this.editProductInformationToolStripMenuItem.Click += new System.EventHandler(this.editProductInformationToolStripMenuItem_Click);
            // 
            // searchForProductsToolStripMenuItem
            // 
            this.searchForProductsToolStripMenuItem.Name = "searchForProductsToolStripMenuItem";
            this.searchForProductsToolStripMenuItem.Size = new System.Drawing.Size(394, 38);
            this.searchForProductsToolStripMenuItem.Text = "Search for Products";
            this.searchForProductsToolStripMenuItem.Click += new System.EventHandler(this.searchForProductsToolStripMenuItem_Click);
            // 
            // manageProductInventoryToolStripMenuItem
            // 
            this.manageProductInventoryToolStripMenuItem.Name = "manageProductInventoryToolStripMenuItem";
            this.manageProductInventoryToolStripMenuItem.Size = new System.Drawing.Size(394, 38);
            this.manageProductInventoryToolStripMenuItem.Text = "Manage Product Inventory";
            this.manageProductInventoryToolStripMenuItem.Click += new System.EventHandler(this.manageProductInventoryToolStripMenuItem_Click);
            // 
            // InstallmentToolStripMenuItem
            // 
            this.InstallmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewInstallmentsToolStripMenuItem,
            this.searchForInstallmentToolStripMenuItem,
            this.recordInstallmentPaymentsToolStripMenuItem,
            this.printInstallmentScheduleToolStripMenuItem});
            this.InstallmentToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallmentToolStripMenuItem.Name = "InstallmentToolStripMenuItem";
            this.InstallmentToolStripMenuItem.Size = new System.Drawing.Size(144, 33);
            this.InstallmentToolStripMenuItem.Text = "Installment";
            // 
            // viewInstallmentsToolStripMenuItem
            // 
            this.viewInstallmentsToolStripMenuItem.Name = "viewInstallmentsToolStripMenuItem";
            this.viewInstallmentsToolStripMenuItem.Size = new System.Drawing.Size(427, 38);
            this.viewInstallmentsToolStripMenuItem.Text = "View Installments";
            this.viewInstallmentsToolStripMenuItem.Click += new System.EventHandler(this.viewInstallmentsToolStripMenuItem_Click);
            // 
            // searchForInstallmentToolStripMenuItem
            // 
            this.searchForInstallmentToolStripMenuItem.Name = "searchForInstallmentToolStripMenuItem";
            this.searchForInstallmentToolStripMenuItem.Size = new System.Drawing.Size(427, 38);
            this.searchForInstallmentToolStripMenuItem.Text = "Search for Installment";
            // 
            // recordInstallmentPaymentsToolStripMenuItem
            // 
            this.recordInstallmentPaymentsToolStripMenuItem.Name = "recordInstallmentPaymentsToolStripMenuItem";
            this.recordInstallmentPaymentsToolStripMenuItem.Size = new System.Drawing.Size(427, 38);
            this.recordInstallmentPaymentsToolStripMenuItem.Text = "Record Installment Payments";
            // 
            // printInstallmentScheduleToolStripMenuItem
            // 
            this.printInstallmentScheduleToolStripMenuItem.Name = "printInstallmentScheduleToolStripMenuItem";
            this.printInstallmentScheduleToolStripMenuItem.Size = new System.Drawing.Size(427, 38);
            this.printInstallmentScheduleToolStripMenuItem.Text = "Print Installment Schedule";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageCustomersToolStripMenuItem,
            this.editCustomerInformationToolStripMenuItem,
            this.searchForCustomersToolStripMenuItem,
            this.trackCustomerTransactionHistoryToolStripMenuItem,
            this.recordCustomerDebtsToolStripMenuItem,
            this.recordCustomerDebtPaymentsToolStripMenuItem,
            this.generateCustomerDebtReportsToolStripMenuItem});
            this.customerToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(145, 33);
            this.customerToolStripMenuItem.Text = "Customers";
            // 
            // ManageCustomersToolStripMenuItem
            // 
            this.ManageCustomersToolStripMenuItem.Name = "ManageCustomersToolStripMenuItem";
            this.ManageCustomersToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.ManageCustomersToolStripMenuItem.Text = "Manage Customers";
            this.ManageCustomersToolStripMenuItem.Click += new System.EventHandler(this.ManageCustomersToolStripMenuItem_Click);
            // 
            // editCustomerInformationToolStripMenuItem
            // 
            this.editCustomerInformationToolStripMenuItem.Name = "editCustomerInformationToolStripMenuItem";
            this.editCustomerInformationToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.editCustomerInformationToolStripMenuItem.Text = "Edit Customer Information";
            // 
            // searchForCustomersToolStripMenuItem
            // 
            this.searchForCustomersToolStripMenuItem.Name = "searchForCustomersToolStripMenuItem";
            this.searchForCustomersToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.searchForCustomersToolStripMenuItem.Text = "Search for Customers";
            // 
            // trackCustomerTransactionHistoryToolStripMenuItem
            // 
            this.trackCustomerTransactionHistoryToolStripMenuItem.Name = "trackCustomerTransactionHistoryToolStripMenuItem";
            this.trackCustomerTransactionHistoryToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.trackCustomerTransactionHistoryToolStripMenuItem.Text = "Track Customer Transaction History";
            // 
            // recordCustomerDebtsToolStripMenuItem
            // 
            this.recordCustomerDebtsToolStripMenuItem.Name = "recordCustomerDebtsToolStripMenuItem";
            this.recordCustomerDebtsToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.recordCustomerDebtsToolStripMenuItem.Text = "Record Customer Debts";
            // 
            // recordCustomerDebtPaymentsToolStripMenuItem
            // 
            this.recordCustomerDebtPaymentsToolStripMenuItem.Name = "recordCustomerDebtPaymentsToolStripMenuItem";
            this.recordCustomerDebtPaymentsToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.recordCustomerDebtPaymentsToolStripMenuItem.Text = "Record Customer Debt Payments";
            // 
            // generateCustomerDebtReportsToolStripMenuItem
            // 
            this.generateCustomerDebtReportsToolStripMenuItem.Name = "generateCustomerDebtReportsToolStripMenuItem";
            this.generateCustomerDebtReportsToolStripMenuItem.Size = new System.Drawing.Size(499, 38);
            this.generateCustomerDebtReportsToolStripMenuItem.Text = "Generate Customer Debt Reports";
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPurchaseOrdersToolStripMenuItem,
            this.trackPurchaseOrderStatusToolStripMenuItem,
            this.managePurchaseDocumentsToolStripMenuItem});
            this.purchaseToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(130, 33);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            // 
            // createNewPurchaseOrdersToolStripMenuItem
            // 
            this.createNewPurchaseOrdersToolStripMenuItem.Name = "createNewPurchaseOrdersToolStripMenuItem";
            this.createNewPurchaseOrdersToolStripMenuItem.Size = new System.Drawing.Size(437, 38);
            this.createNewPurchaseOrdersToolStripMenuItem.Text = "Create New Purchase Orders";
            // 
            // trackPurchaseOrderStatusToolStripMenuItem
            // 
            this.trackPurchaseOrderStatusToolStripMenuItem.Name = "trackPurchaseOrderStatusToolStripMenuItem";
            this.trackPurchaseOrderStatusToolStripMenuItem.Size = new System.Drawing.Size(437, 38);
            this.trackPurchaseOrderStatusToolStripMenuItem.Text = "Track Purchase Order Status";
            // 
            // managePurchaseDocumentsToolStripMenuItem
            // 
            this.managePurchaseDocumentsToolStripMenuItem.Name = "managePurchaseDocumentsToolStripMenuItem";
            this.managePurchaseDocumentsToolStripMenuItem.Size = new System.Drawing.Size(437, 38);
            this.managePurchaseDocumentsToolStripMenuItem.Text = "Manage Purchase Documents";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewSalesInvoicesToolStripMenuItem,
            this.manageSalesDocumentsToolStripMenuItem});
            this.salesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(90, 33);
            this.salesToolStripMenuItem.Text = "Sales";
            // 
            // createNewSalesInvoicesToolStripMenuItem
            // 
            this.createNewSalesInvoicesToolStripMenuItem.Name = "createNewSalesInvoicesToolStripMenuItem";
            this.createNewSalesInvoicesToolStripMenuItem.Size = new System.Drawing.Size(405, 38);
            this.createNewSalesInvoicesToolStripMenuItem.Text = "Create New Sales Invoices";
            this.createNewSalesInvoicesToolStripMenuItem.Click += new System.EventHandler(this.createNewSalesInvoicesToolStripMenuItem_Click);
            // 
            // manageSalesDocumentsToolStripMenuItem
            // 
            this.manageSalesDocumentsToolStripMenuItem.Name = "manageSalesDocumentsToolStripMenuItem";
            this.manageSalesDocumentsToolStripMenuItem.Size = new System.Drawing.Size(405, 38);
            this.manageSalesDocumentsToolStripMenuItem.Text = "Manage Sales Documents";
            this.manageSalesDocumentsToolStripMenuItem.Click += new System.EventHandler(this.manageSalesDocumentsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryReportsToolStripMenuItem,
            this.salesReportsToolStripMenuItem,
            this.purchaseReportsToolStripMenuItem,
            this.profitAndLossReportsToolStripMenuItem,
            this.productMovementReportsToolStripMenuItem,
            this.customerReportsToolStripMenuItem,
            this.debtReportsToolStripMenuItem,
            this.cashFlowReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(114, 33);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // inventoryReportsToolStripMenuItem
            // 
            this.inventoryReportsToolStripMenuItem.Name = "inventoryReportsToolStripMenuItem";
            this.inventoryReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.inventoryReportsToolStripMenuItem.Text = "Inventory Reports";
            // 
            // salesReportsToolStripMenuItem
            // 
            this.salesReportsToolStripMenuItem.Name = "salesReportsToolStripMenuItem";
            this.salesReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.salesReportsToolStripMenuItem.Text = "Sales Reports";
            // 
            // purchaseReportsToolStripMenuItem
            // 
            this.purchaseReportsToolStripMenuItem.Name = "purchaseReportsToolStripMenuItem";
            this.purchaseReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.purchaseReportsToolStripMenuItem.Text = "Purchase Reports";
            // 
            // profitAndLossReportsToolStripMenuItem
            // 
            this.profitAndLossReportsToolStripMenuItem.Name = "profitAndLossReportsToolStripMenuItem";
            this.profitAndLossReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.profitAndLossReportsToolStripMenuItem.Text = "Profit and Loss Reports";
            // 
            // productMovementReportsToolStripMenuItem
            // 
            this.productMovementReportsToolStripMenuItem.Name = "productMovementReportsToolStripMenuItem";
            this.productMovementReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.productMovementReportsToolStripMenuItem.Text = "Product Movement Reports";
            // 
            // customerReportsToolStripMenuItem
            // 
            this.customerReportsToolStripMenuItem.Name = "customerReportsToolStripMenuItem";
            this.customerReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.customerReportsToolStripMenuItem.Text = "Customer Reports";
            // 
            // debtReportsToolStripMenuItem
            // 
            this.debtReportsToolStripMenuItem.Name = "debtReportsToolStripMenuItem";
            this.debtReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.debtReportsToolStripMenuItem.Text = "Debt Reports";
            // 
            // cashFlowReportsToolStripMenuItem
            // 
            this.cashFlowReportsToolStripMenuItem.Name = "cashFlowReportsToolStripMenuItem";
            this.cashFlowReportsToolStripMenuItem.Size = new System.Drawing.Size(408, 38);
            this.cashFlowReportsToolStripMenuItem.Text = "Cash Flow Reports";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewUsersToolStripMenuItem,
            this.manageUsersToolStripMenuItem});
            this.userToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(92, 33);
            this.userToolStripMenuItem.Text = "Users";
            // 
            // createNewUsersToolStripMenuItem
            // 
            this.createNewUsersToolStripMenuItem.Name = "createNewUsersToolStripMenuItem";
            this.createNewUsersToolStripMenuItem.Size = new System.Drawing.Size(313, 38);
            this.createNewUsersToolStripMenuItem.Text = "Create New Users";
            this.createNewUsersToolStripMenuItem.Click += new System.EventHandler(this.createNewUsersToolStripMenuItem_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(313, 38);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // guarantorsToolStripMenuItem
            // 
            this.guarantorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageGuarantorsToolStripMenuItem,
            this.addNewGuarantorToolStripMenuItem});
            this.guarantorsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guarantorsToolStripMenuItem.Name = "guarantorsToolStripMenuItem";
            this.guarantorsToolStripMenuItem.Size = new System.Drawing.Size(147, 33);
            this.guarantorsToolStripMenuItem.Text = "Guarantors";
            this.guarantorsToolStripMenuItem.Click += new System.EventHandler(this.guarantorsToolStripMenuItem_Click);
            // 
            // manageGuarantorsToolStripMenuItem
            // 
            this.manageGuarantorsToolStripMenuItem.Name = "manageGuarantorsToolStripMenuItem";
            this.manageGuarantorsToolStripMenuItem.Size = new System.Drawing.Size(327, 38);
            this.manageGuarantorsToolStripMenuItem.Text = "Manage Guarantors";
            this.manageGuarantorsToolStripMenuItem.Click += new System.EventHandler(this.manageGuarantorsToolStripMenuItem_Click);
            // 
            // addNewGuarantorToolStripMenuItem
            // 
            this.addNewGuarantorToolStripMenuItem.Name = "addNewGuarantorToolStripMenuItem";
            this.addNewGuarantorToolStripMenuItem.Size = new System.Drawing.Size(327, 38);
            this.addNewGuarantorToolStripMenuItem.Text = "Add New Guarantor";
            this.addNewGuarantorToolStripMenuItem.Click += new System.EventHandler(this.addNewGuarantorToolStripMenuItem_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSuppliersToolStripMenuItem,
            this.addSupplierToolStripMenuItem});
            this.suppliersToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(132, 33);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // manageSuppliersToolStripMenuItem
            // 
            this.manageSuppliersToolStripMenuItem.Name = "manageSuppliersToolStripMenuItem";
            this.manageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(312, 38);
            this.manageSuppliersToolStripMenuItem.Text = "Manage Suppliers";
            this.manageSuppliersToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersToolStripMenuItem_Click);
            // 
            // addSupplierToolStripMenuItem
            // 
            this.addSupplierToolStripMenuItem.Name = "addSupplierToolStripMenuItem";
            this.addSupplierToolStripMenuItem.Size = new System.Drawing.Size(312, 38);
            this.addSupplierToolStripMenuItem.Text = "Add New Supplier";
            this.addSupplierToolStripMenuItem.Click += new System.EventHandler(this.addSupplierToolStripMenuItem_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(139, 378);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(99, 46);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1431, 518);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem ProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InstallmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProductInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProductInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInstallmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForInstallmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordInstallmentPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printInstallmentScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCustomerInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackCustomerTransactionHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordCustomerDebtsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordCustomerDebtPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateCustomerDebtReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewPurchaseOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackPurchaseOrderStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePurchaseDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewSalesInvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSalesDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profitAndLossReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productMovementReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debtReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashFlowReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPeopleListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guarantorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageGuarantorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewGuarantorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.Button btnLogout;
    }
}

