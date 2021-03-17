using Microsoft.EntityFrameworkCore;
using Logging.Entities;
using Logging.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.DataAccess.Concrete.Context
{
    public class OnlineExaminationSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=OnlineExaminationSystem;Trusted_Connection=true");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseExam> CourseExams { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
