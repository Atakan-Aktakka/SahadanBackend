using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sahadan.DataAccess.Abstract;
using Sahadan.DataAccess.Concrete.EntityFrameWork.Contexts;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Concrete.EntityFrameWork
{
    public class PlayerRepository: BaseRepository<Player>, IPlayerRepository
    {
         public PlayerRepository(SahadanContext context) : base(context) { }

        public async Task<List<Player>> GetPlayersByTeamId(int id)
        {
            var players = await _dbSet.Where(x => x.TeamId == id).ToListAsync();
            return players;
        }
    }
}