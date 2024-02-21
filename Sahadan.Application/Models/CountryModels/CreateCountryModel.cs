using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models
{
    public class CreateCountryModel
    {
        public string CountryName { get; set; }
    }
    public class CreateCountryModelResponse
    {
        public int CountryId { get; set; }
    }
}