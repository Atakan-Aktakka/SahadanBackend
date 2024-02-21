using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Models.PlayerModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.MappingProfiles
{
    public class PlayerProfile:Profile
    {
        public PlayerProfile()
        {
            CreateMap<CreatePlayerModel, Player>();
            CreateMap<Player, PlayerResponseModel>();

        }
    }
}