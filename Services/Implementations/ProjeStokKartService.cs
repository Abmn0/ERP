using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class ProjeStokKartService : IProjeStokKartService
    {
        private readonly YektamakDbContext _context;

        public ProjeStokKartService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjeStokKart>> GetAllAsync()
        {
            return await _context.ProjeStokKartlar
                .Include(x => x.Proje)
                .Include(x => x.StokKart)
                .ToListAsync();
        }

        public async Task<ProjeStokKart?> GetByIdAsync(int id)
        {
            return await _context.ProjeStokKartlar
                .Include(x => x.Proje)
                .Include(x => x.StokKart)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjeStokKart>> GetAllWithIncludeAsync()
        {
            return await _context.ProjeStokKartlar
                .Include(x => x.Proje)
                .Include(x => x.StokKart)
                .ToListAsync();
        }
        public async Task AddAsync(ProjeStokKart projeStokKart)
        {
            await _context.ProjeStokKartlar.AddAsync(projeStokKart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjeStokKart projeStokKart)
        {
            var existing = await _context.ProjeStokKartlar.FindAsync(projeStokKart.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(projeStokKart);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ProjeStokKartlar.FindAsync(id);
            if (entity != null)
            {
                _context.ProjeStokKartlar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
