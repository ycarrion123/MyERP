// Ruta: MyERP/Services/Interfaces/IIdentityService.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyERP.Models.Identity;

namespace MyERP.Services.Interfaces
{
    public interface IIdentityService
    {
        Task CrearUsuarioAsync(Usuario usuario);
        Task ActualizarUsuarioAsync(Usuario usuario);
        Task BloquearUsuarioAsync(Guid usuarioId);
        Task DesbloquearUsuarioAsync(Guid usuarioId);
        Task<List<Usuario>> ObtenerUsuariosAsync();
    }
}
