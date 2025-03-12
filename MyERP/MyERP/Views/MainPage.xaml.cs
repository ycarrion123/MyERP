// Ruta: MyERP/Views/MainPage.xaml.cs
// Página principal con un SfDataGrid para mostrar usuarios.

using Microsoft.Maui.Controls;
using MyERP.ViewModels;
using Syncfusion.Maui.DataGrid;

namespace MyERP.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            BindingContext = viewModel;
            Title = "Dashboard";

            var dataGrid = new SfDataGrid
            {
                AutoGenerateColumns = false,
                Columns = {
                    new GridTextColumn { MappingName = "Nombre", HeaderText = "Nombre" },
                    new GridTextColumn { MappingName = "Email", HeaderText = "Email" },
                    new GridBooleanColumn { MappingName = "Bloqueado", HeaderText = "Bloqueado" }
                }
            };
            dataGrid.SetBinding(SfDataGrid.ItemsSourceProperty, nameof(viewModel.Usuarios));

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    new Label
                    {
                        Text = "Gestión de Usuarios",
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    dataGrid
                }
            };
        }
    }
}

