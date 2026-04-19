using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidDB26.Helpers;
using MidDB26.Models;
using System.Windows.Forms;

namespace MidDB26.Forms
{
    public partial class DeleteStudents : Form
    {
        DeleteStudentHelper helper = new DeleteStudentHelper();
        private int selectedStudentId = -1;

        public DeleteStudents()
        {
            InitializeComponent();
        }

        private void Search_click(object sender, EventArgs e)
        {
            string searchRegNo = SearchBox.Text.Trim();

            if (searchRegNo == "")
            {
                MessageBox.Show("Please enter registration number.");
                SearchBox.Focus();
                return;
            }

            MidDB26.Models.Student student = helper.GetStudentByRegNo(searchRegNo);

            if (student != null)
            {
                selectedStudentId = student.Id;
                regNo.Text = student.RegistrationNumber;
                fName.Text = student.FirstName;
                LName.Text = student.LastName;
                Contact.Text = student.Contact;
                mailbox.Text = student.Email;
                status.Text = student.Status;
            }
            else
            {
                MessageBox.Show("Student not found.");
                ClearFields();
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please load a student first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int rows = helper.DeleteStudent(selectedStudentId);

                if (rows > 0)
                {
                    MessageBox.Show("Student deleted successfully.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Student could not be deleted.");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            selectedStudentId = -1;
            SearchBox.Clear();
            regNo.Clear();
            fName.Clear();
            LName.Clear();
            Contact.Clear();
            mailbox.Clear();
            status.SelectedIndex=-1;
            SearchBox.Focus();
        }
    }
}