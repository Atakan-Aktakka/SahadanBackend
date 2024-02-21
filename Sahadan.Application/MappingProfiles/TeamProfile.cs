using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Models.TeamModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.MappingProfiles
{
    public class TeamProfile: Profile
    {
        public TeamProfile()
        {
            CreateMap<CreateTeamModel, Team>();
            CreateMap<Team, TeamResponseModel>();
        }
    }
}