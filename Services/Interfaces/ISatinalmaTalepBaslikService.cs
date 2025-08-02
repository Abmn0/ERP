using Models;

public interface ISatinalmaTalepBaslikService
{
    Task<List<SatinalmaTalepBaslik>> GetAllAsync();
    Task<SatinalmaTalepBaslik?> GetByIdAsync(int id);
    Task<List<SatinalmaTalepBaslik>> GetAllWithIncludeAsync();
    Task AddAsync(SatinalmaTalepBaslik baslik);
    Task UpdateAsync(SatinalmaTalepBaslik baslik);
    Task DeleteAsync(int id);
    Task<List<SatinalmaTalepBaslik>> GetKullaniciyaAtananTaleplerAsync(int onayKullaniciId);
    Task BaslikOnaylaAsync(int baslikId);
    Task<string> GetTalepDurumuAsync(int baslikId);
    Task GuncelleOnayDurumuAsync(int baslikId);
    Task BaslikReddetAsync(int baslikId);
    Task<string> GetYeniTalepNoAsync();
    Task<List<SatinalmaTalepBaslik>> GetByKullaniciIdWithIncludeAsync(int kullaniciId);
    Task<int> GetToplamTalepSayisiAsync();
    Task<int> GetOnaylananTalepSayisiAsync();
    Task<int> GetReddedilenTalepSayisiAsync();
    Task<int> GetBekleyenTalepSayisiAsync();
    Task<int> GetAtanmisTalepSayisiAsync(int kullaniciId); // opsiyonel


}
