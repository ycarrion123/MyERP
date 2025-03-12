// Ruta: MyERP/ViewModels/MainViewModel.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyERP.Models.Identity;
using MyERP.Services.Interfaces;

namespace MyERP.ViewModels
{
    // ViewModel para el Dashboard principal
    public partial class MainViewModel : ObservableObject
    {
        private readonly IIdentityService _identityService;

        public MainViewModel(IIdentityService identityService)
        {
            _identityService = identityService;
            LoadUsuariosCommand = new AsyncRelayCommand(LoadUsuariosAsync);
        }

        [ObservableProperty]
        private List<Usuario> usuarios;

        public IAsyncRelayCommand LoadUsuariosCommand { get; }

        private async Task LoadUsuariosAsync()
        {
            try
            {
                Usuarios = await _identityService.ObtenerUsuariosAsync();
            }
            catch (Exception ex)
            {
                // Manejar o loguear el error según sea necesario
            }
        }
    }
}
