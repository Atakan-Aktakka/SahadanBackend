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
    public class LegueRepository : ILegueRepository
    {
        private readonly SahadanContext _context;
        private readonly DbSet<Legue> _dbSet;

        public LegueRepository(SahadanContext context)
        {
            _context = context;
            _dbSet = context.Set<Legue>();
        }
        public async Task<Legue> Add(Legue entity)
        {
            var addedLegue = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedLegue;
        }

        public async Task<Legue> Delete(Legue entity)
        {
            var removedLegue = _dbSet.Remove(entity).Entity;
            await _context.SaveChangesAsync();
            return removedLegue;
        }

        public async Task<List<Legue>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Legue> GetById(int id)
        {
           var legue = await _dbSet.FindAsync(id);
            return legue ?? throw new Exception("Legue not found.");
        }

        public async Task<List<Legue>> GetLeguesByCountryId(int id)
        {
            var legues = await _dbSet.Where(x => x.CountryId == id).ToListAsync();
            return legues;
        }

        public async Task<Legue> Update(Legue entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}