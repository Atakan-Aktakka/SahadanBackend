using AutoMapper;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryrepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryrepository, IMapper mapper)
        {
            _countryrepository = countryrepository;
            _mapper = mapper;
        }

        public async Task<CreateCountryModelResponse> Add(CreateCountryModel country)
        {
            var countryList = _mapper.Map<Country>(country);

            var addedCountry = await _countryrepository.Add(countryList);

            if (addedCountry == null)
            {
                throw new Exception("Country not added");
            }
            return new CreateCountryModelResponse
            {
                CountryId = addedCountry.CountryId
            };
        }

        public async Task<BaseReponseModel> Delete(int id)
        {
            var countryList = await _countryrepository.GetById(id);
            if (countryList == null)
            {
                throw new Exception("Country not found");
            }
            return new BaseReponseModel
            {
                Id = (await _countryrepository.Delete(countryList)).CountryId
            };
        }

        public async Task<IEnumerable<CountryResponseModel>> GetCountries()
        {
            var countryList = await _countryrepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryResponseModel>>(countryList);

        }

        public async Task<Country> GetCountryById(int id)
        {
            var countryList = await _countryrepository.GetById(id);
            if (countryList == null)
            {
                throw new Exception("Country not found");
            }
            return countryList;
        }


        public async Task<UpdateCountryModelResponse> UpdateCountry(int id, UpdateCountryModel country)
        {
            var countryList = await _countryrepository.GetById(id);
            if (countryList == null)
            {
                throw new Exception("Country not found");
            }
            countryList.CountryName = country.CountryName;

            return new UpdateCountryModelResponse
            {
                CountryId = (await _countryrepository.Update(countryList)).CountryId
            };
        }

    }
}
