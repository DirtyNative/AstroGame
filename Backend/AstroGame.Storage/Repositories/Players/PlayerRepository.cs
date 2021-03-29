using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Players;
using AstroGame.Storage.Database;
using AstroGame.Storage.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task AddSpeciesAsync(Guid playerId, Guid speciesId)
        {
            var player = await GetAsync(playerId);
            player.PlayerSpeciesId = speciesId;

            await _context.SaveChangesAsync();
        }

        public async Task<Guid> AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            return player.Id;
        }

        public async Task<bool> ExistsAsync(Guid playerId)
        {
            return await _context.Players.AnyAsync(e => e.Id == playerId);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _context.Players
                .Include(e => e.Credentials)
                .AnyAsync(e => e.Credentials.Email == email);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Players
                .AnyAsync(e => e.Username == username);
        }

        public Task DeleteAsync(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}