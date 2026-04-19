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
using MidDB26.Models;

namespace MidDB26.Forms
{
    public partial class AddAssessmentComponent : Form
    {
        AddAssessmentComponentHelper helper = new AddAssessmentComponentHelper();

        public AddAssessmentComponent()
        {
            InitializeComponent();
            LoadAssessments();
            LoadRubrics();
        }

        private void LoadAssessments()
        {
            DataTable dt = helper.GetAssessments();

            asseeecombo.DataSource = null;
            asseeecombo.Items.Clear();

            asseeecombo.DisplayMember = "AssessmentText";
            asseeecombo.ValueMember = "Id";
            asseeecombo.DataSource = dt;
            asseeecombo.SelectedIndex = -1;
        }

        private void LoadRubrics()
        {
            DataTable dt = helper.GetRubrics();

            rubriccombo.DataSource = null;
            rubriccombo.Items.Clear();

            rubriccombo.DisplayMember = "RubricText";
            rubriccombo.ValueMember = "Id";
            rubriccombo.DataSource = dt;
            rubriccombo.SelectedIndex = -1;
        }

        private void btnSaveComponent_Click(object sender, EventArgs e)
        {
            if (compname.Text.Trim() == "")
            {
                MessageBox.Show("Please enter component name.");
                compname.Focus();
                return;
            }

            if (asseeecombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an assessment.");
                asseeecombo.Focus();
                return;
            }

            if (rubriccombo.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a rubric.");
                rubriccombo.Focus();
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

            int rows = helper.AddAssessmentComponent(
                compname.Text.Trim(),
                Convert.ToInt32(rubriccombo.SelectedValue),
                totalMarks,
                Convert.ToInt32(asseeecombo.SelectedValue)
            );

            if (rows > 0)
            {
                MessageBox.Show("Assessment Component added successfully.");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Assessment Component could not be added.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            compname.Clear();
            marrks.Clear();
            asseeecombo.SelectedIndex = -1;
            rubriccombo.SelectedIndex = -1;
            compname.Focus();
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
