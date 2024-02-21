using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Abstract;

namespace Sahadan.Entities.Concrete
{
    public class Country:IEntity
    {
        
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public List<Legue> Legues { get; set; }
    }
}