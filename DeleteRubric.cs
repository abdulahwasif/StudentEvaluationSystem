using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidDB26.Models;
using MidDB26.Helpers;

namespace MidDB26.Forms
{
    public partial class DeleteRubric : Form
    {
        DeleteRubricHelper helper = new DeleteRubricHelper();
        private int selectedRubricId = -1;

        public DeleteRubric()
        {
            InitializeComponent();
        }

        private void btnLoadRubric_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Rubric ID.");
                SearchBox.Focus();
                return;
            }

            int rubricId;
            if (!int.TryParse(SearchBox.Text.Trim(), out rubricId))
            {
                MessageBox.Show("Rubric ID must be a number.");
                SearchBox.Focus();
                return;
            }

            MidDB26.Models.Rubric rubric = helper.GetRubricById(rubricId);

            if (rubric != null)
            {
                selectedRubricId = rubric.Id;
                textBox1.Text = rubric.CloName;
                Description.Text = rubric.Details;
            }
            else
            {
                MessageBox.Show("Rubric not found.");
                ClearFields();
            }
        }

        private void btnDeleteRubric_Click(object sender, EventArgs e)
        {
            if (selectedRubricId == -1)
            {
                MessageBox.Show("Please load a rubric first.");
                SearchBox.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this rubric?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    int rows = helper.DeleteRubric(selectedRubricId);

                    if (rows > 0)
                    {
                        MessageBox.Show("Rubric deleted successfully.");
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Rubric could not be deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed. This rubric may already be used in another module.\n\n" + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedRubricId = -1;
            SearchBox.Clear();
            textBox1.Clear();
            Description.Clear();
            SearchBox.Focus();
        }

    }
}
