using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.UserModels
{
    public class UpdateUserModel
    {       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class UpdateUserModelResponse
    {
        public int UserId { get; set; }
    }
}