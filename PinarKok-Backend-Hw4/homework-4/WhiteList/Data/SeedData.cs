using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhiteList.Data.Context;
using WhiteList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteList.Data.Entities;

namespace WhiteList.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExamDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<ExamDbContext>>()))
            {
                if (context.Courses.Any())
                {
                    return;
                }
                context.Courses.AddRange(
                    new Course
                    {
                        Id = 1,
                        Title = "x Course",
                        AddedAt = DateTime.Now
                    },
                    new Course
                    {
                        Id = 2,
                        Title = "x Course",
                        AddedAt = DateTime.Now
                    }
);
                context.Exams.AddRange(
                    new Exam
                    {
                        Id = 1,
                        Title = "X Exam",
                        Information = "Midterm Exam",
                        NumberOfQuestions = 5,
                        AddedAt = DateTime.Now,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now
                    },

                    new Exam
                    {
                        Id = 2,
                        Title = "y Exam",
                        Information = "Final Exam",
                        NumberOfQuestions = 5,
                        AddedAt = DateTime.Now,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now
                    }
               );

                context.SaveChanges();
            }
        }
    }
}
