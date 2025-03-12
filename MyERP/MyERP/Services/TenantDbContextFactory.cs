// Ruta: MyERP/Services/TenantDbContextFactory.cs
// Este servicio crea una instancia de MyERPDbContext basado en la información del tenant.
// Permite que cada tenant se conecte a su propia base de datos.

using System;
using Microsoft.EntityFrameworkCore;
using MyERP.Data;
using MyERP.Models.SaaS;

namespace MyERP.Services
{
    public interface ITenantDbContextFactory
    {
        MyERPDbContext CreateDbContext(TenantInfo tenant);
    }

    public class TenantDbContextFactory : ITenantDbContextFactory
    {
        public MyERPDbContext CreateDbContext(TenantInfo tenant)
        {
            if (tenant == null)
                throw new ArgumentNullException(nameof(tenant));

            if (string.IsNullOrEmpty(tenant.ConnectionString))
                throw new Exception("La cadena de conexión del tenant no está configurada.");

            var optionsBuilder = new DbContextOptionsBuilder<MyERPDbContext>();
            optionsBuilder.UseSqlServer(tenant.ConnectionString);
            return new MyERPDbContext(optionsBuilder.Options);
        }
    }
}

