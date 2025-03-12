// Ruta: MyERP/AppShell.xaml.cs

using Microsoft.Maui.Controls;
using MyERP.Views;

namespace MyERP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Registro de rutas para la navegación
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
