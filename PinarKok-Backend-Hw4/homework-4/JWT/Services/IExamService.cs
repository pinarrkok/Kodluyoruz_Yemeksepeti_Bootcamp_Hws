using JWT.Models.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Services
{
    public interface IExamService
    {
        Task<List<ExamDto>> GetExamsAsync();
        Task<ExamDto> GetExamAsync(Guid id);
    }
}
 