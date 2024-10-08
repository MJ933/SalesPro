namespace SalesPro_PresentationLayer.Installments
{
    partial class frmShowInstallmentInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlInstallmentCard1 = new SalesPro_PresentationLayer.Installments.ctrlInstallmentCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(532, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Installment Info";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1122, 662);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 59);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlInstallmentCard1
            // 
            this.ctrlInstallmentCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlInstallmentCard1.Location = new System.Drawing.Point(12, 53);
            this.ctrlInstallmentCard1.Name = "ctrlInstallmentCard1";
            this.ctrlInstallmentCard1.Size = new System.Drawing.Size(1257, 603);
            this.ctrlInstallmentCard1.TabIndex = 3;
            // 
            // frmShowInstallmentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 733);
            this.Controls.Add(this.ctrlInstallmentCard1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "frmShowInstallmentInfo";
            this.Text = "frmShowInstallmentInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmShowInstallmentInfo_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlInstallmentCard installmentCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private ctrlInstallmentCard ctrlInstallmentCard1;
    }
}