using Models;

namespace Services.Interfaces
{
    public interface IUlkeService
    {
        Task<List<Ulke>> GetAllAsync();
        Task<Ulke?> GetByIdAsync(int id);
        Task AddAsync(Ulke ulke);
        Task UpdateAsync(Ulke ulke);
        Task DeleteAsync(int id);
    }
}
