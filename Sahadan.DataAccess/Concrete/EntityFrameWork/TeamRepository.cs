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
    public class TeamRepository:BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(SahadanContext context) : base(context) { }

        public async Task<List<Team>> GetTeamsByLegueId(int id)
        {
          var teams = await _dbSet.Where(x => x.LegueId == id).ToListAsync();
            return teams;
        }
    }
}