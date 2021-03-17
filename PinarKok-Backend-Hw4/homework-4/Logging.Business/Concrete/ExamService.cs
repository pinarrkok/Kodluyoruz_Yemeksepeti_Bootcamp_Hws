using Logging.Business.Abstract;
using Logging.DataAccess.Abstract;
using Logging.Entities.Concrete;
using Logging.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.Business.Concrete
{
    public class ExamService : IExamService
    {
        private IExamDal _examDal;

        public ExamService(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public void Add(ExamDto examDto)
        {
            var exam = new Exam
            {
                Title = examDto.Title,
                Information = examDto.Information,
                NumberOfQuestions = examDto.NumberOfQuestions,
                AddedAt = DateTime.Now,
                StartTime = DateTime.Parse(examDto.StartTime),
                EndTime = DateTime.Parse(examDto.EndTime)
            };

            _examDal.Add(exam);
        }

        public void Delete(int examId)
        {
            _examDal.Delete(_examDal.Get(filter: exam => exam.Id == examId));
        }

        public Exam GetByCourseName(string courseName)
        {
            // join two tables
            throw new NotImplementedException();
        }

        public Exam GetById(int examId)
        {
            return _examDal.Get(filter: exam => exam.Id == examId);
        }

        public Exam GetByTitle(string examTitle)
        {
            return _examDal.Get(filter: exam => exam.Title == examTitle);
        }

        public List<Exam> GetList()
        {
            return new List<Exam>(_examDal.GetList().ToList());
        }

        public void Update(int examId)
        {
            _examDal.Update(_examDal.Get(filter: exam => exam.Id == examId));
        }
    }
}
