using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.UserModels;
using Sahadan.Entities.Utilities.Security.JWT;

namespace Sahadan.WebAPI.Controllers
{

    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserModel userResponseModel)
        {

            var result = await _authService.LoginAsync(userResponseModel);
            var resultToken = await _authService.CreateAccessTokenAsync(result);
            return Ok(ApiResult<AccessToken>.Success(resultToken));

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserModel createUserModel)
        {

            var result = await _authService.RegisterAsync(createUserModel);
            var resultToken = await _authService.CreateAccessTokenAsync(result);
            return Ok(ApiResult<AccessToken>.Success(resultToken));

        }
    }
}