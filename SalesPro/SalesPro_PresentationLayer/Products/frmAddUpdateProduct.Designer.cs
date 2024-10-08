namespace SalesPro_PresentationLayer.Products
{
    partial class frmAddUpdateProduct
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPurshesPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInstallmentPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSuppliersNames = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(402, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(211, 32);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Update Product";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.Location = new System.Drawing.Point(776, 32);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(84, 26);
            this.lblProductID.TabIndex = 17;
            this.lblProductID.Text = "[?????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(983, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(573, 109);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(282, 35);
            this.txtDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(946, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(500, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(355, 35);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(896, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(926, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 56);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPurshesPrice
            // 
            this.txtPurshesPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurshesPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurshesPrice.Location = new System.Drawing.Point(573, 152);
            this.txtPurshesPrice.Name = "txtPurshesPrice";
            this.txtPurshesPrice.Size = new System.Drawing.Size(282, 35);
            this.txtPurshesPrice.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(329, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Supplier Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(883, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "Selling Price";
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQuantity.Location = new System.Drawing.Point(24, 109);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.Size = new System.Drawing.Size(282, 35);
            this.txtStockQuantity.TabIndex = 10;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingPrice.Location = new System.Drawing.Point(573, 195);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(282, 35);
            this.txtSellingPrice.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(329, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 26);
            this.label9.TabIndex = 9;
            this.label9.Text = "Stock Quantity";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(789, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 56);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(869, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Purshes Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInstallmentPrice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbSuppliersNames);
            this.groupBox1.Controls.Add(this.lblProductID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPurshesPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtStockQuantity);
            this.groupBox1.Controls.Add(this.txtSellingPrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(49, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1023, 307);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Product";
            // 
            // txtInstallmentPrice
            // 
            this.txtInstallmentPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstallmentPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallmentPrice.Location = new System.Drawing.Point(24, 203);
            this.txtInstallmentPrice.Name = "txtInstallmentPrice";
            this.txtInstallmentPrice.Size = new System.Drawing.Size(282, 35);
            this.txtInstallmentPrice.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(329, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "Installment Price";
            // 
            // cbSuppliersNames
            // 
            this.cbSuppliersNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSuppliersNames.FormattingEnabled = true;
            this.cbSuppliersNames.Location = new System.Drawing.Point(24, 152);
            this.cbSuppliersNames.Name = "cbSuppliersNames";
            this.cbSuppliersNames.Size = new System.Drawing.Size(282, 37);
            this.cbSuppliersNames.TabIndex = 18;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 539);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddUpdateProduct";
            this.Text = "frmAddUpdateProduct";
            this.Load += new System.EventHandler(this.frmAddUpdateNewProduct_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPurshesPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbSuppliersNames;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInstallmentPrice;
    }
}