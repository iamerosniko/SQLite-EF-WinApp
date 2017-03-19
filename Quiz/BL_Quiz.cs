using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class BL_Quiz
    {
        ThisQuizEntities db = new ThisQuizEntities();
        public IQueryable<Question> GetQuestion()
        {
            var q = from l in db.Questions
                    select l;
            return q;
        }

        public void SaveResults(Student stud)
        {
            stud.S_FirstName = "sadfa";
            db.Entry(stud).State = EntityState.Added;
            db.SaveChanges();
        }
    }
}
