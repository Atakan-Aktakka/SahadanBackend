using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.TeamModels;
using Sahadan.Application.Models.UserModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(User createUserModel)
        {
           var userList = _mapper.Map<User>(createUserModel);
           var addedUser = await _userRepository.Add(userList);
              return addedUser;
        }

        public async Task<BaseReponseModel> DeleteUser(int userId)
        {
            var userList = await _userRepository.GetById(userId);
            if (userList == null)
            {
                throw new Exception("User not found");
            }
            return new BaseReponseModel
            {
                Id = (await _userRepository.Delete(userList)).UserId
            };
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseModel>>(userList);
        }

        public async Task<User> GetByMail(string email)
        {
            var userList = await _userRepository.GetAsync(u => u.Email == email);
            return _mapper.Map<User>(userList);

        }

        public async Task<List<UserRole>> GetRoles(User user)
        {
           var userRoles = await _userRepository.GetRoles(user);
              return userRoles;
        }

        public async Task<UserResponseModel> GetUserById(int userId)
        {
            var userList = await _userRepository.GetById(userId);
            return _mapper.Map<UserResponseModel>(userList);
        }

        public async Task<UpdateUserModelResponse> UpdateUser(int userId, UpdateUserModel updateUserModel)
        {
            var userList = await _userRepository.GetById(userId);
            if (userList == null)
            {
                throw new Exception("User not found");
            }
            userList.FirstName = updateUserModel.UserName;
            userList.LastName = updateUserModel.Password;
            userList.Email = updateUserModel.Email;
            return new UpdateUserModelResponse
            {
                UserId = (await _userRepository.Update(userList)).UserId
            };
        }
    }
}