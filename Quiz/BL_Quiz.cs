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
        public List<QuestionDTO> GetQuestion()
        {
            List<QuestionDTO> ret = new List<QuestionDTO>();
            //IList<Question> q = from l in db.Questions
            //                    select new QuestionD(
            //                        l.Q_Answer,
            //                        l.Q_ChoiceA,
            //                        l.Q_ChoiceB,
            //                        l.Q_ChoiceC,
            //                        l.Q_ChoiceD,
            //                        l.Q_ID,
            //                        l.Q_PicturePath,
            //                        l.Q_Question);
            IEnumerable<QuestionDTO> q = from l in db.Questions
                                      select new QuestionDTO
                                      {
                                          Q_Answer =l.Q_Answer,
                                          Q_ChoiceA =l.Q_ChoiceA,
                                          Q_ChoiceB =l.Q_ChoiceB,
                                          Q_ChoiceC = (l.Q_ChoiceC == null ) ? "" : l.Q_ChoiceC ,
                                          Q_ChoiceD = (l.Q_ChoiceD == null ) ? "" : l.Q_ChoiceD ,
                                          Q_ID=l.Q_ID,
                                          Q_Question=l.Q_Question,
                                          Q_PicturePath=l.Q_PicturePath
                                      };
            foreach (var a in q)
            {
                ret.Add(new QuestionDTO
                {
                    Q_Answer = a.Q_Answer,
                    Q_ChoiceA = a.Q_ChoiceA,
                    Q_Question = a.Q_Question,
                    Q_ChoiceB = a.Q_ChoiceB,
                    Q_ChoiceC = a.Q_ChoiceC,
                    Q_ChoiceD = a.Q_ChoiceD,
                    Q_ID = a.Q_ID,
                    Q_PicturePath = a.Q_PicturePath
                });
            }
            return ret;
        }

        public void SaveResults(Student stud)
        {
            stud.S_FirstName = "sadfa";
            db.Entry(stud).State = EntityState.Added;
            db.SaveChanges();
        }
    }
}
