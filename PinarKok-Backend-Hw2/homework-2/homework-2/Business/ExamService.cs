using homework_2.DataAccess;
using homework_2.Extensions;
using homework_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Business
{
    public class ExamService : IExamService
    {
        private ExamDal _examDal;

        public ExamService(ExamDal examDal)
        {
            _examDal = examDal;
        }
        public void Add(ExamDto examDto)
        {
            Exam exam = examDto.ExamMapping();
            _examDal.Add(exam);
        }

        public List<Exam> GetAll()
        {
           return _examDal.GetAll();
        }

        public void Remove(int id)
        {
            _examDal.Remove(id);
        }

        public void Update(ExamDto examDto)
        {
            Exam exam = examDto.ExamMapping();
            _examDal.Update(exam);
        }
    }
}
