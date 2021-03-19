using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class RecursiveBuilder
    {
        private readonly StarRepository _starRepository;
        private readonly PlanetRepository _planetRepository;
        private readonly MoonRepository _moonRepository;
        private readonly BlackHoleRepository _blackHoleRepository;
        private readonly StellarSystemRepository _stellarSystemRepository;

        public RecursiveBuilder(StarRepository starRepository, PlanetRepository planetRepository,
            MoonRepository moonRepository, BlackHoleRepository blackHoleRepository,
            StellarSystemRepository stellarSystemRepository)
        {
            _starRepository = starRepository;
            _planetRepository = planetRepository;
            _moonRepository = moonRepository;
            _blackHoleRepository = blackHoleRepository;
            _stellarSystemRepository = stellarSystemRepository;
        }

        public async Task<StellarSystem> GetRecursiveAsync(StellarSystem stellarSystem)
        {
            var entity = await _stellarSystemRepository.GetAsync(stellarSystem.Id);

            // Get center objects
            for (var i = 0; i < entity.CenterObjects.Count; i++)
            {
                entity.CenterObjects[i] = await GetRecursiveAsync(entity.CenterObjects[i]);
            }

            // Get satellite systems
            for (var i = 0; i < entity.Satellites.Count; i++)
            {
                entity.Satellites[i] = await GetRecursiveAsync(entity.Satellites[i]);
            }

            // Sort the objects
            entity.CenterObjects = entity.CenterObjects
                .OrderBy(e => e.Coordinates.InterStellar)
                .ThenBy(e => e.Coordinates.Solar)
                .ThenBy(e => e.Coordinates.InterPlanetar)
                .ThenBy(e => e.Coordinates.InterLunar)
                .ThenBy(e => e.Coordinates.Lunar)
                .ToList();

            entity.Satellites = entity.Satellites
                .OrderBy(e => e.CenterObjects.First().Coordinates.InterStellar)
                .ThenBy(e => e.CenterObjects.First().Coordinates.Solar)
                .ThenBy(e => e.CenterObjects.First().Coordinates.InterPlanetar)
                .ThenBy(e => e.CenterObjects.First().Coordinates.InterLunar)
                .ThenBy(e => e.CenterObjects.First().Coordinates.Lunar)
                .ToList();
            
            return entity;
        }

        public async Task<StellarObject> GetRecursiveAsync(StellarObject stellarObject)
        {
            return stellarObject switch
            {
                Star star => await _starRepository.GetAsync(star.Id),
                Planet planet => await _planetRepository.GetAsync(planet.Id),
                Moon moon => await _moonRepository.GetAsync(moon.Id),
                BlackHole blackHole => await _blackHoleRepository.GetAsync(blackHole.Id),
                _ => throw new NotImplementedException($"{stellarObject.GetType()} is not implemented")
            };
        }

        public async Task DeleteRecursiveAsync(StellarSystem stellarSystem)
        {
            var entity = await _stellarSystemRepository.GetAsync(stellarSystem.Id);

            // Delete the center objects
            for (var i = entity.CenterObjects.Count - 1; i >= 0; i--)
            {
                await DeleteRecursiveAsync(entity.CenterObjects[i]);
            }

            // Delete the satellites
            for (var i = entity.Satellites.Count - 1; i >= 0; i--)
            {
                await DeleteRecursiveAsync(entity.Satellites[i]);
            }

            await _stellarSystemRepository.DeleteAsync(entity);
        }

        public async Task DeleteRecursiveAsync(StellarObject stellarObject)
        {
            switch (stellarObject)
            {
                case Star star:
                    await _starRepository.DeleteAsync(star);
                    return;
                case Planet planet:
                    await _planetRepository.DeleteAsync(planet);
                    return;
                case Moon moon:
                    await _moonRepository.DeleteAsync(moon);
                    return;
            }

            throw new NotImplementedException($"{stellarObject.GetType()} is not implemented");
        }
    }
}