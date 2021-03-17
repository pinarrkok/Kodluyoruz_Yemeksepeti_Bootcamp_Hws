using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Services
{
    public interface IExamService
    {
        Exam GetById(int examId);
        List<Exam> GetList();
    }
}
