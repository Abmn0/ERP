using Models;

namespace ApiService.Interfaces
{
    public interface IMarkaService
    {
        Task<List<Marka>> GetAllAsync();
        Task<Marka?> GetByIdAsync(int id);
        Task AddAsync(Marka marka);
        Task UpdateAsync(Marka marka);
        Task DeleteAsync(int id);
    }
}