using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.UserRoleModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Concrete
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserRoleResponseModel> AddRole(CreateUserRoleModel userRole)
        {
            var userRoleList = _mapper.Map<UserRole>(userRole);
            var addedUserRole = await _userRoleRepository.Add(userRoleList);
            return new CreateUserRoleResponseModel
            {
                RoleId = addedUserRole.RoleId
            };
        }

        public async Task<BaseReponseModel> DeleteRole(int roleId)
        {
            var userRoleList = await _userRoleRepository.GetById(roleId);
            if (userRoleList == null)
            {
                throw new Exception("Role not found");
            }
            return new BaseReponseModel
            {
                Id = (await _userRoleRepository.Delete(userRoleList)).RoleId
            };
        }

        public async Task<UserRoleResponseModel> GetRoleById(int roleId)
        {
            var userRoleList = await _userRoleRepository.GetById(roleId);
            return _mapper.Map<UserRoleResponseModel>(userRoleList);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetRoles()
        {
            var userRoleList = await _userRoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRoleResponseModel>>(userRoleList);
        }

        public async Task<UpdateUserRoleResponseModel> UpdateRole(int id ,UpdateUserRoleModel userRole)
        {
            var userRoleList = await _userRoleRepository.GetById(id);
            if (userRoleList == null)
            {
                throw new Exception("Role not found");
            }
            userRoleList.Name = userRole.Name;
            return new UpdateUserRoleResponseModel
            {
                RoleId = (await _userRoleRepository.Update(userRoleList)).RoleId
            };
        }
    }
}