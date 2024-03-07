using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.UserModels;

namespace Sahadan.WebAPI.Controllers
{

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(ApiResult<IEnumerable<UserResponseModel>>.Success(result));

        }
        [Authorize]
        [HttpGet("userId={id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(ApiResult<UserResponseModel>.Success(result));

        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateUserModel updateUserModel)
        {
            var result = await _userService.UpdateUser(id, updateUserModel);
            return Ok(ApiResult<UpdateUserModelResponse>.Success(result));
        }
        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(ApiResult<BaseReponseModel>.Success(result));

        }

    }
}