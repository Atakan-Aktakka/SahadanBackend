using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models.UserModels;
using Sahadan.DataAccess.Identity;


namespace Sahadan.Application.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public Task<LoginUserModel> Login(LoginUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}