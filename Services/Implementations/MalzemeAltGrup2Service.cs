using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MalzemeAltGrup2Service : IMalzemeAltGrup2Service
    {
        private readonly YektamakDbContext _context;

        public MalzemeAltGrup2Service(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<MalzemeAltGrup2>> GetAllAsync()
        {
            return await _context.MalzemeAltGrup2ler.ToListAsync();
        }

        public async Task<MalzemeAltGrup2?> GetByIdAsync(int id)
        {
            return await _context.MalzemeAltGrup2ler.FindAsync(id);
        }

        public async Task AddAsync(MalzemeAltGrup2 entity)
        {
            _context.MalzemeAltGrup2ler.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MalzemeAltGrup2 entity)
        {
            var existing = await _context.MalzemeAltGrup2ler.FindAsync(entity.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MalzemeAltGrup2ler.FindAsync(id);
            if (entity is not null)
            {
                _context.MalzemeAltGrup2ler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MalzemeAltGrup2>> GetAllWithIncludeAsync()
        {
            return await _context.MalzemeAltGrup2ler
                .Include(x => x.MalzemeAltGrup)
                .ToListAsync();
        }

        public async Task<List<MalzemeAltGrup2>> GetByMalzemeAltGrupIdAsync(int altGrupId)
        {
            return await _context.MalzemeAltGrup2ler
                .Where(x => x.MalzemeAltGrupId.HasValue && x.MalzemeAltGrupId == altGrupId)
                .OrderBy(x => x.Ad) 
                .ToListAsync();
        }

    }
}
