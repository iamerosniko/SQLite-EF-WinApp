using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class BL_Quiz
    {
        QuizEntities db = new QuizEntities();
        public IQueryable<Question> GetQuestion()
        {
            var q = from l in db.Questions
                    select l;
            return q;
        }

        public void SaveResults(Student stud)
        {
            db.Entry(stud).State = EntityState.Added;
            db.SaveChanges();
        }
    }
}
