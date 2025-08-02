using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class SatisSiparisService : ISatisSiparisService
    {
        private readonly YektamakDbContext _context;

        public SatisSiparisService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<SatisSiparis>> GetAllAsync()
        {
            return await _context.SatisSiparisler.ToListAsync();
        }

        public async Task<SatisSiparis?> GetByIdAsync(int id)
        {
            return await _context.SatisSiparisler.FindAsync(id);
        }

        public async Task AddAsync(SatisSiparis siparis)
        {
            await _context.SatisSiparisler.AddAsync(siparis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SatisSiparis siparis)
        {
            var existing = await _context.SatisSiparisler
                                 .FirstOrDefaultAsync(x => x.Id == siparis.Id);

            if (existing != null)
            {
                existing.SiparisNo = siparis.SiparisNo;
                existing.SiparisTarihi = siparis.SiparisTarihi;
                existing.TeslimTarihi = siparis.TeslimTarihi;
                existing.SiparisTutari = siparis.SiparisTutari;
                existing.OngoruMaliyeti = siparis.OngoruMaliyeti;
                existing.Kdv = siparis.Kdv;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SatisSiparisler.FindAsync(id);
            if (entity != null)
            {
                _context.SatisSiparisler.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
