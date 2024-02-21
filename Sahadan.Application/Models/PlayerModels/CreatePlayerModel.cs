using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models.PlayerModels
{
    public class CreatePlayerModel
    {
        public string PlayerName { get; set; }   
        public int TeamId { get; set; }
    }
    public class CreatePlayerModelResponse
    {
        public int PlayerId { get; set; }
    }
}