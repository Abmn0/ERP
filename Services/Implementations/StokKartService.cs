using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StokKartService : IStokKartService
    {
        private readonly YektamakDbContext _context;

        public StokKartService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<StokKart>> GetAllAsync()
        {
            return await _context.StokKartlar
                .Include(x => x.StokGrup)
                .Include(x => x.StokTip)
                .Include(x => x.MalzemeGrup)
                .Include(x => x.MalzemeAltGrup)
                .Include(x => x.MalzemeAltGrup2)
                .Include(x => x.OlcuBirim)
                .Include(x => x.MalzemeStandart)
                .Include(x => x.Hammadde)
                .ToListAsync();
        }

        public async Task<StokKart?> GetByIdAsync(int id)
        {
            return await _context.StokKartlar
                .Include(x => x.StokGrup)
                .Include(x => x.StokTip)
                .Include(x => x.MalzemeGrup)
                .Include(x => x.MalzemeAltGrup)
                .Include(x => x.MalzemeAltGrup2)
                .Include(x => x.OlcuBirim)
                .Include(x => x.MalzemeStandart)
                .Include(x => x.Hammadde)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<StokKart>> GetAllWithIncludeAsync()
        {
            return await _context.StokKartlar
                .Include(x => x.StokGrup)
                .Include(x => x.StokTip)
                .Include(x => x.MalzemeGrup)
                .Include(x => x.MalzemeAltGrup)
                .Include(x => x.MalzemeAltGrup2)
                .Include(x => x.OlcuBirim)
                .ToListAsync();
        }
        public async Task AddAsync(StokKart stokKart)
        {
            await _context.StokKartlar.AddAsync(stokKart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StokKart stokKart)
        {
            _context.StokKartlar.Update(stokKart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var iliskiliVarMi = await _context.SatinalmaTalepDetaylar.AnyAsync(x => x.StokKartId == id);
            if (iliskiliVarMi)
                throw new InvalidOperationException("Bu stok kartı, en az bir talep detayı ile ilişkili olduğu için silinemez.");

            var entity = await _context.StokKartlar.FindAsync(id);
            if (entity != null)
            {
                _context.StokKartlar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
