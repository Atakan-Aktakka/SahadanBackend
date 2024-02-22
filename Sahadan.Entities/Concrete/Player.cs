using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Abstract;

namespace Sahadan.Entities.Concrete
{
    public class Player:IEntity
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string ImageURL { get; set; }
        public int Age { get; set; }
        public int JerseyNumber { get; set; }
        public int TeamId { get; set; }
    }
}