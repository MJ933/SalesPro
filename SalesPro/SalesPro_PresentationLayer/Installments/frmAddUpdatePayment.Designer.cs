namespace SalesPro_PresentationLayer.Installments
{
    partial class frmAddUpdatePayment
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.txtPaymentStatus = new System.Windows.Forms.TextBox();
            this.txtPaymentType = new System.Windows.Forms.TextBox();
            this.rtxtPaymentNote = new System.Windows.Forms.RichTextBox();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOutStandingBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInstallmentAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtGuarantorName = new System.Windows.Forms.TextBox();
            this.lblInstallmentPrice = new System.Windows.Forms.Label();
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPaymentID);
            this.groupBox1.Controls.Add(this.txtPaymentStatus);
            this.groupBox1.Controls.Add(this.txtPaymentType);
            this.groupBox1.Controls.Add(this.rtxtPaymentNote);
            this.groupBox1.Controls.Add(this.txtPaymentAmount);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblOutStandingBalance);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblInstallmentAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDueDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtGuarantorName);
            this.groupBox1.Controls.Add(this.lblInstallmentPrice);
            this.groupBox1.Controls.Add(this.lblInvoiceID);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1280, 455);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Installment Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1045, 22);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(175, 32);
            this.label3.TabIndex = 79;
            this.label3.Text = "Payment  ID:";
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentID.Location = new System.Drawing.Point(833, 22);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaymentID.Size = new System.Drawing.Size(206, 32);
            this.lblPaymentID.TabIndex = 78;
            this.lblPaymentID.Text = "[???????????]";
            // 
            // txtPaymentStatus
            // 
            this.txtPaymentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentStatus.Location = new System.Drawing.Point(38, 255);
            this.txtPaymentStatus.Name = "txtPaymentStatus";
            this.txtPaymentStatus.ReadOnly = true;
            this.txtPaymentStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaymentStatus.Size = new System.Drawing.Size(278, 39);
            this.txtPaymentStatus.TabIndex = 77;
            // 
            // txtPaymentType
            // 
            this.txtPaymentType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentType.Location = new System.Drawing.Point(38, 207);
            this.txtPaymentType.Name = "txtPaymentType";
            this.txtPaymentType.ReadOnly = true;
            this.txtPaymentType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaymentType.Size = new System.Drawing.Size(278, 39);
            this.txtPaymentType.TabIndex = 76;
            // 
            // rtxtPaymentNote
            // 
            this.rtxtPaymentNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtPaymentNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtPaymentNote.Location = new System.Drawing.Point(38, 318);
            this.rtxtPaymentNote.Name = "rtxtPaymentNote";
            this.rtxtPaymentNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtxtPaymentNote.Size = new System.Drawing.Size(1001, 128);
            this.rtxtPaymentNote.TabIndex = 75;
            this.rtxtPaymentNote.Text = "";
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentAmount.Location = new System.Drawing.Point(38, 159);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaymentAmount.Size = new System.Drawing.Size(278, 39);
            this.txtPaymentAmount.TabIndex = 74;
            this.txtPaymentAmount.TextChanged += new System.EventHandler(this.txtPaymentAmount_TextChanged);
            this.txtPaymentAmount.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(101, 114);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.RightToLeftLayout = true;
            this.dtpPaymentDate.Size = new System.Drawing.Size(215, 39);
            this.dtpPaymentDate.TabIndex = 74;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(328, 262);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label19.Size = new System.Drawing.Size(222, 32);
            this.label19.TabIndex = 72;
            this.label19.Text = "Payment Status:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1045, 308);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(215, 32);
            this.label17.TabIndex = 70;
            this.label17.Text = "Payment Notes:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(328, 212);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(204, 32);
            this.label13.TabIndex = 68;
            this.label13.Text = "Payment Type:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(328, 164);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(239, 32);
            this.label11.TabIndex = 62;
            this.label11.Text = "Payment Amount:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(328, 114);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(201, 32);
            this.label8.TabIndex = 66;
            this.label8.Text = "Payment Date:";
            // 
            // lblOutStandingBalance
            // 
            this.lblOutStandingBalance.AutoSize = true;
            this.lblOutStandingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutStandingBalance.Location = new System.Drawing.Point(148, 70);
            this.lblOutStandingBalance.Name = "lblOutStandingBalance";
            this.lblOutStandingBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOutStandingBalance.Size = new System.Drawing.Size(174, 32);
            this.lblOutStandingBalance.TabIndex = 65;
            this.lblOutStandingBalance.Text = "[?????????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(328, 70);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(288, 32);
            this.label6.TabIndex = 64;
            this.label6.Text = "Outstanding Balance:";
            // 
            // lblInstallmentAmount
            // 
            this.lblInstallmentAmount.AutoSize = true;
            this.lblInstallmentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallmentAmount.Location = new System.Drawing.Point(148, 22);
            this.lblInstallmentAmount.Name = "lblInstallmentAmount";
            this.lblInstallmentAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInstallmentAmount.Size = new System.Drawing.Size(174, 32);
            this.lblInstallmentAmount.TabIndex = 63;
            this.lblInstallmentAmount.Text = "[?????????]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 22);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(172, 32);
            this.label4.TabIndex = 62;
            this.label4.Text = "Ins. Amount:";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(761, 262);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDueDate.Size = new System.Drawing.Size(174, 32);
            this.lblDueDate.TabIndex = 61;
            this.lblDueDate.Text = "[?????????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1045, 262);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 60;
            this.label1.Text = "Due Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1045, 70);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 55;
            this.label2.Text = "Invoice ID:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1045, 166);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(144, 32);
            this.label15.TabIndex = 56;
            this.label15.Text = "Customer:";
            // 
            // txtGuarantorName
            // 
            this.txtGuarantorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuarantorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuarantorName.Location = new System.Drawing.Point(761, 212);
            this.txtGuarantorName.Name = "txtGuarantorName";
            this.txtGuarantorName.ReadOnly = true;
            this.txtGuarantorName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGuarantorName.Size = new System.Drawing.Size(278, 39);
            this.txtGuarantorName.TabIndex = 59;
            // 
            // lblInstallmentPrice
            // 
            this.lblInstallmentPrice.AutoSize = true;
            this.lblInstallmentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallmentPrice.Location = new System.Drawing.Point(865, 114);
            this.lblInstallmentPrice.Name = "lblInstallmentPrice";
            this.lblInstallmentPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInstallmentPrice.Size = new System.Drawing.Size(174, 32);
            this.lblInstallmentPrice.TabIndex = 51;
            this.lblInstallmentPrice.Text = "[?????????]";
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.Location = new System.Drawing.Point(833, 70);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvoiceID.Size = new System.Drawing.Size(206, 32);
            this.lblInvoiceID.TabIndex = 54;
            this.lblInvoiceID.Text = "[???????????]";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(761, 162);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerName.Size = new System.Drawing.Size(278, 39);
            this.txtCustomerName.TabIndex = 57;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1045, 214);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(150, 32);
            this.label16.TabIndex = 58;
            this.label16.Text = "Guarantor:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1045, 118);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(139, 32);
            this.label10.TabIndex = 50;
            this.label10.Text = "Ins. Price:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1176, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 62);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(939, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 62);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdatePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddUpdatePayment";
            this.Text = "frmAddUpdatePayment";
            this.Load += new System.EventHandler(this.frmRecordInstallmentPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.Label lblInstallmentPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOutStandingBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInstallmentAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.RichTextBox rtxtPaymentNote;
        private System.Windows.Forms.TextBox txtPaymentStatus;
        private System.Windows.Forms.TextBox txtPaymentType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPaymentID;
    }
}