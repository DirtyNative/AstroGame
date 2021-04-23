using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Conditions;
using AstroGame.Storage.Repositories.Conditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Conditions
{
    [ScopedService]
    public class ConditionManager
    {
        private readonly ConditionRepository _conditionRepository;

        public ConditionManager(ConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<List<Condition>> GetAsync()
        {
            return await _conditionRepository.GetAsync();
        }
    }
}