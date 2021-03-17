using ExamSystem.DataAccess.Context;
using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExamSystem.DataAccess
{
    public class UserDal : IUserDal
    {

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (var context = new ExamSystemContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public IList<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new ExamSystemContext())
            {
                return filter == null
                    ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();
            }
        }
    }
}
