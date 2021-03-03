using AstroGame.Api.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/prefab/star")]
    [ApiController]
    public class StarPrefabController : Controller
    {
        private readonly StarPrefabManager _starPrefabManager;

        public StarPrefabController(StarPrefabManager starPrefabManager)
        {
            _starPrefabManager = starPrefabManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _starPrefabManager.GetAsync(id);
            return Ok(result);
        }
    }
}