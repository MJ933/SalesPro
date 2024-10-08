namespace SalesPro_PresentationLayer.Installments
{
    partial class ctrlInstallmentCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateDiscount = new System.Windows.Forms.Button();
            this.btnAddDiscount = new System.Windows.Forms.Button();
            this.txtPriceAfterDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPriceBeforeDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInstallmentPrice = new System.Windows.Forms.TextBox();
            this.txtOutstandingBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LLCustomerInfo = new System.Windows.Forms.LinkLabel();
            this.LLGuarantorInfo = new System.Windows.Forms.LinkLabel();
            this.LLProductInfo = new System.Windows.Forms.LinkLabel();
            this.txtGuarantorName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.dgvInstallments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpdateDiscount);
            this.groupBox1.Controls.Add(this.btnAddDiscount);
            this.groupBox1.Controls.Add(this.txtPriceAfterDiscount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPriceBeforeDiscount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInstallmentPrice);
            this.groupBox1.Controls.Add(this.txtOutstandingBalance);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LLCustomerInfo);
            this.groupBox1.Controls.Add(this.LLGuarantorInfo);
            this.groupBox1.Controls.Add(this.LLProductInfo);
            this.groupBox1.Controls.Add(this.txtGuarantorName);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblInvoiceID);
            this.groupBox1.Controls.Add(this.dgvInstallments);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1352, 736);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Installment Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnUpdateDiscount
            // 
            this.btnUpdateDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDiscount.Location = new System.Drawing.Point(291, 258);
            this.btnUpdateDiscount.Name = "btnUpdateDiscount";
            this.btnUpdateDiscount.Size = new System.Drawing.Size(264, 50);
            this.btnUpdateDiscount.TabIndex = 78;
            this.btnUpdateDiscount.Text = "Update Discount";
            this.btnUpdateDiscount.UseVisualStyleBackColor = true;
            this.btnUpdateDiscount.Click += new System.EventHandler(this.btnUpdateDiscount_Click);
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDiscount.Location = new System.Drawing.Point(21, 258);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(264, 50);
            this.btnAddDiscount.TabIndex = 77;
            this.btnAddDiscount.Text = "Add Discount";
            this.btnAddDiscount.UseVisualStyleBackColor = true;
            this.btnAddDiscount.Click += new System.EventHandler(this.btnAddDiscount_Click);
            // 
            // txtPriceAfterDiscount
            // 
            this.txtPriceAfterDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriceAfterDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceAfterDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceAfterDiscount.Location = new System.Drawing.Point(649, 269);
            this.txtPriceAfterDiscount.Name = "txtPriceAfterDiscount";
            this.txtPriceAfterDiscount.ReadOnly = true;
            this.txtPriceAfterDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceAfterDiscount.Size = new System.Drawing.Size(386, 39);
            this.txtPriceAfterDiscount.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1047, 271);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(272, 32);
            this.label5.TabIndex = 75;
            this.label5.Text = "Price After Discount:";
            // 
            // txtPriceBeforeDiscount
            // 
            this.txtPriceBeforeDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriceBeforeDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceBeforeDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceBeforeDiscount.Location = new System.Drawing.Point(649, 224);
            this.txtPriceBeforeDiscount.Name = "txtPriceBeforeDiscount";
            this.txtPriceBeforeDiscount.ReadOnly = true;
            this.txtPriceBeforeDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceBeforeDiscount.Size = new System.Drawing.Size(386, 39);
            this.txtPriceBeforeDiscount.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1047, 226);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(296, 32);
            this.label6.TabIndex = 73;
            this.label6.Text = "Price Before Discount:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(21, 121);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.Size = new System.Drawing.Size(304, 39);
            this.txtQuantity.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 123);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(129, 32);
            this.label3.TabIndex = 71;
            this.label3.Text = "Quantity:";
            // 
            // txtProductName
            // 
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(21, 73);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProductName.Size = new System.Drawing.Size(304, 39);
            this.txtProductName.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 75);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(202, 32);
            this.label1.TabIndex = 69;
            this.label1.Text = "Product Name:";
            // 
            // txtInstallmentPrice
            // 
            this.txtInstallmentPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallmentPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstallmentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallmentPrice.Location = new System.Drawing.Point(799, 73);
            this.txtInstallmentPrice.Name = "txtInstallmentPrice";
            this.txtInstallmentPrice.ReadOnly = true;
            this.txtInstallmentPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInstallmentPrice.Size = new System.Drawing.Size(304, 39);
            this.txtInstallmentPrice.TabIndex = 68;
            // 
            // txtOutstandingBalance
            // 
            this.txtOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutstandingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutstandingBalance.Location = new System.Drawing.Point(21, 25);
            this.txtOutstandingBalance.Name = "txtOutstandingBalance";
            this.txtOutstandingBalance.ReadOnly = true;
            this.txtOutstandingBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOutstandingBalance.Size = new System.Drawing.Size(304, 39);
            this.txtOutstandingBalance.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(331, 27);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(288, 32);
            this.label4.TabIndex = 65;
            this.label4.Text = "Outstanding Balance:";
            // 
            // LLCustomerInfo
            // 
            this.LLCustomerInfo.AutoSize = true;
            this.LLCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLCustomerInfo.Location = new System.Drawing.Point(174, 213);
            this.LLCustomerInfo.Name = "LLCustomerInfo";
            this.LLCustomerInfo.Size = new System.Drawing.Size(156, 29);
            this.LLCustomerInfo.TabIndex = 64;
            this.LLCustomerInfo.TabStop = true;
            this.LLCustomerInfo.Text = "CustomerInfo";
            this.LLCustomerInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLCustomerInfo_LinkClicked);
            // 
            // LLGuarantorInfo
            // 
            this.LLGuarantorInfo.AutoSize = true;
            this.LLGuarantorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLGuarantorInfo.Location = new System.Drawing.Point(351, 213);
            this.LLGuarantorInfo.Name = "LLGuarantorInfo";
            this.LLGuarantorInfo.Size = new System.Drawing.Size(158, 29);
            this.LLGuarantorInfo.TabIndex = 63;
            this.LLGuarantorInfo.TabStop = true;
            this.LLGuarantorInfo.Text = "GuarantorInfo";
            this.LLGuarantorInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLGuarantorInfo_LinkClicked);
            // 
            // LLProductInfo
            // 
            this.LLProductInfo.AutoSize = true;
            this.LLProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLProductInfo.Location = new System.Drawing.Point(21, 213);
            this.LLProductInfo.Name = "LLProductInfo";
            this.LLProductInfo.Size = new System.Drawing.Size(135, 29);
            this.LLProductInfo.TabIndex = 61;
            this.LLProductInfo.TabStop = true;
            this.LLProductInfo.Text = "ProductInfo";
            this.LLProductInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLProductInfo_LinkClicked);
            // 
            // txtGuarantorName
            // 
            this.txtGuarantorName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGuarantorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuarantorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuarantorName.Location = new System.Drawing.Point(717, 168);
            this.txtGuarantorName.Name = "txtGuarantorName";
            this.txtGuarantorName.ReadOnly = true;
            this.txtGuarantorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGuarantorName.Size = new System.Drawing.Size(386, 39);
            this.txtGuarantorName.TabIndex = 59;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1115, 170);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(150, 32);
            this.label16.TabIndex = 58;
            this.label16.Text = "Guarantor:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(717, 121);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.Size = new System.Drawing.Size(386, 39);
            this.txtCustomerName.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1115, 123);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(144, 32);
            this.label15.TabIndex = 56;
            this.label15.Text = "Customer:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1115, 29);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 55;
            this.label2.Text = "Invoice ID:";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.Location = new System.Drawing.Point(999, 29);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvoiceID.Size = new System.Drawing.Size(110, 32);
            this.lblInvoiceID.TabIndex = 54;
            this.lblInvoiceID.Text = "[?????]";
            // 
            // dgvInstallments
            // 
            this.dgvInstallments.AllowUserToAddRows = false;
            this.dgvInstallments.AllowUserToDeleteRows = false;
            this.dgvInstallments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInstallments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstallments.Location = new System.Drawing.Point(6, 313);
            this.dgvInstallments.Name = "dgvInstallments";
            this.dgvInstallments.ReadOnly = true;
            this.dgvInstallments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvInstallments.RowHeadersWidth = 62;
            this.dgvInstallments.RowTemplate.Height = 28;
            this.dgvInstallments.Size = new System.Drawing.Size(1336, 418);
            this.dgvInstallments.TabIndex = 53;
            this.dgvInstallments.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInstallments_CellMouseClick);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1115, 73);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(232, 32);
            this.label10.TabIndex = 50;
            this.label10.Text = "Installment Price:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.updatePaymentToolStripMenuItem,
            this.recordPaymentToolStripMenuItem,
            this.printPaymentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 165);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            // 
            // updatePaymentToolStripMenuItem
            // 
            this.updatePaymentToolStripMenuItem.Name = "updatePaymentToolStripMenuItem";
            this.updatePaymentToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.updatePaymentToolStripMenuItem.Text = "Update Payment";
            this.updatePaymentToolStripMenuItem.Click += new System.EventHandler(this.updatePaymentToolStripMenuItem_Click);
            // 
            // recordPaymentToolStripMenuItem
            // 
            this.recordPaymentToolStripMenuItem.Name = "recordPaymentToolStripMenuItem";
            this.recordPaymentToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.recordPaymentToolStripMenuItem.Text = "Record Payment";
            this.recordPaymentToolStripMenuItem.Click += new System.EventHandler(this.recordPaymentToolStripMenuItem_Click);
            // 
            // printPaymentToolStripMenuItem
            // 
            this.printPaymentToolStripMenuItem.Name = "printPaymentToolStripMenuItem";
            this.printPaymentToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.printPaymentToolStripMenuItem.Text = "Print Payment";
            this.printPaymentToolStripMenuItem.Click += new System.EventHandler(this.printPaymentToolStripMenuItem_Click);
            // 
            // ctrlInstallmentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlInstallmentCard";
            this.Size = new System.Drawing.Size(1359, 741);
            this.Load += new System.EventHandler(this.InstallmentCard_Load);
            this.Resize += new System.EventHandler(this.ctrlInstallmentCard_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGuarantorName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvInstallments;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel LLCustomerInfo;
        private System.Windows.Forms.LinkLabel LLGuarantorInfo;
        private System.Windows.Forms.LinkLabel LLProductInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordPaymentToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInstallmentPrice;
        private System.Windows.Forms.TextBox txtOutstandingBalance;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPriceAfterDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPriceBeforeDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddDiscount;
        private System.Windows.Forms.Button btnUpdateDiscount;
        private System.Windows.Forms.ToolStripMenuItem printPaymentToolStripMenuItem;
    }
}
