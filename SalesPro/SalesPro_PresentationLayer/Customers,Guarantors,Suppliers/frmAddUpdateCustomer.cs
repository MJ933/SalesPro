using SalesPro_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.Customers
{
    public partial class frmAddUpdateCustomer : Form
    {

        private int _CustomerID = -1;
        clsCustomersBL _Customer;


        public frmAddUpdateCustomer()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CancelButton = btnClose;
            ctrlPersonCardWithFilter1.DataBack += ReloadData;

        }
        public frmAddUpdateCustomer(bool update)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CancelButton = btnClose;
            label1.Text = "Update";
            ctrlPersonCardWithFilter1.DataBack += ReloadData;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonInfo == null)
            {
                MessageBox.Show("Please enter Correct Id or Name!");
                return;
            }
            if (clsCustomersBL.CustomerExists(ctrlPersonCardWithFilter1.PersonInfo.PersonName))
            {
                MessageBox.Show("The Customer is Already Exist please Choose another one!");
                return;
            }
            clsCustomersBL _Customer = new clsCustomersBL();
            _Customer.PersonID = ctrlPersonCardWithFilter1.PersonInfo.PersonID;
            if (_Customer.Save())
            {
                MessageBox.Show("The Customer Has been Saved Successfully.");
            }

        }



        private void ReloadData(object sender, int person_id)
        {
            //To stop infinite loop you need to unsubscribe from the event first
            //ctrlPersonCardWithFilter1.OnProductSelected -= Load_dgvInstallments;
            ctrlPersonCardWithFilter1.LoadPersonInfo(person_id);
            //And after you are done, subscribe again
            //ctrlPersonCardWithFilter1.OnProductSelected += Load_dgvInstallments;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
