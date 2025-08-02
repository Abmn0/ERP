using Models;

namespace ApiService.Interfaces
{
    public interface IProjeSurecTanimService
    {
        Task<List<ProjeSurecTanim>> GetAllAsync();
        Task<ProjeSurecTanim?> GetByIdAsync(int id);
        Task AddAsync(ProjeSurecTanim surec);
        Task UpdateAsync(ProjeSurecTanim surec);
        Task DeleteAsync(int id);
    }
}
