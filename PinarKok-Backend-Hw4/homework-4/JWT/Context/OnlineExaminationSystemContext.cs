using Microsoft.EntityFrameworkCore;
using JWT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Context
{
    public class OnlineExaminationSystemContext : DbContext
    {
        public OnlineExaminationSystemApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
