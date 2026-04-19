using Microsoft.Reporting.WinForms;
using MidDB26.Helpers;
using MidDB26.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidDB26.Forms
{
    public partial class AssessmentWiseReportForm : Form
    {
        AssessmentReportHelper helper = new AssessmentReportHelper();
        public AssessmentWiseReportForm()
        {
            InitializeComponent();
            LoadAssessmentWiseReport();
        }

        private void LoadAssessmentWiseReport()
        {
            List<AssessmentWiseResult> list = helper.GetAllAssessmentWiseResults();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();

            string reportPath = Path.Combine(Application.StartupPath,"AssessmentWiseReport.rdlc");

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

