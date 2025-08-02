using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class PersonelResimService : IPersonelResimService
    {
        private readonly YektamakDbContext _context;

        public PersonelResimService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonelResim>> GetAllAsync()
        {
            return await _context.PersonelResimler.ToListAsync();
        }

        public async Task<PersonelResim?> GetByIdAsync(int id)
        {
            return await _context.PersonelResimler.FindAsync(id);
        }

        public async Task AddAsync(PersonelResim resim)
        {
            await _context.PersonelResimler.AddAsync(resim);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PersonelResim resim)
        {
            _context.PersonelResimler.Update(resim);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var resim = await _context.PersonelResimler.FindAsync(id);
            if (resim != null)
            {
                _context.PersonelResimler.Remove(resim);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PersonelResim?> GetByPersonelIdAsync(int personelId)
        {
            return await _context.PersonelResimler
                                 .FirstOrDefaultAsync(r => r.PersonelId == personelId);
        }
    }
}
