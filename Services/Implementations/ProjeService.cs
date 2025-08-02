using DataAccess;
using Models;
using Microsoft.EntityFrameworkCore;


public class ProjeService : IProjeService
{
    private readonly YektamakDbContext _context;

    public ProjeService(YektamakDbContext context)
    {
        _context = context;
    }

    public async Task<List<Proje>> GetAllAsync()
    {
        return await _context.Projeler
            .Include(p => p.ProjeTip)
            .Include(p => p.Marka)
            .Include(p => p.AltGrup)
            .Include(p => p.Kategori)
            .ToListAsync();
    }

    public async Task<Proje?> GetByIdAsync(int id)
    {
        return await _context.Projeler.FindAsync(id);
    }

    public async Task AddAsync(Proje proje)
    {
        await _context.Projeler.AddAsync(proje);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Proje proje)
    {
        _context.Projeler.Update(proje);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var entity = await _context.Projeler.FindAsync(id);
            if (entity != null)
            {
                _context.Projeler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("Bu proje silinemiyor. Önce bu projeye bağlı Proje Takvim kayıtlarını silmelisiniz.", ex);
        }
    }

}
