using Models;

public interface IProjeService
{
    Task<List<Proje>> GetAllAsync();
    Task<Proje?> GetByIdAsync(int id);
    Task AddAsync(Proje proje);
    Task UpdateAsync(Proje proje);
    Task DeleteAsync(int id);
}
