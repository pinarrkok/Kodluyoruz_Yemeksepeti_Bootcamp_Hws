using ExamSystem.DataAccess;
using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem.Services
{
    public class ExamService : IExamService
    {
        private IExamDal _examDal;

        public ExamService(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public Exam GetById(int examId)
        {
            return _examDal.Get(filter: exam => exam.Id == examId);
        }

        public List<Exam> GetList()
        {
            return new List<Exam>(_examDal.GetList().ToList());
        }
    }
}
