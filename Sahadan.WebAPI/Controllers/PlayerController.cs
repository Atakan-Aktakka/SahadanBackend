using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.PlayerModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(ApiResult<IEnumerable<PlayerResponseModel>>.Success(await _playerService.GetPlayers()));
        }
        [HttpGet("playerId={id:int}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            return Ok(ApiResult<Player>.Success(await _playerService.GetPlayerById(id)));
        }
        [HttpGet("teamId={id:int}")]
        public async Task<IActionResult> GetPlayersByTeamId(int id)
        {
            return Ok(ApiResult<IEnumerable<Player>>.Success(await _playerService.GetPlayersByTeamId(id)));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreatePlayerModel player)
        {
            try
            {
                var result = await _playerService.Add(player);
                return Ok(ApiResult<CreatePlayerModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<CreatePlayerModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdatePlayerModel player)
        {
            try
            {
                var result = await _playerService.Update(id, player);
                return Ok(ApiResult<UpdatePlayerModelResponse>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<UpdatePlayerModelResponse>.Failure(new List<string> { ex.Message }));
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _playerService.Delete(id);
                return Ok(ApiResult<BaseReponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<BaseReponseModel>.Failure(new List<string> { ex.Message }));
            }
        }
    }
}