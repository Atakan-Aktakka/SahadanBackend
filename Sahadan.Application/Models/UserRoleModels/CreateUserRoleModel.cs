using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.UserRoleModels
{
    public class CreateUserRoleModel
    {
        public string Name { get; set; }
    }
    public class CreateUserRoleResponseModel
    {
        public int RoleId { get; set; }
        
    }
}