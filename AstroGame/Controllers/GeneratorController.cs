using AstroGame.Api.Repositories;
using AstroGame.Shared.Generators.SystemGenerators;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class GeneratorController : Controller
    {
        private readonly SolarSystemGenerator _solarSystemGenerator;
        private readonly SolarSystemRepository _solarSystemRepository;

        public GeneratorController(SolarSystemGenerator solarSystemGenerator,
            SolarSystemRepository solarSystemRepository)
        {
            _solarSystemGenerator = solarSystemGenerator;
            _solarSystemRepository = solarSystemRepository;
        }

        [HttpGet("first")]
        public async Task<IActionResult> GetFirstAsync()
        {
            var solarSystem = await _solarSystemRepository.GetFirstAsync();

            return Ok(solarSystem);
        }

        [HttpGet("generate/solar-system")]
        public async Task<IActionResult> GenerateSolarSystem()
        {
            var solarSystem = _solarSystemGenerator.Generate(null);

            await _solarSystemRepository.AddAsync(solarSystem);

            return Ok(solarSystem);
        }
    }
}