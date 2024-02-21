using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models.UserModels;

namespace Sahadan.Application.Abstract
{
    public interface IAuthService
    {
        Task<LoginUserModel> Login(LoginUserModel model);
       

    }
}