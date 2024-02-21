using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.LegueModels
{
    public class CreateLegueModel
    {
        public string LegueName { get; set; }
        public int CountryId { get; set; }
    }
    public class CreateLegueModelResponse
    {
        public int LegueId { get; set; }
    }
}