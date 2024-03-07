using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.TeamModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.WebAPI.Controllers
{

    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var result = await _teamService.GetTeams();
            return Ok(ApiResult<IEnumerable<TeamResponseModel>>.Success(result));
        }
        [HttpGet("teamId={id:int}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var result = await _teamService.GetTeamById(id);
            return Ok(ApiResult<Team>.Success(result));

        }
        [HttpGet("legueId={id:int}")]
        public async Task<IActionResult> GetTeamsByLegueId(int id)
        {
            var result = await _teamService.GetTeamsByLegueId(id);
            return Ok(ApiResult<IEnumerable<Team>>.Success(result));
        }
        [Authorize]
        [HttpPost("Teamadd")]
        public async Task<IActionResult> Add(CreateTeamModel team)
        {

            var result = await _teamService.Add(team);
            return Ok(ApiResult<CreateTeamModelResponse>.Success(result));

        }
        [Authorize]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateTeamModel team)
        {

            var result = await _teamService.Update(id, team);
            return Ok(ApiResult<UpdateTeamModelResponse>.Success(result));

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _teamService.Delete(id);
            return Ok(ApiResult<BaseReponseModel>.Success(result));

        }
    }
}