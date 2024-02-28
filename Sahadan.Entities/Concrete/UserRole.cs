using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Abstract;

namespace Sahadan.Entities.Concrete
{
    public class UserRole:IEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}