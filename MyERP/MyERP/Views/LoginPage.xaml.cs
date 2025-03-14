// Ruta: MyERP/MyERP/Views/LoginPage.xaml.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
using MyERP.Models.SaaS; // Modelo TenantInfo

namespace MyERP.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Debe ingresar Email y Contraseña", "OK");
                return;
            }

            // Validación básica del formato de email
            if (!email.Contains("@"))
            {
                await DisplayAlert("Error", "El Email no es válido", "OK");
                return;
            }

            // Cargar la lista de tenants desde el archivo JSON
            var tenants = LoadTenants();
            var tenant = tenants.Find(t => t.USERID.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (tenant == null)
            {
                await DisplayAlert("Error", "No se encontró configuración para el usuario", "OK");
                return;
            }

            // Validar contraseña (para este ejemplo se compara en texto plano; en producción usar hash)
            if (!tenant.PASSWORD.Equals(password))
            {
                await DisplayAlert("Error", "Contraseña incorrecta", "OK");
                return;
            }

            // Crear la cadena de conexión a partir de la información del tenant
            string connectionString = GenerateConnectionString(tenant);

            // Almacenar la información del tenant en propiedades globales para su uso posterior
            App.Current.Properties["TenantConnectionString"] = connectionString;
            App.Current.Properties["TenantUser"] = tenant.USERID;
            App.Current.Properties["TenantDatabase"] = tenant.DatabaseSQL;

            // Navegar a la página de Usuarios (o página principal)
            await Navigation.PushAsync(new UsuariosPage());
        }

        private List<TenantInfo> LoadTenants()
        {
            // Se asume que el archivo JSON está incrustado en Resources/tenants.json
            var assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("MyERP.Resources.tenants.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<TenantInfo>>(json);
            }
        }

        private string GenerateConnectionString(TenantInfo tenant)
        {
            // Ejemplo de construcción de cadena de conexión
            string xServer = tenant.ServerSQL;
            string xLogin = tenant.LoginSQL;
            string xPwd = tenant.PasswordSQL;
            string xDb = tenant.DatabaseSQL;
            string lcProgram_Name = "MyErp";  // Dato fijo
            string lcEquipo = Environment.MachineName;  // Nombre del equipo (no editable)

            // Se puede ajustar para utilizar un driver específico, en este ejemplo se arma una cadena similar al propuesto
            string connectionString = $"Driver={{SQL Server}};SERVER={xServer};UID={xLogin};PWD={xPwd};APP={lcProgram_Name};WSID={lcEquipo};DATABASE={xDb};Encrypt=no;";

            return connectionString;
        }
    }
}
