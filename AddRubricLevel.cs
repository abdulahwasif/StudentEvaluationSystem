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
    public partial class AddRubricLevel : Form
    {
        AddLevelHelper helper = new AddLevelHelper();
        public AddRubricLevel()
        {
            InitializeComponent();
        }

        private void AddRubricLevel_Load(object sender, EventArgs e)
        {
            LoadRubrics();
        }

        private void LoadRubrics()
        {
            DataTable dt = helper.GetRubrics();

            rubricName.DataSource = dt;
            rubricName.DisplayMember = "Details";
            rubricName.ValueMember = "Id";
            rubricName.SelectedIndex = -1;
        }

        private void btnSaveLevel_Click(object sender, EventArgs e)
        {
            if (rubricName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a rubric.");
                rubricName.Focus();
                return;
            }

            if (measurment.Text.Trim() == "")
            {
                MessageBox.Show("Please enter measurement level.");
                measurment.Focus();
                return;
            }

            int measurementLevel;
            if (!int.TryParse(measurment.Text.Trim(), out measurementLevel))
            {
                MessageBox.Show("Measurement level must be a number.");
                measurment.Focus();
                return;
            }

            if (Description.Text.Trim() == "")
            {
                MessageBox.Show("Please enter details.");
                Description.Focus();
                return;
            }

            int rows = helper.AddRubricLevel(
                Convert.ToInt32(rubricName.SelectedValue),
                Description.Text.Trim(),
                measurementLevel
            );

            if (rows > 0)
            {
                MessageBox.Show("Rubric level added successfully.");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Rubric level could not be added.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            rubricName.SelectedIndex = -1;
            measurment.Clear();
            Description.Clear();
            rubricName.Focus();
        }
    }
}
