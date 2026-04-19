using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidDB26.Helpers;

namespace MidDB26.Forms
{
    public partial class AddAssessment : Form
    {
        AddAssessmentHelper helper = new AddAssessmentHelper();

        public AddAssessment()
        {
            InitializeComponent();
        }

        private void btnSaveAssessment_Click(object sender, EventArgs e)
        {
            string title = titlebox.Text.Trim();

            if (title == "")
            {
                MessageBox.Show("Please enter assessment title.");
                titlebox.Focus();
                return;
            }

            if (marrks.Text.Trim() == "")
            {
                MessageBox.Show("Please enter total marks.");
                marrks.Focus();
                return;
            }

            int totalMarks;
            if (!int.TryParse(marrks.Text.Trim(), out totalMarks))
            {
                MessageBox.Show("Total marks must be a number.");
                marrks.Focus();
                return;
            }

            if (per.Text.Trim() == "")
            {
                MessageBox.Show("Please enter total weightage.");
                per.Focus();
                return;
            }

            decimal totalWeightage;
            if (!decimal.TryParse(per.Text.Trim(), out totalWeightage))
            {
                MessageBox.Show("Total weightage must be a valid number.");
                per.Focus();
                return;
            }

            if (helper.AssessmentTitleExists(title))
            {
                MessageBox.Show("An assessment with this title already exists.");
                titlebox.Focus();
                return;
            }

            int rows = helper.AddAssessment(title, totalMarks, totalWeightage);

            if (rows > 0)
            {
                MessageBox.Show("Assessment added successfully.");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Assessment could not be added.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            titlebox.Clear();
            marrks.Clear();
            per.Clear();
            titlebox.Focus();
        }


        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
