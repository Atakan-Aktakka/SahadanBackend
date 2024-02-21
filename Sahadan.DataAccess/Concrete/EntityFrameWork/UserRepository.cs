using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.DataAccess.Abstract;
using Sahadan.DataAccess.Concrete.EntityFrameWork.Contexts;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Concrete.EntityFrameWork
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
         public UserRepository(SahadanContext context) : base(context) { }
    }
}