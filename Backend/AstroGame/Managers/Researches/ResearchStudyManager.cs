using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Repositories.Researches;
using System;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Researches
{
    [ScopedService]
    public class ResearchStudyManager
    {
        private readonly ResearchStudyRepository _researchStudyRepository;

        public ResearchStudyManager(ResearchStudyRepository researchStudyRepository)
        {
            _researchStudyRepository = researchStudyRepository;
        }

        public async Task<ResearchStudy> GetAsync(Guid id)
        {
            return await _researchStudyRepository.GetAsync(id);
        }

        public async Task<ResearchStudy> GetByPlayerAsync(Guid playerId)
        {
            return await _researchStudyRepository.GetByPlayerAsync(playerId);
        }
    }
}
