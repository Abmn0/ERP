using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Services.Interfaces;
using System.Security.Claims;

namespace YektamakWeb.Shared
{
    public abstract class AuthorizedPageBase : ComponentBase
    {
        [Inject] protected AuthenticationStateProvider AuthStateProvider { get; set; } = default!;
        [Inject] protected IYetkiService YetkiService { get; set; } = default!;
        [Inject] protected NavigationManager Navigation { get; set; } = default!;

        private bool _erisimVar = false;
        private bool _erisimKontrolEdildi = false;

        public bool ErisimVar => _erisimVar;
        public bool ErisimKontrolEdildi => _erisimKontrolEdildi;

        protected virtual string GercekSayfaYolu
        {
            get
            {
                var path = Navigation.ToBaseRelativePath(Navigation.Uri);
                var firstSegment = path.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault() ?? "";
                return $"/{firstSegment}";
            }
        }

        protected override async Task OnInitializedAsync()
        {

            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            _erisimVar = await YetkiService.HasAccessAsync(user, GercekSayfaYolu);
            _erisimKontrolEdildi = true;

            if (!_erisimVar)
            {
                Navigation.NavigateTo("/erisim-yok");
                return;
            }

            await OnSayfaYuklendi();
        }

        protected virtual Task OnSayfaYuklendi() => Task.CompletedTask;
    }

}
