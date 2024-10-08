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
using System.Xml.Linq;

namespace SalesPro_PresentationLayer.People
{
    public partial class ctrlPersonCard : UserControl
    {
        public delegate void DataBackEventHandler(object sender, int person_id);

        public event DataBackEventHandler DataBack;

        clsPeopleBL _Person;
        private int _PersonId = -1;

        public int PersonId { get { return _Person.PersonID; } }
        public clsPeopleBL PersonInfo { get { return _Person; } }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadInfo(int PersonID)
        {
            _Person = clsPeopleBL.FindPersonByID(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadInfo(string PersonName)
        {
            _Person = clsPeopleBL.FindPersonByName(PersonName);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with Name = " + PersonName.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        private void _FillPersonInfo()
        {
            LLUpdatePersonInfo.Enabled = true;
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

        public void ResetPersonInfo()
        {
            _PersonId = -1;
            lblID.Text = "";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtPhone3.Text = "";
            txtPhone4.Text = "";
            txtEmail.Text = "";
            rtxtNotes.Text = "";
        }

        private void LLUpdatePersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person != null)
            {
                frmAddUpdatePerson frm = new frmAddUpdatePerson(_Person.PersonID);
                LoadInfo(_Person.PersonID);
                frm.DataBack += frm_DataBack;
                frm.ShowDialog();
            }
            else MessageBox.Show("Please enter a valid ID or Name!");
        }


        private void frm_DataBack(object sender, int person_id)
        {
            LoadInfo(person_id);
            DataBack?.Invoke(this, person_id);
        }
    }
}
