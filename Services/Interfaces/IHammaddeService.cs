using Models;

namespace Services.Interfaces
{
    public interface IHammaddeService
    {
        Task<List<Hammadde>> GetAllAsync();
        Task<Hammadde?> GetByIdAsync(int id);
        Task AddAsync(Hammadde hammadde);
        Task UpdateAsync(Hammadde hammadde);
        Task DeleteAsync(int id);
    }
}
