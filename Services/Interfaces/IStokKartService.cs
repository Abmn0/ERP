using Models;

namespace Services.Interfaces
{
    public interface IStokKartService
    {
        Task<List<StokKart>> GetAllAsync();
        Task<StokKart?> GetByIdAsync(int id);
        Task<List<StokKart>> GetAllWithIncludeAsync();
        Task AddAsync(StokKart stokKart);
        Task UpdateAsync(StokKart stokKart);
        Task DeleteAsync(int id);
    }
}
