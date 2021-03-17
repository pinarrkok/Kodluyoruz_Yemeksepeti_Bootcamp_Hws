using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteList.Data.Entities
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
