using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
