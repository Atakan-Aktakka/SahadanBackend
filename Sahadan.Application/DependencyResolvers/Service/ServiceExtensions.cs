using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sahadan.Application.Abstract;
using Sahadan.Application.Concrete;
using Sahadan.DataAccess.Abstract;
using Sahadan.DataAccess.Concrete.EntityFrameWork;
using Sahadan.Entities.Utilities.Security.JWT;

namespace Sahadan.Application.DependencyResolvers.Service
{
   public static class ServiceExtensions
    {
        public static void AddSahadanServices(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ILegueRepository, LegueRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();


            // Register services
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILegueService, LegueService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
                        services.AddScoped<ITokenHelper, JwtHelper>();

            
        }
    }
}