using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models
{
    public class UpdateCountryModel
    {
           public string CountryName { get; set; }
    }
    public class UpdateCountryModelResponse
    {
        public int CountryId { get; set; }
    }
}