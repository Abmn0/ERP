using Models;

namespace Services.Interfaces
{
    public interface IStokGrupService
    {
        Task<List<StokGrup>> GetAllAsync();
        Task<StokGrup?> GetByIdAsync(int id);
        Task AddAsync(StokGrup entity);
        Task UpdateAsync(StokGrup entity);
        Task DeleteAsync(int id);
    }
}
