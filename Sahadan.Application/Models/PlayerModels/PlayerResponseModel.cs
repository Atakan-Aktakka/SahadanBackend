using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.PlayerModels
{
    public class PlayerResponseModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int TeamId { get; set; }
        public string ImageURL { get; set; }
        public int Age { get; set; }
        public int JerseyNumber { get; set; }
    }
}