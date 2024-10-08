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
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int person_id)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnClose;
            ctrlPersonCard1.LoadInfo(person_id);
        }
        public frmShowPersonInfo(string name)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnClose;
            ctrlPersonCard1.LoadInfo(name);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
