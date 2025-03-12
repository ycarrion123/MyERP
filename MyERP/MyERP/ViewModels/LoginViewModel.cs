// Ruta: MyERP/ViewModels/LoginViewModel.cs

using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyERP.Models.Account;
using MyERP.Services.Interfaces;

namespace MyERP.ViewModels
{
    // ViewModel para Login utilizando CommunityToolkit.Mvvm
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;

        public LoginViewModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
        }

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        public async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ErrorMessage = "El email y la contraseña son requeridos.";
                return;
            }
            IsBusy = true;
            ErrorMessage = string.Empty;
            try
            {
                var loginRequest = new LoginRequest
                {
                    Email = email,
                    Password = password,
                    Captcha = "dummy" // En producción, validar captcha
                };
                bool result = await _accountService.LoginAsync(loginRequest);
                if (result)
                {
                    await _navigationService.NavigateToAsync("//MainPage");
                }
                else
                {
                    ErrorMessage = "Credenciales inválidas.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error al iniciar sesión: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

