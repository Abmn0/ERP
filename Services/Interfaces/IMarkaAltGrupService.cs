using Models;

namespace ApiService.Interfaces
{
    public interface IMarkaAltGrupService
    {
        Task<List<MarkaAltGrup>> GetAllAsync();
        Task<MarkaAltGrup?> GetByIdAsync(int id);
        Task<List<MarkaAltGrup>> GetAllWithIncludeAsync();
        Task AddAsync(MarkaAltGrup markaAltGrup);
        Task UpdateAsync(MarkaAltGrup markaAltGrup);
        Task<(bool success, string errorMessage)> DeleteAsync(int id);
    }
}