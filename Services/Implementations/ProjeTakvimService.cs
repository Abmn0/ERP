using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class ProjeTakvimService : IProjeTakvimService
    {
        private readonly YektamakDbContext _context;

        public ProjeTakvimService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjeTakvim>> GetAllAsync()
        {
            return await _context.ProjeTakvimleri
                .Include(p => p.Proje)
                .Include(p => p.ProjeSurec)
                .ToListAsync();
        }

        public async Task<ProjeTakvim?> GetByIdAsync(int id)
        {
            return await _context.ProjeTakvimleri
                .Include(p => p.Proje)
                .Include(p => p.ProjeSurec)
                .FirstOrDefaultAsync(p => p.ProjeTakvimId == id);
        }

        public async Task<List<ProjeTakvim>> GetAllByProjeIdAsync(int projeId)
        {
            return await _context.ProjeTakvimleri
                .Where(pt => pt.ProjeId == projeId)
                .Include(pt => pt.Proje)
                .Include(pt => pt.ProjeSurec)
                .ToListAsync();
        }

        public async Task AddAsync(ProjeTakvim projeTakvim)
        {
            await _context.ProjeTakvimleri.AddAsync(projeTakvim);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjeTakvim projeTakvim)
        {
            _context.ProjeTakvimleri.Update(projeTakvim);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ProjeTakvimleri.FindAsync(id);
            if (entity != null)
            {
                _context.ProjeTakvimleri.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
