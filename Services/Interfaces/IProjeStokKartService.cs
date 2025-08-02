using Models;

namespace ApiService.Interfaces
{
    public interface IProjeStokKartService
    {
        Task<List<ProjeStokKart>> GetAllAsync();
        Task<List<ProjeStokKart>> GetAllWithIncludeAsync();
        Task<ProjeStokKart?> GetByIdAsync(int id);
        Task AddAsync(ProjeStokKart projeStokKart);
        Task UpdateAsync(ProjeStokKart projeStokKart);
        Task DeleteAsync(int id);
    }
}
