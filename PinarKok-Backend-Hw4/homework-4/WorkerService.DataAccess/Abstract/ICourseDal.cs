using WorkerService.Core.DataAccess;
using WorkerService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {
    }
}
