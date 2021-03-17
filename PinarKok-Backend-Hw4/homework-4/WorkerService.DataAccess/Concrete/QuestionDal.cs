using WorkerService.Core.DataAccess;
using WorkerService.DataAccess.Abstract;
using WorkerService.DataAccess.Concrete.Context;
using WorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.DataAccess.Concrete
{
    public class QuestionDal : EntityRepositoryBase<Question, OnlineExaminationSystemContext>, IQuestionDal
    {
    }
}
