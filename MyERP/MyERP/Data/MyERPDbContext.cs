// Ruta: MyERP/Data/MyERPDbContext.cs
// Este DbContext se conecta a SQL Server usando EF Core. Se definen los DbSet para las entidades.
// Se contempla tanto el constructor que recibe DbContextOptions (para inyección de dependencias)
// como un constructor que recibe una cadena de conexión para escenarios multi-tenant.

using Microsoft.EntityFrameworkCore;
using MyERP.Models.Identity;
using MyERP.Models.SaaS;
using System.Collections.Generic;
using System.Reflection.Emit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Syncfusion.Maui.DataGrid;


namespace MyERP.Data
{
    public class MyERPDbContext : DbContext
    {
        // Constructor para inyección de dependencias
        public MyERPDbContext(DbContextOptions<MyERPDbContext> options) : base(options)
        {
        }

        // Constructor alternativo para crear el contexto con una cadena de conexión (multi-tenant)
        public MyERPDbContext(string connectionString)
            : base(new DbContextOptionsBuilder<MyERPDbContext>().UseSqlServer(connectionString).Options)
        {
        }

        // DbSet para la entidad Usuario (puedes agregar otros según tus necesidades)
        public DbSet<Usuario> Usuarios { get; set; }

        // DbSet para TenantInfo (si deseas almacenar la información de los tenants en una base central)
        public DbSet<TenantInfo> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí se pueden configurar las relaciones y restricciones adicionales
        }
    }
}
