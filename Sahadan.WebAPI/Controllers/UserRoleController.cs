using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.UserRoleModels;

namespace Sahadan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpGet("userId={id:int}")]
        public async Task<IActionResult> GetUserRoleById(int id)
        {
            return Ok(ApiResult<UserRoleResponseModel>.Success(await _userRoleService.GetRoleById(id)));
        }
        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
            return Ok(ApiResult<IEnumerable<UserRoleResponseModel>>.Success(await _userRoleService.GetRoles()));
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateUserRoleModel userRole)
        {
            try
            {
                var result = await _userRoleService.AddRole(userRole);
                return Ok(ApiResult<CreateUserRoleResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<CreateUserRoleResponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRole(int id, UpdateUserRoleModel userRole)
        {
            try
            {
                var result = await _userRoleService.UpdateRole(id, userRole);
                return Ok(ApiResult<UpdateUserRoleResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<UpdateUserRoleResponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var result = await _userRoleService.DeleteRole(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<BaseReponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
    }
}