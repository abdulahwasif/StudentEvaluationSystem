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
    public partial class DeleteRubricLevel : Form
    {
        DeleteLevelsHelper helper = new DeleteLevelsHelper();
        private int selectedLevelId = -1;

        public DeleteRubricLevel()
        {
            InitializeComponent();
        }

        private void btnLoadLevel_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Rubric Level ID.");
                SearchBox.Focus();
                return;
            }

            int id;
            if (!int.TryParse(SearchBox.Text.Trim(), out id))
            {
                MessageBox.Show("Rubric Level ID must be a number.");
                SearchBox.Focus();
                return;
            }

            MidDB26.Models.RubricLevel level = helper.GetLevelById(id);

            if (level != null)
            {
                selectedLevelId = level.Id;
                textBox1.Text = level.RubricName;
                measurment.Text = level.MeasurementLevel.ToString();
                Description.Text = level.Details;
            }
            else
            {
                MessageBox.Show("Rubric Level not found.");
                ClearFields();
            }
        }

        private void btnDeleteLevel_Click(object sender, EventArgs e)
        {
            if (selectedLevelId == -1)
            {
                MessageBox.Show("Please load a Rubric Level first.");
                SearchBox.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this Rubric Level?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int rows = helper.DeleteLevel(selectedLevelId);

                if (rows > 0)
                {
                    MessageBox.Show("Rubric Level deleted successfully.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Rubric Level could not be deleted.");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedLevelId = -1;
            SearchBox.Clear();
            textBox1.Clear();
            measurment.Clear();
            Description.Clear();
            SearchBox.Focus();
        }

    }
}
