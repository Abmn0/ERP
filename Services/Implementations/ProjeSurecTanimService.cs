using ApiService.Interfaces;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiService.Implementations
{
    public class ProjeSurecTanimService : IProjeSurecTanimService
    {
        private readonly YektamakDbContext _context;

        public ProjeSurecTanimService(YektamakDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjeSurecTanim>> GetAllAsync()
        {
            return await _context.ProjeSurecTanimlari.ToListAsync();
        }

        public async Task<ProjeSurecTanim?> GetByIdAsync(int id)
        {
            return await _context.ProjeSurecTanimlari.FindAsync(id);
        }

        public async Task AddAsync(ProjeSurecTanim surec)
        {
            await _context.ProjeSurecTanimlari.AddAsync(surec);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjeSurecTanim surec)
        {
            var tracked = await _context.ProjeSurecTanimlari.FindAsync(surec.Id);
            if (tracked != null)
            {
                _context.Entry(tracked).CurrentValues.SetValues(surec);
            }
            else
            {
                _context.ProjeSurecTanimlari.Update(surec);
            }

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ProjeSurecTanimlari.FindAsync(id);
            if (entity != null)
            {
                _context.ProjeSurecTanimlari.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
