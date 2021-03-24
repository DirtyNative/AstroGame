using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Players
{
    [ScopedService]
    public class PerkRepository
    {
        private readonly AstroGameDataContext _context;

        public PerkRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<List<Perk>> GetAsync()
        {
            return await _context.Perks.ToListAsync();
        }
    }
}