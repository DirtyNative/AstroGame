using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Players;
using AstroGame.Storage.Repositories.Stellar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;

namespace AstroGame.Api.Managers.Players
{
    [ScopedService]
    public class SpeciesManager
    {
        private readonly SpeciesRepository _speciesRepository;
        private readonly ImageRepository _imageRepository;

        public SpeciesManager(SpeciesRepository speciesRepository, ImageRepository imageRepository)
        {
            _speciesRepository = speciesRepository;
            _imageRepository = imageRepository;
        }

        public async Task<List<Species>> GetAsync()
        {
            return await _speciesRepository.GetAsync();
        }

        public async Task<Species> GetAsync(Guid id)
        {
            return await _speciesRepository.GetAsync(id);
        }

        public async Task<Stream> GetImageAsync(Guid speciesId)
        {
            var stellarObject = await _speciesRepository.GetAsync(speciesId);

            return await _imageRepository.GetAsync(Stores.SpeciesStore, stellarObject.AssetName);
        }
    }
}