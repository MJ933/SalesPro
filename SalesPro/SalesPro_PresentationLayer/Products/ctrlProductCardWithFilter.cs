using SalesPro_BusinessLayer;
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

namespace SalesPro_PresentationLayer.Products
{
    public partial class ctrlProductCardWithFilter : UserControl
    {
        public event Action<int> OnProductSelected;

        protected virtual void ProductSelected(int person_id)
        {
            Action<int> handler = OnProductSelected;
            if (handler != null)
                handler(person_id);
        }

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        private bool _ShowAddProduct = true;
        public bool ShowAddProduct
        {
            get { return _ShowAddProduct; }
            set
            {
                _ShowAddProduct = value;
                btnAddNewPerson.Enabled = _ShowAddProduct;
            }
        }

        private bool _FilterEnable = true;
        public bool FilterEnable

        {
            get { return _FilterEnable; }
            set
            {
                _FilterEnable = value;
                btnFind.Enabled = _FilterEnable;
            }
        }


        public ctrlProductCardWithFilter()
        {
            InitializeComponent();
            ctrlProductCard1.DataBack += LoadDataFromDataBack;
        }
        private void LoadDataFromDataBack(object sender, int product_id)
        {
            LoadInfo(product_id);
            DataBack?.Invoke(this, product_id); // Raise the event for parent controls 
            //OnProductSelected?.Invoke(product_id); // إضافة هذا السطر 

        }

        private int _ProductID = -1;

        public int ProductID { get { return ctrlProductCard1.ProductID; } }



        public clsProductsBL ProductInfo
        {
            get { return ctrlProductCard1.ProductInfo; }
        }

        public void LoadInfo(int product_id)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = product_id.ToString();
            FindNow();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Product ID":
                    ctrlProductCard1.LoadInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "Name":
                    ctrlProductCard1.LoadInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnProductSelected != null && FilterEnable)
                ProductSelected(int.Parse(txtFilterValue.Text));

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();

        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            frmAddUpdateProduct frm = new frmAddUpdateProduct();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
            //ctrlProductCard1.LoadInfo(product_id);
        }

        private void DataBackEvent(object sender, int product_id)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = product_id.ToString();
            ctrlProductCard1.LoadInfo(product_id);
            // OnProductSelected?.Invoke(product_id);
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();


            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Product ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        private void ctrlProductCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
        }
    }
}
