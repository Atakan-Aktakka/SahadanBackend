using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Entities.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}