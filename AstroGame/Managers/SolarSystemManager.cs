using AstroGame.Api.Repositories;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    public class SolarSystemManager : ManagerBase<SolarSystem>
    {
        private readonly SolarSystemRepository _solarSystemRepository;

        public SolarSystemManager(SolarSystemRepository solarSystemRepository,
            MultiObjectSystemRepository multiObjectSystemRepository,
            SingleObjectSystemRepository singleObjectSystemRepository,
            StarRepository starRepository,
            PlanetRepository planetRepository,
            MoonRepository moonRepository
        ) : base(multiObjectSystemRepository, singleObjectSystemRepository, starRepository, planetRepository,
            moonRepository)
        {
            _solarSystemRepository = solarSystemRepository;
        }

        public async Task<SolarSystem> GetRecursiveAsync(Guid solarSystemId)
        {
            var solarSystem = await GetAsync(solarSystemId);

            // Get the center systems
            return await GetRecursiveAsync(solarSystem) as SolarSystem;
        }

        public override async Task<SolarSystem> GetAsync(Guid id)
        {
            return await _solarSystemRepository.GetAsync(id);
        }

        public override async Task<List<SolarSystem>> GetByParentAsync(Guid parentId)
        {
            return await _solarSystemRepository.GetByParentAsync(parentId);
        }
    }
}