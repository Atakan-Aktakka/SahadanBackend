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
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(ApiResult<IEnumerable<UserResponseModel>>.Success(await _userService.GetAllUsers()));
        }
        [Authorize]
        [HttpGet("userId={id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            return Ok(ApiResult<UserResponseModel>.Success(await _userService.GetUserById(id)));
        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateUserModel updateUserModel)
        {
            try
            {
                var result = await _userService.UpdateUser(id, updateUserModel);
                return Ok(ApiResult<UpdateUserModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<UpdateUserModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _userService.DeleteUser(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<BaseReponseModel>.Failure(new List<string> { ex.Message }));
            }
        }

    }
}