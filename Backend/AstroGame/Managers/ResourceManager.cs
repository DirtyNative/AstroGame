using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Storage.Repositories.Resources;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class ResourceManager
    {
        private readonly ResourceRepository _resourceRepository;

        public ResourceManager(ResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<Resource> GetAsync(Guid id)
        {
            return await _resourceRepository.GetAsync(id);
        }

        public async Task<List<Resource>> GetAsync()
        {
            return await _resourceRepository.GetAsync();
        }
    }
}