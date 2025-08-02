using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SatinalmaTalepDetayService : ISatinalmaTalepDetayService
    {
        private readonly YektamakDbContext _context;

        public SatinalmaTalepDetayService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<SatinalmaTalepDetay>> GetAllAsync()
        {
            return await _context.SatinalmaTalepDetaylar
                .Include(d => d.Baslik)
                .ToListAsync();
        }

        public async Task<SatinalmaTalepDetay?> GetByIdAsync(int id)
        {
            return await _context.SatinalmaTalepDetaylar
                .Include(d => d.Baslik)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(SatinalmaTalepDetay detay)
        {
            await _context.SatinalmaTalepDetaylar.AddAsync(detay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SatinalmaTalepDetay detay)
        {
            var mevcut = await _context.SatinalmaTalepDetaylar.FindAsync(detay.Id);
            if (mevcut is not null)
            {
                mevcut.SatinalmaTalepBaslikId = detay.SatinalmaTalepBaslikId;
                mevcut.StokKartId = detay.StokKartId;
                mevcut.Miktar = detay.Miktar;
                mevcut.OlcuBirimi = detay.OlcuBirimi;
                mevcut.Aciklama = detay.Aciklama;
                mevcut.UpdatedTime = DateTime.Now;
                mevcut.UpdatedByComputer = Environment.MachineName;

                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var detay = await _context.SatinalmaTalepDetaylar.FindAsync(id);
            if (detay != null)
            {
                _context.SatinalmaTalepDetaylar.Remove(detay);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SatinalmaTalepDetay>> GetBekleyenTaleplerAsync(int onayKullaniciId)
        {
            return await _context.SatinalmaTalepDetaylar
                .Include(d => d.Baslik) // "Baslik" navigation property'si olmalı
                .Where(d => d.OnayDurum == null &&
                            d.Baslik != null &&
                            d.Baslik.OnayKullaniciId == onayKullaniciId)
                .ToListAsync();
        }



        public async Task OnaylaAsync(int id)
        {
            var detay = await _context.SatinalmaTalepDetaylar.FindAsync(id);
            if (detay != null)
            {
                detay.OnayDurum = true;
                detay.OnayTarihi = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ReddetAsync(int id)
        {
            var detay = await _context.SatinalmaTalepDetaylar.FindAsync(id);
            if (detay != null)
            {
                detay.OnayDurum = false;
                detay.OnayTarihi = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<SatinalmaTalepDetay>> GetDetailsByHeaderIdAsync(int headerId)
        {
            return await _context.SatinalmaTalepDetaylar
                .Where(d => d.SatinalmaTalepBaslikId == headerId)
                .ToListAsync();
        }

        public async Task DeleteDetailsByHeaderIdAsync(int headerId)
        {
            var detaylar = await _context.SatinalmaTalepDetaylar
                .Where(d => d.SatinalmaTalepBaslikId == headerId)
                .ToListAsync();

            if (detaylar.Any())
            {
                _context.SatinalmaTalepDetaylar.RemoveRange(detaylar);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<SatinalmaTalepDetay>> GetAllByBaslikIdWithIncludeAsync(int baslikId)
        {
            return await _context.SatinalmaTalepDetaylar
                .Include(d => d.StokKart)
                .Where(d => d.SatinalmaTalepBaslikId == baslikId)
                .ToListAsync();
        }


        public async Task<List<SatinalmaTalepDetay>> GetOnaylanmisDetaylarAsync()
        {
            return await _context.SatinalmaTalepDetaylar
                .Include(d => d.StokKart)
                .Include(d => d.Baslik)
                .Where(d => d.OnayDurum == true)
                .ToListAsync();
        }

    }
}
