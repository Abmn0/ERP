using Models;

namespace Services.Interfaces
{
    public interface IMalzemeAltGrup2Service
    {
        Task<List<MalzemeAltGrup2>> GetAllAsync();
        Task<List<MalzemeAltGrup2>> GetAllWithIncludeAsync();
        Task<MalzemeAltGrup2?> GetByIdAsync(int id);
        Task<List<MalzemeAltGrup2>> GetByMalzemeAltGrupIdAsync(int altGrupId); 
        Task AddAsync(MalzemeAltGrup2 entity);
        Task UpdateAsync(MalzemeAltGrup2 entity);
        Task DeleteAsync(int id);
    }
}
