using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.TeamModels
{
    public class CreateTeamModel
    {
        public string TeamName { get; set; }
        public int LegueId { get; set; }
        public string TeamLogo { get; set; }
    }
    public class CreateTeamModelResponse
    {
        public int TeamId { get; set; }
    }
}