using ExamSystem.DataAccess.Context;
using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExamSystem.DataAccess
{
    public class ExamDal : IExamDal
    {

        public Exam Get(Expression<Func<Exam, bool>> filter)
        {
            using (var context = new ExamSystemContext())
            {
                return context.Set<Exam>().SingleOrDefault(filter);
            }
        }

        public IList<Exam> GetList(Expression<Func<Exam, bool>> filter = null)
        {
            using (var context = new ExamSystemContext())
            {
                return filter == null
                    ? context.Set<Exam>().ToList()
                    : context.Set<Exam>().Where(filter).ToList();
            }
        }
    }
}
