using Models;

namespace Services.Interfaces
{
    public interface IPozisyonService
    {
        Task<List<Pozisyon>> GetAllAsync();
        Task<Pozisyon?> GetByIdAsync(int id);
        Task AddAsync(Pozisyon pozisyon);
        Task UpdateAsync(Pozisyon pozisyon);
        Task DeleteAsync(int id);
    }
}
