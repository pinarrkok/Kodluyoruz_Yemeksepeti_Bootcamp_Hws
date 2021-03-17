using OnlineExaminationSystem.Core.DataAccess;
using OnlineExaminationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {
    }
}
