using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
    }
}
