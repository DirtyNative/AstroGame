using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Technologies;
using AstroGame.Storage.Repositories.Technologies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Technologies
{
    [ScopedService]
    public class TechnologyUpgradeManager
    {
        private readonly TechnologyUpgradeRepository _technologyUpgradeRepository;

        public TechnologyUpgradeManager(TechnologyUpgradeRepository technologyUpgradeRepository)
        {
            _technologyUpgradeRepository = technologyUpgradeRepository;
        }

        public async Task<List<TechnologyUpgrade>> GetAsync(Guid playerId, Guid stellarObjectId)
        {
            return await _technologyUpgradeRepository.GetAsync(playerId, stellarObjectId);
        }
    }
}