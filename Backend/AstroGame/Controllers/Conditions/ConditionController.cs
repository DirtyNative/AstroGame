using AstroGame.Api.Managers.Conditions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstroGame.Api.Controllers.Conditions
{
    [Route("api/v1/condition")]
    public class ConditionController : ControllerBase
    {
        private readonly ConditionManager _conditionManager;

        public ConditionController(ConditionManager conditionManager)
        {
            _conditionManager = conditionManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var conditions = await _conditionManager.GetAsync();
            return Ok(conditions);
        }
    }
}