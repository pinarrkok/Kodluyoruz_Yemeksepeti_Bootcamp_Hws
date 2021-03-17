using Logging.Business.Abstract;
using Logging.DataAccess.Abstract;
using Logging.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging.Business.Concrete
{
    public class StudentService : IStudentService
    {
        private IStudentDal _studentDal;

        public StudentService(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void Add(Student student)
        {
            _studentDal.Add(student);
        }

        public void Delete(Student student)
        {
            _studentDal.Delete(student);
        }

        public Student GetById(int userId)
        {
            return _studentDal.Get(filter: student => student.UserId == userId);
        }

        public Student GetByStudentId(string studentId)
        {
            return _studentDal.Get(s => s.StudentId == studentId);
        }

        public List<Student> GetList()
        {
            return new List<Student>(_studentDal.GetList().ToList());
        }

        public void Update(Student student)
        {
            _studentDal.Update(student);
        }
    }
}
