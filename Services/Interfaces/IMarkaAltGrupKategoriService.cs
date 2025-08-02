using Models;

namespace ApiService.Interfaces
{
    public interface IMarkaAltGrupKategoriService
    {
        Task<List<MarkaAltGrupKategori>> GetAllAsync();
        Task<MarkaAltGrupKategori?> GetByIdAsync(int id);
        Task<List<MarkaAltGrupKategori>> GetAllWithIncludeAsync();
        Task AddAsync(MarkaAltGrupKategori kategori);
        Task UpdateAsync(MarkaAltGrupKategori kategori);
        Task DeleteAsync(int id);
    }
}
