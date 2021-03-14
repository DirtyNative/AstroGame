using AstroGame.Api.Repositories.Stellar;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    public abstract class ManagerBase<T>
    {
        private readonly StellarSystemRepository _stellarSystemRepository;

        private readonly StarRepository _starRepository;
        private readonly PlanetRepository _planetRepository;
        private readonly MoonRepository _moonRepository;


        protected ManagerBase(StellarSystemRepository stellarSystemRepository,
            StarRepository starRepository,
            PlanetRepository planetRepository,
            MoonRepository moonRepository
        )
        {
            _stellarSystemRepository = stellarSystemRepository;

            _starRepository = starRepository;
            _planetRepository = planetRepository;
            _moonRepository = moonRepository;
        }

        public abstract Task<T> GetAsync(Guid id);

        public abstract Task<List<T>> GetByParentAsync(Guid parentId);


        protected virtual async Task<StellarSystem> GetRecursiveAsync(StellarSystem stellarSystem)
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

            return entity;
        }

        /*protected virtual async Task<StellarSystem> GetRecursiveAsync(StellarSystem system)
        {
            return system switch
            {
                MultiObjectSystem multiObjectSystem => await GetRecursiveAsync(multiObjectSystem),
                SolarSystem solarSystem => await GetRecursiveAsync(solarSystem),
                _ => throw new NotImplementedException($"{system.GetType()} is not implemented")
            };
        }*/

        protected virtual async Task<StellarObject> GetRecursiveAsync(StellarObject stellarObject)
        {
            return stellarObject switch
            {
                Star star => await _starRepository.GetAsync(star.Id),
                Planet planet => await _planetRepository.GetAsync(planet.Id),
                Moon moon => await _moonRepository.GetAsync(moon.Id),
                _ => throw new NotImplementedException($"{stellarObject.GetType()} is not implemented")
            };
        }


        protected virtual async Task DeleteRecursiveAsync(StellarSystem stellarSystem)
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

       /* protected virtual async Task DeleteRecursiveAsync(StellarSystem system)
        {
            switch (system)
            {
                case MultiObjectSystem multiObjectSystem:
                    await DeleteRecursiveAsync(multiObjectSystem);
                    return;
            }

            throw new NotImplementedException($"{system.GetType()} is not implemented");
        } */

        protected virtual async Task DeleteRecursiveAsync(StellarObject stellarObject)
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