using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class FirmaService : IFirmaService
    {
        private readonly YektamakDbContext _context;

        public FirmaService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Firma>> GetAllAsync()
        {
            return await _context.Firmalar
                .Include(f => f.Sehir)
                .Include(f => f.Ulke)
                .ToListAsync();
        }

        public async Task<Firma?> GetByIdAsync(int id)
        {
            return await _context.Firmalar
                .Include(f => f.Sehir)
                .Include(f => f.Ulke)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Firma firma)
        {
            _context.Firmalar.Add(firma);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Firma firma)
        {
            _context.Firmalar.Update(firma);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var firma = await _context.Firmalar.FindAsync(id);
            if (firma != null)
            {
                _context.Firmalar.Remove(firma);
                await _context.SaveChangesAsync();
            }
        }
    }
}
