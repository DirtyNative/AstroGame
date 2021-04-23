using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Researches;
using AstroGame.Storage.Repositories.Researches;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers.Researches
{
    [ScopedService]
    public class StudiedResearchManager
    {
        private readonly StudiedResearchRepository _studiedResearchRepository;

        public StudiedResearchManager(StudiedResearchRepository studiedResearchRepository)
        {
            _studiedResearchRepository = studiedResearchRepository;
        }

        public async Task<List<StudiedResearch>> GetAsync(Guid playerId)
        {
            return await _studiedResearchRepository.GetAsync(playerId);
        }

        public async Task<StudiedResearch> GetByResearchAndPlayerAsync(Guid researchId, Guid playerId)
        {
            return await _studiedResearchRepository.GetByResearchAndPlayerAsync(researchId, playerId);
        }
    }
}
