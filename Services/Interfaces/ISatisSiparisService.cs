using Models;

public interface ISatisSiparisService
{
    Task<List<SatisSiparis>> GetAllAsync();
    Task<SatisSiparis> GetByIdAsync(int id);
    Task AddAsync(SatisSiparis siparis);
    Task UpdateAsync(SatisSiparis siparis);
    Task DeleteAsync(int id);
}
