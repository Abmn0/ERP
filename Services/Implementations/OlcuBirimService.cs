using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class OlcuBirimService : IOlcuBirimService
    {
        private readonly YektamakDbContext _context;

        public OlcuBirimService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<OlcuBirim>> GetAllAsync()
        {
            return await _context.OlcuBirimler.ToListAsync();
        }

        public async Task<OlcuBirim?> GetByIdAsync(int id)
        {
            return await _context.OlcuBirimler.FindAsync(id);
        }

        public async Task AddAsync(OlcuBirim entity)
        {
            _context.OlcuBirimler.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OlcuBirim entity)
        {
            var existing = await _context.OlcuBirimler.FindAsync(entity.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.OlcuBirimler.FindAsync(id);
            if (entity is not null)
            {
                _context.OlcuBirimler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
