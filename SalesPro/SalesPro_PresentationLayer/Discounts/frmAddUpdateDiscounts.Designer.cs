namespace SalesPro_PresentationLayer.Discounts
{
    partial class frmAddUpdateDiscounts
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
            this.lblInvoiceID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDiscountTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiscountValue = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpDiscountDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblDiscountDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInvoiceID
            // 
            this.lblInvoiceID.AutoSize = true;
            this.lblInvoiceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceID.Location = new System.Drawing.Point(195, 31);
            this.lblInvoiceID.Name = "lblInvoiceID";
            this.lblInvoiceID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvoiceID.Size = new System.Drawing.Size(158, 32);
            this.lblInvoiceID.TabIndex = 34;
            this.lblInvoiceID.Text = "[????????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(359, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 33;
            this.label2.Text = "Invoice ID:";
            // 
            // cbDiscountTypes
            // 
            this.cbDiscountTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDiscountTypes.FormattingEnabled = true;
            this.cbDiscountTypes.Items.AddRange(new object[] {
            "Fixed Amount",
            "Percentage"});
            this.cbDiscountTypes.Location = new System.Drawing.Point(111, 81);
            this.cbDiscountTypes.Name = "cbDiscountTypes";
            this.cbDiscountTypes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDiscountTypes.Size = new System.Drawing.Size(242, 40);
            this.cbDiscountTypes.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 81);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(203, 32);
            this.label3.TabIndex = 37;
            this.label3.Text = "Discount Type:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(359, 136);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(214, 32);
            this.label13.TabIndex = 44;
            this.label13.Text = "Discount Value:";
            // 
            // txtDiscountValue
            // 
            this.txtDiscountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountValue.Location = new System.Drawing.Point(111, 134);
            this.txtDiscountValue.Name = "txtDiscountValue";
            this.txtDiscountValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscountValue.Size = new System.Drawing.Size(242, 39);
            this.txtDiscountValue.TabIndex = 43;
            this.txtDiscountValue.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(333, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(115, 56);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(454, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(115, 56);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtpDiscountDate
            // 
            this.dtpDiscountDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDiscountDate.Location = new System.Drawing.Point(126, 193);
            this.dtpDiscountDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtpDiscountDate.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dtpDiscountDate.Name = "dtpDiscountDate";
            this.dtpDiscountDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDiscountDate.Size = new System.Drawing.Size(227, 30);
            this.dtpDiscountDate.TabIndex = 52;
            // 
            // lblDiscountDate
            // 
            this.lblDiscountDate.AutoSize = true;
            this.lblDiscountDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountDate.Location = new System.Drawing.Point(359, 193);
            this.lblDiscountDate.Name = "lblDiscountDate";
            this.lblDiscountDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscountDate.Size = new System.Drawing.Size(82, 32);
            this.lblDiscountDate.TabIndex = 51;
            this.lblDiscountDate.Text = "Date:";
            // 
            // frmAddUpdateDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 369);
            this.Controls.Add(this.dtpDiscountDate);
            this.Controls.Add(this.lblDiscountDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDiscountValue);
            this.Controls.Add(this.cbDiscountTypes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblInvoiceID);
            this.Controls.Add(this.label2);
            this.Name = "frmAddUpdateDiscounts";
            this.Text = "frmAddUpdateDiscounts";
            this.Load += new System.EventHandler(this.frmAddUpdateDiscounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInvoiceID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDiscountTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiscountValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpDiscountDate;
        private System.Windows.Forms.Label lblDiscountDate;
    }
}