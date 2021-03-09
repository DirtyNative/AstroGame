using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Generator.Generators.SystemGenerators;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class SolarSystemManager : ManagerBase<SolarSystem>
    {
        private readonly SolarSystemRepository _solarSystemRepository;
        private readonly SolarSystemGenerator _solarSystemGenerator;

        private readonly AstroGameDataContext _context;

        public SolarSystemManager(SolarSystemRepository solarSystemRepository,
            MultiObjectSystemRepository multiObjectSystemRepository,
            SingleObjectSystemRepository singleObjectSystemRepository,
            StarRepository starRepository,
            PlanetRepository planetRepository,
            MoonRepository moonRepository, SolarSystemGenerator solarSystemGenerator,
            AstroGameDataContext context) : base(
            multiObjectSystemRepository, singleObjectSystemRepository, starRepository, planetRepository,
            moonRepository, solarSystemRepository)
        {
            _solarSystemRepository = solarSystemRepository;
            _solarSystemGenerator = solarSystemGenerator;
            _context = context;
        }

        public async Task<SolarSystem> GetRecursiveAsync(Guid solarSystemId)
        {
            var solarSystem = await GetAsync(solarSystemId);

            if (solarSystem.IsGenerated == false)
            {
                solarSystem = _solarSystemGenerator.GenerateChildren(solarSystem);
                await _context.SaveChangesAsync();
            }

            // Get the center systems
            return await GetRecursiveAsync(solarSystem) as SolarSystem;
        }

        public async Task<SolarSystem> GetBySystemNumberRecursiveAsync(uint systemNumber)
        {
            var solarSystem = await _solarSystemRepository.GetBySystemNumberAsync(systemNumber);

            if (solarSystem.IsGenerated == false)
            {
                solarSystem = _solarSystemGenerator.GenerateChildren(solarSystem);
                await _context.SaveChangesAsync();
            }

            // Get the center systems
            return await GetRecursiveAsync(solarSystem) as SolarSystem;
        }

        public async Task<List<SolarSystem>> GetRecursiveAsync()
        {
            var solarSystems = await GetAsync();

            for (var i = 0; i < solarSystems.Count; i++)
            {
                var solarSystem = await GetRecursiveAsync(solarSystems[i]) as SolarSystem;

                // Should not happen but better catch
                if (solarSystem == null) continue;

                if (solarSystem.IsGenerated == false)
                {
                    solarSystem = _solarSystemGenerator.GenerateChildren(solarSystem);
                    await _context.SaveChangesAsync();
                }

                solarSystems[i] = solarSystem;
            }

            return solarSystems;
        }

        public override async Task<SolarSystem> GetAsync(Guid id)
        {
            return await _solarSystemRepository.GetAsync(id);
        }

        public async Task<List<SolarSystem>> GetAsync()
        {
            return await _solarSystemRepository.GetAsync();
        }

        public override async Task<List<SolarSystem>> GetByParentAsync(Guid parentId)
        {
            return await _solarSystemRepository.GetByParentAsync(parentId);
        }

        public async Task DeleteRecursiveAsync(Guid id)
        {
            var solarSystem = await GetRecursiveAsync(id);

            await DeleteRecursiveAsync(solarSystem);
        }
    }
}