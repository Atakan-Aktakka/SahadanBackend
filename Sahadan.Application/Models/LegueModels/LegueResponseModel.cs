using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.LegueModels
{
    public class LegueResponseModel
    {
        public int LegueId { get; set; }
        public string LegueName { get; set; }
        public int CountryId { get; set; }
    }
}