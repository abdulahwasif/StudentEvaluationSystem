using Microsoft.Reporting.WinForms;
using MidDB26.Helpers;
using MidDB26.Models;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MidDB26.Forms
{
    public partial class CLOWiseReportForm : Form
    {
        CLOReportHelper helper = new CLOReportHelper();

        public CLOWiseReportForm()
        {
            InitializeComponent();
            LoadCLOWiseReport();
        }

        private void LoadCLOWiseReport()
        {
            List<CLOWiseResult> list = helper.GetAllCLOWiseResults();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();

            string reportPath = Path.Combine(Application.StartupPath, "CLOWiseReport.rdlc");

            if (!File.Exists(reportPath))
            {
                MessageBox.Show("RDLC file not found:\n" + reportPath);
                return;
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", list);

            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

    }

}
