using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Abstract
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<List<UserRole>> GetRoles(User user);
    }
}