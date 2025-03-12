// Ruta: MyERP/Services/SaaS/TenantService.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyERP.Models.SaaS;
using MyERP.Services.Interfaces;

namespace MyERP.Services.SaaS
{
    public class TenantService : ITenantService
    {
        private readonly IRepository<TenantInfo> _tenantRepository;

        public TenantService(IRepository<TenantInfo> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task CrearTenantAsync(TenantInfo tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException(nameof(tenant));
            try
            {
                await _tenantRepository.AddAsync(tenant);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear tenant", ex);
            }
        }

        public async Task ActualizarTenantAsync(TenantInfo tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException(nameof(tenant));
            try
            {
                await _tenantRepository.UpdateAsync(tenant);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar tenant", ex);
            }
        }

        public async Task<List<TenantInfo>> ObtenerTenantsAsync()
        {
            try
            {
                return await _tenantRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tenants", ex);
            }
        }
    }
}

