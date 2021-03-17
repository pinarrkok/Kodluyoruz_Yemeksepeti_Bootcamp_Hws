using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Model
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
