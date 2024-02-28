using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models.UserModels;
using Sahadan.Entities.Concrete;
using Sahadan.Entities.Utilities.Security.JWT;

namespace Sahadan.Application.Abstract
{
    public interface IAuthService
    {
        Task<User> LoginAsync(LoginUserModel userToLoginDTO);
        Task<User> RegisterAsync(CreateUserModel userToRegisterDTO);
        Task<AccessToken> CreateAccessTokenAsync(User user);

    }
}