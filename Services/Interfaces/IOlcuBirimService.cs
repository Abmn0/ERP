using Models;

namespace Services.Interfaces
{
    public interface IOlcuBirimService
    {
        Task<List<OlcuBirim>> GetAllAsync();
        Task<OlcuBirim?> GetByIdAsync(int id);
        Task AddAsync(OlcuBirim entity);
        Task UpdateAsync(OlcuBirim entity);
        Task DeleteAsync(int id);
    }
}
