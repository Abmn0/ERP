using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class EkranService : IEkranService
    {
        private readonly YektamakDbContext _context;

        public EkranService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ekran>> GetAllAsync()
        {
            return await _context.Ekranlar.ToListAsync();
        }

        public async Task<Ekran?> GetByIdAsync(int id)
        {
            return await _context.Ekranlar.FindAsync(id);
        }

        public async Task AddAsync(Ekran ekran)
        {
            _context.Ekranlar.Add(ekran);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ekran ekran)
        {
            _context.Ekranlar.Update(ekran);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ekran = await _context.Ekranlar.FindAsync(id);
            if (ekran != null)
            {
                _context.Ekranlar.Remove(ekran);
                await _context.SaveChangesAsync();
            }
        }
    }
}
