using OnlineExaminationSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.Entities
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public char AnswerOption { get; set; }
    }
}
