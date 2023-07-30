using AccApp.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccApp
{
    public partial class frmBillHistory : Form
    {
        public frmBillHistory()
        {
            InitializeComponent();
        }

        private void frmBillHistory_Load(object sender, EventArgs e)
        {
            // fill the data grid view with data
            dbManager.FillDGVFromDB(dgvBill, modelTypes.Bill);
        }

        private void dgvBill_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBill.CurrentRow != null)// check if the user has selected a row
            {
                // get the bill id
                int billId = Convert.ToInt32(dgvBill.CurrentRow.Cells[0].Value);
                // display the selected bill items in the data grid view
                dgvBillProducts.DataSource = dbManager.GetBillRows(billId);
            }
            else
            {
                dgvBillProducts.DataSource = null;
            }
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            
            if(dgvBill.CurrentRow != null)// check if the user has selected a row
            {
                // get the bill id
                int billId = Convert.ToInt32(dgvBill.CurrentRow.Cells[0].Value);
                // delete the bill from the data base
                dbManager.DeleteModelFromDB(billId, modelTypes.Bill);
            }
        }
    }
}
