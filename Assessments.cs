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
    public partial class Assessments : Form
    {
        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel4.Controls.Clear();
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        public Assessments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddAssessment());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditAssessment());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViewAssessments());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeleteAssessment());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DashboardUI dashboard = new DashboardUI();
            dashboard.Show();

            this.Close();
        }
    }
}
