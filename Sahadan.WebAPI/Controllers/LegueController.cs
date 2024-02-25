using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.LegueModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;
using Sahadan.WebAPI;

namespace Sahadan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegueController : ControllerBase
    {
        private readonly ILegueService _legueService;

        public LegueController(ILegueService legueService)
        {
            _legueService = legueService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLegues()
        {
            return Ok(ApiResult<IEnumerable<LegueResponseModel>>.Success(await _legueService.GetLegues()));
        }
        [HttpGet("getbyid/legueId={id:int}")]
        public async Task<IActionResult> GetLegueById(int id)
        {
            return Ok(ApiResult<Legue>.Success(await _legueService.GetLegueById(id)));
        }
        [HttpGet("getbycountry/countryId={id:int}")]
        public async Task<IActionResult> GetLeguesByCountryId(int id)
        {
            return Ok(ApiResult<IEnumerable<Legue>>.Success(await _legueService.GetLeguesByCountryId(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateLegueModel legue)
        {
            try{
                var result = await _legueService.Add(legue);
                return Ok(ApiResult<CreateLegueModelResponse>.Success(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResult<CreateLegueModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateLegueModel legue)
        {
            try{
                var result = await _legueService.Update(id,legue);
                return Ok(ApiResult<UpdateLegueModelResponse>.Success(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResult<UpdateLegueModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var result = await _legueService.Delete(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiResult<BaseReponseModel>.Failure(new List<string> { ex.Message }));
            }
        }   
    }
}