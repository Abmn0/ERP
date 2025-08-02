using Microsoft.EntityFrameworkCore;
using DataAccess;
using YektamakWeb.Data;
using Services.Implementations;
using Services.Interfaces;
using Utilities.Implementations;
using Utilities.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using YektamakWeb.Accounts;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ApiService.Implementations;
using ApiService.Interfaces;



var builder = WebApplication.CreateBuilder(args);

// EF Core - YektamakDbContext
builder.Services.AddDbContext<YektamakDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("YektamakConnection"),
        new MySqlServerVersion(new Version(8, 0, 42))));

// Dependency Injection
builder.Services.AddScoped<IFirmaService, FirmaService>();
builder.Services.AddScoped<IPersonelService, PersonelService>();
builder.Services.AddScoped<IPozisyonService, PozisyonService>();
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ISehirService, SehirService>();
builder.Services.AddScoped<IUlkeService, UlkeService>();
builder.Services.AddScoped<IPersonelResimService, PersonelResimService>();
builder.Services.AddScoped<IPermissionCheckerService, PermissionCheckerService>();
builder.Services.AddScoped<IYetkiService, YetkiService>();
builder.Services.AddScoped<IEkranService, EkranService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<IStokKartService, StokKartService>();
builder.Services.AddScoped<IStokGrupService, StokGrupService>();
builder.Services.AddScoped<IStokTipService, StokTipService>();
builder.Services.AddScoped<IMalzemeGrupService, MalzemeGrupService>();
builder.Services.AddScoped<IMalzemeAltGrupService, MalzemeAltGrupService>();
builder.Services.AddScoped<IMalzemeAltGrup2Service, MalzemeAltGrup2Service>();
builder.Services.AddScoped<IOlcuBirimService, OlcuBirimService>();
builder.Services.AddScoped<IMalzemeStandartService, MalzemeStandartService>();
builder.Services.AddScoped<IHammaddeService, HammaddeService>();
builder.Services.AddScoped<IProjeService, ProjeService>();
builder.Services.AddScoped<ISatisSiparisService, SatisSiparisService>();
builder.Services.AddScoped<IMarkaService, MarkaService>();
builder.Services.AddScoped<IMarkaAltGrupService, MarkaAltGrupService>();
builder.Services.AddScoped<IMarkaAltGrupKategoriService, MarkaAltGrupKategoriService>();
builder.Services.AddScoped<IProjeTipService, ProjeTipService>();
builder.Services.AddScoped<IProjeSorumluService, ProjeSorumluService>();
builder.Services.AddScoped<IProjeTakvimService, ProjeTakvimService>();
builder.Services.AddScoped<IProjeSurecTanimService, ProjeSurecTanimService>();
builder.Services.AddScoped<IProjeStokKartService, ProjeStokKartService>();
builder.Services.AddScoped<ISatinalmaTalepBaslikService, SatinalmaTalepBaslikService>();
builder.Services.AddScoped<ISatinalmaTalepDetayService, SatinalmaTalepDetayService>();
builder.Services.AddScoped<ISatinalmaSiparisBaslikService, SatinalmaSiparisBaslikService>();
builder.Services.AddScoped<ISatinalmaSiparisDetayService, SatinalmaSiparisDetayService>();



// Auth
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddAuthorizationCore();

// Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // Ýsteðe baðlý
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization(); // bu sadece policy-based auth içindir

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
