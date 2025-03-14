// Ruta: MyERP/MauiProgram.cs
// Se configura la aplicación MAUI, se registra EF Core y el factory para multi-tenant,
// además de los repositorios basados en EF Core.

using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui;
using MyERP.Services.Interfaces;
using MyERP.Services.Repositories;
using MyERP.Services.Identity;
using MyERP.Services.Account;
using MyERP.Services.SaaS;
using MyERP.Services.Integration;
using MyERP.Services;
using MyERP.ViewModels;
using MyERP.Views;
using MyERP.Models.Identity;
using MyERP.Models.SaaS;
using MyERP.Data;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Syncfusion.Maui.DataGrid;


namespace MyERP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit();

            // Registro de la configuración (si se requiere leer appsettings, etc.)
            builder.Configuration.AddJsonFile("Resources/appsettings.json", optional: true);

            // Registro de servicios y factorías
            builder.Services.AddSingleton<TenantDbContextFactory>();

            // Registrar el DbContext para un tenant "default" o de desarrollo.
            // En un escenario real, la cadena de conexión se obtendría dinámicamente según el tenant.
            string defaultConnectionString = "Server=localhost;Database=MyERP_Default;User Id=usuario;Password=contraseña;TrustServerCertificate=True;";
            builder.Services.AddDbContext<MyERPDbContext>(options =>
                options.UseSqlServer(defaultConnectionString));

            // Registrar el repositorio basado en EF Core (para Usuario y TenantInfo)
            builder.Services.AddScoped<IRepository<Usuario>, EfRepository<Usuario>>();
            builder.Services.AddScoped<IRepository<TenantInfo>, EfRepository<TenantInfo>>();

            // Registrar servicios de dominio
            builder.Services.AddSingleton<IIdentityService, IdentityService>();
            builder.Services.AddSingleton<IAccountService, AccountService>();
            builder.Services.AddSingleton<ITenantService, TenantService>();
            builder.Services.AddSingleton<IMicroserviceClient, MicroserviceClient>();

            // Registrar el TenantDbContextFactory para multi-tenant
            builder.Services.AddSingleton<ITenantDbContextFactory, TenantDbContextFactory>();

            // Registrar el servicio de navegación
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Registrar ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<MainViewModel>();

            // Registrar páginas (Views)
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<MainPage>();

            // La página de usuarios se registrará, esperando recibir el DbContext ya configurado y la información del tenant.
            builder.Services.AddTransient<UsuariosPage>();
            builder.Services.AddTransient<UsuariosViewModel>();

            return builder.Build();
        }
    }
}
