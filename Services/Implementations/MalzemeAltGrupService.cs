using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MalzemeAltGrupService : IMalzemeAltGrupService
    {
        private readonly YektamakDbContext _context;

        public MalzemeAltGrupService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<MalzemeAltGrup>> GetAllAsync()
        {
            return await _context.MalzemeAltGruplar.ToListAsync();
        }

        public async Task<MalzemeAltGrup?> GetByIdAsync(int id)
        {
            return await _context.MalzemeAltGruplar.FindAsync(id);
        }

        public async Task AddAsync(MalzemeAltGrup entity)
        {
            _context.MalzemeAltGruplar.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MalzemeAltGrup entity)
        {
            var existing = await _context.MalzemeAltGruplar.FindAsync(entity.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MalzemeAltGruplar.FindAsync(id);
            if (entity is not null)
            {
                _context.MalzemeAltGruplar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MalzemeAltGrup>> GetAllWithIncludeAsync()
        {
            return await _context.MalzemeAltGruplar
                .Include(x => x.MalzemeGrup)
                .ToListAsync();
        }

        public async Task<List<MalzemeAltGrup>> GetByMalzemeGrupIdAsync(int grupId)
        {
            return await _context.MalzemeAltGruplar
                .Where(x => x.MalzemeGrupId.HasValue && x.MalzemeGrupId == grupId)
                .OrderBy(x => x.Ad)
                .ToListAsync();
        }

    }
}
