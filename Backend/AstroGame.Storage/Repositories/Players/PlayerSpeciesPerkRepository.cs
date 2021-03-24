using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Players
{
    [ScopedService]
    public class PlayerSpeciesPerkRepository
    {
        private readonly AstroGameDataContext _context;

        public PlayerSpeciesPerkRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<bool> HasAnyAsync(Guid playerSpeciesId)
        {
            return await _context.PlayerSpeciesPerks
                .AnyAsync(e => e.PlayerSpeciesId == playerSpeciesId);
        }
    }
}
