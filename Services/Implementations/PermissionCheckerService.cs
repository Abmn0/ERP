using DataAccess;
using Microsoft.EntityFrameworkCore;

public class PermissionCheckerService : IPermissionCheckerService
{
    private readonly YektamakDbContext _context;

    public PermissionCheckerService(YektamakDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HasViewPermissionAsync(int kullaniciId, int alanId)
    {
        return await _context.AlanYetkiler
            .AnyAsync(x => x.KullaniciId == kullaniciId && x.AlanId == alanId && x.GormeYetki);
    }

    public async Task<bool> HasEditPermissionAsync(int kullaniciId, int alanId)
    {
        return await _context.AlanYetkiler
            .AnyAsync(x => x.KullaniciId == kullaniciId && x.AlanId == alanId && x.DuzenlemeYetki);
    }
}
