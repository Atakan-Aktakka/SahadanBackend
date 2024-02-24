using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Abstract;

namespace Sahadan.Entities.Concrete
{
    public class UserClaims:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
    }
}