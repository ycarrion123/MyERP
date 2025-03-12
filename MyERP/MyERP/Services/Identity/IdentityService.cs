// Ruta: MyERP/Services/Identity/IdentityService.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyERP.Models.Identity;
using MyERP.Services.Interfaces;

namespace MyERP.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public IdentityService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            try
            {
                // Lógica: hash de password, validaciones, etc.
                await _usuarioRepository.AddAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario", ex);
            }
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            try
            {
                await _usuarioRepository.UpdateAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario", ex);
            }
        }

        public async Task BloquearUsuarioAsync(Guid usuarioId)
        {
            try
            {
                var usuarios = await _usuarioRepository.GetAllAsync();
                var usuario = usuarios.Find(u => u.Id == usuarioId);
                if (usuario != null)
                {
                    usuario.Bloqueado = true;
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al bloquear el usuario", ex);
            }
        }

        public async Task DesbloquearUsuarioAsync(Guid usuarioId)
        {
            try
            {
                var usuarios = await _usuarioRepository.GetAllAsync();
                var usuario = usuarios.Find(u => u.Id == usuarioId);
                if (usuario != null)
                {
                    usuario.Bloqueado = false;
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desbloquear el usuario", ex);
            }
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            try
            {
                return await _usuarioRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios", ex);
            }
        }
    }
}

