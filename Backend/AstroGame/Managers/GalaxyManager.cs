using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Repositories.Stellar;
using AstroGame.Generator.Generators.SystemGenerators;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    [ScopedService]
    public class GalaxyManager
    {
        private readonly GalaxyRepository _galaxyRepository;
        private readonly GalaxyGenerator _galaxyGenerator;

        public GalaxyManager(GalaxyRepository galaxyRepository, GalaxyGenerator galaxyGenerator)
        {
            _galaxyRepository = galaxyRepository;
            _galaxyGenerator = galaxyGenerator;
        }

        public async Task GenerateAsync(int countSystems, int countArms)
        {
            var galaxy = _galaxyGenerator.Generate(countSystems, countArms);

            await _galaxyRepository.AddAsync(galaxy);
        }
    }
}