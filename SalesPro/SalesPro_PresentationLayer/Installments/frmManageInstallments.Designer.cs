namespace SalesPro_PresentationLayer.Installments
{
    partial class frmManageInstallments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvManageInstallments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecorsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkIsPaid = new System.Windows.Forms.CheckBox();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInstallments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(472, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(311, 37);
            this.label1.TabIndex = 19;
            this.label1.Text = "Manage Installments";
            // 
            // dgvManageInstallments
            // 
            this.dgvManageInstallments.AllowUserToAddRows = false;
            this.dgvManageInstallments.AllowUserToDeleteRows = false;
            this.dgvManageInstallments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManageInstallments.ColumnHeadersHeight = 34;
            this.dgvManageInstallments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvManageInstallments.Location = new System.Drawing.Point(11, 123);
            this.dgvManageInstallments.Name = "dgvManageInstallments";
            this.dgvManageInstallments.ReadOnly = true;
            this.dgvManageInstallments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvManageInstallments.RowHeadersWidth = 62;
            dataGridViewCellStyle3.NullValue = null;
            this.dgvManageInstallments.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageInstallments.RowTemplate.Height = 28;
            this.dgvManageInstallments.Size = new System.Drawing.Size(1407, 491);
            this.dgvManageInstallments.TabIndex = 18;
            this.dgvManageInstallments.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvManageInstallments_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.addToolStripMenuItem,
            this.recordPaymentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 165);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // recordPaymentToolStripMenuItem
            // 
            this.recordPaymentToolStripMenuItem.Name = "recordPaymentToolStripMenuItem";
            this.recordPaymentToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.recordPaymentToolStripMenuItem.Text = "Record Payment";
            this.recordPaymentToolStripMenuItem.Click += new System.EventHandler(this.recordPaymentToolStripMenuItem_Click);
            // 
            // lblRecorsCount
            // 
            this.lblRecorsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecorsCount.AutoSize = true;
            this.lblRecorsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecorsCount.Location = new System.Drawing.Point(119, 628);
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
            this.label2.Location = new System.Drawing.Point(11, 628);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Rcords: ";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(1085, 87);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(210, 28);
            this.cbFilterBy.TabIndex = 25;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(822, 89);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(256, 26);
            this.txtFilterValue.TabIndex = 24;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1301, 86);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(117, 29);
            this.label3.TabIndex = 23;
            this.label3.Text = "Filter By:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(152, 59);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Values.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkIsPaid
            // 
            this.chkIsPaid.AutoSize = true;
            this.chkIsPaid.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkIsPaid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIsPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsPaid.Location = new System.Drawing.Point(676, 81);
            this.chkIsPaid.Name = "chkIsPaid";
            this.chkIsPaid.Size = new System.Drawing.Size(100, 34);
            this.chkIsPaid.TabIndex = 27;
            this.chkIsPaid.Text = "Paid";
            this.chkIsPaid.UseVisualStyleBackColor = true;
            this.chkIsPaid.CheckedChanged += new System.EventHandler(this.chkIsPaid_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(187, 58);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrint.Size = new System.Drawing.Size(152, 59);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Values.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmManageInstallments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 666);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkIsPaid);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvManageInstallments);
            this.Controls.Add(this.lblRecorsCount);
            this.Controls.Add(this.label2);
            this.Name = "frmManageInstallments";
            this.Text = "frmManageInstallments";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManageInstallments_Load);
            this.Resize += new System.EventHandler(this.frmManageInstallments_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInstallments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvManageInstallments;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Label lblRecorsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private System.Windows.Forms.ToolStripMenuItem recordPaymentToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkIsPaid;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
    }
}