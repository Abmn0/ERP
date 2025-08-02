using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using Services.Interfaces;
using Models;

namespace YektamakWeb.Accounts
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IKullaniciService _kullaniciService;


        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

        public CustomAuthStateProvider(
            ProtectedSessionStorage sessionStorage,
            IKullaniciService kullaniciService)
        {
            _sessionStorage = sessionStorage;
            _kullaniciService = kullaniciService;
           
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var storedUser = await _sessionStorage.GetAsync<string>("authUser");

                if (storedUser.Success && !string.IsNullOrEmpty(storedUser.Value))
                {
                    int userId = int.Parse(storedUser.Value);
                    var user = await _kullaniciService.GetUserByKodAsync(storedUser.Value);

                    

                    if (user != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Kod),
                            new Claim(ClaimTypes.Role, user.Rol?.Ad ?? "Kullanici"),
                            new Claim("UserId", user.Id.ToString())
                        };

                        _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "YektamakAuth"));
                    }
                }
            }
            catch
            {
                _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            }

            return new AuthenticationState(_currentUser);
        }

        public async Task<Kullanici?> GetCurrentUserAsync()
        {
            var storedUserKod = await _sessionStorage.GetAsync<string>("authUser");

            if (storedUserKod.Success && !string.IsNullOrWhiteSpace(storedUserKod.Value))
            {
                return await _kullaniciService.GetUserByKodAsync(storedUserKod.Value);
            }

            return null;
        }
        public async Task MarkUserAsAuthenticated(int userId)
        {
            var user = await _kullaniciService.GetByIdAsync(userId);

            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Kod),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("UserId", user.Id.ToString()),

            // Eksik olan bu satırı EKLE!
            new Claim(ClaimTypes.Role, user.Rol?.Ad ?? "Kullanici")
        };

                var identity = new ClaimsIdentity(claims, "apiauth");
                _currentUser = new ClaimsPrincipal(identity);

                await _sessionStorage.SetAsync("authUser", user.Id.ToString());
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
            }
        }



        public async Task MarkUserAsLoggedOut()
        {
            await _sessionStorage.DeleteAsync("authUser");
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
}
