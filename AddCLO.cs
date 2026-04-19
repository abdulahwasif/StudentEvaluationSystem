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
    public partial class AddCLO : Form
    {
        AddCLOHelper helper = new AddCLOHelper();

        public AddCLO()
        {
            InitializeComponent();
        }

        private void btnSaveCLO_Click(object sender, EventArgs e)
        {
            string cloName = textBox1.Text.Trim();

            if (cloName == "")
            {
                MessageBox.Show("Please enter CLO name.");
                textBox1.Focus();
                return;
            }

            if (helper.CLOLexists(cloName))
            {
                MessageBox.Show("This CLO already exists.");
                textBox1.Focus();
                return;
            }

            int rows = helper.AddCLO(cloName);

            if (rows > 0)
            {
                MessageBox.Show("CLO added successfully.");
                ClearFields();
            }
            else
            {
                MessageBox.Show("CLO could not be added.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
