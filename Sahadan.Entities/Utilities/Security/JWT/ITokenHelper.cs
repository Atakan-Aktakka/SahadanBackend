using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Concrete;

namespace Sahadan.Entities.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        Task<AccessToken>CreateToken(User user, List<UserRole> operationClaims);
    }
}