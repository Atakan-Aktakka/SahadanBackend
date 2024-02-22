using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.UserModels;

namespace Sahadan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserModel userResponseModel)
        {
            try
            {
                var user = await _authService.LoginAsync(userResponseModel);
                return Ok(ApiResult<UserResponseModel>.Success(user));
            }catch(Exception ex)
            {
                return BadRequest(ApiResult<UserResponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserModel createUserModel)
        {
            try
            {
                var result = await _authService.RegisterAsync(createUserModel);
                return Ok(ApiResult<UserResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<UserResponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
    }
}