using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models.UserModels;
using Sahadan.Entities.Concrete;
using Sahadan.Entities.Utilities.Security.Hashing;
using Sahadan.Entities.Utilities.Security.JWT;


namespace Sahadan.Application.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(IMapper mapper, IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;

        }

        public async Task<AccessToken> CreateAccessTokenAsync(User user)
        {
           var userRoles = await _userService.GetRoles(user);
           var token = await _tokenHelper.CreateToken(user, userRoles);
            return token;
        }

        public async Task<User> LoginAsync(LoginUserModel userToLoginDTO)
        {
            var userToCheck = await _userService.GetByMail(userToLoginDTO.Email);
            if (userToCheck == null)
            {
                throw new System.Exception("User not found");
            }
            if (!HashingHelper.VerifyPasswordHash(userToLoginDTO.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new System.Exception("Password is wrong");
            }
            return _mapper.Map<User>(userToCheck);
        }


        public async Task<User> RegisterAsync(CreateUserModel userToRegisterDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userToRegisterDTO.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userToRegisterDTO.FirstName,
                LastName = userToRegisterDTO.LastName,
                Email = userToRegisterDTO.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var addedUser = await _userService.CreateUser(user);
            return addedUser;
        }


        private string GenerateToken(int userId, string username)
        {
            var claims = new[]
                   {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}