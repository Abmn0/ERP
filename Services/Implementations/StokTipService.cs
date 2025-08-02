using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StokTipService : IStokTipService
    {
        private readonly YektamakDbContext _context;

        public StokTipService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<StokTip>> GetAllAsync()
        {
            return await _context.StokTipler.ToListAsync();
        }

        public async Task<StokTip?> GetByIdAsync(int id)
        {
            return await _context.StokTipler.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(StokTip stokTip)
        {
            await _context.StokTipler.AddAsync(stokTip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StokTip stokTip)
        {
            var existing = await _context.StokTipler.FindAsync(stokTip.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(stokTip);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.StokTipler.FindAsync(id);
            if (entity != null)
            {
                _context.StokTipler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
