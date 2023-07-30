using Microsoft.Reporting.WinForms;
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
    public partial class frmReport : Form
    {
        int billId;
        public frmReport(int id)
        {
            InitializeComponent();
            // get the bill id for the report
            billId = id;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // set the report data source
            ReportDataSource rds = new ReportDataSource("DataSet1", accAppDataSet1.GetBillReport.AsEnumerable());
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.getBillReportTableAdapter1.Fill(this.accAppDataSet1.GetBillReport, billId);
            this.reportViewer1.RefreshReport();
        }
    }
}
