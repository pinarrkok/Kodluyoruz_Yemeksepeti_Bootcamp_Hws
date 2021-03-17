using JWT.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Context
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<OnlineExaminationSystemContext>());
        }

        public static async Task AddSampleData(OnlineExaminationSystemContext dbContext)
        {
            if (!dbContext.Exams.Any())
            { 
                dbContext.Exams.Add(new Exam
                {
                    Id = Guid.Parse("b58e956b-02bd-44af-8dde-59a139b2bd47"),
                    Title = "something",
                    NumberOfQuestions = 5
                });
            }

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User
                {
                    Id = 1,
                    Name = "Pinar",
                    LastName = "Kok",
                    LoginName = "pinarrkok",
                    Password = "12345",
                    Phone = "12345678910"
                });
            }
            await dbContext.SaveChangesAsync();  
        }
    }
}
