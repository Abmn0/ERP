using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UlkeService : IUlkeService
    {
        private readonly YektamakDbContext _context;

        public UlkeService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ulke>> GetAllAsync()
        {
            return await _context.Ulkeler.ToListAsync();
        }

        public async Task<Ulke?> GetByIdAsync(int id)
        {
            return await _context.Ulkeler.FindAsync(id);
        }

        public async Task AddAsync(Ulke ulke)
        {
            await _context.Ulkeler.AddAsync(ulke);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ulke ulke)
        {
            _context.Ulkeler.Update(ulke);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Ulkeler.FindAsync(id);
            if (entity != null)
            {
                _context.Ulkeler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
