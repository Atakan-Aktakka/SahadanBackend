using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.LegueModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.WebAPI.Controllers
{

    public class LegueController : BaseController
    {
        private readonly ILegueService _legueService;

        public LegueController(ILegueService legueService)
        {
            _legueService = legueService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLegues()
        {
            var result = await _legueService.GetLegues();
            return Ok(ApiResult<IEnumerable<LegueResponseModel>>.Success(result));
            
        }
        [HttpGet("getbyid/legueId={id:int}")]
        public async Task<IActionResult> GetLegueById(int id)
        {
            var result = await _legueService.GetLegueById(id);
            return Ok(ApiResult<Legue>.Success(result));
            
        }
        [HttpGet("getbycountry/countryId={id:int}")]
        public async Task<IActionResult> GetLeguesByCountryId(int id)
        {
            var result = await _legueService.GetLeguesByCountryId(id);
            return Ok(ApiResult<IEnumerable<Legue>>.Success(result));
            
        }
        [Authorize]
        [HttpPost("Legueadd")]
        public async Task<IActionResult> Add(CreateLegueModel legue)
        {
            var result = await _legueService.Add(legue);
            return Ok(ApiResult<CreateLegueModelResponse>.Success(result));
        }
        [Authorize]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateLegueModel legue)
        {

            var result = await _legueService.Update(id, legue);
            return Ok(ApiResult<UpdateLegueModelResponse>.Success(result));

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _legueService.Delete(id);
            return Ok(ApiResult<BaseReponseModel>.Success(result));

        }
    }
}