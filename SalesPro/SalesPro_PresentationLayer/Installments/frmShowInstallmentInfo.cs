using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Installments
{
    public partial class frmShowInstallmentInfo : Form
    {
        int InvoiceID;
        public frmShowInstallmentInfo(int invoice_id)
        {
            InitializeComponent();
            //ctrlInstallmentCard1.DataBack += closeForm3;
            ctrlInstallmentCard1.LoadInfo(invoice_id);
        }

        //private void closeForm3(object sender)
        //{
        //    this.Close();
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInstallmentInfo_Resize(object sender, EventArgs e)
        {

        }
    }
}
