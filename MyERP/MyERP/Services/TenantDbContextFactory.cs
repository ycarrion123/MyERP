// Ruta: MyERP/MyERP/Services/TenantDbContextFactory.cs
using MyERP.Data;
using Microsoft.EntityFrameworkCore;

namespace MyERP.Services
{
    public class TenantDbContextFactory
    {
        public static MyERPDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyERPDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyERPDbContext(optionsBuilder.Options);
        }
    }
}
