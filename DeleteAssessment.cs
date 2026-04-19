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
    public partial class DeleteAssessment : Form
    {
        DeleteAssessmentHelper helper = new DeleteAssessmentHelper();
        private int selectedAssessmentId = -1;

        public DeleteAssessment()
        {
            InitializeComponent();
        }

        private void btnLoadAssessment_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Assessment ID.");
                SearchBox.Focus();
                return;
            }

            int id;
            if (!int.TryParse(SearchBox.Text.Trim(), out id))
            {
                MessageBox.Show("Assessment ID must be a number.");
                SearchBox.Focus();
                return;
            }

            Assessment assessment = helper.GetAssessmentById(id);

            if (assessment != null)
            {
                selectedAssessmentId = assessment.Id;
                titlebox.Text = assessment.Title;
                marrks.Text = assessment.TotalMarks.ToString();
                per.Text = assessment.TotalWeightage.ToString();
            }
            else
            {
                MessageBox.Show("Assessment not found.");
                ClearFields();
            }
        }

        private void btnDeleteAssessment_Click(object sender, EventArgs e)
        {
            if (selectedAssessmentId == -1)
            {
                MessageBox.Show("Please load an assessment first.");
                SearchBox.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this assessment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    int rows = helper.DeleteAssessment(selectedAssessmentId);

                    if (rows > 0)
                    {
                        MessageBox.Show("Assessment deleted successfully.");
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Assessment could not be deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed. This assessment may already be used in Assessment Components.\n\n" + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedAssessmentId = -1;
            SearchBox.Clear();
            titlebox.Clear();
            marrks.Clear();
            per.Clear();
            SearchBox.Focus();
        }
    }
}
