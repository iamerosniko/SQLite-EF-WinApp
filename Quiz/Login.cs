using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Login : Form
    {

        public Student getStudents()
        {
            return new Student
            {
                S_FirstName=txtName.Text.Trim(),
                S_Course=txtCourse.Text.Trim(),
                S_LastName=txtLname.Text.Trim(),
                S_Year=txtYearSec.Text.Trim()
            };
        }
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
