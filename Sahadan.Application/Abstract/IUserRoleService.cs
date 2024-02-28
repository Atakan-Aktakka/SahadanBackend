using Sahadan.Application.Models;
using Sahadan.Application.Models.UserModels;
using Sahadan.Application.Models.UserRoleModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Abstract
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleResponseModel>> GetRoles();
        Task<CreateUserRoleResponseModel> AddRole(CreateUserRoleModel userRole);
        Task<UpdateUserRoleResponseModel> UpdateRole(int id ,UpdateUserRoleModel userRole);
        Task<BaseReponseModel> DeleteRole(int roleId);
        Task<UserRoleResponseModel> GetRoleById(int roleId);

    }
}