using System;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Repositories.Researches;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AstroGame.Core.Exceptions;
using AstroGame.Storage.Configurations;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers.Researches
{
    [ScopedService]
    public class ResearchManager
    {
        private readonly ResearchRepository _researchRepository;
        private readonly ImageRepository _imageRepository;

        public ResearchManager(ResearchRepository researchRepository, ImageRepository imageRepository)
        {
            _researchRepository = researchRepository;
            _imageRepository = imageRepository;
        }

        public async Task<List<Research>> GetAsync()
        {
            return await _researchRepository.GetAsync();
        }

        public async Task<Stream> GetImageAsync(Guid researchId)
        {
            var building = await _researchRepository.GetAsync(researchId);

            if (building == null)
            {
                throw new NotFoundException($"Building {researchId} not found");
            }

            return await _imageRepository.GetAsync(Stores.ResearchStore, building.AssetName);
        }
    }
}