using Models;

namespace Services.Interfaces
{
    public interface IMalzemeAltGrupService
    {
        Task<List<MalzemeAltGrup>> GetAllAsync();
        Task<List<MalzemeAltGrup>> GetAllWithIncludeAsync();
        Task<MalzemeAltGrup?> GetByIdAsync(int id);
        Task<List<MalzemeAltGrup>> GetByMalzemeGrupIdAsync(int grupId);
        Task AddAsync(MalzemeAltGrup entity);
        Task UpdateAsync(MalzemeAltGrup entity);
        Task DeleteAsync(int id);
    }
}
