using OnlineExaminationSystem.Core.DataAccess;
using OnlineExaminationSystem.DataAccess.Abstract;
using OnlineExaminationSystem.DataAccess.Concrete.Context;
using OnlineExaminationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExaminationSystem.DataAccess.Concrete
{
    public class CourseDal : EntityRepositoryBase<Course, OnlineExaminationSystemContext>, ICourseDal
    {
    }
}
