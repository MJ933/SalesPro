namespace SalesPro_PresentationLayer.Sales
{
    partial class frmShowSaleInvoiceInfo
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
            this.ctrlSaleInvoiceCard1 = new SalesPro_PresentationLayer.Sales.ctrlSaleInvoiceCard();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSaleInvoiceCard1
            // 
            this.ctrlSaleInvoiceCard1.Location = new System.Drawing.Point(12, 62);
            this.ctrlSaleInvoiceCard1.Name = "ctrlSaleInvoiceCard1";
            this.ctrlSaleInvoiceCard1.Size = new System.Drawing.Size(1025, 658);
            this.ctrlSaleInvoiceCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(426, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sale Invoice Info";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(895, 726);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 64);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowSaleInvoiceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 808);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlSaleInvoiceCard1);
            this.Name = "frmShowSaleInvoiceInfo";
            this.Text = "frmShowSaleInvoiceInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlSaleInvoiceCard ctrlSaleInvoiceCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}