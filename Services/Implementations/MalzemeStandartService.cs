using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MalzemeStandartService : IMalzemeStandartService
    {
        private readonly YektamakDbContext _context;

        public MalzemeStandartService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<MalzemeStandart>> GetAllAsync()
        {
            return await _context.MalzemeStandartlar.ToListAsync();
        }

        public async Task<MalzemeStandart?> GetByIdAsync(int id)
        {
            return await _context.MalzemeStandartlar.FindAsync(id);
        }

        public async Task AddAsync(MalzemeStandart entity)
        {
            _context.MalzemeStandartlar.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MalzemeStandart entity)
        {
            var existing = await _context.MalzemeStandartlar.FindAsync(entity.Id);
            if (existing is not null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MalzemeStandartlar.FindAsync(id);
            if (entity is not null)
            {
                _context.MalzemeStandartlar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
