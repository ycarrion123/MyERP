// Ruta: MyERP/ViewModels/NavigationService.cs

using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MyERP.ViewModels
{
    // Servicio de navegación simple basado en Shell
    public interface INavigationService
    {
        Task NavigateToAsync(string route);
    }

    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}

