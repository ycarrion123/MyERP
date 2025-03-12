// Ruta: MyERP/Models/SaaS/TenantInfo.cs

using System;

namespace MyERP.Models.SaaS
{
    public class TenantInfo
    {
        public Guid TenantId { get; set; }
        public string Nombre { get; set; }
        public string Edicion { get; set; }
        public string ConnectionString { get; set; }
    }
}
