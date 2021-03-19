﻿using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories.Stellar
{
    [ScopedService]
    public class BlackHoleRepository : IRepository<BlackHole>
    {
        private readonly AstroGameDataContext _context;

        public BlackHoleRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<BlackHole> GetAsync(Guid id)
        {
            return await _context.BlackHoles
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<BlackHole>> GetAsync()
        {
            return await _context.BlackHoles
                .Include(e => e.Resources)
                .ThenInclude(e => e.Resource)
                .ToListAsync();
        }

        public async Task DeleteAsync(BlackHole entity)
        {
            throw new NotImplementedException();
        }
    }
}