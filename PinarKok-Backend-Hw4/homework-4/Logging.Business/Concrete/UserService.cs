using Logging.Business.Abstract;
using Logging.DataAccess.Abstract;
using Logging.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(filter: user => user.Id == userId);
        }

        public User GetByLastName(string lastName)
        {
            return _userDal.Get(u => u.LastName == lastName);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public User GetByName(string firstName)
        {
            return _userDal.Get(u => u.FirstName == firstName);
        }

        public List<User> GetList()
        {
            return new List<User>(_userDal.GetList().ToList());
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
