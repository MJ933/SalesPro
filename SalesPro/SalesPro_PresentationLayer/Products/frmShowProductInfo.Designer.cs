namespace SalesPro_PresentationLayer.Products
{
    partial class frmShowProductInfo
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
            this.ctrlProductCard1 = new SalesPro_PresentationLayer.Products.ctrlProductCard();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlProductCard1
            // 
            this.ctrlProductCard1.Location = new System.Drawing.Point(12, 130);
            this.ctrlProductCard1.Name = "ctrlProductCard1";
            this.ctrlProductCard1.Size = new System.Drawing.Size(1033, 319);
            this.ctrlProductCard1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(919, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 49);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Info";
            // 
            // frmShowProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctrlProductCard1);
            this.Name = "frmShowProductInfo";
            this.Text = "frmShowProductInfo";
            this.Load += new System.EventHandler(this.frmShowProductInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlProductCard ctrlProductCard1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}