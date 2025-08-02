using Models;

namespace Services.Interfaces
{
    public interface ISatinalmaSiparisDetayService
    {
        Task<List<SatinalmaSiparisDetay>> GetByBaslikIdAsync(int baslikId);
        Task<SatinalmaSiparisDetay?> GetByIdAsync(int id);

        Task AddAsync(SatinalmaSiparisDetay detay);
        Task AddRangeAsync(IEnumerable<SatinalmaSiparisDetay> detaylar);
        Task UpdateAsync(SatinalmaSiparisDetay detay);
        Task DeleteAsync(int id);
        Task DeleteByBaslikIdAsync(int baslikId);
    }
}
