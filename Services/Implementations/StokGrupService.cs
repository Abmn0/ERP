using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StokGrupService : IStokGrupService
    {
        private readonly YektamakDbContext _context;

        public StokGrupService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<StokGrup>> GetAllAsync()
        {
            return await _context.StokGruplar.ToListAsync();
        }

        public async Task<StokGrup?> GetByIdAsync(int id)
        {
            return await _context.StokGruplar.FindAsync(id);
        }

        public async Task AddAsync(StokGrup entity)
        {
            _context.StokGruplar.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StokGrup entity)
        {
            _context.StokGruplar.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.StokGruplar.FindAsync(id);
            if (entity is not null)
            {
                _context.StokGruplar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
