using MidDB26.Models;
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
    public partial class DashboardUI : Form
    {
        public DashboardUI()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();

            this.Close();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();

            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CLO clo = new CLO();
            clo.Show();

            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Assessments assessments = new Assessments();
            assessments.Show();

            this .Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Rubric rubric = new Rubric();
            rubric.Show();

            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            RubricLevel rubricLevel = new RubricLevel();
            rubricLevel.Show();

            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ViewReports viewReports = new ViewReports();
            viewReports.Show();

            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            AssessmentComponent assessmentComponent = new AssessmentComponent();
            assessmentComponent.Show();

            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            EvaluationManager manager = new EvaluationManager();
            manager.Show();

            this.Close();
        }
    }
}
