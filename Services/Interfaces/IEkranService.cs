using Models;

namespace Services.Interfaces
{
    public interface IEkranService
    {
        Task<List<Ekran>> GetAllAsync();
        Task<Ekran?> GetByIdAsync(int id);
        Task AddAsync(Ekran ekran);
        Task UpdateAsync(Ekran ekran);
        Task DeleteAsync(int id);
    }
}
