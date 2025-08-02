using Models;

namespace Services.Interfaces
{
    public interface IKullaniciService
    {
        Task<List<Kullanici>> GetAllAsync();
        Task<Kullanici?> GetByIdAsync(int id);
        Task<Kullanici?> GetUserByKodAsync(string kod);
        Task<int?> GetYoneticiKullaniciIdByKullaniciIdAsync(int kullaniciId);
        Task AddAsync(Kullanici kullanici);
        Task UpdateAsync(Kullanici kullanici);
        Task DeleteAsync(int id);
    }
}
