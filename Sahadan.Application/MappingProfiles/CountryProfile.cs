using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Models;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountryModel, Country>();
            CreateMap<Country, CountryResponseModel>();
        }
    }
}