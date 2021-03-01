using AstroGame.Api.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers
{
    [Route("api/v1/material")]
    public class MaterialController : ControllerBase
    {
        private readonly MaterialManager _materialManager;

        public MaterialController(MaterialManager materialManager)
        {
            _materialManager = materialManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _materialManager.GetAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _materialManager.GetAsync(id);

            return Ok(result);
        }
    }
}