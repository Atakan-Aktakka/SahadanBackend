using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Concrete;

namespace Sahadan.Entities.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
         AccessToken CreateToken(UserTest user, List<UserRoles> operationClaims);
    }
}