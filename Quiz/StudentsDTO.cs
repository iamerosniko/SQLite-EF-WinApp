using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class StudentsDTO
    {
        public long S_ID { get; set; }
        public string S_FirstName { get; set; }
        public string S_LastName { get; set; }
        public string S_Course { get; set; }
        public string S_Year { get; set; }
        public int S_Score { get; set; }
    }
}
