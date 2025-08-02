using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SehirService : ISehirService
    {
        private readonly YektamakDbContext _context;

        public SehirService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sehir>> GetAllAsync()
        {
            return await _context.Sehirler
                .Include(s => s.Ulke)
                .ToListAsync();
        }

        public async Task<Sehir?> GetByIdAsync(int id)
        {
            return await _context.Sehirler
                .Include(s => s.Ulke)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Sehir sehir)
        {
            await _context.Sehirler.AddAsync(sehir);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sehir sehir)
        {
            _context.Sehirler.Update(sehir);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Sehirler.FindAsync(id);
            if (entity != null)
            {
                _context.Sehirler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
