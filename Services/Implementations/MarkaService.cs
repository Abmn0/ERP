using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class MarkaService : IMarkaService
    {
        private readonly YektamakDbContext _context;

        public MarkaService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Marka>> GetAllAsync()
        {
            return await _context.Markalar.ToListAsync();
        }

        public async Task<Marka?> GetByIdAsync(int id)
        {
            return await _context.Markalar.FindAsync(id);
        }

        public async Task AddAsync(Marka marka)
        {
            await _context.Markalar.AddAsync(marka);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Marka marka)
        {
            var existing = await _context.Markalar.FindAsync(marka.Id);
            if (existing is null) return;

            _context.Entry(existing).CurrentValues.SetValues(marka);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Markalar.FindAsync(id);
            if (entity != null)
            {
                _context.Markalar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}