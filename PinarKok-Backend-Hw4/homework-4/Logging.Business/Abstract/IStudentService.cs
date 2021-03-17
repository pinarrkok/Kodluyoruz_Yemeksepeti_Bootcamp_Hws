using Logging.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Business.Abstract
{
    public interface IStudentService
    {
        Student GetById(int userId);
        Student GetByStudentId(string studentId);
        List<Student> GetList();
        void Add(Student student);
        void Delete(Student student);
        void Update(Student student);
    }
}
