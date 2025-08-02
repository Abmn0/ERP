using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class KullaniciService : IKullaniciService
    {
        private readonly YektamakDbContext _context;

        public KullaniciService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kullanici>> GetAllAsync()
        {
            return await _context.Kullanicilar
                .Include(k => k.Personel)
                .Include(k => k.Rol)
                .ToListAsync();
        }

        public async Task<Kullanici?> GetByIdAsync(int id)
        {
            return await _context.Kullanicilar
                .Include(k => k.Personel)
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task AddAsync(Kullanici kullanici)
        {
            await _context.Kullanicilar.AddAsync(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Kullanici kullanici)
        {
            _context.Kullanicilar.Update(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Kullanicilar.FindAsync(id);
            if (entity != null)
            {
                _context.Kullanicilar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Kullanici?> GetUserByKodAsync(string kod)
        {
            return await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.Kod == kod);
        }

        public async Task<int?> GetYoneticiKullaniciIdByKullaniciIdAsync(int kullaniciId)
        {
            var kullanici = await _context.Kullanicilar
                .Include(k => k.Personel)
                .FirstOrDefaultAsync(k => k.Id == kullaniciId);

            if (kullanici?.Personel == null || kullanici.Personel.YoneticiPersonelId == null)
                return null;

            var yoneticiKullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.PersonelId == kullanici.Personel.YoneticiPersonelId);

            return yoneticiKullanici?.Id;
        }

    }
}
