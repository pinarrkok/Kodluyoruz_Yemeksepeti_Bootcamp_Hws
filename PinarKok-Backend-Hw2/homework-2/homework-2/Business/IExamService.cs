using homework_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Business
{
    public interface IExamService
    {
        List<Exam> GetAll();
        void Add(ExamDto examDto);
        void Update(ExamDto examDto);
        void Remove(int id);
    }
}
