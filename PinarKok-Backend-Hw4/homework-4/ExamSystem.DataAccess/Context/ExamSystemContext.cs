using ExamSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.DataAccess.Context
{
    public class ExamSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=OnlineExaminationSystem;Trusted_Connection=true");
        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
