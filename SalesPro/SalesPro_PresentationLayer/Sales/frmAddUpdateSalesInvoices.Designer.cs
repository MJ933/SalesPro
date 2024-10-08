namespace SalesPro_PresentationLayer.Sales
{
    partial class frmAddUpdateSalesInvoices
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.rbtnInstallments = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFindCustomerName = new System.Windows.Forms.TextBox();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProducts = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFindProduct = new System.Windows.Forms.TextBox();
            this.ctrlProductCard1 = new SalesPro_PresentationLayer.Products.ctrlProductCard();
            this.tabInstallmetPage = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.cbGuarantors = new System.Windows.Forms.ComboBox();
            this.txtFindGuarantorName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCustomerName2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblInvoiceID2 = new System.Windows.Forms.Label();
            this.dgvInstallments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAmountOfInstallment = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.nudNumberOfInstallments = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpDateOfFirstIns = new System.Windows.Forms.DateTimePicker();
            this.tabCashPage = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabInstallmetPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfInstallments)).BeginInit();
            this.tabCashPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(444, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Sales";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(889, 792);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(115, 56);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1020, 792);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(115, 56);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(905, 142);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(144, 32);
            this.label3.TabIndex = 18;
            this.label3.Text = "Customer:";
            // 
            // rbtnCash
            // 
            this.rbtnCash.AutoSize = true;
            this.rbtnCash.Checked = true;
            this.rbtnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCash.Location = new System.Drawing.Point(153, 106);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtnCash.Size = new System.Drawing.Size(105, 36);
            this.rbtnCash.TabIndex = 27;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "Cash";
            this.rbtnCash.UseVisualStyleBackColor = true;
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.btnPaymnetMethodChanged);
            // 
            // rbtnInstallments
            // 
            this.rbtnInstallments.AutoSize = true;
            this.rbtnInstallments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnInstallments.Location = new System.Drawing.Point(67, 64);
            this.rbtnInstallments.Name = "rbtnInstallments";
            this.rbtnInstallments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtnInstallments.Size = new System.Drawing.Size(191, 36);
            this.rbtnInstallments.TabIndex = 28;
            this.rbtnInstallments.Text = "Installments";
            this.rbtnInstallments.UseVisualStyleBackColor = true;
            this.rbtnInstallments.CheckedChanged += new System.EventHandler(this.btnPaymnetMethodChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtFindCustomerName);
            this.groupBox1.Controls.Add(this.cbCustomers);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblInvoiceID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbtnCash);
            this.groupBox1.Controls.Add(this.rbtnInstallments);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1094, 198);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Info:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(905, 94);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(177, 29);
            this.label13.TabIndex = 42;
            this.label13.Text = "Find Customer:";
            // 
            // txtFindCustomerName
            // 
            this.txtFindCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindCustomerName.Location = new System.Drawing.Point(576, 94);
            this.txtFindCustomerName.Name = "txtFindCustomerName";
            this.txtFindCustomerName.Size = new System.Drawing.Size(323, 39);
            this.txtFindCustomerName.TabIndex = 37;
            this.txtFindCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // cbCustomers
            // 
            this.cbCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(576, 139);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(323, 40);
            this.cbCustomers.TabIndex = 36;
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
            this.cbCustomers.Click += new System.EventHandler(this.cbCustomers_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 68);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(204, 32);
            this.label5.TabIndex = 35;
            this.label5.Text = "Payment Type:";
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker1.Location = new System.Drawing.Point(79, 22);
            this.DateTimePicker1.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker1.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DateTimePicker1.Size = new System.Drawing.Size(153, 30);
            this.DateTimePicker1.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(264, 22);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(179, 32);
            this.label4.TabIndex = 33;
            this.label4.Text = "Invoice Date:";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.Location = new System.Drawing.Point(769, 35);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvoiceID.Size = new System.Drawing.Size(158, 32);
            this.lblInvoiceID.TabIndex = 32;
            this.lblInvoiceID.Text = "[????????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(933, 36);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 31;
            this.label2.Text = "Invoice ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(468, 41);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(129, 32);
            this.label7.TabIndex = 39;
            this.label7.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(349, 38);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(113, 39);
            this.txtQuantity.TabIndex = 38;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(933, 84);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(120, 32);
            this.label6.TabIndex = 36;
            this.label6.Text = "Product:";
            // 
            // cbProducts
            // 
            this.cbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProducts.FormattingEnabled = true;
            this.cbProducts.Items.AddRange(new object[] {
            "Name",
            "Person ID"});
            this.cbProducts.Location = new System.Drawing.Point(703, 81);
            this.cbProducts.Name = "cbProducts";
            this.cbProducts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbProducts.Size = new System.Drawing.Size(222, 40);
            this.cbProducts.TabIndex = 36;
            this.cbProducts.SelectedIndexChanged += new System.EventHandler(this.cbProducts_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtFindProduct);
            this.groupBox2.Controls.Add(this.ctrlProductCard1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbProducts);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1094, 433);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice Info:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(931, 41);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(156, 29);
            this.label9.TabIndex = 41;
            this.label9.Text = "Find Product:";
            // 
            // txtFindProduct
            // 
            this.txtFindProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindProduct.Location = new System.Drawing.Point(702, 36);
            this.txtFindProduct.Name = "txtFindProduct";
            this.txtFindProduct.Size = new System.Drawing.Size(223, 39);
            this.txtFindProduct.TabIndex = 38;
            this.txtFindProduct.TextChanged += new System.EventHandler(this.txtFindProduct_TextChanged);
            // 
            // ctrlProductCard1
            // 
            this.ctrlProductCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProductCard1.Location = new System.Drawing.Point(53, 129);
            this.ctrlProductCard1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlProductCard1.Name = "ctrlProductCard1";
            this.ctrlProductCard1.Size = new System.Drawing.Size(1033, 296);
            this.ctrlProductCard1.TabIndex = 40;
            this.ctrlProductCard1.Load += new System.EventHandler(this.ctrlProductCard1_Load);
            // 
            // tabInstallmetPage
            // 
            this.tabInstallmetPage.Controls.Add(this.label17);
            this.tabInstallmetPage.Controls.Add(this.cbGuarantors);
            this.tabInstallmetPage.Controls.Add(this.txtFindGuarantorName);
            this.tabInstallmetPage.Controls.Add(this.label16);
            this.tabInstallmetPage.Controls.Add(this.txtCustomerName2);
            this.tabInstallmetPage.Controls.Add(this.label15);
            this.tabInstallmetPage.Controls.Add(this.label14);
            this.tabInstallmetPage.Controls.Add(this.lblInvoiceID2);
            this.tabInstallmetPage.Controls.Add(this.dgvInstallments);
            this.tabInstallmetPage.Controls.Add(this.label8);
            this.tabInstallmetPage.Controls.Add(this.lblAmountOfInstallment);
            this.tabInstallmetPage.Controls.Add(this.label10);
            this.tabInstallmetPage.Controls.Add(this.label11);
            this.tabInstallmetPage.Controls.Add(this.cbPeriod);
            this.tabInstallmetPage.Controls.Add(this.nudNumberOfInstallments);
            this.tabInstallmetPage.Controls.Add(this.label12);
            this.tabInstallmetPage.Controls.Add(this.dtpDateOfFirstIns);
            this.tabInstallmetPage.Location = new System.Drawing.Point(4, 29);
            this.tabInstallmetPage.Name = "tabInstallmetPage";
            this.tabInstallmetPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstallmetPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabInstallmetPage.Size = new System.Drawing.Size(1115, 697);
            this.tabInstallmetPage.TabIndex = 1;
            this.tabInstallmetPage.Text = "Installment Page";
            this.tabInstallmetPage.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(364, 136);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(179, 29);
            this.label17.TabIndex = 45;
            this.label17.Text = "Find Guarantor:";
            // 
            // cbGuarantors
            // 
            this.cbGuarantors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGuarantors.FormattingEnabled = true;
            this.cbGuarantors.Items.AddRange(new object[] {
            "Month",
            "Week"});
            this.cbGuarantors.Location = new System.Drawing.Point(49, 186);
            this.cbGuarantors.Name = "cbGuarantors";
            this.cbGuarantors.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGuarantors.Size = new System.Drawing.Size(309, 37);
            this.cbGuarantors.TabIndex = 44;
            this.cbGuarantors.SelectedIndexChanged += new System.EventHandler(this.cbGuarantors_SelectedIndexChanged);
            // 
            // txtFindGuarantorName
            // 
            this.txtFindGuarantorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindGuarantorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindGuarantorName.Location = new System.Drawing.Point(49, 130);
            this.txtFindGuarantorName.Name = "txtFindGuarantorName";
            this.txtFindGuarantorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFindGuarantorName.Size = new System.Drawing.Size(309, 35);
            this.txtFindGuarantorName.TabIndex = 43;
            this.txtFindGuarantorName.TextChanged += new System.EventHandler(this.txtGuarantorName_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(364, 190);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(150, 32);
            this.label16.TabIndex = 41;
            this.label16.Text = "Guarantor:";
            // 
            // txtCustomerName2
            // 
            this.txtCustomerName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName2.Location = new System.Drawing.Point(49, 73);
            this.txtCustomerName2.Name = "txtCustomerName2";
            this.txtCustomerName2.ReadOnly = true;
            this.txtCustomerName2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName2.Size = new System.Drawing.Size(309, 35);
            this.txtCustomerName2.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(364, 76);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(144, 32);
            this.label15.TabIndex = 38;
            this.label15.Text = "Customer:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(840, 11);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(146, 32);
            this.label14.TabIndex = 34;
            this.label14.Text = "Invoice ID:";
            // 
            // lblInvoiceID2
            // 
            this.lblInvoiceID2.AutoSize = true;
            this.lblInvoiceID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID2.Location = new System.Drawing.Point(697, 11);
            this.lblInvoiceID2.Name = "lblInvoiceID2";
            this.lblInvoiceID2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvoiceID2.Size = new System.Drawing.Size(110, 32);
            this.lblInvoiceID2.TabIndex = 33;
            this.lblInvoiceID2.Text = "[?????]";
            // 
            // dgvInstallments
            // 
            this.dgvInstallments.AllowUserToAddRows = false;
            this.dgvInstallments.AllowUserToDeleteRows = false;
            this.dgvInstallments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstallments.Location = new System.Drawing.Point(17, 286);
            this.dgvInstallments.Name = "dgvInstallments";
            this.dgvInstallments.ReadOnly = true;
            this.dgvInstallments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvInstallments.RowHeadersWidth = 62;
            this.dgvInstallments.RowTemplate.Height = 28;
            this.dgvInstallments.Size = new System.Drawing.Size(1092, 369);
            this.dgvInstallments.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(840, 235);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(231, 29);
            this.label8.TabIndex = 17;
            this.label8.Text = ".period between Ins:";
            // 
            // lblAmountOfInstallment
            // 
            this.lblAmountOfInstallment.AutoSize = true;
            this.lblAmountOfInstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountOfInstallment.Location = new System.Drawing.Point(671, 126);
            this.lblAmountOfInstallment.Name = "lblAmountOfInstallment";
            this.lblAmountOfInstallment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAmountOfInstallment.Size = new System.Drawing.Size(135, 29);
            this.lblAmountOfInstallment.TabIndex = 16;
            this.lblAmountOfInstallment.Text = "[?????????]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(840, 126);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(264, 29);
            this.label10.TabIndex = 15;
            this.label10.Text = "Amount Of Installments:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(840, 186);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(245, 29);
            this.label11.TabIndex = 14;
            this.label11.Text = ".Date Of The First Ins:";
            // 
            // cbPeriod
            // 
            this.cbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
            "Month",
            "Week"});
            this.cbPeriod.Location = new System.Drawing.Point(639, 235);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPeriod.Size = new System.Drawing.Size(162, 37);
            this.cbPeriod.TabIndex = 13;
            this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
            // 
            // nudNumberOfInstallments
            // 
            this.nudNumberOfInstallments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberOfInstallments.Location = new System.Drawing.Point(717, 67);
            this.nudNumberOfInstallments.Name = "nudNumberOfInstallments";
            this.nudNumberOfInstallments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nudNumberOfInstallments.Size = new System.Drawing.Size(84, 35);
            this.nudNumberOfInstallments.TabIndex = 12;
            this.nudNumberOfInstallments.ValueChanged += new System.EventHandler(this.nudNumberOfInstallments_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(840, 69);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(270, 29);
            this.label12.TabIndex = 10;
            this.label12.Text = "Number Of Installments:";
            // 
            // dtpDateOfFirstIns
            // 
            this.dtpDateOfFirstIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfFirstIns.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfFirstIns.Location = new System.Drawing.Point(623, 181);
            this.dtpDateOfFirstIns.Name = "dtpDateOfFirstIns";
            this.dtpDateOfFirstIns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDateOfFirstIns.Size = new System.Drawing.Size(178, 35);
            this.dtpDateOfFirstIns.TabIndex = 9;
            this.dtpDateOfFirstIns.ValueChanged += new System.EventHandler(this.dtpDateOfFirstIns_ValueChanged);
            // 
            // tabCashPage
            // 
            this.tabCashPage.Controls.Add(this.btnNext);
            this.tabCashPage.Controls.Add(this.groupBox1);
            this.tabCashPage.Controls.Add(this.groupBox2);
            this.tabCashPage.Location = new System.Drawing.Point(4, 29);
            this.tabCashPage.Name = "tabCashPage";
            this.tabCashPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabCashPage.Size = new System.Drawing.Size(1115, 697);
            this.tabCashPage.TabIndex = 0;
            this.tabCashPage.Text = "Cash Page";
            this.tabCashPage.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(974, 641);
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNext.Size = new System.Drawing.Size(126, 50);
            this.btnNext.TabIndex = 39;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCashPage);
            this.tabControl1.Controls.Add(this.tabInstallmetPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1123, 730);
            this.tabControl1.TabIndex = 38;
            // 
            // frmAddUpdateSalesInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 876);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "frmAddUpdateSalesInvoices";
            this.Text = "frmAddUpdateSalesInvoices";
            this.Load += new System.EventHandler(this.frmAddUpdateSalesInvoices_Load);
            this.Resize += new System.EventHandler(this.frmAddUpdateSalesInvoices_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabInstallmetPage.ResumeLayout(false);
            this.tabInstallmetPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfInstallments)).EndInit();
            this.tabCashPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.RadioButton rbtnInstallments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker DateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProducts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.TextBox txtFindCustomerName;
        private System.Windows.Forms.TabPage tabInstallmetPage;
        private System.Windows.Forms.TabPage tabCashPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAmountOfInstallment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.NumericUpDown nudNumberOfInstallments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDateOfFirstIns;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvInstallments;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtFindGuarantorName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCustomerName2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblInvoiceID2;
        private System.Windows.Forms.ComboBox cbGuarantors;
        private Products.ctrlProductCard ctrlProductCard1;
        private System.Windows.Forms.TextBox txtFindProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
    }
}