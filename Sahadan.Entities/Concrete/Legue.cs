using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Abstract;

namespace Sahadan.Entities.Concrete
{
    public class Legue:IEntity
    {
        public int LegueId { get; set; }
        public string LegueName { get; set; }
        public int CountryId { get; set; }
        public List<Team> Teams { get; set; }
    }
}