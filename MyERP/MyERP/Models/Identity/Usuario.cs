// Ruta: MyERP/Models/Identity/Usuario.cs
// Contiene la clase de dominio Usuario para el módulo Identity.

using System;

namespace MyERP.Models.Identity
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Bloqueado { get; set; }
        public string PasswordHash { get; set; }
        // Otros atributos: foto de perfil, 2FA, etc.
    }
}
