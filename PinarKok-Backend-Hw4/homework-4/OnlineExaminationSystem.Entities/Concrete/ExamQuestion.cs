using OnlineExaminationSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.Entities
{
    public class ExamQuestion : IEntity
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int Point { get; set; }
    }
}
