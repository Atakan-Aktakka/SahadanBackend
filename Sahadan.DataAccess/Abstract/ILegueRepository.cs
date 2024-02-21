using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Entities.Concrete;

namespace Sahadan.DataAccess.Abstract
{
    public interface ILegueRepository
    {
        Task<List<Legue>> GetAllAsync();
        Task<Legue> GetById(int id);
        Task<Legue> Add(Legue entity);
        Task<Legue> Update(Legue entity);
        Task<Legue> Delete(Legue entity);
        Task<List<Legue>> GetLeguesByCountryId(int id);
    }
}