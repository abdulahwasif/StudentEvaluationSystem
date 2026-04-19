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
    public partial class AssessmentComponent : Form
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
        public AssessmentComponent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddAssessmentComponent());
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditAssessmentComponent());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViewAssessmentComponents());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DeleteAssessmentComponent());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DashboardUI dashboard = new DashboardUI();
            dashboard.Show();

            this.Close();
        }
    }
}
