using MidDB26.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidDB26.Forms
{
    public partial class AddRubric : Form
    {
        AddRubricHelper helper = new AddRubricHelper();
        public AddRubric()
        {
            InitializeComponent();
        }

        private void AddRubric_Load(object sender, EventArgs e)
            {
                LoadCLOs();
            }

            private void LoadCLOs()
            {
                DataTable dt = helper.GetCLOs();

                cloID.DataSource = dt;
            cloID.DisplayMember = "Name";
            cloID.ValueMember = "Id";
            cloID.SelectedIndex = -1;
            }

            private void btnSaveRubric_Click(object sender, EventArgs e)
            {
                if (rubricID.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Rubric ID.");
                    rubricID.Focus();
                    return;
                }

                int rubricId;
                if (!int.TryParse(rubricID.Text.Trim(), out rubricId))
                {
                    MessageBox.Show("Rubric ID must be a number.");
                    rubricID.Focus();
                    return;
                }

                if (cloID.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a CLO.");
                    cloID.Focus();
                    return;
                }

                if (Description.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter rubric details.");
                    Description.Focus();
                    return;
                }

                if (helper.RubricIdExists(rubricId))
                {
                    MessageBox.Show("A rubric with this ID already exists.");
                    rubricID.Focus();
                    return;
                }

                int rows = helper.AddRubric(
                    rubricId,
                    Description.Text.Trim(),
                    Convert.ToInt32(cloID.SelectedValue)
                );

                if (rows > 0)
                {
                    MessageBox.Show("Rubric added successfully.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Rubric could not be added.");
                }
            }

            private void btnClear_Click(object sender, EventArgs e)
            {
                ClearFields();
            }

            private void ClearFields()
            {
                rubricID.Clear();
                Description.Clear();
                cloID.SelectedIndex = -1;
                rubricID.Focus();
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cloID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }