using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamSystem.DataAccess
{
    public interface IUserDal
    {
        User Get(Expression<Func<User, bool>> filter);
        IList<User> GetList(Expression<Func<User, bool>> filter = null);

    }
}
