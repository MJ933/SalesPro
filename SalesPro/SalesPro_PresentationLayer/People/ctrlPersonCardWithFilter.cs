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

namespace SalesPro_PresentationLayer
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int person_id)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
                handler(person_id);
        }
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        DataTable dtPeopleNames = clsPeopleBL.GetAllPeopleNames();
        private string _PersonName;
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Enabled = _ShowAddPerson;
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
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            ctrlPersonCard1.DataBack += LoadDataFromDataBack;

        }
        private void LoadDataFromDataBack(object sender, int person_id)
        {
            LoadPersonInfo(person_id);
            /*DataBack?.Invoke(this, person_id);*/ // Raise the event for parent controls 
        }

        private int _PersonID = -1;

        public int PersonID { get { return ctrlPersonCard1.PersonId; } }

        public clsPeopleBL PersonInfo
        {
            get { return ctrlPersonCard1.PersonInfo; }
        }

        public void LoadPersonInfo(int person_id)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = person_id.ToString();
            FindNow();
        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "Name":
                    ctrlPersonCard1.LoadInfo(cbPeople.SelectedValue.ToString());
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null)
                PersonSelected(int.Parse(txtFilterValue.Text));

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            if (cbFilterBy.SelectedIndex == 0)
                cbPeople.Visible = true;
            else cbPeople.Visible = false;
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

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
            // ctrlPersonCard1.LoadInfo(PersonID);

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadInfo(PersonID);
            // OnProductSelected?.Invoke(PersonID);
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
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFilterValue.Text;
            if (!string.IsNullOrEmpty(filterText))
            {

                DataRow[] filteredRows = dtPeopleNames.Select($"[PersonName] LIKE '%{filterText}%'");

                if (filteredRows.Length > 0)
                {
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    cbPeople.DataSource = filteredDataTable;

                    cbPeople.DisplayMember = "PersonName";
                    cbPeople.ValueMember = "PersonName";

                    //cbCustomers.SelectedIndex = -1; // Prevent selection
                }
                else
                {
                    cbPeople.DataSource = dtPeopleNames; // Reset to original if no matches
                }
            }
            else
            {
                cbPeople.DataSource = dtPeopleNames; // Reset to original if no filter
            }
        }



    }




}

