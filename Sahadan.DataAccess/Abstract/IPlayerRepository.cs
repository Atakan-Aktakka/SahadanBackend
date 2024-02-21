using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Abstract
{
    public interface IPlayerRepository:IBaseRepository<Player>
    {
        Task<List<Player>> GetPlayersByTeamId(int id);
    }
}