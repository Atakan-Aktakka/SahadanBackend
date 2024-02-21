using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Models.LegueModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.MappingProfiles
{
    public class LegueProfile:Profile
    {
        public LegueProfile()
        {
            CreateMap<CreateLegueModel, Legue>();
            CreateMap<Legue, LegueResponseModel>();
        }
    }
}