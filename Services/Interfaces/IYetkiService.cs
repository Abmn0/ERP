using Models;
using System.Security.Claims;

namespace Services.Interfaces
{
    public interface IYetkiService
    {
        Task<List<Yetki>> GetByRolIdAsync(int rolId);
        Task UpdateRoleMenuPermissionsAsync(int rolId, List<Yetki> yeniYetkiler);
        Task<bool> HasAccessAsync(ClaimsPrincipal user, string formAd);
        Task<List<string>> GetYetkiliFormAdlarAsync(ClaimsPrincipal user);
        Task<List<string>> GetYetkiliFormAdlarAsync(Kullanici user);
    }
}
