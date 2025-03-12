// Ruta: MyERP/Services/Account/AccountService.cs

using System;
using System.Threading.Tasks;
using MyERP.Models.Account;
using MyERP.Models.Identity;
using MyERP.Services.Interfaces;

namespace MyERP.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public AccountService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            try
            {
                var usuarios = await _usuarioRepository.GetAllAsync();
                var user = usuarios.Find(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
                // Comparación simplificada; en producción, comparar usando hash
                return user != null && user.PasswordHash == request.Password;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el login", ex);
            }
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Password != request.ConfirmPassword)
                throw new Exception("Las contraseñas no coinciden");
            try
            {
                var nuevoUsuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nombre = request.Nombre,
                    Email = request.Email,
                    PasswordHash = request.Password, // En producción, aplicar hash
                    Bloqueado = false
                };
                await _usuarioRepository.AddAsync(nuevoUsuario);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el registro", ex);
            }
        }
    }
}
