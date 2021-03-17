using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamSystem.DataAccess
{
    public interface IExamDal
    {
        Exam Get(Expression<Func<Exam, bool>> filter);
        IList<Exam> GetList(Expression<Func<Exam, bool>> filter = null);

    }
}
