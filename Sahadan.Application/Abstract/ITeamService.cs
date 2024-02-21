using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sahadan.Application.Models;
using Sahadan.Application.Models.TeamModels;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Abstract
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponseModel>> GetTeams();
        Task<Team> GetTeamById(int id);
        Task<CreateTeamModelResponse> Add(CreateTeamModel team);
        Task<UpdateTeamModelResponse> Update(int id,UpdateTeamModel team);
        Task<BaseReponseModel> Delete(int id);
        Task<IEnumerable<Team>> GetTeamsByLegueId(int id);
    }
}