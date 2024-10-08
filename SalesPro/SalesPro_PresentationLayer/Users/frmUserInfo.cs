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

namespace SalesPro_PresentationLayer.Users
{
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }
        public frmUserInfo(int user_id)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CancelButton = btnClose;
            ctrlUserCard1.LoadUserInfo(user_id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
