using Models;

namespace Services.Interfaces
{
    public interface IStokTipService
    {
        Task<List<StokTip>> GetAllAsync();
        Task<StokTip?> GetByIdAsync(int id);
        Task AddAsync(StokTip stokTip);
        Task UpdateAsync(StokTip stokTip);
        Task DeleteAsync(int id);
    }
}
