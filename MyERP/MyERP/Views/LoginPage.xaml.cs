// Ruta: MyERP/Views/LoginPage.xaml.cs
// Página de Login con binding a su ViewModel.

using Microsoft.Maui.Controls;
using MyERP.ViewModels;
using Syncfusion.Maui.DataGrid; // Si necesitas SyncFusion en esta página

namespace MyERP.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            BindingContext = viewModel;
            Title = "Iniciar Sesión";

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    new Entry
                    {
                        Placeholder = "Email"
                    }.Bind(Entry.TextProperty, nameof(viewModel.Email)),
                    new Entry
                    {
                        Placeholder = "Contraseña",
                        IsPassword = true
                    }.Bind(Entry.TextProperty, nameof(viewModel.Password)),
                    new Button
                    {
                        Text = "Entrar",
                        Command = viewModel.LoginAsyncCommand
                    },
                    new Label
                    {
                        TextColor = Colors.Red
                    }.Bind(Label.TextProperty, nameof(viewModel.ErrorMessage))
                }
            };
        }
    }
}
