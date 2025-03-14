// Ruta: MyERP/MyERP/Data/MyERPDbContext.cs
using Microsoft.EntityFrameworkCore;
using MyERP.Models.Identity; // Ejemplo: entidad Usuario

namespace MyERP.Data
{
    public class MyERPDbContext : DbContext
    {
        private readonly string _connectionString;

        // Constructor que recibe la cadena de conexión dinámica
        public MyERPDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Constructor para la inyección de dependencias (en caso de configuración desde MauiProgram.cs)
        public MyERPDbContext(DbContextOptions<MyERPDbContext> options) : base(options)
        {
        }

        // Ejemplo de DbSet (la tabla Usuarios)
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Si no se configuró y se tiene una cadena dinámica, se configura SQL Server
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        // Configuración adicional de modelos (mapeo, relaciones, etc.)
    }
}
