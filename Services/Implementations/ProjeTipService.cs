using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class ProjeTipService : IProjeTipService
    {
        private readonly YektamakDbContext _context;

        public ProjeTipService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjeTip>> GetAllAsync()
        {
            return await _context.ProjeTipler.ToListAsync();
        }

        public async Task<ProjeTip?> GetByIdAsync(int id)
        {
            return await _context.ProjeTipler.FindAsync(id);
        }

        public async Task AddAsync(ProjeTip projeTip)
        {
            await _context.ProjeTipler.AddAsync(projeTip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjeTip projeTip)
        {
            var existing = await _context.ProjeTipler
                                 .FirstOrDefaultAsync(x => x.ProjeTipId == projeTip.ProjeTipId);

            if (existing != null)
            {
                existing.ProjeTipAd = projeTip.ProjeTipAd;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ProjeTipler.FindAsync(id);
            if (entity != null)
            {
                _context.ProjeTipler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
