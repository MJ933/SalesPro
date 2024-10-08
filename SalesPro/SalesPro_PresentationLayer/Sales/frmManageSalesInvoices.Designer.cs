namespace SalesPro_PresentationLayer.Sales
{
    partial class frmManageSalesInvoices
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvManageSales = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecorsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageSales)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(619, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(220, 37);
            this.label1.TabIndex = 19;
            this.label1.Text = "Manage Sales";
            // 
            // dgvManageSales
            // 
            this.dgvManageSales.AllowUserToAddRows = false;
            this.dgvManageSales.AllowUserToDeleteRows = false;
            this.dgvManageSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManageSales.ColumnHeadersHeight = 34;
            this.dgvManageSales.Location = new System.Drawing.Point(11, 123);
            this.dgvManageSales.Name = "dgvManageSales";
            this.dgvManageSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvManageSales.RowHeadersWidth = 62;
            this.dgvManageSales.RowTemplate.Height = 28;
            this.dgvManageSales.Size = new System.Drawing.Size(1498, 508);
            this.dgvManageSales.TabIndex = 18;
            this.dgvManageSales.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvManageSales_CellMouseClick);
            this.dgvManageSales.Resize += new System.EventHandler(this.dgvManageSales_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.addToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelToolStripMenuItem,
            this.retrieveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 170);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(165, 32);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(165, 32);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(165, 32);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(165, 32);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // retrieveToolStripMenuItem
            // 
            this.retrieveToolStripMenuItem.Name = "retrieveToolStripMenuItem";
            this.retrieveToolStripMenuItem.Size = new System.Drawing.Size(165, 32);
            this.retrieveToolStripMenuItem.Text = "Retrieve";
            this.retrieveToolStripMenuItem.Click += new System.EventHandler(this.retrieveToolStripMenuItem_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(1088, 73);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(295, 40);
            this.cbFilterBy.TabIndex = 25;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(747, 74);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(334, 39);
            this.txtFilterValue.TabIndex = 24;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1389, 76);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(126, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "Filter By:";
            // 
            // lblRecorsCount
            // 
            this.lblRecorsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecorsCount.AutoSize = true;
            this.lblRecorsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecorsCount.Location = new System.Drawing.Point(119, 646);
            this.lblRecorsCount.Name = "lblRecorsCount";
            this.lblRecorsCount.Size = new System.Drawing.Size(87, 29);
            this.lblRecorsCount.TabIndex = 22;
            this.lblRecorsCount.Text = "[?????]";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 646);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Rcords: ";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(11, 48);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 69);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmManageSalesInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 684);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageSales);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecorsCount);
            this.Controls.Add(this.label2);
            this.Name = "frmManageSalesInvoices";
            this.Text = "frmManageSalesInvoices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManageSalesInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageSales)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvManageSales;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecorsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retrieveToolStripMenuItem;
    }
}