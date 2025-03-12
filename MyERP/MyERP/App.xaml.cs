// Ruta: MyERP/App.xaml.cs

using Microsoft.Maui.Controls;

namespace MyERP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}

