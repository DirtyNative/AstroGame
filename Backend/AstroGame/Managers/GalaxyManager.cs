using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Generator.Generators.SystemGenerators;
using System.Threading.Tasks;
using AstroGame.Storage.Repositories.Stellar;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class GalaxyManager
    {
        private readonly GalaxyRepository _galaxyRepository;
        private readonly GalaxyStellarObjectGenerator _galaxyStellarObjectGenerator;

        public GalaxyManager(GalaxyRepository galaxyRepository, GalaxyStellarObjectGenerator galaxyStellarObjectGenerator)
        {
            _galaxyRepository = galaxyRepository;
            _galaxyStellarObjectGenerator = galaxyStellarObjectGenerator;
        }

        public async Task GenerateAsync(int countSystems, int countArms)
        {
            var galaxy = _galaxyStellarObjectGenerator.Generate(countSystems, countArms);

            await _galaxyRepository.AddAsync(galaxy);
        }
    }
}