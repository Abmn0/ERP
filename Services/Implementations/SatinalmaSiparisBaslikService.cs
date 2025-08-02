using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SatinalmaSiparisBaslikService : ISatinalmaSiparisBaslikService
    {
        private readonly YektamakDbContext _context;

        public SatinalmaSiparisBaslikService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<SatinalmaSiparisBaslik>> GetAllAsync()
        {
            return await _context.SatinalmaSiparisBasliklar
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<List<SatinalmaSiparisBaslik>> GetAllWithIncludeAsync()
        {
            return await _context.SatinalmaSiparisBasliklar
                                 .Include(b => b.Detaylar)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<SatinalmaSiparisBaslik?> GetByIdAsync(int id)
        {
            return await _context.SatinalmaSiparisBasliklar
                                 .Include(b => b.Detaylar)
                                 .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(SatinalmaSiparisBaslik baslik)
        {
            baslik.CreationTime = DateTime.Now;
            _context.SatinalmaSiparisBasliklar.Add(baslik);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SatinalmaSiparisBaslik baslik)
        {
            var existing = await _context.SatinalmaSiparisBasliklar
                                         .FirstOrDefaultAsync(x => x.Id == baslik.Id);

            if (existing is null) return;

            baslik.UpdatedTime = DateTime.Now;

            // Change tracker çakışmasını engelle
            _context.Entry(existing).CurrentValues.SetValues(baslik);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SatinalmaSiparisBasliklar
                                       .Include(b => b.Detaylar)
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                // Detayları ile birlikte sil
                if (entity.Detaylar?.Any() == true)
                    _context.SatinalmaSiparisDetaylar.RemoveRange(entity.Detaylar);

                _context.SatinalmaSiparisBasliklar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetYeniSiparisNoAsync(string prefix = "YKMSIP")
        {
            // İster sadece sayısal artır, ister yıl bilgisini ekle
            // Örn: YKMSIP-2025-000012
            var year = DateTime.Now.Year;
            var likeStr = $"{prefix}-{year}-";

            var lastNo = await _context.SatinalmaSiparisBasliklar
                .Where(x => x.SiparisNo != null && x.SiparisNo.StartsWith(likeStr))
                .OrderByDescending(x => x.Id)
                .Select(x => x.SiparisNo!)
                .FirstOrDefaultAsync();

            int next = 1;
            if (!string.IsNullOrEmpty(lastNo))
            {
                var parts = lastNo.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 3 && int.TryParse(parts[2], out var num))
                    next = num + 1;
            }

            return $"{prefix}-{year}-{next.ToString("D6")}";
        }

        public async Task<List<SatinalmaSiparisBaslik>> GetByFirmaIdAsync(int firmaId)
        {
            return await _context.SatinalmaSiparisBasliklar
                                 .Include(b => b.Detaylar)
                                 .Where(b => b.FirmaId == firmaId)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<List<SatinalmaSiparisBaslik>> GetByDateRangeAsync(DateTime? start, DateTime? end)
        {
            var query = _context.SatinalmaSiparisBasliklar
                                .Include(b => b.Detaylar)
                                .AsQueryable();

            if (start.HasValue) query = query.Where(b => b.SiparisTarihi >= start.Value);
            if (end.HasValue) query = query.Where(b => b.SiparisTarihi <= end.Value);

            return await query.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Detaylardan toplam tutarı hesaplayıp başlığa yazar.
        /// </summary>
        public async Task RecalculateTotalAsync(int baslikId)
        {
            var baslik = await _context.SatinalmaSiparisBasliklar
                                       .Include(b => b.Detaylar)
                                       .FirstOrDefaultAsync(b => b.Id == baslikId);

            if (baslik == null) return;

            double total = 0;

            if (baslik.Detaylar != null)
            {
                foreach (var d in baslik.Detaylar)
                {
                    if (d.BirimFiyat.HasValue && d.Miktar.HasValue)
                    {
                        var line = d.BirimFiyat.Value * d.Miktar.Value;
                        if (d.Kdv.HasValue)
                            line += line * (d.Kdv.Value / 100.0);
                        total += line;
                    }
                }
            }

            baslik.Tutar = total;
            await _context.SaveChangesAsync();
        }
    }
}
