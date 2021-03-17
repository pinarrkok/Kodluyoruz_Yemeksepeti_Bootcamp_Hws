using OnlineExaminationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.Business.Abstract
{
    public interface IUserService
    {
        User GetById(int userId);
        User GetByMail(string email);
        User GetByName(string firstName);
        User GetByLastName(string lastName);
        List<User> GetList();
        void Add(User user);
        void Delete(User user);
        void Update(User user);
    }
}
