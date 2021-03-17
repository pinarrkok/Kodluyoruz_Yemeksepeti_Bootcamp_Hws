using Logging.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Entities
{
    public class CourseExam : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
    }
}
