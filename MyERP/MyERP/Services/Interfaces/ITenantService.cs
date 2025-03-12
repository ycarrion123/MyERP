// Ruta: MyERP/Services/Interfaces/ITenantService.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using MyERP.Models.SaaS;

namespace MyERP.Services.Interfaces
{
    public interface ITenantService
    {
        Task CrearTenantAsync(TenantInfo tenant);
        Task ActualizarTenantAsync(TenantInfo tenant);
        Task<List<TenantInfo>> ObtenerTenantsAsync();
    }
}

