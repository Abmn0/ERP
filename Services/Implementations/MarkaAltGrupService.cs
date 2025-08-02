using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MarkaAltGrupService : IMarkaAltGrupService
    {
        private readonly YektamakDbContext _context;

        public MarkaAltGrupService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarkaAltGrup>> GetAllAsync()
        {
            return await _context.MarkaAltGruplar
                .Include(m => m.Marka)
                .Include(m => m.MarkaAltGrupKategoriler)
                .ToListAsync();
        }

        public async Task<MarkaAltGrup?> GetByIdAsync(int id)
        {
            return await _context.MarkaAltGruplar
                .Include(m => m.Marka)
                .Include(m => m.MarkaAltGrupKategoriler)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<MarkaAltGrup>> GetAllWithIncludeAsync()
        {
            return await _context.MarkaAltGruplar
                .Include(m => m.Marka)
                .ToListAsync();
        }

        public async Task AddAsync(MarkaAltGrup markaAltGrup)
        {
            await _context.MarkaAltGruplar.AddAsync(markaAltGrup);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MarkaAltGrup markaAltGrup)
        {
            var existing = await _context.MarkaAltGruplar
                                         .FirstOrDefaultAsync(x => x.Id == markaAltGrup.Id);

            if (existing != null)
            {
                existing.Ad = markaAltGrup.Ad;
                existing.Kod = markaAltGrup.Kod;
                existing.MarkaId = markaAltGrup.MarkaId;

                await _context.SaveChangesAsync();
            }
        }



        public async Task<(bool success, string errorMessage)> DeleteAsync(int id)
        {
            var kategoriSayisi = await _context.MarkaAltGrupKategoriler
                                               .CountAsync(x => x.MarkaAltGrupId == id);

            if (kategoriSayisi > 0)
            {
                return (false, $"Bu Marka Alt Grup, {kategoriSayisi} adet kategori ile ilişkili. Önce bunları silin.");
            }

            var markaAltGrup = await _context.MarkaAltGruplar.FindAsync(id);
            if (markaAltGrup != null)
            {
                _context.MarkaAltGruplar.Remove(markaAltGrup);
                await _context.SaveChangesAsync();
            }

            return (true, string.Empty);
        }
    }
}
