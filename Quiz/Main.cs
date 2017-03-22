using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Quiz
{
    public partial class Main : Form
    {
        BL_Quiz q = new BL_Quiz();
        List<QuestionDTO> myQuestion = new List<QuestionDTO>();
        public Student myStudent ;
        int score;
        int page = 1;
        int lastPage;
        string tempAns, myAns;
        public Main()
        {
            InitializeComponent();
            lblScore.Text = @"(c) Alpha Corporation && Stephanie Bardolasa";

        }

        private void Main_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        //custom functions

        private void Initiate()
        {
            page = 1;
            button1.Enabled = true;
            myQuestion = q.GetQuestion();
            //MessageBox.Show(a.ElementAt(page).Q_Answer.ToString());
            lastPage = myQuestion.Count();
            refresh();
        }
        private void refresh()
        {
            if (page <= lastPage)
            {
                //lblScore.Text = score.ToString();
                choiceA.Checked = false;
                choiceB.Checked = false;
                choiceC.Checked = false;
                choiceD.Checked = false;
                lblCtr.Text = "Question #: " + page.ToString() + " of " + lastPage.ToString();
                provideThings(page);
                isEmpty();
            }
            else
            {
                MessageBox.Show("Examination Over\nYour Score is : " + score );
                myStudent.S_Score = score;
                q.SaveResults(myStudent);
                button1.Enabled = false;
                startQuizToolStripMenuItem.Enabled = true;
            }
        }

        private void provideThings(int currentPage)
        {
            txtQuestion.Text = myQuestion[currentPage-1].Q_Question.ToString().Trim();
            choiceA.Text = myQuestion[currentPage-1].Q_ChoiceA.ToString().Trim();
            choiceB.Text = myQuestion[currentPage-1].Q_ChoiceB.ToString().Trim();
            choiceC.Text = myQuestion[currentPage-1].Q_ChoiceC.ToString().Trim();
            choiceD.Text = myQuestion[currentPage-1].Q_ChoiceD.ToString().Trim();
            tempAns= myQuestion[currentPage-1].Q_Answer.ToString().Trim();
        }
        private void isEmpty()
        {

            choiceC.Enabled = choiceC.Text.Trim().Equals("") ? false : true;
            choiceD.Enabled = choiceD.Text.Trim().Equals("") ? false : true;
        }
        private void confirmStudent()
        {
            if (myStudent.S_FirstName.Equals("") || myStudent.S_LastName.Equals("") || myStudent.S_Year.Equals("") || myStudent.S_Course.Equals(""))
            {
                MessageBox.Show("Fill up all fields upon login first!");
            }
            else
            {
                startQuizToolStripMenuItem.Enabled = false;
                MessageBox.Show("Hi " + myStudent.S_FirstName + " " + myStudent.S_LastName + "\nYour Quiz will now start.");
                label1.Text = "Hi " + myStudent.S_FirstName + " " + myStudent.S_LastName;
                Initiate();
            }
        }

        //event triggers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Login login = new Login())
            {
                login.ShowDialog();
                myStudent = login.getStudents();
                login.Close();
            }
            confirmStudent();
            //Initiate();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (choiceA.Checked)
                myAns = "A";
            else if (choiceB.Checked)
                myAns = "B";
            else if (choiceC.Checked)
                myAns = "C";
            else if (choiceD.Checked)
                myAns = "D";
            else myAns="";

            if (!myAns.Equals(""))
            {
                score += tempAns.Equals(myAns) ? 1 : 0;
                page += 1;
                refresh();
            }
            else
                MessageBox.Show("Please provide your answer.");
        }

        private void showStudentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.ShowDialog();
        }

        
    }
}
