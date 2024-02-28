using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sahadan.DataAccess.Abstract;
using Sahadan.DataAccess.Concrete.EntityFrameWork.Contexts;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Concrete.EntityFrameWork
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
         public UserRepository(SahadanContext context) : base(context) { }

        public Task<List<UserRole>> GetRoles(User user)
        {
            var result = from userRole in _context.UserRoles
                join userClaim in _context.UserClaims on userRole.RoleId equals userClaim.UserRoleId
                where userClaim.UserId == user.UserId
                select new UserRole
                {
                    RoleId = userRole.RoleId,
                    Name = userRole.Name
                };
            return result.ToListAsync();
        }
    }
}