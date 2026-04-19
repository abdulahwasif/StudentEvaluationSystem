using MidDB26.Helpers;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace MidDB26.Forms
{
    public partial class AddStudent : Form
    {
        private AddStudentHelper addStudentHelper;

        public AddStudent()
        {
            InitializeComponent();
            addStudentHelper = new AddStudentHelper();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

            DataTable dt = addStudentHelper.GetStatus();

            status.DataSource = dt;
            status.DisplayMember = "Name";
            status.ValueMember = "LookupId";
            status.SelectedIndex = 0;

        }


        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string firstName = fName.Text;
            string lastName = LName.Text;
            string contact = Contact.Text;
            string email = mailbox.Text;
            string regNo = this.regNo.Text;
            int status = Convert.ToInt32(this.status.SelectedValue);

            if (string.IsNullOrWhiteSpace(this.regNo.Text) || string.IsNullOrWhiteSpace(fName.Text) || string.IsNullOrWhiteSpace(LName.Text) || string.IsNullOrWhiteSpace(Contact.Text) || string.IsNullOrWhiteSpace(mailbox.Text) || this.status.SelectedIndex == -1)
            {
                MessageBox.Show("All Fields are Required");
            }

            else
            addStudentHelper.AddStudent(firstName, lastName, contact, email, regNo, status);

        }
    }
}
