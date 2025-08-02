using Models;

public interface IPersonelService
{
    Task<List<Personel>> GetAllAsync();
    Task<List<Personel>> GetAllWithIncludeAsync();
    Task<Personel?> GetByIdAsync(int id);
    Task<int> AddAsync(Personel personel); // Geriye int döndürsün
    Task UpdateAsync(Personel personel);
    Task DeleteAsync(int id);
}
