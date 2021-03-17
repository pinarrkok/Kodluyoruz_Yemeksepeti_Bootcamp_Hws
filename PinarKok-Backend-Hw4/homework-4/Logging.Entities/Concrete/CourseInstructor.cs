using Logging.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Entities
{
    public class CourseInstructor : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
    }
}
