using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories.Resources;
using AstroGame.Shared.Models.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class MaterialManager
    {
        private readonly MaterialRepository _materialRepository;

        public MaterialManager(MaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Material> GetAsync(Guid id)
        {
            return await _materialRepository.GetAsync(id);
        }

        public async Task<List<Material>> GetAsync()
        {
            return await _materialRepository.GetAsync();
        }
    }
}