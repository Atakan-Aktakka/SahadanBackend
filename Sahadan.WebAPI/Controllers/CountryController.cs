using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Entities.Concrete;

namespace Sahadan.WebAPI.Controllers
{
    
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _countryService.GetCountries();
            return Ok(ApiResult<IEnumerable<CountryResponseModel>>.Success(result));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var result = await _countryService.GetCountryById(id);
            return Ok(ApiResult<Country>.Success(result));
        }
        [Authorize]
        [HttpPost("Countryadd")]
        public async Task<IActionResult> AddAsync(CreateCountryModel createCountry)
        {
            var result = await _countryService.Add(createCountry);
            return Ok(ApiResult<CreateCountryModelResponse>.Success(result));
        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCountryModel country)
        {

            var result = await _countryService.UpdateCountry(id, country);
            return Ok(ApiResult<UpdateCountryModelResponse>.Success(result));

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _countryService.Delete(id);
            return Ok(ApiResult<BaseReponseModel>.Success(result));

        }

    }
}
