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
        List<Question> myQuestion=new List<Question>();
        int page = 1;
        int lastPage;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        //custom functions

        private void Initiate()
        {
            var a = q.GetQuestion();
            MessageBox.Show(a.ElementAt(page).Q_Answer.ToString());
            lastPage = myQuestion.Count();
            //refresh();
        }
        private void refresh()
        {
            //refresh lblCtr
            lblCtr.Text = "Question #: " + page.ToString() + " of " + lastPage.ToString();
            provideThings(page);
        }

        private void provideThings(int currentPage)
        {
            txtQuestion.Text = myQuestion[currentPage-1].Q_Question.ToString().Trim();
            choiceA.Text = myQuestion[currentPage-1].Q_ChoiceA.ToString().Trim();
            choiceB.Text = myQuestion[currentPage-1].Q_ChoiceB.ToString().Trim();
            choiceC.Text = myQuestion[currentPage-1].Q_ChoiceC.ToString().Trim();
            choiceD.Text = myQuestion[currentPage-1].Q_ChoiceD.ToString().Trim();
            isEmpty();
        }
        private void isEmpty()
        {
            choiceC.Enabled = choiceC.Text.Trim().Equals(0);
            choiceD.Enabled = choiceD.Text.Trim().Equals(0);
        }
        //event triggers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startQuizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initiate();
        }

        
    }
}
