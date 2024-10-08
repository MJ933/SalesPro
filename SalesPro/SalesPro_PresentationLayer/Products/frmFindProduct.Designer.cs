namespace SalesPro_PresentationLayer.Products
{
    partial class frmFindProduct
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlProductCardWithFilter1 = new SalesPro_PresentationLayer.Products.ctrlProductCardWithFilter();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(930, 559);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 56);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(449, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 37);
            this.label1.TabIndex = 27;
            this.label1.Text = "Find";
            // 
            // ctrlProductCardWithFilter1
            // 
            this.ctrlProductCardWithFilter1.FilterEnable = true;
            this.ctrlProductCardWithFilter1.Location = new System.Drawing.Point(8, 140);
            this.ctrlProductCardWithFilter1.Name = "ctrlProductCardWithFilter1";
            this.ctrlProductCardWithFilter1.ShowAddProduct = true;
            this.ctrlProductCardWithFilter1.Size = new System.Drawing.Size(1037, 413);
            this.ctrlProductCardWithFilter1.TabIndex = 0;
            // 
            // frmFindProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctrlProductCardWithFilter1);
            this.Name = "frmFindProduct";
            this.Text = "frmFindProduct";
            this.Load += new System.EventHandler(this.frmFindProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlProductCardWithFilter ctrlProductCardWithFilter1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
    }
}