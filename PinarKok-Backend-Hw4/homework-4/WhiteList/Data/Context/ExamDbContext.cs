using Microsoft.EntityFrameworkCore;
using WhiteList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteList.Data.Entities;

namespace WhiteList.Data.Context
{
    public class ExamDbContext : DbContext
    {

        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {

        }


        public DbSet<Exam> Exams { get; set; }
        public DbSet<Course> Courses { get; set; }


    }
}
