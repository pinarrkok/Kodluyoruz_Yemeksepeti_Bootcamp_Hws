using Logging.Core.DataAccess;
using Logging.DataAccess.Abstract;
using Logging.DataAccess.Concrete.Context;
using Logging.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.DataAccess.Concrete
{
    public class UserDal : EntityRepositoryBase<User, OnlineExaminationSystemContext>, IUserDal
    {
    }
}
