using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Database;
using System;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Players
{
    [ScopedService]
    public class PlayerSpeciesRepository
    {
        private readonly AstroGameDataContext _context;

        public PlayerSpeciesRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(PlayerSpecies playerSpecies)
        {
            await _context.AddAsync(playerSpecies);
            await _context.SaveChangesAsync();

            return playerSpecies.Id;
        }
    }
}