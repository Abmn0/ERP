using Models;

namespace Services.Interfaces
{
    public interface IMalzemeGrupService
    {
        Task<List<MalzemeGrup>> GetAllAsync();
        Task<List<MalzemeGrup>> GetAllWithIncludeAsync();
        Task<MalzemeGrup?> GetByIdAsync(int id);
        Task<List<MalzemeGrup>> GetByStokGrupIdAsync(int stokGrupId);
        Task AddAsync(MalzemeGrup entity);
        Task UpdateAsync(MalzemeGrup entity);
        Task DeleteAsync(int id);
    }
}
