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
    public partial class DeleteCLO : Form
    {
        DeleteCLOHelper helper = new DeleteCLOHelper();

        private int selectedCLOId = -1;
        public DeleteCLO()
        {
            InitializeComponent();
        }

            private void btnLoadCLO_Click(object sender, EventArgs e)
            {
                if (SearchBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter CLO ID.");
                    return;
                }

                int id;
                if (!int.TryParse(SearchBox.Text.Trim(), out id))
                {
                    MessageBox.Show("CLO ID must be a number.");
                    return;
                }

                MidDB26.Models.CLO clo = helper.GetCLOById(id);

                if (clo != null)
                {
                    selectedCLOId = clo.Id;
                    textBox1.Text = clo.Name;
                }
                else
                {
                    MessageBox.Show("CLO not found.");
                    ClearFields();
                }
            }

            private void btnDeleteCLO_Click(object sender, EventArgs e)
            {
                if (selectedCLOId == -1)
                {
                    MessageBox.Show("Load a CLO first.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this CLO?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    int rows = helper.DeleteCLO(selectedCLOId);

                    if (rows > 0)
                    {
                        MessageBox.Show("CLO deleted successfully.");
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("CLO could not be deleted.");
                    }
                }
            }

            private void btnClear_Click(object sender, EventArgs e)
            {
                ClearFields();
            }

            private void ClearFields()
            {
                selectedCLOId = -1;
                SearchBox.Clear();
                textBox1.Clear();
                SearchBox.Focus();
            }
        }
    }
