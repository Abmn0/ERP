using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

public class MenuService : IMenuService
{
    private readonly YektamakDbContext _context;

    public MenuService(YektamakDbContext context)
    {
        _context = context;
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await _context.Menuler
       .Include(m => m.MenuGroup)
       .OrderBy(m => m.SiraNo)
       .ToListAsync();
    }
    public async Task<List<Menu>> GetMenusByRolIdAsync(int rolId)
    {
        return await _context.Yetkiler
            .Where(y => y.RolId == rolId)
            .Select(y => y.Menu)
            .Distinct()
            .ToListAsync();
    }

}
