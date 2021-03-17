using Logging.Core.DataAccess;
using Logging.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {
    }
}
