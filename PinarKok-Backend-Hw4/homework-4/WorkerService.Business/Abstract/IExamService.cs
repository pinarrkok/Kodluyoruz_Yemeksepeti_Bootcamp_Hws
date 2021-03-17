using WorkerService.Entities.Concrete;
using WorkerService.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.Business.Abstract
{
    public interface IExamService
    {
        Exam GetById(int examId);
        Exam GetByTitle(string examTitle);
        Exam GetByCourseName(string courseName);
        List<Exam> GetList();
        void Add(ExamDto examDto);
        void Delete(int examId);
        void Update(int examId);
    }
}
