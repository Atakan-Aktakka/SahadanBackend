using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.TeamModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            return Ok(ApiResult<IEnumerable<TeamResponseModel>>.Success(await _teamService.GetTeams()));
        }
        [HttpGet("teamId={id:int}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            return Ok(ApiResult<Team>.Success(await _teamService.GetTeamById(id)));
        }
        [HttpGet("legueId={id:int}")]
        public async Task<IActionResult> GetTeamsByLegueId(int id)
        {
            return Ok(ApiResult<IEnumerable<Team>>.Success(await _teamService.GetTeamsByLegueId(id)));
        }
        [Authorize]
        [HttpPost("Teamadd")]
        public async Task<IActionResult> Add(CreateTeamModel team)
        {
            try
            {
                var result = await _teamService.Add(team);
                return Ok(ApiResult<CreateTeamModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<CreateTeamModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [Authorize]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateTeamModel team)
        {
            try
            {
                var result = await _teamService.Update(id, team);
                return Ok(ApiResult<UpdateTeamModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<UpdateTeamModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _teamService.Delete(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<BaseReponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
    }
}