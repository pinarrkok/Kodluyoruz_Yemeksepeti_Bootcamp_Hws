using ExamSystem.DataAccess;
using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem.Services
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetById(int userId)
        {
            return _userDal.Get(filter: user => user.Id == userId);
        }

        public List<User> GetList()
        {
            return new List<User>(_userDal.GetList().ToList());
        }
    }
}
