using SalesPro_PresentationLayer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Sales
{
    public partial class frmShowSaleInvoiceInfo : Form
    {
        public frmShowSaleInvoiceInfo(int sale_invoice_id, int sale_invoice_item_id)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnClose;
            ctrlSaleInvoiceCard1.LoadInfo(sale_invoice_id, sale_invoice_item_id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
