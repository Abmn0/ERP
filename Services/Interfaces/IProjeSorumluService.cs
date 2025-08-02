using Models;

namespace ApiService.Interfaces
{
    public interface IProjeSorumluService
    {
        Task<List<ProjeSorumlu>> GetAllAsync();
        Task<ProjeSorumlu?> GetByIdAsync(int id);
        Task AddAsync(ProjeSorumlu projeSorumlu);
        Task UpdateAsync(ProjeSorumlu projeSorumlu);
        Task DeleteAsync(int id);
    }
}
