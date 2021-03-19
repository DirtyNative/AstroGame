using AstroGame.Api.Repositories.Stellar;
using AstroGame.Generator.Generators.SystemGenerators;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AstroGame.Core.Structs;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/generator")]
    [ApiController]
    public class GeneratorController : Controller
    {
        private readonly SolarSystemGenerator _solarSystemGenerator;
        private readonly SolarSystemRepository _solarSystemRepository;
        private readonly GalaxyRepository _galaxyRepository;
        private readonly GalaxyStellarObjectGenerator _galaxyStellarObjectGenerator;

        public GeneratorController(SolarSystemGenerator solarSystemGenerator,
            SolarSystemRepository solarSystemRepository, GalaxyRepository galaxyRepository,
            GalaxyStellarObjectGenerator galaxyStellarObjectGenerator)
        {
            _solarSystemGenerator = solarSystemGenerator;
            _solarSystemRepository = solarSystemRepository;
            _galaxyRepository = galaxyRepository;
            _galaxyStellarObjectGenerator = galaxyStellarObjectGenerator;
        }

        [HttpGet("first")]
        public async Task<IActionResult> GetFirstAsync()
        {
            var solarSystem = await _solarSystemRepository.GetFirstAsync();

            return Ok(solarSystem);
        }

        [HttpGet("last")]
        public async Task<IActionResult> GetLastAsync()
        {
            var solarSystem = await _solarSystemRepository.GetLastAsync();

            return Ok(solarSystem);
        }

        [HttpGet("generate/solar-system")]
        public async Task<IActionResult> GenerateSolarSystem()
        {
            var solarSystem = _solarSystemGenerator.GenerateRecursive(null, Vector3.Zero, 1);

            await _solarSystemRepository.AddAsync(solarSystem);

            return Ok(solarSystem);
        }
    }
}