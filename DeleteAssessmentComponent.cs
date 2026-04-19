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
    public partial class DeleteAssessmentComponent : Form
    {
        DeleteAssessmentComponentHelper helper = new DeleteAssessmentComponentHelper();
        private int selectedComponentId = -1;

        public DeleteAssessmentComponent()
        {
            InitializeComponent();
        }

        private void btnLoadComponent_Click(object sender, EventArgs e)
        {
            if (SearchBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Component ID.");
                SearchBox.Focus();
                return;
            }

            int id;
            if (!int.TryParse(SearchBox.Text.Trim(), out id))
            {
                MessageBox.Show("Component ID must be a number.");
                SearchBox.Focus();
                return;
            }

            MidDB26.Models.AssessmentComponent component = helper.GetComponentById(id);

            if (component != null)
            {
                selectedComponentId = component.Id;
                compname.Text = component.Name;
                asseeecombo.Text = component.AssessmentTitle;
                rubriccombo.Text = component.RubricName;
                marrks.Text = component.TotalMarks.ToString();
            }
            else
            {
                MessageBox.Show("Assessment Component not found.");
                ClearFields();
            }
        }

        private void btnDeleteComponent_Click(object sender, EventArgs e)
        {
            if (selectedComponentId == -1)
            {
                MessageBox.Show("Please load a component first.");
                SearchBox.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this Assessment Component?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int rows = helper.DeleteComponent(selectedComponentId);

                if (rows > 0)
                {
                    MessageBox.Show("Assessment Component deleted successfully.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Assessment Component could not be deleted.");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedComponentId = -1;
            SearchBox.Clear();
            compname.Clear();
            asseeecombo.Clear();
            rubriccombo.Clear();
            marrks.Clear();
            SearchBox.Focus();
        }
    }
}
