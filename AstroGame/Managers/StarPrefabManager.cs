using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories;
using AstroGame.Shared.Models.Prefabs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Api.Repositories.Stellar;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class StarPrefabManager : ManagerBase<StarPrefab>
    {
        private readonly StarPrefabRepository _starPrefabRepository;

        public StarPrefabManager(MultiObjectSystemRepository multiObjectSystemRepository,
            SingleObjectSystemRepository singleObjectSystemRepository, StarRepository starRepository,
            PlanetRepository planetRepository, MoonRepository moonRepository, StarPrefabRepository starPrefabRepository) : base(multiObjectSystemRepository,
            singleObjectSystemRepository, starRepository, planetRepository, moonRepository)
        {
            _starPrefabRepository = starPrefabRepository;
        }

        public override async Task<StarPrefab> GetAsync(Guid id)
        {
            return await _starPrefabRepository.GetAsync(id);
        }

        public override Task<List<StarPrefab>> GetByParentAsync(Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}