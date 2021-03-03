using AstroGame.Api.Repositories;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AstroGame.Api.Repositories.Stellar;

namespace AstroGame.Api.Managers
{
    public abstract class ManagerBase<T>
    {
        private readonly MultiObjectSystemRepository _multiObjectSystemRepository;
        private readonly SingleObjectSystemRepository _singleObjectSystemRepository;

        private readonly StarRepository _starRepository;
        private readonly PlanetRepository _planetRepository;
        private readonly MoonRepository _moonRepository;


        protected ManagerBase(MultiObjectSystemRepository multiObjectSystemRepository,
            SingleObjectSystemRepository singleObjectSystemRepository,
            StarRepository starRepository,
            PlanetRepository planetRepository,
            MoonRepository moonRepository)
        {
            _multiObjectSystemRepository = multiObjectSystemRepository;
            _singleObjectSystemRepository = singleObjectSystemRepository;
            _starRepository = starRepository;
            _planetRepository = planetRepository;
            _moonRepository = moonRepository;
        }

        public abstract Task<T> GetAsync(Guid id);

        public abstract Task<List<T>> GetByParentAsync(Guid parentId);




        protected virtual async Task<MultiObjectSystem> GetRecursiveAsync(MultiObjectSystem multiObjectSystem)
        {
            var entity = await _multiObjectSystemRepository.GetAsync(multiObjectSystem.Id);

            // Get center objects
            for (var i = 0; i < entity.CenterSystems.Count; i++)
            {
                entity.CenterSystems[i] = await GetRecursiveAsync(entity.CenterSystems[i]);
            }

            // Get satellite systems
            for (var i = 0; i < entity.Satellites.Count; i++)
            {
                entity.Satellites[i] = await GetRecursiveAsync(entity.Satellites[i]);
            }

            return multiObjectSystem;
        }

        protected virtual async Task<SingleObjectSystem> GetRecursiveAsync(SingleObjectSystem singleObjectSystem)
        {
            var entity = await _singleObjectSystemRepository.GetAsync(singleObjectSystem.Id);

            // Get center object
            entity.CenterObject = await GetRecursiveAsync(entity.CenterObject);

            // Get satellites
            for (var i = 0; i < entity.Satellites.Count; i++)
            {
                entity.Satellites[i] = await GetRecursiveAsync(entity.Satellites[i]);
            }

            return entity;
        }

        protected virtual async Task<StellarSystem> GetRecursiveAsync(StellarSystem system)
        {
            return system switch
            {
                MultiObjectSystem multiObjectSystem => await GetRecursiveAsync(multiObjectSystem),
                SingleObjectSystem singleObjectSystem => await GetRecursiveAsync(singleObjectSystem),
                _ => throw new NotImplementedException($"{system.GetType()} is not implemented")
            };
        }

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







        protected virtual async Task DeleteRecursiveAsync(MultiObjectSystem multiObjectSystem)
        {
            var entity = await _multiObjectSystemRepository.GetAsync(multiObjectSystem.Id);

            // Delete the center objects
            for (var i = entity.CenterSystems.Count - 1; i >= 0; i--)
            {
                await DeleteRecursiveAsync(entity.CenterSystems[i]);
            }

            // Delete the satellites
            for (var i = entity.Satellites.Count - 1; i >= 0; i--)
            {
                await DeleteRecursiveAsync(entity.Satellites[i]);
            }

            await _multiObjectSystemRepository.DeleteAsync(entity);
        }

        protected virtual async Task DeleteRecursiveAsync(SingleObjectSystem singleObjectSystem)
        {
            var entity = await _singleObjectSystemRepository.GetAsync(singleObjectSystem.Id);

            // Delete the center
            await DeleteRecursiveAsync(entity.CenterObject);

            // Delete the satellites
            for (var i = entity.Satellites.Count - 1; i >= 0; i--)
            {
                await DeleteRecursiveAsync(entity.Satellites[i]);
            }

            await _singleObjectSystemRepository.DeleteAsync(entity);
        }

        protected virtual async Task DeleteRecursiveAsync(StellarSystem system)
        {
            switch (system)
            {
                case MultiObjectSystem multiObjectSystem:
                    await DeleteRecursiveAsync(multiObjectSystem);
                    return;
                case SingleObjectSystem singleObjectSystem:
                    await DeleteRecursiveAsync(singleObjectSystem);
                    return;
            }

            throw new NotImplementedException($"{system.GetType()} is not implemented");
        }

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