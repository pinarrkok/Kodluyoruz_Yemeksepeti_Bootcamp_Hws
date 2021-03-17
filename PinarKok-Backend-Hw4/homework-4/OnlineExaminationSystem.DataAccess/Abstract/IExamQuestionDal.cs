using OnlineExaminationSystem.Core.DataAccess;
using OnlineExaminationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.DataAccess.Abstract
{
    public interface IExamQuestionDal : IEntityRepository<ExamQuestion>
    {
    }
}
