using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.TeamModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public async Task<CreateTeamModelResponse> Add(CreateTeamModel team)
        {
            var teamList = _mapper.Map<Team>(team);
            var addedTeam = await _teamRepository.Add(teamList);
            return new CreateTeamModelResponse
            {
                TeamId = addedTeam.TeamId
            };

        }

        public async Task<BaseReponseModel> Delete(int id)
        {
            var teamList = await _teamRepository.GetById(id);
            if (teamList == null)
            {
                throw new Exception("Team not found");
            }
            return new BaseReponseModel
            {
                Id = (await _teamRepository.Delete(teamList)).TeamId
            };
        }

        public async Task<Team> GetTeamById(int id)
        {
            var teamList = await _teamRepository.GetById(id);
            return _mapper.Map<Team>(teamList);
        }

        public async Task<IEnumerable<TeamResponseModel>> GetTeams()
        {
            var teamList = await _teamRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamResponseModel>>(teamList);
        }

        public async Task<IEnumerable<Team>> GetTeamsByLegueId(int id)
        {
            var teamList = await _teamRepository.GetTeamsByLegueId(id);
            return _mapper.Map<IEnumerable<Team>>(teamList);
        }

        public async Task<UpdateTeamModelResponse> Update(int id,UpdateTeamModel team)
        {
            var teamList = await _teamRepository.GetById(id);
             if(teamList == null)
            {
                throw new Exception("Team not found");
            }
            teamList.TeamName = team.TeamName;
           
            return new UpdateTeamModelResponse
            {
                TeamId = (await _teamRepository.Update(teamList)).TeamId
            };
        }
    }
}