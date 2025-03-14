// Ruta: MyERP/MyERP/Views/UsuariosPage.xaml.cs
using Microsoft.Maui.Controls;
using MyERP.Data;
using MyERP.Models.Identity;  // Se asume que la entidad Usuario se encuentra aquí
using MyERP.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyERP.Views
{
    public partial class UsuariosPage : ContentPage
    {
        public UsuariosPage()
        {
            InitializeComponent();
            LoadUsuarios();
        }

        private async void LoadUsuarios()
        {
            // Recuperar la cadena de conexión y datos del tenant desde App.Current.Properties
            string connectionString = App.Current.Properties.ContainsKey("TenantConnectionString")
                ? App.Current.Properties["TenantConnectionString"].ToString()
                : "";
            string tenantUser = App.Current.Properties.ContainsKey("TenantUser")
                ? App.Current.Properties["TenantUser"].ToString()
                : "";
            string tenantDatabase = App.Current.Properties.ContainsKey("TenantDatabase")
                ? App.Current.Properties["TenantDatabase"].ToString()
                : "";

            HeaderLabel.Text = $"Conectado: {tenantUser} | Database: {tenantDatabase}";

            // Usar la factory para crear el DbContext con la cadena de conexión dinámica
            using (var context = TenantDbContextFactory.CreateDbContext(connectionString))
            {
                var usuarios = await context.Set<Usuario>().ToListAsync();
                UsuariosListView.ItemsSource = usuarios;
            }
        }
    }
}
