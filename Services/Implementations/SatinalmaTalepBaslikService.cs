using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SatinalmaTalepBaslikService : ISatinalmaTalepBaslikService
    {
        private readonly YektamakDbContext _context;

        public SatinalmaTalepBaslikService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<SatinalmaTalepBaslik>> GetAllAsync()
        {
            return await _context.SatinalmaTalepBasliklar
                .Include(b => b.Firma)
                .Include(b => b.Detaylar)
                .ToListAsync();
        }

        public async Task<SatinalmaTalepBaslik?> GetByIdAsync(int id)
        {
            return await _context.SatinalmaTalepBasliklar
                .Include(b => b.Firma)
                .Include(b => b.TalepEdenKullanici)
                .Include(b => b.OnayKullanici)
                .Include(b => b.Detaylar)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SatinalmaTalepBaslik>> GetAllWithIncludeAsync()
        {
            return await _context.SatinalmaTalepBasliklar
                .Include(t => t.Firma)
                .Include(t => t.TalepEdenKullanici)
                .Include(t => t.OnayKullanici)
                .Include(t => t.Detaylar)
                .ToListAsync();
        }

        public async Task AddAsync(SatinalmaTalepBaslik baslik)
        {
            _context.SatinalmaTalepBasliklar.Add(baslik);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SatinalmaTalepBaslik baslik)
        {
            _context.SatinalmaTalepBasliklar.Update(baslik);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SatinalmaTalepBasliklar.FindAsync(id);
            if (entity != null)
            {
                _context.SatinalmaTalepBasliklar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SatinalmaTalepBaslik>> GetKullaniciyaAtananTaleplerAsync(int onayKullaniciId)
        {
            return await _context.SatinalmaTalepBasliklar
                .Include(b => b.Firma)
                .Include(b => b.TalepEdenKullanici)
                .Include(b => b.OnayKullanici)
                .Include(b => b.Detaylar)
                .Where(b => b.OnayKullaniciId == onayKullaniciId)
                .ToListAsync();
        }

        // Başlık elle direkt onaylandığında kullanılabilir.
        public async Task BaslikOnaylaAsync(int baslikId)
        {
            var baslik = await _context.SatinalmaTalepBasliklar.FindAsync(baslikId);
            if (baslik != null)
            {
                baslik.OnayDurum = true;
                baslik.OnayTarihi = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        // Durum: string olarak okunabilir versiyon
        public async Task<string> GetTalepDurumuAsync(int baslikId)
        {
            var detaylar = await _context.SatinalmaTalepDetaylar
                .Where(d => d.SatinalmaTalepBaslikId == baslikId)
                .ToListAsync();

            if (!detaylar.Any())
                return "Bekliyor";

            if (detaylar.All(d => d.OnayDurum == true))
                return "Onaylandı";

            if (detaylar.All(d => d.OnayDurum == false))
                return "Reddedildi";

            // Bu koşul orijinal kodunuzda yoktu, eklenmesi daha doğru olur.
            if (detaylar.Any(d => d.OnayDurum == null))
                return "Bekliyor";

            if (detaylar.Any(d => d.OnayDurum == true))
                return "Kısmen Onaylandı";

            return "Bekliyor";
        }

        // Gerçek tabloyu güncelleyen metot
        public async Task GuncelleOnayDurumuAsync(int baslikId)
        {
            var detaylar = await _context.SatinalmaTalepDetaylar
                .Where(d => d.SatinalmaTalepBaslikId == baslikId)
                .ToListAsync();

            var baslik = await _context.SatinalmaTalepBasliklar
                .FirstOrDefaultAsync(b => b.Id == baslikId);

            if (baslik == null) return;

            if (!detaylar.Any())
            {
                baslik.OnayDurum = null;
                baslik.OnayTarihi = null;
            }
            else if (detaylar.All(d => d.OnayDurum == true))
            {
                baslik.OnayDurum = true;
                baslik.OnayTarihi = DateTime.Now;
            }
            else if (detaylar.All(d => d.OnayDurum == false))
            {
                baslik.OnayDurum = false;
                baslik.OnayTarihi = DateTime.Now;
            }
            else
            {
                // Kısmi red/onay: Görselde ayrı gösterilecek, burada null kalır
                baslik.OnayDurum = null;
                baslik.OnayTarihi = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }

        public async Task BaslikReddetAsync(int baslikId)
        {
            var baslik = await _context.SatinalmaTalepBasliklar.FindAsync(baslikId);
            if (baslik != null)
            {
                baslik.OnayDurum = false;
                baslik.OnayTarihi = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<string> GetYeniTalepNoAsync()
        {
            var prefix = "YKMTLP54";
            var sonTalep = await _context.SatinalmaTalepBasliklar
                .Where(x => x.SatinalmaTalepNo.StartsWith(prefix))
                .OrderByDescending(x => x.Id)
                .Select(x => x.SatinalmaTalepNo)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(sonTalep))
            {
                return prefix + "1";
            }

            var numericPart = sonTalep.Substring(prefix.Length);

            if (int.TryParse(numericPart, out int sayi))
            {
                return prefix + (sayi + 1);
            }

            // Eğer parse edilemediyse baştan başla
            return prefix + "1";
        }

        public async Task<List<SatinalmaTalepBaslik>> GetByKullaniciIdWithIncludeAsync(int kullaniciId)
        {
            return await _context.SatinalmaTalepBasliklar
                .Include(t => t.Firma)
                .Include(t => t.TalepEdenKullanici)
                .Include(t => t.OnayKullanici)
                .Include(t => t.Detaylar) // Detayları da dahil etmek isteyebilirsiniz.
                .Where(t => t.TalepEdenKullaniciId == kullaniciId)
                .ToListAsync();
        }
        public async Task<int> GetToplamTalepSayisiAsync()
        {
            return await _context.SatinalmaTalepBasliklar.CountAsync();
        }
        public async Task<int> GetOnaylananTalepSayisiAsync()
        {
            return await _context.SatinalmaTalepBasliklar
                .Where(t => t.OnayDurum == true)
                .CountAsync();
        }
        public async Task<int> GetReddedilenTalepSayisiAsync()
        {
            return await _context.SatinalmaTalepBasliklar
                .Where(t => t.OnayDurum == false)
                .CountAsync();
        }
        public async Task<int> GetBekleyenTalepSayisiAsync()
        {
            return await _context.SatinalmaTalepBasliklar
                .Where(t => t.OnayDurum == null)
                .CountAsync();
        }
        public async Task<int> GetAtanmisTalepSayisiAsync(int kullaniciId)
        {
            return await _context.SatinalmaTalepBasliklar
                .Where(t => t.OnayKullaniciId == kullaniciId)
                .CountAsync();
        }


    }
}