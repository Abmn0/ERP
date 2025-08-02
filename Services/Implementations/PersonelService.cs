using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class PersonelService : IPersonelService
    {
        private readonly YektamakDbContext _context;

        public PersonelService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<Personel>> GetAllAsync()
        {
            return await _context.Personeller
                .Include(p => p.Pozisyon)
                .Include(p => p.Firma)
                .Include(p => p.PersonelResim) // Bu satır kritik
                .ToListAsync();
        }

        public async Task<List<Personel>> GetAllWithIncludeAsync()
        {
            return await _context.Personeller
                .Include(p => p.Pozisyon)
                .Include(p => p.Firma)
                .Include(p => p.Yonetici)
                .ToListAsync();
        }

        public async Task<Personel?> GetByIdAsync(int id)
        {
            return await _context.Personeller
                .Include(p => p.Pozisyon)
                .Include(p => p.Firma)
                .Include(p => p.PersonelResim)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> AddAsync(Personel personel)
        {
            await _context.Personeller.AddAsync(personel);
            await _context.SaveChangesAsync();
            return personel.Id;
        }

        public async Task UpdateAsync(Personel personel)
        {
            _context.Personeller.Update(personel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            if (personel != null)
            {
                _context.Personeller.Remove(personel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PersonelResim?> GetByPersonelIdAsync(int personelId)
        {
            return await _context.PersonelResimler.FirstOrDefaultAsync(r => r.PersonelId == personelId);
        }

    }
}
