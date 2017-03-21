using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class QuestionDTO
    {
        public long Q_ID { get; set; }
        public string Q_Question { get; set; }
        public string Q_ChoiceA { get; set; }
        public string Q_ChoiceB { get; set; }
        public string Q_ChoiceC { get; set; }
        public string Q_ChoiceD { get; set; }
        public string Q_Answer { get; set; }
        public string Q_PicturePath { get; set; }
    }
}
