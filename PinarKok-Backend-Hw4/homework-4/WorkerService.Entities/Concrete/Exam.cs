using WorkerService.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.Entities.Concrete
{
    public class Exam : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
        public int NumberOfQuestions { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsFinished { get; set; }
    }
}
