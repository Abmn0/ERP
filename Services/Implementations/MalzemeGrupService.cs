using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MalzemeGrupService : IMalzemeGrupService
    {
        private readonly YektamakDbContext _context;

        public MalzemeGrupService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<MalzemeGrup>> GetAllAsync()
        {
            return await _context.MalzemeGruplar.ToListAsync();
        }

        public async Task<MalzemeGrup?> GetByIdAsync(int id)
        {
            return await _context.MalzemeGruplar.FindAsync(id);
        }

        public async Task<List<MalzemeGrup>> GetAllWithIncludeAsync()
        {
            return await _context.MalzemeGruplar
                .Include(mg => mg.StokGrup)
                .ToListAsync();
        }

        public async Task<List<MalzemeGrup>> GetByStokGrupIdAsync(int stokGrupId)
        {
            return await _context.MalzemeGruplar
                .Where(x => x.StokGrupId.HasValue && x.StokGrupId == stokGrupId)
                .OrderBy(x => x.Ad)
                .ToListAsync();
        }


        public async Task AddAsync(MalzemeGrup entity)
        {
            _context.MalzemeGruplar.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MalzemeGrup entity)
        {
            var existing = await _context.MalzemeGruplar.FindAsync(entity.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MalzemeGruplar.FindAsync(id);
            if (entity is not null)
            {
                _context.MalzemeGruplar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
