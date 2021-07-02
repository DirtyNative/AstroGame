﻿using System;
using AstroGame.Api.Managers.Researches;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Researches
{
    [Route("api/v1/research")]
    public class ResearchController : ControllerBase
    {
        private readonly ResearchManager _researchManager;

        public ResearchController(ResearchManager researchManager)
        {
            _researchManager = researchManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var researches = await _researchManager.GetAsync();
            return Ok(researches);
        }

        [HttpGet("image/{researchId}")]
        [Produces("image/png")]
        public async Task<IActionResult> GetImageAsync(Guid researchId)
        {
            var image = await _researchManager.GetImageAsync(researchId);

            return File(image, "image/png");
        }

        [HttpGet("values/research/{researchId}/level/{startLevel}")]
        public async Task<IActionResult> GetBuildingValuesAsync([FromRoute] Guid researchId,
            [FromRoute] uint startLevel,
            [FromQuery] uint countLevels = 1)
        {
            var response = await _researchManager.GetResearchValuesAsync(researchId, startLevel, countLevels);

            return Ok(response);
        }
    }
}