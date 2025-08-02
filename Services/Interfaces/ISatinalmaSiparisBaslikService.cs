using Models;

namespace Services.Interfaces
{
    public interface ISatinalmaSiparisBaslikService
    {
        Task<List<SatinalmaSiparisBaslik>> GetAllAsync();
        Task<List<SatinalmaSiparisBaslik>> GetAllWithIncludeAsync();
        Task<SatinalmaSiparisBaslik?> GetByIdAsync(int id);

        Task AddAsync(SatinalmaSiparisBaslik baslik);
        Task UpdateAsync(SatinalmaSiparisBaslik baslik);
        Task DeleteAsync(int id);

        Task<string> GetYeniSiparisNoAsync(string prefix = "YKMSIP");   // İstersen prefix parametreli
        Task<List<SatinalmaSiparisBaslik>> GetByFirmaIdAsync(int firmaId);
        Task<List<SatinalmaSiparisBaslik>> GetByDateRangeAsync(DateTime? start, DateTime? end);

        Task RecalculateTotalAsync(int baslikId);
    }
}
