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
    public partial class Reports : Form
    {
        BL_Quiz q = new BL_Quiz();

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            List<StudentsDTO> stud = new List<StudentsDTO>();
            stud = q.GetStudents();

            foreach (var a in stud)
            {
                this.dgStud.Rows.Add(
                    a.S_FirstName+" "+a.S_LastName,
                    a.S_Course,
                    a.S_Year,
                    a.S_Score.ToString()
                    );
            }
        }
    }
}
