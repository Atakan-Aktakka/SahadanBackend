using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sahadan.Application.Abstract;
using Sahadan.Application.Models;
using Sahadan.Application.Models.LegueModels;
using Sahadan.DataAccess.Abstract;
using Sahadan.Entities.Concrete;

namespace Sahadan.Application.Concrete
{
    public class LegueService : ILegueService
    {
        private readonly ILegueRepository _legueRepository;
        private readonly IMapper _mapper;

        public LegueService(IMapper mapper,ILegueRepository legueRepository)
        {
            _mapper = mapper;
            _legueRepository = legueRepository;
        }

        public async Task<CreateLegueModelResponse> Add(CreateLegueModel legue)
        {
           var legueList = _mapper.Map<Legue>(legue);
           var addedLegue =  await _legueRepository.Add(legueList);
            return new CreateLegueModelResponse
            {
                LegueId = addedLegue.LegueId
            };  
        }

        public async Task<BaseReponseModel> Delete(int id)
        {
            var legueList = await _legueRepository.GetById(id);
            if (legueList == null)
            {
                throw new Exception("Legue not found");
            }
            return new BaseReponseModel
            {
                Id = (await _legueRepository.Delete(legueList)).LegueId
            };
        }

        public async  Task<Legue> GetLegueById(int id)
        {
            var legueList = await _legueRepository.GetById(id);
            return _mapper.Map<Legue>(legueList);
        }

        public async Task<IEnumerable<LegueResponseModel>> GetLegues()
        {
            var legueList = await _legueRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LegueResponseModel>>(legueList);
        }

        public async Task<IEnumerable<Legue>> GetLeguesByCountryId(int countryId)
    {
        var legueList = await _legueRepository.GetLeguesByCountryId(countryId);
        return _mapper.Map<IEnumerable<Legue>>(legueList);
    }

        public async Task<UpdateLegueModelResponse> Update(int id, UpdateLegueModel legue)
        {
            var legueList = await _legueRepository.GetById(id);
            if (legueList == null)
            {
                throw new Exception("Legue not found");
            }
            legueList.LegueName = legue.LegueName;

            return new UpdateLegueModelResponse
            {
                LegueId = (await _legueRepository.Update(legueList)).LegueId
            };
        }
    }
}