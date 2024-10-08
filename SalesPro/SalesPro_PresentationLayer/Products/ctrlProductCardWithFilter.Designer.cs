namespace SalesPro_PresentationLayer.Products
{
    partial class ctrlProductCardWithFilter
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
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlProductCard1 = new SalesPro_PresentationLayer.Products.ctrlProductCard();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFilterBy);
            this.groupBox1.Controls.Add(this.btnAddNewPerson);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFilterValue);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1027, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Name",
            "Product ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(706, 44);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(173, 34);
            this.cbFilterBy.TabIndex = 17;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPerson.Location = new System.Drawing.Point(160, 35);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddNewPerson.Size = new System.Drawing.Size(97, 51);
            this.btnAddNewPerson.TabIndex = 3;
            this.btnAddNewPerson.Text = "Add";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(298, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnFind.Size = new System.Drawing.Size(97, 51);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(885, 40);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(92, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find By:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(446, 43);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(236, 35);
            this.txtFilterValue.TabIndex = 2;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlProductCard1
            // 
            this.ctrlProductCard1.Location = new System.Drawing.Point(3, 109);
            this.ctrlProductCard1.Name = "ctrlProductCard1";
            this.ctrlProductCard1.Size = new System.Drawing.Size(1038, 301);
            this.ctrlProductCard1.TabIndex = 0;
            // 
            // ctrlProductCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlProductCard1);
            this.Name = "ctrlProductCardWithFilter";
            this.Size = new System.Drawing.Size(1037, 413);
            this.Load += new System.EventHandler(this.ctrlProductCardWithFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlProductCard ctrlProductCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
