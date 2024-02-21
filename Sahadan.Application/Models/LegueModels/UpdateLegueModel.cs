using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.LegueModels
{
    public class UpdateLegueModel
    {
        public string LegueName { get; set; }
    }
    public class UpdateLegueModelResponse
    {
        public int LegueId { get; set; }
    }
}