using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models;
using Sahadan.Application.Models.TeamModels;
using Sahadan.Application.Models.UserModels;

namespace Sahadan.Application.Abstract
{
    public interface IUserService
    {
        Task<UserResponseModel> GetUserById(int userId);
        Task<CreateUserModelResponse> CreateUser(CreateUserModel createUserModel);
        Task<UpdateUserModelResponse> UpdateUser(int userId, UpdateUserModel updateUserModel);
        Task<BaseReponseModel> DeleteUser(int userId);
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
    }
}