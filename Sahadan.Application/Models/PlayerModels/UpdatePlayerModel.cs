using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.PlayerModels
{
    public class UpdatePlayerModel
    {
        public string PlayerName { get; set; }
    }
    public class UpdatePlayerModelResponse
    {
        public int PlayerId { get; set; }
    }
    
}