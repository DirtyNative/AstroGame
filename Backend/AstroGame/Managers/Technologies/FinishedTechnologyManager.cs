using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies.FinishedTechnologies;
using AstroGame.Storage.Repositories.Technologies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Technologies
{
    [ScopedService]
    public class FinishedTechnologyManager
    {
        private readonly StellarObjectDependentFinishedTechnologyRepository
            _stellarObjectDependentFinishedTechnologyRepository;

        private readonly PlayerDependentFinishedTechnologyRepository _playerDependentFinishedTechnologyRepository;

        public FinishedTechnologyManager(
            StellarObjectDependentFinishedTechnologyRepository stellarObjectDependentFinishedTechnologyRepository,
            PlayerDependentFinishedTechnologyRepository playerDependentFinishedTechnologyRepository)
        {
            _stellarObjectDependentFinishedTechnologyRepository = stellarObjectDependentFinishedTechnologyRepository;
            _playerDependentFinishedTechnologyRepository = playerDependentFinishedTechnologyRepository;
        }

        public async Task<IEnumerable<FinishedTechnology>> GetByStellarObjectAsync(Guid stellarObjectId)
        {
            return await _stellarObjectDependentFinishedTechnologyRepository.GetAsync(stellarObjectId);
        }

        public async Task<FinishedTechnology> GetByStellarObjectAndTechnologyAsync(Guid stellarObjectId, Guid technologyId)
        {
            return await _stellarObjectDependentFinishedTechnologyRepository.GetByBuildingAsync(stellarObjectId,
                technologyId);
        }

        public async Task<IEnumerable<FinishedTechnology>> GetByPlayerAsync(Guid playerId)
        {
            return await _playerDependentFinishedTechnologyRepository.GetAsync(playerId);
        }

        public async Task<FinishedTechnology> GetByPlayerAndResearchAsync(Guid playerId, Guid researchId)
        {
            return await _playerDependentFinishedTechnologyRepository.GetByTechnologyAndPlayerAsync(researchId, playerId);
        }
    }
}