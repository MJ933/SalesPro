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
    public partial class frmFindPerson : Form
    {

        public frmFindPerson()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ctrlPersonCardWithFilter1.DataBack += ReloadData;

        }
        public frmFindPerson(bool update)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CancelButton = btnCancel;
            label1.Text = "Update";
            ctrlPersonCardWithFilter1.DataBack += ReloadData;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReloadData(object sender, int person_id)
        {
            //To stop infinite loop you need to unsubscribe from the event first
            //ctrlPersonCardWithFilter1.OnProductSelected -= Load_dgvInstallments;
            ctrlPersonCardWithFilter1.LoadPersonInfo(person_id);
            //And after you are done, subscribe again
            //ctrlPersonCardWithFilter1.OnProductSelected += Load_dgvInstallments;

        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
        }
    }
}