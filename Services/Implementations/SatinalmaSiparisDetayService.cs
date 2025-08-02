using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SatinalmaSiparisDetayService : ISatinalmaSiparisDetayService
    {
        private readonly YektamakDbContext _context;

        public SatinalmaSiparisDetayService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<SatinalmaSiparisDetay>> GetByBaslikIdAsync(int baslikId)
        {
            return await _context.SatinalmaSiparisDetaylar
                                 .Where(d => d.SatinalmaSiparisBaslikId == baslikId)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<SatinalmaSiparisDetay?> GetByIdAsync(int id)
        {
            return await _context.SatinalmaSiparisDetaylar
                                 .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(SatinalmaSiparisDetay detay)
        {
            detay.CreationTime = DateTime.Now;
            _context.SatinalmaSiparisDetaylar.Add(detay);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<SatinalmaSiparisDetay> detaylar)
        {
            var now = DateTime.Now;
            foreach (var d in detaylar)
            {
                d.CreationTime = now;
            }

            await _context.SatinalmaSiparisDetaylar.AddRangeAsync(detaylar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SatinalmaSiparisDetay detay)
        {
            var existing = await _context.SatinalmaSiparisDetaylar
                                         .FirstOrDefaultAsync(x => x.Id == detay.Id);

            if (existing is null) return;

            detay.UpdatedTime = DateTime.Now;

            _context.Entry(existing).CurrentValues.SetValues(detay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SatinalmaSiparisDetaylar.FindAsync(id);
            if (entity != null)
            {
                _context.SatinalmaSiparisDetaylar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByBaslikIdAsync(int baslikId)
        {
            var list = await _context.SatinalmaSiparisDetaylar
                .Where(x => x.SatinalmaSiparisBaslikId == baslikId)
                .ToListAsync();

            _context.SatinalmaSiparisDetaylar.RemoveRange(list);
            await _context.SaveChangesAsync();
        }
    }
}
