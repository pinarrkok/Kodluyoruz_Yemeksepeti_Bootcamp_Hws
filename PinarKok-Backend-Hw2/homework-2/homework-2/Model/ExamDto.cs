using homework_2.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Model
{
    public class ExamDto
    {
        public int Id { get; set; }
        [ExamTitle(10, ErrorMessage = "Exam title cannot be greater than 10 char length.")]
        public string Title { get; set; }
        public string Information { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
