using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class HammaddeService : IHammaddeService
    {
        private readonly YektamakDbContext _context;

        public HammaddeService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hammadde>> GetAllAsync()
        {
            return await _context.Hammaddeler.ToListAsync();
        }

        public async Task<Hammadde?> GetByIdAsync(int id)
        {
            return await _context.Hammaddeler.FindAsync(id);
        }

        public async Task AddAsync(Hammadde hammadde)
        {
            _context.Hammaddeler.Add(hammadde);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hammadde hammadde)
        {
            var existing = await _context.Hammaddeler.FindAsync(hammadde.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(hammadde);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Hammaddeler.FindAsync(id);
            if (entity is not null)
            {
                _context.Hammaddeler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
