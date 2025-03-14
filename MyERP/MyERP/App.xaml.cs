// Ruta: MyERP/App.xaml.cs

using Microsoft.Maui.Controls;

namespace MyERP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Se envuelve la primera página en un NavigationPage para habilitar la navegación
            MainPage = new NavigationPage(new Views.LoginPage());
        }
    }
}

