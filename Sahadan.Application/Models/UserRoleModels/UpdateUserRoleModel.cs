using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.UserRoleModels
{
    public class UpdateUserRoleModel
    {
        public string Name { get; set; }
    }
    public class UpdateUserRoleResponseModel
    {
        public int RoleId { get; set; }
        
    }
}