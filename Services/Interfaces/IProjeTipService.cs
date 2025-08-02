using Models;

namespace ApiService.Interfaces
{
    public interface IProjeTipService
    {
        Task<List<ProjeTip>> GetAllAsync();
        Task<ProjeTip?> GetByIdAsync(int id);
        Task AddAsync(ProjeTip projeTip);
        Task UpdateAsync(ProjeTip projeTip);
        Task DeleteAsync(int id);
    }
}
