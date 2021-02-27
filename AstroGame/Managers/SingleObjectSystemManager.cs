using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class SingleObjectSystemManager
    {
        private readonly SingleObjectSystemRepository _singleObjectSystemRepository;

        public SingleObjectSystemManager(SingleObjectSystemRepository singleObjectSystemRepository)
        {
            _singleObjectSystemRepository = singleObjectSystemRepository;
        }

        public async Task<SingleObjectSystem> GetAsync(Guid id)
        {
            return await _singleObjectSystemRepository.GetAsync(id);
        }

        public async Task<List<SingleObjectSystem>> GetByParentAsync(Guid parentId)
        {
            return await _singleObjectSystemRepository.GetByParentAsync(parentId);
        }
    }
}