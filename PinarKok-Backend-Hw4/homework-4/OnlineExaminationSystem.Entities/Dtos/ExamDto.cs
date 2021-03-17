using OnlineExaminationSystem.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.Entities.Dtos
{
    public class ExamDto : IDto
    {
        public string Title { get; set; }
        public string Information { get; set; }
        public int NumberOfQuestions { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
