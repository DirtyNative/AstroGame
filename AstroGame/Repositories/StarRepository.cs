﻿using AstroGame.Api.Databases;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Api.Repositories
{
    public class StarRepository
    {
        private readonly AstroGameDataContext _context;

        public StarRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public async Task<Star> GetAsync(Guid id)
        {
            return await _context.Stars.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Star>> GetByParentAsync(Guid parentId)
        {
            return await _context.Stars.Where(e => e.ParentSystemId == parentId).ToListAsync();
        }
    }
}