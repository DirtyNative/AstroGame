using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class MultiObjectSystemManager : ManagerBase<MultiObjectSystem>
    {
        private readonly MultiObjectSystemRepository _multiObjectSystemRepository;

        public MultiObjectSystemManager(
            MultiObjectSystemRepository multiObjectSystemRepository,
            SingleObjectSystemRepository singleObjectSystemRepository,
            StarRepository starRepository,
            PlanetRepository planetRepository,
            MoonRepository moonRepository,
            SolarSystemRepository solarSystemRepository
        ) : base(multiObjectSystemRepository, singleObjectSystemRepository, starRepository, planetRepository,
            moonRepository, solarSystemRepository)
        {
            _multiObjectSystemRepository = multiObjectSystemRepository;
        }

        public override async Task<MultiObjectSystem> GetAsync(Guid id)
        {
            return await _multiObjectSystemRepository.GetAsync(id);
        }

        public override async Task<List<MultiObjectSystem>> GetByParentAsync(Guid parentId)
        {
            return await _multiObjectSystemRepository.GetByParentAsync(parentId);
        }
    }
}