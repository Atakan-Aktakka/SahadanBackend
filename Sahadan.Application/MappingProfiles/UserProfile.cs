using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Models.UserModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserResponseModel>();
        }
        
    }
}