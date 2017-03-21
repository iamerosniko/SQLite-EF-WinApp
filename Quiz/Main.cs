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
        int page = 1;
        int lastPage;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lastPage = q.GetQuestion().Count();
            refresh();
        }

        private void refresh()
        {
            //refresh lblCtr
            lblCtr.Text = "Question #: " + page.ToString() + " of " + lastPage.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
            //string connStr = ConfigurationManager.ConnectionStrings["ThisQuizEntities"].ConnectionString;
            //MessageBox.Show(connStr);
            
            //string newConnStr = @"metadata=res://*/QuizContext.csdl|res://*/QuizContext.ssdl|res://*/QuizContext.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=;" + Application.StartupPath +@"\Quiz.sqlite" + @";'";
            //MessageBox.Show(newConnStr);
            ////MessageBox.Show(ConfigurationSettings.AppSettings["ThisQuizEntities"].ToString());
            //ConfigurationManager.ConnectionStrings["ThisQuizEntities"].ConnectionString = newConnStr;
            //MessageBox.Show(q.GetQuestion().Count().ToString());
            //q.SaveResults(new Student());
    }
}
