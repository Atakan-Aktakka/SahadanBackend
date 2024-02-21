using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.UserModels
{
    public class LoginUserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    public class LoginResponseModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}