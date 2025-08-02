using Models;

namespace Services.Interfaces
{
    public interface IPersonelResimService
    {
        Task<List<PersonelResim>> GetAllAsync();
        Task<PersonelResim?> GetByIdAsync(int id);
        Task AddAsync(PersonelResim resim);
        Task UpdateAsync(PersonelResim resim); // EKLENDİ
        Task DeleteAsync(int id);
        Task<PersonelResim?> GetByPersonelIdAsync(int personelId);

    }
}
