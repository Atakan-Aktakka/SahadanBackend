using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models;
using Sahadan.Application.Models.LegueModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Abstract
{
    public interface ILegueService
    {
        Task<IEnumerable<LegueResponseModel>> GetLegues();
        Task<Legue> GetLegueById(int id);
        Task<CreateLegueModelResponse> Add(CreateLegueModel legue);
        Task<UpdateLegueModelResponse> Update(int id, UpdateLegueModel legue);
        Task<BaseReponseModel> Delete(int id);
        Task<IEnumerable<Legue>> GetLeguesByCountryId(int countryId);
    }
}