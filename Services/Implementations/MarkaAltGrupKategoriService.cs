using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class MarkaAltGrupKategoriService : IMarkaAltGrupKategoriService
    {
        private readonly YektamakDbContext _context;

        public MarkaAltGrupKategoriService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarkaAltGrupKategori>> GetAllAsync()
        {
            return await _context.MarkaAltGrupKategoriler
                .Include(k => k.MarkaAltGrup)
                .ThenInclude(ag => ag.Marka)
                .ToListAsync();
        }

        public async Task<MarkaAltGrupKategori?> GetByIdAsync(int id)
        {
            return await _context.MarkaAltGrupKategoriler
                .Include(k => k.MarkaAltGrup)
                .ThenInclude(ag => ag.Marka)
                .FirstOrDefaultAsync(k => k.Id == id);
        }
        public async Task<List<MarkaAltGrupKategori>> GetAllWithIncludeAsync()
        {
            return await _context.MarkaAltGrupKategoriler
                                 .Include(x => x.MarkaAltGrup)
                                 .ToListAsync();
        }
        public async Task AddAsync(MarkaAltGrupKategori kategori)
        {
            await _context.MarkaAltGrupKategoriler.AddAsync(kategori);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MarkaAltGrupKategori kategori)
        {
            var existing = await _context.MarkaAltGrupKategoriler
                                         .FirstOrDefaultAsync(x => x.Id == kategori.Id);

            if (existing != null)
            {
                existing.Ad = kategori.Ad;
                existing.Kod = kategori.Kod;
                existing.MarkaAltGrupId = kategori.MarkaAltGrupId;

                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MarkaAltGrupKategoriler.FindAsync(id);
            if (entity != null)
            {
                _context.MarkaAltGrupKategoriler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
