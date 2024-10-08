using SalesPro_BusinessLayer;
using SalesPro_PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesPro_PresentationLayer.People
{
    public partial class ucAddUpdatePerson : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private string _Name;
        private int _PersonID;
        clsPeopleBL _Person;

        public ucAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public ucAddUpdatePerson(string name)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _Name = name;
        }
        public ucAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
                _Person = new clsPeopleBL();
            lblID.Text = "[????]";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtPhone3.Text = "";
            txtPhone4.Text = "";
            txtEmail.Text = "";
            rtxtNotes.Text = "";
        }

        private void _LoadData()
        {
            _Person = clsPeopleBL.FindPersonByName(_Name);
            
            if (_Person == null)
            {
                MessageBox.Show($"Person Name = {_Name}, was NOT Found");
                return;
            }
            lblID.Text = _Person.PersonID.ToString();
            txtFullName.Text = _Person.PersonName;
            txtAddress.Text = _Person.Address;
            txtPhone1.Text = _Person.Phone1;
            txtPhone2.Text = _Person.Phone2;
            txtPhone3.Text = _Person.Phone3;
            txtPhone4.Text = _Person.Phone4;
            txtEmail.Text = _Person.Email;
            rtxtNotes.Text = _Person.Notes;
        }
        private void ucAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _Person.PersonName = txtFullName.Text;
            _Person.Address = txtAddress.Text;
            _Person.Phone1 = txtPhone1.Text;
            _Person.Phone2 = txtPhone2.Text;
            _Person.Phone3 = txtPhone3.Text;
            _Person.Phone4 = txtPhone4.Text;
            _Person.Email = txtEmail.Text;
            _Person.Notes = rtxtNotes.Text;
            if (_Person.Save())
            {
                MessageBox.Show("The Person has Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblID.Text = _Person.PersonID.ToString();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidatoin.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
