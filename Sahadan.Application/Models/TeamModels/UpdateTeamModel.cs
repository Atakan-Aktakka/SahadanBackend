using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.TeamModels
{
    public class UpdateTeamModel
    {
        public string TeamName { get; set; }
    }
    public class UpdateTeamModelResponse
    {
        public int TeamId { get; set; }
    }
}