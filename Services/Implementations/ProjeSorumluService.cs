using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class ProjeSorumluService : IProjeSorumluService
    {
        private readonly YektamakDbContext _context;

        public ProjeSorumluService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjeSorumlu>> GetAllAsync()
        {
            return await _context.ProjeSorumlular
                .Include(p => p.Proje)
                .Include(p => p.Personel)
                .ToListAsync();
        }

        public async Task<ProjeSorumlu?> GetByIdAsync(int id)
        {
            return await _context.ProjeSorumlular
                .Include(p => p.Proje)
                .Include(p => p.Personel)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(ProjeSorumlu projeSorumlu)
        {
            await _context.ProjeSorumlular.AddAsync(projeSorumlu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjeSorumlu projeSorumlu)
        {
            var existing = await _context.ProjeSorumlular.FindAsync(projeSorumlu.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(projeSorumlu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ProjeSorumlular.FindAsync(id);
            if (entity != null)
            {
                _context.ProjeSorumlular.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
