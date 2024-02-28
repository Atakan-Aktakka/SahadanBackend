using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.UserModels
{
    public class CreateUserModel
    {
       public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CreateUserModelResponse
    {
        public int UserId { get; set; }
    }
}