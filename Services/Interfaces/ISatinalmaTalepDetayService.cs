using Models;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISatinalmaTalepDetayService
    {
        Task<List<SatinalmaTalepDetay>> GetAllAsync();
        Task<SatinalmaTalepDetay?> GetByIdAsync(int id);
        Task AddAsync(SatinalmaTalepDetay detay);
        Task UpdateAsync(SatinalmaTalepDetay detay);
        Task DeleteAsync(int id);
        Task OnaylaAsync(int id);
        Task ReddetAsync(int id);
        Task<List<SatinalmaTalepDetay>> GetBekleyenTaleplerAsync(int onayKullaniciId);
        Task<List<SatinalmaTalepDetay>> GetDetailsByHeaderIdAsync(int headerId);
        Task DeleteDetailsByHeaderIdAsync(int headerId);
        Task<List<SatinalmaTalepDetay>> GetAllByBaslikIdWithIncludeAsync(int baslikId);
        Task<List<SatinalmaTalepDetay>> GetOnaylanmisDetaylarAsync();
    }
}
