using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.PlayerModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public async Task<CreatePlayerModelResponse> Add(CreatePlayerModel player)
        {
            var playerList = _mapper.Map<Player>(player);
            var addedPlayer = await _playerRepository.Add(playerList);
            return new CreatePlayerModelResponse
            {
                PlayerId = addedPlayer.PlayerId
            };
        }

        public async Task<BaseReponseModel> Delete(int id)
        {
            var playerList = await _playerRepository.GetById(id);
            if (playerList == null)
            {
                throw new Exception("Player not found");
            }
            return new BaseReponseModel
            {
                Id = (await _playerRepository.Delete(playerList)).PlayerId
            };
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var playerList = await _playerRepository.GetById(id);
            return _mapper.Map<Player>(playerList);
        }

        public async Task<IEnumerable<PlayerResponseModel>> GetPlayers()
        {
            var playerList =  await _playerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlayerResponseModel>>(playerList);
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeamId(int teamId)
        {
            var playerList = await _playerRepository.GetPlayersByTeamId(teamId);
            return _mapper.Map<IEnumerable<Player>>(playerList);
        }

        public async Task<UpdatePlayerModelResponse> Update(int id ,UpdatePlayerModel player)
        {
           var playerlist = await _playerRepository.GetById(id);
            if (playerlist == null)
            {
                throw new Exception("Player not found");
            }
           playerlist.PlayerName = player.PlayerName;
           
            return new UpdatePlayerModelResponse
            {
                PlayerId = (await _playerRepository.Update(playerlist)).PlayerId
            };

        }
    }
}