using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Generator.Generators.SystemGenerators;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AstroGame.Storage.Database;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class SolarSystemManager : ManagerBase<SolarSystem>
    {
        private readonly SolarSystemRepository _solarSystemRepository;
        private readonly SolarSystemGenerator _solarSystemGenerator;
        private readonly RecursiveBuilder _recursiveBuilder;

        private readonly AstroGameDataContext _context;

        public SolarSystemManager(SolarSystemRepository solarSystemRepository,
            SolarSystemGenerator solarSystemGenerator,
            AstroGameDataContext context,
            RecursiveBuilder recursiveBuilder)
        {
            _solarSystemRepository = solarSystemRepository;
            _solarSystemGenerator = solarSystemGenerator;
            _context = context;
            _recursiveBuilder = recursiveBuilder;
        }

        public async Task<SolarSystem> GetRecursiveAsync(Guid solarSystemId)
        {
            var solarSystem = await GetAsync(solarSystemId);

            if (solarSystem.IsGenerated == false)
            {
                solarSystem = _solarSystemGenerator.GenerateChildren(solarSystem, solarSystem.Coordinates);
                await _context.SaveChangesAsync();
            }

            // Get the center systems
            return await _recursiveBuilder.GetRecursiveAsync(solarSystem) as SolarSystem;
        }

        public async Task<SolarSystem> GetBySystemNumberRecursiveAsync(uint systemNumber)
        {
            var solarSystem = await _solarSystemRepository.GetBySystemNumberAsync(systemNumber);

            if (solarSystem == null)
            {
                //throw new NotFoundException();
                return null;
            }

            if (solarSystem.IsGenerated == false)
            {
                solarSystem = _solarSystemGenerator.GenerateChildren(solarSystem, solarSystem.Coordinates);
                await _context.SaveChangesAsync();
            }

            // Get the center systems
            return await _recursiveBuilder.GetRecursiveAsync(solarSystem) as SolarSystem;
        }

        public async Task<List<SolarSystem>> GetRecursiveAsync()
        {
            var solarSystems = await GetAsync();

            for (var i = 0; i < solarSystems.Count; i++)
            {
                var solarSystem = await _recursiveBuilder.GetRecursiveAsync(solarSystems[i]) as SolarSystem;

                // Should not happen but better catch
                if (solarSystem == null) continue;

                if (solarSystem.IsGenerated == false)
                {
                    solarSystem = _solarSystemGenerator.GenerateChildren(solarSystem, solarSystem.Coordinates);
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

            await _recursiveBuilder.DeleteRecursiveAsync(solarSystem);
        }
    }
}