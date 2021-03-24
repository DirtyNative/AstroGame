using AstroGame.Shared.Models.Players;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Storage.Database;
using AstroGame.Storage.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AstroGame.Storage.Repositories.Players
{
    [ScopedService]
    public class PlayerRepository : IRepository<Player>
    {
        private readonly AstroGameDataContext _context;

        public PlayerRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public Task<Player> GetAsync(Guid id)
        {
            return _context.Players
                .IncludeAll()
                // Credentials
                //.Include(e => e.Credentials)

                // Species
                //.Include(e => e.PlayerSpecies)
                //.ThenInclude(e => e.Species)

                // Perks
                //.Include(e => e.PlayerSpecies)
                //.ThenInclude(e => e.Perks)
                // .ThenInclude(e => e.Perk)

                // Colonies
                //.Include(e => e.ColonizedObjects)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<Player>> GetAsync()
        {
            return _context.Players
                .IncludeAll()
                // Credentials
                /*.Include(e => e.Credentials)

                // Species
                .Include(e => e.PlayerSpecies)
                .ThenInclude(e => e.Species)

                // Perks
                .Include(e => e.PlayerSpecies)
                .ThenInclude(e => e.Perks)
                .ThenInclude(e => e.Perk)

                // Colonies
                .Include(e => e.ColonizedObjects) */
                .ToListAsync();
        }

        public Task<Player> GetByEmailAsync(string email)
        {
            return _context.Players
                .IncludeAll()
                // Credentials
                /*.Include(e => e.Credentials)

                // Species
                .Include(e => e.PlayerSpecies)
                .ThenInclude(e => e.Species)

                // Perks
                .Include(e => e.PlayerSpecies)
                .ThenInclude(e => e.Perks)
                .ThenInclude(e => e.Perk)

                // Colonies
                .Include(e => e.ColonizedObjects) */
                .FirstOrDefaultAsync(e => e.Credentials.Email == email);
        }

        public async Task<bool> ExistsAsync(Guid playerId)
        {
            return await _context.Players.AnyAsync(e => e.Id == playerId);
        }

        public Task DeleteAsync(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}