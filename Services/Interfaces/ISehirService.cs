using Models;

namespace Services.Interfaces
{
    public interface ISehirService
    {
        Task<List<Sehir>> GetAllAsync();
        Task<Sehir?> GetByIdAsync(int id);
        Task AddAsync(Sehir sehir);
        Task UpdateAsync(Sehir sehir);
        Task DeleteAsync(int id);
    }
}
