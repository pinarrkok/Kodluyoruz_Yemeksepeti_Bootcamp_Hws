using ExamSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Services
{
    public interface IUserService
    {
        User GetById(int userId);
        List<User> GetList();
    }
}
