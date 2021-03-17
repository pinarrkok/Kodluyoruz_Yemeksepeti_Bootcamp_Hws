using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineExaminationSystem.Business.Abstract;
using OnlineExaminationSystem.Business.Concrete;
using OnlineExaminationSystem.DataAccess.Abstract;
using OnlineExaminationSystem.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExaminationSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<ICourseDal, CourseDal>();
            services.AddScoped<ICourseExamDal, CourseExamDal>();
            services.AddScoped<ICourseInstructorDal, CourseInstructorDal>();
            services.AddScoped<IExamDal, ExamDal>();
            services.AddScoped<IExamQuestionDal, ExamQuestionDal>();
            services.AddScoped<IInstructorDal, InstructorDal>();
            services.AddScoped<IQuestionDal, QuestionDal>();
            services.AddScoped<IStudentDal, StudentDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
