using Models;

namespace ApiService.Interfaces
{
    public interface IProjeTakvimService
    {
        Task<List<ProjeTakvim>> GetAllAsync();
        Task<ProjeTakvim?> GetByIdAsync(int id);
        Task<List<ProjeTakvim>> GetAllByProjeIdAsync(int projeId);
        Task AddAsync(ProjeTakvim projeTakvim);
        Task UpdateAsync(ProjeTakvim projeTakvim);
        Task DeleteAsync(int id);
    }
}
