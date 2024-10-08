using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Products
{
    public partial class frmShowProductInfo : Form
    {
        public frmShowProductInfo(int product_id)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnCancel;
            ctrlProductCard1.LoadInfo(product_id);
        }
        public frmShowProductInfo(string product_name)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnCancel;
            ctrlProductCard1.LoadInfo(product_name);

        }

        private void frmShowProductInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
