using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Resources;
using AstroGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories.Resources
{
    [ScopedService]
    public class ElementRepository : IRepository<Element>
    {
        private readonly AstroGameDataContext _context;

        public ElementRepository(AstroGameDataContext context)
        {
            _context = context;
        }

        public List<Element> Get()
        {
            return _context.Elements.ToList();
        }

        public async Task<Element> GetAsync(Guid id)
        {
            return await _context.Elements
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Element>> GetAsync()
        {
            return await _context.Elements
                .ToListAsync();
        }

        public Task DeleteAsync(Element entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Element>> GetBaseAsync()
        {
            return await _context.Elements
                .Where(e => e.IsBaseResource)
                .ToListAsync();
        }
    }
}