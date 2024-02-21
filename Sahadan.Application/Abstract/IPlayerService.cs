using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models;
using Sahadan.Application.Models.PlayerModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Abstract
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerResponseModel>> GetPlayers();
        Task<Player> GetPlayerById(int id);
        Task<CreatePlayerModelResponse> Add(CreatePlayerModel player);
        Task<UpdatePlayerModelResponse> Update(int id ,UpdatePlayerModel player);
        Task<BaseReponseModel> Delete(int id);
        Task<IEnumerable<Player>> GetPlayersByTeamId(int teamId);
    }
}