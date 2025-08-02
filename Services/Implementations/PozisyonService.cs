using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class PozisyonService : IPozisyonService
    {
        private readonly YektamakDbContext _context;

        public PozisyonService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pozisyon>> GetAllAsync()
        {
            return await _context.Pozisyonlar.ToListAsync();
        }

        public async Task<Pozisyon?> GetByIdAsync(int id)
        {
            return await _context.Pozisyonlar.FindAsync(id);
        }

        public async Task AddAsync(Pozisyon pozisyon)
        {
            await _context.Pozisyonlar.AddAsync(pozisyon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pozisyon pozisyon)
        {
            _context.Pozisyonlar.Update(pozisyon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Pozisyonlar.FindAsync(id);
            if (entity != null)
            {
                _context.Pozisyonlar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
