using Models;

namespace Services.Interfaces
{
    public interface IMalzemeStandartService
    {
        Task<List<MalzemeStandart>> GetAllAsync();
        Task<MalzemeStandart?> GetByIdAsync(int id);
        Task AddAsync(MalzemeStandart entity);
        Task UpdateAsync(MalzemeStandart entity);
        Task DeleteAsync(int id);
    }
}
