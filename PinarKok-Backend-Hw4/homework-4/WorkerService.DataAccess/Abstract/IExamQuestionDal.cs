using WorkerService.Core.DataAccess;
using WorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.DataAccess.Abstract
{
    public interface IExamQuestionDal : IEntityRepository<ExamQuestion>
    {
    }
}
