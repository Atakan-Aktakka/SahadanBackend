using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models.UserModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;


namespace Sahadan.Application.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;

        }

        public Task<Entities.Utilities.Security.JWT.AccessToken> CreateAccessTokenAsync(UserResponseModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponseModel> LoginAsync(LoginUserModel userToLoginDTO)
        {
            var user = await _userRepository.GetAsync(u => u.UserName == userToLoginDTO.UserName.ToLower() && u.Password == userToLoginDTO.Password);

            if (user == null)
            {
                return null;
            }

            var userToReturn = _mapper.Map<UserResponseModel>(user);
            userToReturn.Token = GenerateToken(user.UserId, user.UserName);

            return userToReturn;
        }


        public async Task<UserResponseModel> RegisterAsync(RegisterUserModel userToRegisterDTO)
        {
            userToRegisterDTO.UserName = userToRegisterDTO.UserName.ToLower();

            var addedUser = await _userRepository.Add(_mapper.Map<User>(userToRegisterDTO));

            var userToReturn = _mapper.Map<UserResponseModel>(addedUser);
            userToReturn.Token = GenerateToken(addedUser.UserId, addedUser.UserName);

            return userToReturn;
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