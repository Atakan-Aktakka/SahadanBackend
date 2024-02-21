using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;
using Sahadan.WebAPI;

namespace Sahadan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(ApiResult<IEnumerable<CountryResponseModel>>.Success(await _countryService.GetCountries()));
            //return Ok(await _countryService.GetCountries());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            return Ok(ApiResult<Country>.Success(await _countryService.GetCountryById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateCountryModel createCountry)
        {
            try
            {
                var result = await _countryService.Add(createCountry);
                return Ok(ApiResult<CreateCountryModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<CreateCountryModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCountryModel country)
        {
            try
            {
                var result = await _countryService.UpdateCountry(id, country);
                return Ok(ApiResult<UpdateCountryModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<UpdateCountryModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _countryService.Delete(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return NotFound(ApiResult<BaseReponseModel>.Failure(new List<string> { ex.Message }));
            }
        }

    }
}