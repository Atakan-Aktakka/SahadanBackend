using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Abstract
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryResponseModel>> GetCountries();
        Task<Country> GetCountryById(int id);
        Task<CreateCountryModelResponse> Add(CreateCountryModel country);
        Task<UpdateCountryModelResponse> UpdateCountry(int id, UpdateCountryModel country);
        Task<BaseReponseModel> Delete(int id);
    }
}