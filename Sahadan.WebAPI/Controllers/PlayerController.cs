using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.PlayerModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.WebAPI.Controllers
{

    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var result = await _playerService.GetPlayers();
            return Ok(ApiResult<IEnumerable<PlayerResponseModel>>.Success(result));
            
        }
        [HttpGet("playerId={id:int}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var result = await _playerService.GetPlayerById(id);
            return Ok(ApiResult<Player>.Success(result));
        }
        [HttpGet("teamId={id:int}")]
        public async Task<IActionResult> GetPlayersByTeamId(int id)
        {
            var result = await _playerService.GetPlayersByTeamId(id);
            return Ok(ApiResult<IEnumerable<Player>>.Success(result));
           
        }
        [Authorize]
        [HttpPost("Playeradd")]
        public async Task<IActionResult> Add(CreatePlayerModel player)
        {
            var result = await _playerService.Add(player);
            return Ok(ApiResult<CreatePlayerModelResponse>.Success(result));
        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdatePlayerModel player)
        {
            var result = await _playerService.Update(id, player);
            return Ok(ApiResult<UpdatePlayerModelResponse>.Success(result));

        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _playerService.Delete(id);
            return Ok(ApiResult<BaseReponseModel>.Success(result));

        }
    }
}