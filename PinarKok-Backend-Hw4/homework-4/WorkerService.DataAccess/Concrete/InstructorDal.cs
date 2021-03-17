using WorkerService.Core.DataAccess;
using WorkerService.DataAccess.Abstract;
using WorkerService.DataAccess.Concrete.Context;
using WorkerService.Entities;
using WorkerService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.DataAccess.Concrete
{
    public class InstructorDal : EntityRepositoryBase<Instructor, OnlineExaminationSystemContext>, IInstructorDal
    {
    }
}
