using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models.UserModels;
using Sahadan.Entities.Utilities.Security.JWT;

namespace Sahadan.Application.Abstract
{
    public interface IAuthService
    {
        Task<UserResponseModel> LoginAsync(LoginUserModel userToLoginDTO);
        Task<UserResponseModel> RegisterAsync(RegisterUserModel userToRegisterDTO);
        Task<AccessToken> CreateAccessTokenAsync(UserResponseModel user);

    }
}