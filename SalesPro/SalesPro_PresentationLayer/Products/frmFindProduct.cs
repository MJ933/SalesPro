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
    public partial class frmFindProduct : Form
    {
        public frmFindProduct()
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ctrlProductCardWithFilter1.DataBack += ReloadData;
        }
        public frmFindProduct(bool update)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CancelButton = btnCancel;
            label1.Text = "Update";
            ctrlProductCardWithFilter1.DataBack += ReloadData;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReloadData(object sender, int product_id)
        {
            //To stop infinite loop you need to unsubscribe from the event first
            //ctrlPersonCardWithFilter1.OnProductSelected -= Load_dgvInstallments;
            ctrlProductCardWithFilter1.LoadInfo(product_id);
            //And after you are done, subscribe again
            //ctrlPersonCardWithFilter1.OnProductSelected += Load_dgvInstallments;

        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
