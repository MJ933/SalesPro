namespace SalesPro_PresentationLayer.Customers_Guarantors_Suppliers
{
    partial class frmAddUpdateGuarantors
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new SalesPro_PresentationLayer.ctrlPersonCardWithFilter();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(745, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 62);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnable = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(12, 57);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1020, 514);
            this.ctrlPersonCardWithFilter1.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(897, 595);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 62);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(416, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add Guarantor";
            // 
            // frmAddUpdateGuarantors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 668);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "frmAddUpdateGuarantors";
            this.Text = "frmAddUpdateGuarantors";
            this.Load += new System.EventHandler(this.frmAddUpdateGuarantors_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}