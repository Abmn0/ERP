using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System.Security.Claims;

namespace Services.Implementations
{
    public class YetkiService : IYetkiService
    {
        private readonly YektamakDbContext _context;

        public YetkiService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Yetki>> GetByRolIdAsync(int rolId)
        {
            return await _context.Yetkiler
                .Include(y => y.Menu)
                .Where(y => y.RolId == rolId)
                .ToListAsync();
        }

        public async Task UpdateRoleMenuPermissionsAsync(int rolId, List<Yetki> yeniYetkiler)
        {
            var eskiYetkiler = await _context.Yetkiler
                .Where(y => y.RolId == rolId && y.MenuId != null)
                .ToListAsync();

            _context.Yetkiler.RemoveRange(eskiYetkiler);
            await _context.Yetkiler.AddRangeAsync(yeniYetkiler);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasAccessAsync(ClaimsPrincipal user, string formAd)
        {
            var kullaniciKod = user.Identity?.Name;

            if (string.IsNullOrWhiteSpace(kullaniciKod))
                return false;

            var kullanici = await _context.Kullanicilar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(k => k.Kod == kullaniciKod);

            if (kullanici == null)
                return false;

            var normalFormAd = formAd.Trim('/').ToLower(); // Örn: "/personeller/" => "personeller"

            // DEBUG log (isteğe bağlı)
            Console.WriteLine($"Kullanıcı: {kullaniciKod}, İstenen FormAd: {formAd} -> Normalleştirilmiş: {normalFormAd}");

            var yetkiliMi = await _context.Yetkiler
                .Include(y => y.Menu)
                .AnyAsync(y => y.RolId == kullanici.RolId &&
                               y.GormeYetki &&
                               y.Menu.FormAd.ToLower().Trim('/') == normalFormAd);

            return yetkiliMi;
        }

        public async Task<List<string>> GetYetkiliFormAdlarAsync(ClaimsPrincipal user)
        {
            var kullaniciKod = user.Identity?.Name;

            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Kod == kullaniciKod);

            if (kullanici == null)
                return new List<string>();

            return await _context.Yetkiler
                .Include(y => y.Menu)
                .Where(y => y.RolId == kullanici.RolId && y.GormeYetki)
                .Select(y => y.Menu.FormAd!.Trim('/').ToLower())
                .ToListAsync();
        }
        public async Task<List<string>> GetYetkiliFormAdlarAsync(Kullanici user)
        {
            if (user == null || user.RolId == null)
                return new List<string>();

            return await _context.Yetkiler
                .Include(y => y.Menu)
                .Where(y => y.RolId == user.RolId && y.GormeYetki)
                .Select(y => y.Menu.FormAd!.Trim('/').ToLower())
                .ToListAsync();
        }


    }
}
