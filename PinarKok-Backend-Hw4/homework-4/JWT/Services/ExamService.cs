using JWT.Context;
using JWT.Models.Derived;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Services
{
    public class ExamService : IExamService
    {
        private readonly OnlineExaminationSystemContext _dbContext;
        private readonly IMapper _mapper;

        public ExamService(OnlineExaminationSystemContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ExamDto> GetExamAsync(Guid id)
        {
            var exam = await _dbContext.Exams.SingleOrDefaultAsync(exam => exam.Id == id);
            
            if (exam == null)
            {
                return null;
            }
            return _mapper.Map<Exam>(exam);
        }

        public async Task<List<ExamDto>> GetExamsAsync()
        {
            var examEntities = await _dbContext.Exams.ToListAsync();
            var result = examEntities.Select(exam => _mapper.Map<Exam>(exam)).ToList();

            return result;

        }
    }
}
