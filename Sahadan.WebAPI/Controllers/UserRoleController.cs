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

    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpGet("userId={id:int}")]
        public async Task<IActionResult> GetUserRoleById(int id)
        {
            var result = await _userRoleService.GetRoleById(id);
            return Ok(ApiResult<UserRoleResponseModel>.Success(result));
           
        }
        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
            var result = await _userRoleService.GetRoles();
            return Ok(ApiResult<IEnumerable<UserRoleResponseModel>>.Success(result));
            
        }
        [HttpPost("Roleadd")]
        public async Task<IActionResult> AddRole(CreateUserRoleModel userRole)
        {

                var result = await _userRoleService.AddRole(userRole);
                return Ok(ApiResult<CreateUserRoleResponseModel>.Success(result));
 
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRole(int id, UpdateUserRoleModel userRole)
        {

                var result = await _userRoleService.UpdateRole(id, userRole);
                return Ok(ApiResult<UpdateUserRoleResponseModel>.Success(result));
         
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {

                var result = await _userRoleService.DeleteRole(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
       
        }
    }
}