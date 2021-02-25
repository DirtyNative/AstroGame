using AstroGame.Api.Repositories;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        protected virtual async Task<StellarSystem> GetRecursiveAsync(StellarSystem thing)
        {
            if (thing is MultiObjectSystem multiObjectSystem)
            {
                return await GetRecursiveAsync(multiObjectSystem);
            }

            if (thing is SingleObjectSystem singleObjectSystem)
            {
                return await GetRecursiveAsync(singleObjectSystem);
            }


            throw new NotImplementedException($"{thing.GetType()} is not implemented");
        }

        protected virtual async Task<StellarObject> GetRecursiveAsync(StellarObject stellarObject)
        {
            if (stellarObject is Star star)
            {
                return await _starRepository.GetAsync(star.Id);
            }

            else if (stellarObject is Planet planet)
            {
                return await _planetRepository.GetAsync(planet.Id);
            }

            else if (stellarObject is Moon moon)
            {
                return await _moonRepository.GetAsync(moon.Id);
            }

            throw new NotImplementedException($"{stellarObject.GetType()} is not implemented");
        }
    }
}